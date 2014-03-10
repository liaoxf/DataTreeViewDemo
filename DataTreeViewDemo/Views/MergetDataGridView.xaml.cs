using System.Windows.Controls;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls.GridView;

namespace DataTreeViewDemo.Views {
    public partial class MergetDataGridView : UserControl {
        public MergetDataGridView() {
            InitializeComponent();
            this.RadGridView.SelectionUnit = GridViewSelectionUnit.Mixed;
            this.RadGridView.SelectionMode = SelectionMode.Multiple;
            this.RadGridView.ItemsSource = new VehicleViewModel().SampleList;
        }
    }
}
