using System.Collections.Generic;

namespace DataTreeViewDemo.Models {
    public class DataItem {
        public DataItem() {
            this.Items = new List<DataItem>();
        }

        public string Name {
            get;
            set;
        }

        public System.Windows.Automation.ToggleState CheckState {
            get;
            set;
        }

        public List<DataItem> Items {
            get;
            set;
        }
    }
}
