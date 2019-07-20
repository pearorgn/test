using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;

namespace DevExpress.RealtorWorld.Win {
    public partial class ucStats : BaseModule {
        public ucStats() {
            InitializeComponent();
            pnlList.ItemSize = 120;
            int width = pnlList.ItemSize * 3 / 2;
            ((ITileControl)pnlList).Properties.LargeItemWidth = width;
            pnlList.Width = width + pnlList.Padding.Horizontal + SystemInformation.VerticalScrollBarWidth + 2;
        }
        public override string ModuleCaption { get { return "Statistics"; } }
        internal override void InitModule(IDXMenuManager manager, object data) {
            base.InitModule(manager, data);
            TileGroup group = new TileGroup();
            foreach(Home home in DataHelper.Homes) {
                TileItem item = new TileItem();
                item.BackgroundImageScaleMode = TileItemImageScaleMode.Squeeze;
                item.IsLarge = true;
                item.BackgroundImage = home.Photo;
                item.Text3 = string.Format("<size=+2>{0}<br><size=-2>{1} Beds / {2} Baths", home.PriceString, home.BedsString, home.BathsString);
                item.TextShowMode = TileItemContentShowMode.Hover;
                item.Tag = home;
                group.Items.Add(item);
            }
            pnlList.Groups.Add(group);
            ucStatistics1.InitData(DataHelper.Homes[0]);
            DataHelper.SetTileSelectedItem(DataHelper.Homes[0], pnlList);
        }
        private void pnlList_ItemClick_1(object sender, TileItemEventArgs e) {
            ucStatistics1.InitData((Home)e.Item.Tag);
        }
    }
}
