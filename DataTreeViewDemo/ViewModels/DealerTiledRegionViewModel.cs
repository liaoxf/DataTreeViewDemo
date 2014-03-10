using System;
using System.Collections.ObjectModel;

namespace DataTreeViewDemo.ViewModels {
    public class DealerTiledRegionViewModel {
        private int index = int.MaxValue;
        public ObservableCollection<BaseDataTreeViewModel> Categories {
            get;
            set;
        }

        public DealerTiledRegionViewModel() {
            Init();
        }

        private void Init() {
            Categories = new ObservableCollection<BaseDataTreeViewModel>();
            BaseDataTreeViewModel beverages = new BaseDataTreeViewModel(null);
            beverages.Id = index--;
            beverages.Name = "AAA";
            beverages.Level = 1;
            Categories.Add(beverages);

            BaseDataTreeViewModel confections = new BaseDataTreeViewModel(null);
            confections.Id = index--;
            confections.Name = "BBB";
            confections.Level = 1;
            Categories.Add(confections);

            BaseDataTreeViewModel condiments = new BaseDataTreeViewModel(null);
            condiments.Id = index--;
            condiments.Name = "CCC";
            condiments.Level = 1;
            Categories.Add(condiments);
        }

        internal bool BulidChirdrens(BaseDataTreeViewModel viewModel) {
            if(viewModel.Name != "BBB")

                for(int i = 0; i < 5; i++) {
                    BaseDataTreeViewModel prod = new BaseDataTreeViewModel(viewModel) {
                        Id = index--,
                        Name = String.Format("{0}-{1}", i, viewModel.Name, i),
                        Level = 2,
                        //CheckState = System.Windows.Automation.ToggleState.Off
                    };
                    viewModel.SubCategories.Add(prod);
                }
            return viewModel.Name != "BBB";
        }
    }
}
