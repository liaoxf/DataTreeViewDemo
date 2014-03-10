using System.Collections.ObjectModel;
using System.ComponentModel;
using DataTreeViewDemo.Models;

namespace DataTreeViewDemo.ViewModels {
    public class ProvinceConvert : INotifyPropertyChanged {
        private string _provinceName;
        private double _totalCoverage;
        private ObservableCollection<VirtualMonthlyPlan> _virtualMonthlyPlan;
        public string ProvinceName {
            get {
                return this._provinceName;
            }
            set {
                this._provinceName = value;
                this.OnPropertyChanged("ProvinceName");
            }
        }

        public ObservableCollection<VirtualMonthlyPlan> VirtualMonthlyPlans {
            get {
                return this._virtualMonthlyPlan;
            }
            set {
                this._virtualMonthlyPlan = value;
                this.OnPropertyChanged("VirtualMonthlyPlans");
            }
        }

        public ProvinceConvert(string provinceName) {
            this.ProvinceName = provinceName;
        }


        private void OnPropertyChanged(string propertyName) {
            var handler = this.PropertyChanged;
            if(handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
