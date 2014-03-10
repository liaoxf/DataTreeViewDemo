
namespace DataTreeViewDemo.Models {
    public class MonthlyForecastRecommend {
        //销售车型编号
        //销售车型名称
        //型号ID
        //型号编号
        //型号名称
        //潜客户意向A
        //前3月平均销量
        //现有库存
        //在途库存
        //未完成月目标实销数量
        //下月目标数量
        //本月月度系数
        //推荐值

        //ProductCategoryCode
        //ProductCategoryName
        //ModelId
        //ModelCode
        //ModelName
        //IntentLevelAQuantity
        //LastThreeMonthSales
        //CurrentStock
        //InTransitStock
        //SalesGap
        //QuotaQuantityOfNextMonth
        //CoefficientOfThisMonth
        //RecommendedQuantity

        public int Id {
            get;
            set;
        }

        public string ProductCategoryCode {
            get;
            set;
        }

        public string ProductCategoryName {
            get;
            set;
        }

        public int ModelId {
            get;
            set;
        }

        public string ModelCode {
            get;
            set;
        }

        public string ModelName {
            get;
            set;
        }

        public int IntentLevelAQuantity {
            get;
            set;
        }

        public double LastThreeMonthSales {
            get;
            set;
        }

        public int CurrentStock {
            get;
            set;
        }

        public int InTransitStock {
            get;
            set;
        }

        public int SalesGap {
            get;
            set;
        }

        public int QuotaQuantityOfNextMonth {
            get;
            set;
        }

        public int CoefficientOfThisMonth {
            get;
            set;
        }

        public int RecommendedQuantity {
            get;
            set;
        }
    }
}
