using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using WoWPriceSyncUI.DataProviders;
using Scott.WoWAPI.APIModel;

namespace WoWPriceSyncUI
{
    public partial class ucCharting : UserControl
    {
        WowDataProvider provider;
        bool loading = false;
        Item _item;
        DBManager _dbMan;
        bool editingChart = true;

        private List<Color> colorsToUse;

        public ucCharting()
        {
            InitializeComponent();
            colorsToUse = CreateColorList();
            ResizeChart();
        }

        private List<Color> CreateColorList()
        {
            List<Color> lst = new List<Color>()
            {
                Color.Red,
                Color.Blue,
                Color.Black,
                Color.Orange,
                Color.Purple,
                Color.Yellow,
                Color.Green,
                Color.Gray,
                Color.Brown
            };
            return lst;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            
        }

        public async void LoadItem(Item i)
        {
            //Prevent LoadItem from running twice at the same time
            if (loading)//TODO: Queue up items and wait for loading==false, w/ a timeout
                return;

            Logger.Log(string.Format("Loading [{0}] Data!", i.name), Logger.Level.Info);
            _item = i;
            loading = true;

            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }

            //provider = new VolumeProvider(_item);
            if (provider == null || (provider.GetItem() != null && provider.GetItem().id != _item.id))
            {
                provider = new MinimumBuyoutDataProvider(_item);
            }
            
            
            //propChartProperties.SelectedObject = provider;
            if(editingChart == false)
                propChartProperties.SelectedObject = provider;

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = provider.GetTitle();
            myPane.XAxis.Title.Text = provider.GetXAxisTitle();
            myPane.YAxis.Title.Text = provider.GetYAxisTitle();
            myPane.XAxis.Type = provider.GetXAxisType();

            await RefreshData();
            loading = false;
        }

        public void ChangeProvider<T>(params object[] providerParams) where T : WowDataProvider
        {
            provider = (T)Activator.CreateInstance(typeof(T), providerParams);
        }

        public async Task RefreshData()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            zedGraphControl1.AxisChange();

            DataCurveDescriptor[] curves = await provider.GetData();
            //PointPairList list1 = await provider.GetData();

            int colorIndex = 0;
            bool singleLine = curves.Count() == 1;
            int index = 0;
            foreach (DataCurveDescriptor curve in curves)
            {
                LineItem myCurve = myPane.AddCurve(_item.name + " - " + curve.Title, curve.pointList, colorsToUse[colorIndex], curve.Symbol);
                
                if(curve.DoFill)
                    myCurve.Line.Fill = new Fill(Color.White, colorsToUse[colorIndex], 45F);

                myCurve.Line.Width = curve.LineWidth;
                myCurve.Line.IsAntiAlias = curve.DoAntiAlias;
                
                colorIndex++;
                if (colorIndex >= colorsToUse.Count)    //Recycle colors if we go over # of defined colors
                    colorIndex = 0;
                index++;
            }

            zedGraphControl1.AxisChange();
            this.Refresh();
        }

        public void ResizeChart()
        {
            zedGraphControl1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);
        }

        private void propChartProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!editingChart)
            {
                provider.PropertyChanged(s, e);
                RefreshData();
                if (e.ChangedItem.Label == "Factions")
                {
                    //RefreshData();
                }
            }
            else
            {
                if (editingChart)
                    RefreshData();
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            editingChart = true;
            propChartProperties.SelectedObject = zedGraphControl1.GraphPane;
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            editingChart = false;
            propChartProperties.SelectedObject = provider;
        }

        private void btnChangeProvider_Click(object sender, EventArgs e)
        {
            if (provider is MinimumBuyoutDataProvider)
                ChangeProvider<VolumeProvider>(_item);
            else if (provider is VolumeProvider)
                ChangeProvider<MinimumBuyoutDataProvider>(_item);
            LoadItem(_item);
        }
    }
}
