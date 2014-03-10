using System.Linq;
using System.Windows;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo {
    public class StadiumCapacityStyle : StyleSelector {
        public override Style SelectStyle(object item, DependencyObject container) {
            if(item is ProvinceConvert) {
                var club = item as ProvinceConvert;
                if(club.ProvinceName == "Proportion") {
                    return club.VirtualMonthlyPlans.Select(customItem => customItem.Coverage < 0 ? SmallStadiumStyle : BigStadiumStyle).FirstOrDefault();
                }
            }
            return null;
        }
        public Style BigStadiumStyle {
            get;
            set;
        }
        public Style SmallStadiumStyle {
            get;
            set;
        }
    }
}
