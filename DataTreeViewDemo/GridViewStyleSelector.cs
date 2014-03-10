using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace DataTreeViewDemo {
    public class GridViewStyleSelector : StyleSelector {
        public override Style SelectStyle(object item, DependencyObject container) {
            if(this.ExecuteFunc != null)
                return this.ExecuteFunc.Invoke(item, container);
            return null;
        }

        public Func<object, DependencyObject, Style> ExecuteFunc {
            get;
            set;
        }
    }
}
