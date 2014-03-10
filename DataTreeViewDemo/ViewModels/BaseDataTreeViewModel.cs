using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
namespace DataTreeViewDemo.ViewModels {
    public class BaseDataTreeViewModel : ViewModelBase {
        public BaseDataTreeViewModel ParentItem {
            get;
            set;
        }

        private ObservableCollection<BaseDataTreeViewModel> _subCategories = null;
        public int Id {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public double Level {
            get;
            set;
        }

        //public ToggleState CheckState {
        //    get;
        //    set;
        //}

        public ObservableCollection<BaseDataTreeViewModel> SubCategories {
            get {
                return this._subCategories ?? (this._subCategories = new ObservableCollection<BaseDataTreeViewModel>());
            }
        }

        public BaseDataTreeViewModel(BaseDataTreeViewModel parent) {
            this.ParentItem = parent;
        }
    }
}
