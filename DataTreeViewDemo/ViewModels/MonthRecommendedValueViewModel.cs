
using System.Collections.ObjectModel;
using DataTreeViewDemo.Models;
namespace DataTreeViewDemo.ViewModels {
    public class MonthRecommendedValueViewModel {
        public ObservableCollection<MonthlyForecastRecommend> MonthlyForecastRecommends {
            get;
            set;
        }

        public MonthRecommendedValueViewModel() {
            this.MonthlyForecastRecommends = new ObservableCollection<MonthlyForecastRecommend>();
            for(int i = 0; i < 5; i++) {
                var item = new MonthlyForecastRecommend {
                    Id = i,
                    ProductCategoryCode = string.Format("ProductCategoryCodeA"),
                    ProductCategoryName = string.Format("ProductCategoryNameA"),
                    ModelId = i,
                    ModelCode = string.Format("ModelCode" + i.ToString()),
                    ModelName = string.Format("ModelName" + i.ToString()),
                    IntentLevelAQuantity = i,
                    LastThreeMonthSales = 10 + i,
                    CurrentStock = 12 + i,
                    InTransitStock = 100 - i,
                    SalesGap = i,
                    QuotaQuantityOfNextMonth = i,
                    CoefficientOfThisMonth = i,
                    RecommendedQuantity = i
                };
                this.MonthlyForecastRecommends.Add(item);
            }
            for(int i = 0; i < 8; i++) {
                var entity = new MonthlyForecastRecommend {
                    Id = i,
                    ProductCategoryCode = string.Format("ProductCategoryCodeB"),
                    ProductCategoryName = string.Format("ProductCategoryNameB"),
                    ModelId = i,
                    ModelCode = string.Format("ModelCode" + i.ToString()),
                    ModelName = string.Format("ModelName" + i.ToString()),
                    IntentLevelAQuantity = i,
                    LastThreeMonthSales = 10 + i,
                    CurrentStock = 12 + i,
                    InTransitStock = 100 - i,
                    SalesGap = i,
                    QuotaQuantityOfNextMonth = i,
                    CoefficientOfThisMonth = i,
                    RecommendedQuantity = i
                };
                this.MonthlyForecastRecommends.Add(entity);
            }
        }
    }
}
