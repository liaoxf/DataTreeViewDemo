using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo.Views {
    public partial class ExpandTreeView : UserControl {
        private List<int> pendingSelectionPath;

        public RadWindow RadWindow {
            get;
            set;
        }

        public ExpandTreeView() {
            InitializeComponent();
            radTreeView.ItemPrepared += new EventHandler<Telerik.Windows.Controls.RadTreeViewItemPreparedEventArgs>(radTreeView_ItemPrepared);
            radTreeView.ItemsSource = Enumerable.Range(1, 2).Select(i => new MyViewModel() {
                Title = "Item " + i
            }).ToList();
        }

        private void radTreeView_LoadOnDemand(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            var timer = new DispatcherTimer() {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Start();
            var item = (e.OriginalSource as FrameworkElement).DataContext as MyViewModel;
            timer.Tick += (t, args) => {
                foreach(var child in Enumerable.Range(1, 2).Select(i => new MyViewModel() {
                    Title = item.Title + "." + i
                })) {
                    item.Children.Add(child);
                }
                timer.Stop();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            pendingSelectionPath = new List<int>();
            pendingSelectionPath.Add(2);
            pendingSelectionPath.Add(4);
            //pendingSelectionPath.Add(18);
            //pendingSelectionPath.Add(22);
            this.ExpandToPendingSelection();
        }

        private void ExpandToPendingSelection() {
            // Grabs the treeview control.
            var itemsControl = radTreeView as Telerik.Windows.Controls.ItemsControl;
            var itemFound = true;

            while(itemsControl != null && itemFound) {
                itemFound = false;
                // Gets the next Id. If the current treeview item has the same id
                // then this is the target item that should be expanded.
                var id = pendingSelectionPath.First();
                for(int i = 0; i < itemsControl.Items.Count; i++) {
                    var viewModel = itemsControl.Items[i] as MyViewModel;
                    if(viewModel.Id == id) {
                        itemFound = true;
                        pendingSelectionPath.RemoveAt(0);
                        BringIndexIntoView(itemsControl, i);
                        itemsControl.UpdateLayout();
                        var container = itemsControl.ItemContainerGenerator.ContainerFromIndex(i) as Telerik.Windows.Controls.RadTreeViewItem;

                        container.IsExpanded = true;
                        container.UpdateLayout();
                        itemsControl = container as Telerik.Windows.Controls.ItemsControl;
                    }
                }
            }
        }

        private void BringIndexIntoView(Telerik.Windows.Controls.ItemsControl itemsControl, int index) {
            var treeView = itemsControl as Telerik.Windows.Controls.RadTreeView;
            if(treeView != null) {
                treeView.BringIndexIntoView(index);
            }
            var treeViewItem = itemsControl as Telerik.Windows.Controls.RadTreeViewItem;
            if(treeViewItem != null) {
                treeViewItem.BringIndexIntoView(index);
            }
        }

        private void radTreeView_ItemPrepared(object sender, Telerik.Windows.Controls.RadTreeViewItemPreparedEventArgs e) {
            if(pendingSelectionPath == null || !pendingSelectionPath.Any())
                return;
            var myViewModel = e.PreparedItem.Item as MyViewModel;
            if(pendingSelectionPath.Contains(myViewModel.Id)) {
                e.PreparedItem.IsExpanded = true;


                // If we have retrieved the item we need, select it.
                if(pendingSelectionPath.Count == 1)
                    radTreeView.SelectedItem = myViewModel;
                pendingSelectionPath.Remove(myViewModel.Id);
            }
        }
    }
}
