using System;
using System.Collections.Generic;
using DataTreeViewDemo.Models;

namespace DataTreeViewDemo.ViewModels {
    public class RawDataSourceViewModel : List<DataItem> {
        public RawDataSourceViewModel() {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for(int i = 1; i < 3; i++) {
                DataItem item = new DataItem() {
                    Name = String.Format("Item {0}", i.ToString()),
                    CheckState = GetToggleState(rand.Next(0, 3))
                };
                for(int j = 1; j < 3; j++) {
                    DataItem subItem = new DataItem() {
                        Name = String.Format("Item {0}.{1}", i.ToString(), j.ToString()),
                        CheckState = GetToggleState(rand.Next(0, 3))
                    };
                    item.Items.Add(subItem);
                }
                this.Add(item);
            }
        }

        private System.Windows.Automation.ToggleState GetToggleState(int code) {
            switch(code) {
                case 0:
                    return System.Windows.Automation.ToggleState.Off;
                case 1:
                    return System.Windows.Automation.ToggleState.On;
                case 2:
                    return System.Windows.Automation.ToggleState.Indeterminate;
                default:
                    return System.Windows.Automation.ToggleState.Off;
            }
        }
    }
}
