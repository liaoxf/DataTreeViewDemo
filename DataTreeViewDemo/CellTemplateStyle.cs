using System;
using System.Linq;
using System.Windows;
using DataTreeViewDemo.ViewModels;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo {
    public class CellTemplateStyle : StyleSelector {
        public override Style SelectStyle(object item, DependencyObject container) {
            if(item is ProvinceConvert) {
                var club = item as ProvinceConvert;
                if(club.ProvinceName == "Proportion") {
                    return club.VirtualMonthlyPlans.Select(customItem => Convert.ToDecimal(customItem.Coverage) < 0 ? IntegerStyle : ProportionStyle).FirstOrDefault();
                }
            }
            return null;
        }
        public Style ProportionStyle {
            get;
            set;
        }
        public Style IntegerStyle {
            get;
            set;
        }
    }
}
