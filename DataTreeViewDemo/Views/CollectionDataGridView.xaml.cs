using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using DataTreeViewDemo.Models;
using Telerik.Windows.Data;

namespace DataTreeViewDemo.Views {
    public partial class CollectionDataGridView {
        private int _index = int.MaxValue;

        public ObservableCollection<object> ScanningData {
            get;
            set;
        }

        public ObservableCollection<Customer> DataBaseData {
            get;
            set;
        }

        public ObservableCollection<Customer> OrgDataBaseData {
            get;
            set;
        }

        private void Action() {
            //一致/盘亏
            foreach(var item in DataBaseData) {
                item.Status = this.ScanningData.Contains(item.Code) ? "一致" : "盘亏";
            }

            //盘盈
            foreach(var entity in ScanningData.Where(entity => this.DataBaseData.All(v => v.Code != entity.ToString()))) {
                this.DataBaseData.Add(new Customer(this._index--, this._index--, entity.ToString(), "盘盈"));
            }
            this.radGridView.ItemsSource = null;
            this.radGridView.ItemsSource = this.DataBaseData;
        }

        public CollectionDataGridView() {
            InitializeComponent();
            this.ScanningData = new ObservableCollection<object>();
            this.DataBaseData = new ObservableCollection<Customer>
                                    {
                                        new Customer(this._index--,this._index--, "AAA", "有效"),
                                        new Customer(this._index--,this._index--, "BBB", "有效"),
                                        new Customer(this._index--, this._index--,"CCC", "有效"),
                                        new Customer(this._index--, this._index--,"DDD", "有效")
                                    };
            this.OrgDataBaseData = new ObservableCollection<Customer>
                                    {
                                        new Customer(this._index--,this._index--, "AAA", "有效"),
                                        new Customer(this._index--,this._index--, "BBB", "有效"),
                                        new Customer(this._index--, this._index--,"EEE", "有效"),
                                        new Customer(this._index--, this._index--,"FFF", "有效")
                                    };
            //this.OrgRadGridView.Columns.Clear();
            //foreach(var item in this.OrgDataBaseData) {

            //    this.OrgRadGridView.Columns.Add(new GridViewDataColumn {
            //        Header = item.Code,
            //        UniqueName = item.Code,
            //        DataMemberBinding = new Binding(item.Code)
            //    });
            //}
            this.OrgRadGridView.ItemsSource = this.OrgDataBaseData;
            this.OrgRadGridView.Columns["Count"].AggregateFunctions.Add(new SumFunction {
                Caption = "Sum:",
                FunctionName = "合计"
            });
            this.OrgRadGridView.Columns["Count"].AggregateFunctions.Add(new CountFunction {
                Caption = "Count:",
                FunctionName = "数量"
            });
            this.OrgRadGridView.ShowColumnFooters = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) {
            if(e.Key != Key.Enter)
                return;
            var inputValue = sender as TextBox;

            if(inputValue != null && !string.IsNullOrWhiteSpace(inputValue.Text)) this.ScanningData.Add(inputValue.Text.Trim());
        }

        private void RadButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            this.Action();

        }
    }
}
