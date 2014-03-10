using System;
using System.Collections.ObjectModel;

namespace DataTreeViewDemo.ViewModels {
    public class MainViewModel {
        public ObservableCollection<BaseDataTreeViewModel> Categories {
            get;
            set;
        }

        public MainViewModel() {
            Categories = new ObservableCollection<BaseDataTreeViewModel>();
            BaseDataTreeViewModel beverages = new BaseDataTreeViewModel(null);
            beverages.Name = "Bevereges";
            beverages.Level = 1;
            Categories.Add(beverages);

            BaseDataTreeViewModel confections = new BaseDataTreeViewModel(null);
            confections.Name = "Confections";
            confections.Level = 1;
            Categories.Add(confections);

            BaseDataTreeViewModel condiments = new BaseDataTreeViewModel(null);
            condiments.Name = "Condiments";
            condiments.Level = 1;
            Categories.Add(condiments);
        }

        internal void BulidChirdrens(BaseDataTreeViewModel viewModel) {
            for(int i = 0; i < 5; i++) {
                BaseDataTreeViewModel prod = new BaseDataTreeViewModel(viewModel) {
                    Name = String.Format("{0}-{1}", i, viewModel.Name, i),
                    Level = 2,
                    IsChecked = false
                };
                viewModel.SubCategories.Add(prod);
            }
        }
    }
}
