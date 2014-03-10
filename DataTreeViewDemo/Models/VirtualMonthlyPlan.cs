
namespace DataTreeViewDemo.Models {
    public class VirtualMonthlyPlan {
        public int Id {
            get;
            set;
        }

        /// <summary>
        /// 承运商名称
        /// </summary>
        public string VehicleCarrierName {
            get;
            set;
        }


        /// <summary>
        ///承运商业务覆盖比例.省份
        /// </summary>
        public string ProvinceName {
            get;
            set;
        }


        /// <summary>
        /// 承运商覆盖比例
        /// </summary>
        public string Coverage {
            get;
            set;
        }
    }
}
