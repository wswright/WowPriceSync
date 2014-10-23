using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scott.WoWAPI.APIModel;
using ZedGraph;
using WoWPriceSyncUI.DataProviders;

namespace WoWPriceSyncUI
{
    public partial class ucFarmers : UserControl
    {
        private bool loading = false;
        private Item _item;
        private DBManager _dbMan;
        private WowDataProvider provider;
        private List<Color> colorsToUse;

        public ucFarmers()
        {
            InitializeComponent();
            colorsToUse = CreateColorList();
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

        public async void LoadItem(Item i)
        {
            if (loading)
                return;
            loading = true;
            _item = i;

            //Initialize dbmanager if it isn't already
            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }

            GraphPane pane = zedGraphControlFarmers.GraphPane;
            pane.XAxis.Type = AxisType.Text;
            

            if (provider == null || (provider.GetItem() != null && provider.GetItem().id != _item.id))
            {
                provider = new TopFarmersProvider(_item);
            }

            pane.Title.Text = provider.GetTitle();
            pane.XAxis.Title.Text = provider.GetXAxisTitle();
            pane.YAxis.Title.Text = provider.GetYAxisTitle();
            pane.XAxis.Type = provider.GetXAxisType();


            //BarItem bItem1 = pane.AddBar("Loreley",
            //                            new double[] { 0 },
            //                            new double[] { 50 },
            //                            Color.Orange);
            //bItem1.IsSelectable = true;
            //pane.AddBar("Kodgar",
            //            new double[] { 1 },
            //            new double[] { 25 },
            //            Color.Blue);

            await RefreshData();
            loading = false;
        }

        private async Task RefreshData()
        {
            GraphPane pane = zedGraphControlFarmers.GraphPane;
            pane.CurveList.Clear();
            zedGraphControlFarmers.AxisChange();

            DataCurveDescriptor[] curves = await provider.GetData();
            int colorIndex = 0;
            var labels = from c in curves
                         select c.Title;

            ////Set X-Axis labels
            //pane.XAxis.Scale.TextLabels = labels.ToArray();
            //pane.XAxis.MajorTic.IsBetweenLabels = true;
            //pane.XAxis.Scale.FontSpec.Size = 10;
            
            

            foreach (DataCurveDescriptor curve in curves)
            {
                BarItem bItem = pane.AddBar(curve.Title, curve.pointList, colorsToUse[colorIndex]);
                //pane.AddBar(curve.Title, null, new double[1]{curve.pointList[0].Y}, colorsToUse[colorIndex]);

                colorIndex++;
                if (colorIndex >= colorsToUse.Count)    //Recycle colors if we go over # of defined colors
                    colorIndex = 0;
            }

            
            

            zedGraphControlFarmers.AxisChange();
            this.Refresh();
        }

        public void ResizeChart()
        {
            zedGraphControlFarmers.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zedGraphControlFarmers.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);
        }
    }
}
