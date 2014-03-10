using System;
using System.Windows.Controls;
using DataTreeViewDemo.Models;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Views {
    public partial class ItemPeparedEventDataTree : UserControl {
        public ItemPeparedEventDataTree() {
            InitializeComponent();
        }

        private void radTreeView_ItemPrepared(object sender, Telerik.Windows.Controls.RadTreeViewItemPreparedEventArgs e) {
            e.PreparedItem.CheckState = (e.PreparedItem.Item as DataItem).CheckState;
            e.PreparedItem.Checked += new EventHandler<Telerik.Windows.RadRoutedEventArgs>(PreparedItem_Checked);
            e.PreparedItem.Unchecked += new EventHandler<Telerik.Windows.RadRoutedEventArgs>(PreparedItem_Unchecked);
        }

        void PreparedItem_Unchecked(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            RadTreeViewItem item = sender as RadTreeViewItem;
            if(item != null) {
                (item.Item as DataItem).CheckState = System.Windows.Automation.ToggleState.Off;
            }
        }

        void PreparedItem_Checked(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            RadTreeViewItem item = sender as RadTreeViewItem;
            if(item != null) {
                (item.Item as DataItem).CheckState = System.Windows.Automation.ToggleState.On;
            }
        }
    }
}
