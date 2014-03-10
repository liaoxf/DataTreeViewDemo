using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using DataTreeViewDemo.Models;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace DataTreeViewDemo.Views {
    public partial class GenerateDataGridView : UserControl {
        private ObservableCollection<ProvinceConvert> provinceConverts;
        private RadWindow radWindow;
        public ObservableCollection<VirtualMonthlyPlan> VirtualMonthlyPlans {
            get;
            set;
        }
        public ObservableCollection<ProvinceConvert> ProvinceConverts {
            get {
                return this.provinceConverts ?? (this.provinceConverts = new ObservableCollection<ProvinceConvert>());
            }
            set {
                this.provinceConverts = value;
            }
        }
        public RadWindow RadWindow {
            get {
                return this.radWindow ?? (this.radWindow = new RadWindow());
            }
            set {
                this.radWindow = value;
            }
        }

        public GenerateDataGridView() {
            InitializeComponent();
            this.DataGridView.IsReadOnly = true;
            this.DataGridView.SelectionUnit = Telerik.Windows.Controls.GridView.GridViewSelectionUnit.Cell;

            this.CreatSourceData();
            this.CreateDataGridViewColumns();
            this.DataGridView.CellLoaded += DataGridView_CellLoaded;
        }


        private void DataGridView_CellLoaded(object sender, Telerik.Windows.Controls.GridView.CellEventArgs e) {
            if(e.Cell is Telerik.Windows.Controls.GridView.GridViewCell && e.Cell.Column.Header.Equals("Total")) {
                ((GridViewCell)e.Cell).Value = ((GridViewCell)e.Cell).Value == null ? "/" : ((GridViewCell)e.Cell).Value;
            }
        }

        private void CreatSourceData() {
            this.VirtualMonthlyPlans = new ObservableCollection<VirtualMonthlyPlan>();
            for(var i = 1; i <= 2; i++) {
                this.VirtualMonthlyPlans.Add(new VirtualMonthlyPlan {
                    Id = i,
                    ProvinceName = "上海",
                    VehicleCarrierName = "SHQR" + i,
                    Coverage = i.ToString()
                });
            }

            for(var i = 1; i <= 3; i++) {
                this.VirtualMonthlyPlans.Add(new VirtualMonthlyPlan {
                    Id = i,
                    ProvinceName = "北京",
                    VehicleCarrierName = "BJQR" + i,
                    Coverage = (i + 2).ToString()
                });
            }
            for(var i = 1; i <= 4; i++) {
                this.VirtualMonthlyPlans.Add(new VirtualMonthlyPlan {
                    Id = i,
                    ProvinceName = "深圳",
                    VehicleCarrierName = "SZQR" + i,
                    Coverage = (i + 3).ToString()
                });
            }
            this.DataGridView.Columns.Add(new GridViewDataColumn {
                Header = "ProvinceName",
                UniqueName = "ProvinceName",
                DataMemberBinding = new Binding("ProvinceName")
            });
        }

        private void RadButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            CreateDataGridViewColumns();
        }

        private void CreateDataGridViewColumns() {
            if(this.ProvinceConverts.Any())
                this.ProvinceConverts.Clear();
            this.DataGridView.Columns.RemoveItems(
                (DataGridView.Columns.OfType<GridViewDataColumn>()).Where(
                    v => !new[] { "ProvinceName" }.Contains(v.UniqueName)).ToArray());

            this.DataGridView.Columns.Add(new GridViewDataColumn {
                Header = "Total",
                UniqueName = "TotalColumnCoverage",
                DataMemberBinding =
                    new Binding(
                    string.Format("VirtualMonthlyPlans[{0}].Coverage",
                                  this.VirtualMonthlyPlans.Count)) {
                                      Mode = BindingMode.TwoWay
                                  }
            });

            for(var i = 0; i < VirtualMonthlyPlans.Count(); i++) {
                var hyperlink = new GridViewDataColumn {
                    Header = VirtualMonthlyPlans[i].VehicleCarrierName,
                    UniqueName = VirtualMonthlyPlans[i].VehicleCarrierName.ToUpper(),
                    DataMemberBinding =
           new Binding(string.Format(
               "VirtualMonthlyPlans[{0}].Coverage", i)) {
                   Mode = BindingMode.TwoWay
               }
                };
                this.DataGridView.Columns.Add(hyperlink);
            }


            var customProvinceNames = from query in this.VirtualMonthlyPlans
                                      group query by query.ProvinceName
                                          into queryGroup
                                          select new {
                                              ProvinceName = queryGroup.Key,
                                              TotalCount = queryGroup.Sum(v => Convert.ToDecimal(v.Coverage))
                                          };
            foreach(var customProvinceName in customProvinceNames) {
                var customVirtualMonthlyPlans = new ObservableCollection<VirtualMonthlyPlan>();
                foreach(var handerVirtualMonthlyPlan in VirtualMonthlyPlans) {
                    var customeStat =
                        this.VirtualMonthlyPlans.FirstOrDefault(
                            v => v.ProvinceName == customProvinceName.ProvinceName && v.VehicleCarrierName == handerVirtualMonthlyPlan.VehicleCarrierName);
                    customVirtualMonthlyPlans.Add(new VirtualMonthlyPlan {
                        ProvinceName = customProvinceName.ProvinceName,
                        VehicleCarrierName = handerVirtualMonthlyPlan.VehicleCarrierName,
                        Coverage = customeStat == null ? "0" : handerVirtualMonthlyPlan.Coverage
                    });
                }

                var name = customProvinceName;
                customVirtualMonthlyPlans.Add(new VirtualMonthlyPlan {
                    Coverage = this.VirtualMonthlyPlans.Where(v => v.ProvinceName == name.ProvinceName).Sum(v => Convert.ToDecimal(v.Coverage)).ToString()
                });
                //Add ColumnSum
                var item = new ProvinceConvert(customProvinceName.ProvinceName) {
                    VirtualMonthlyPlans =
                        new ObservableCollection<VirtualMonthlyPlan>(customVirtualMonthlyPlans)
                };
                this.ProvinceConverts.Add(item);
            }
            //Add RowSum
            var totalRowItems = new ObservableCollection<VirtualMonthlyPlan>();
            foreach(var virtualMonthlyPlan in this.VirtualMonthlyPlans) {
                VirtualMonthlyPlan plan = virtualMonthlyPlan;
                totalRowItems.Add(new VirtualMonthlyPlan {
                    Coverage = this.VirtualMonthlyPlans.Where(v => v.VehicleCarrierName == plan.VehicleCarrierName).Sum(v => Convert.ToDecimal(v.Coverage)).ToString()
                });
            }
            totalRowItems.Add(new VirtualMonthlyPlan {
                Coverage = this.VirtualMonthlyPlans.Sum(v => Convert.ToDecimal(v.Coverage)).ToString()
            });
            var totalRow = new ProvinceConvert("Total") {
                VirtualMonthlyPlans = totalRowItems
            };
            this.ProvinceConverts.Add(totalRow);
            //Add Proportion
            var proportionItems = new ObservableCollection<VirtualMonthlyPlan>();
            foreach(var virtualMonthlyPlan in this.VirtualMonthlyPlans) {
                VirtualMonthlyPlan plan = virtualMonthlyPlan;
                var columnCount =
                    this.VirtualMonthlyPlans.Where(v => v.VehicleCarrierName == plan.VehicleCarrierName).Sum(v => Convert.ToDecimal(v.Coverage));
                var totalCount = this.VirtualMonthlyPlans.Sum(v => Convert.ToDecimal(v.Coverage));
                proportionItems.Add(new VirtualMonthlyPlan {
                    Coverage = Math.Round((columnCount / totalCount), 2).ToString("p"),
                    VehicleCarrierName = virtualMonthlyPlan.VehicleCarrierName
                });
            }
            proportionItems.Add(new VirtualMonthlyPlan {
                Coverage = "/"
            });
            var proportionRow = new ProvinceConvert("Proportion") {
                VirtualMonthlyPlans = proportionItems
            };

            this.ProvinceConverts.Add(proportionRow);
            this.DataGridView.ItemsSource = this.ProvinceConverts;
        }

        private void Hyperlink_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if(!(sender is GridViewHyperlinkColumn))
                return;
            var currentItem = (GridViewHyperlinkColumn)sender;
            this.RadWindow.Content = new TextBlock {
                Text = currentItem.Header.ToString(),
                Width = 100
            };
            this.RadWindow.Show();
        }
    }
}
