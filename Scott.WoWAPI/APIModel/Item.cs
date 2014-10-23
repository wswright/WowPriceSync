using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel
{
    public class Item
    {
        public const double MAXIMUM_BUYOUT = 9999999999;

        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int stackable { get; set; }
        public int itemBind { get; set; }
        public List<object> bonusStats { get; set; }
        public List<object> itemSpells { get; set; }
        public long buyPrice { get; set; }
        public int itemClass { get; set; }
        public int itemSubClass { get; set; }
        public int containerSlots { get; set; }
        public int inventoryType { get; set; }
        public bool equippable { get; set; }
        public int itemLevel { get; set; }
        public int maxCount { get; set; }
        public int maxDurability { get; set; }
        public int minFactionId { get; set; }
        public int minReputation { get; set; }
        public int quality { get; set; }
        public long sellPrice { get; set; }
        public int requiredSkill { get; set; }
        public int requiredLevel { get; set; }
        public int requiredSkillRank { get; set; }
        public ItemSource itemSource { get; set; }
        public int baseArmor { get; set; }
        public bool hasSockets { get; set; }
        public bool isAuctionable { get; set; }
        public int armor { get; set; }
        public int displayInfoId { get; set; }
        public string nameDescription { get; set; }
        public string nameDescriptionColor { get; set; }
        public bool upgradable { get; set; }
        public bool heroicTooltip { get; set; }

        //Custom properties - client side only
        public bool IsFavorite { get; set; }
        public double BuyoutCutoff { get; set; }
        public double MaxIncreasePercent { get; set; }

        public static async Task<int?> GetNextItemID(IDBLayer db, int[] badItemIDs)
        {
            string qry;
            if (badItemIDs.Length == 0)
                qry = "SELECT TOP 1 item FROM AuctionData WHERE item NOT IN (SELECT id FROM ItemData) GROUP BY item ORDER BY count(item) DESC";
            else
            {
                string badIDs = IntArrayToString(badItemIDs);
                qry = string.Format("SELECT TOP 1 item FROM AuctionData WHERE item NOT IN (SELECT id FROM ItemData) AND item NOT IN ({0}) GROUP BY item ORDER BY count(item) DESC", badIDs);
            }
            SqlCommand cmd = new SqlCommand(qry);
            return await db.ExecuteQuery_ScalarInt(cmd);
        }

        private static string IntArrayToString(int[] ints)
        {
            string intStr = string.Empty;
            int index = 0;
            foreach(int i in ints)
            {
                if (index++ == 0)
                    intStr += i.ToString();
                else
                    intStr += "," + i.ToString();
            }
            return intStr;
        }

        public async Task<bool> Save(IDBLayer db)
        {
            string qry = "INSERT INTO ItemData (id, name, description, icon, sellprice, stackable, itemclass, itemlevel, isauctionable, itembind, isfavorite, buyoutcutoff, maxincreasepercent) VALUES ";
            qry += "(@id, @name, @description, @icon, @sellprice, @stackable, @itemclass, @itemlevel, @isauctionable, @itembind, @isfavorite, @buyoutcutoff, @maxincreasepercent)";

            SqlCommand cmd = new SqlCommand(qry);
            SqlParameter[] sParams = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@description", description),
                new SqlParameter("@icon", icon),
                new SqlParameter("@sellprice", sellPrice),
                new SqlParameter("@stackable", stackable),
                new SqlParameter("@itemclass", itemClass),
                new SqlParameter("@itemlevel", itemLevel),
                new SqlParameter("@isauctionable", isAuctionable),
                new SqlParameter("@itembind", itemBind),
                new SqlParameter("@isfavorite", IsFavorite),
                new SqlParameter("@buyoutcutoff", BuyoutCutoff),
                new SqlParameter("@maxincreasepercent", MaxIncreasePercent)
            };
            cmd.Parameters.AddRange(sParams);
            return await db.ExecuteNonQuery(cmd, true);
        }

        /// <summary>
        /// Asynchronously updates the custom client-side properties of the item.
        /// </summary>
        /// <param name="db">The IDBLayer to perform the task with.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public async Task<bool> Update(IDBLayer db)
        {
            string qry = @"UPDATE ItemData SET isfavorite=@isfavorite, buyoutcutoff=@buyoutcutoff, maxincreasepercent=@maxincreasepercent WHERE id=@id";

            SqlCommand cmd = new SqlCommand(qry);
            SqlParameter[] sParams = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@isfavorite", IsFavorite),
                new SqlParameter("@buyoutcutoff", BuyoutCutoff),
                new SqlParameter("@maxincreasepercent", MaxIncreasePercent)
            };
            cmd.Parameters.AddRange(sParams);
            return await db.ExecuteNonQuery(cmd, true);
        }

        public static async Task<List<Item>> GetItems(IDBLayer db)
        {
            string qry = @"SELECT id, name, description, icon, sellprice, stackable, itemclass, itemlevel, isauctionable, itembind, isfavorite, buyoutcutoff, maxincreasepercent FROM ItemData";
            SqlCommand cmd = new SqlCommand(qry);
            DataTable tbl = await db.ExecuteQuery(cmd);
            List<Item> items = new List<Item>();
            foreach (DataRow dr in tbl.Rows)
            {
                Item i = ItemFromDataRow(dr);
                if(i != null)
                    items.Add(i);
            }
            return items;
        }

        public static Item GetItem(int id, IDBLayer db)
        {
            string qry = @"SELECT id, name, description, icon, sellprice, stackable, itemclass, itemlevel, isauctionable, itembind, isfavorite, buyoutcutoff, maxincreasepercent FROM ItemData WHERE id=" + id.ToString();
            SqlCommand cmd = new SqlCommand(qry);
            DataTable tbl = db.ExecuteQuerySynchronous(cmd);
            return ItemFromDataRow(tbl.Rows[0]);
        }

        public static Item ItemFromDataRow(DataRow dr)
        {
            try
            {
                Item i = new Item();
                i.id = (int)dr["id"];
                i.name = (string)dr["name"];
                i.description = (string)dr["description"];
                i.icon = (string)dr["icon"];
                i.sellPrice = (long)dr["sellprice"];
                i.stackable = (int)dr["stackable"];
                i.itemClass = (int)dr["itemclass"];
                i.itemLevel = (int)dr["itemlevel"];
                i.isAuctionable = (bool)dr["isauctionable"];
                i.itemBind = (int)dr["itembind"];
                i.IsFavorite = (bool)dr["isfavorite"];
                i.BuyoutCutoff = (double)dr["buyoutcutoff"];
                i.MaxIncreasePercent = (double)dr["maxincreasepercent"];
                return i;
            }
            catch (Exception eX)
            {
                return null;
            }
        }
    }

    public class ItemSource
    {
        public int sourceId { get; set; }
        public string sourceType { get; set; }
    }
}
