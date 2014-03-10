
namespace DataTreeViewDemo.Web {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // MetadataTypeAttribute 将 ProductMetadata 标识为类
    //，以携带 Product 类的其他元数据。
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product {

        // 通过此类可将自定义特性附加到
        //Product 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProductMetadata {

            // 元数据类不会实例化。
            private ProductMetadata() {
            }

            public Nullable<int> AbandonerId {
                get;
                set;
            }

            public string AbandonerName {
                get;
                set;
            }

            public Nullable<DateTime> AbandonTime {
                get;
                set;
            }

            public bool CanBeOrdered {
                get;
                set;
            }

            public string Code {
                get;
                set;
            }

            public Nullable<int> Color {
                get;
                set;
            }

            public string ColorCode {
                get;
                set;
            }

            public string Configuration {
                get;
                set;
            }

            public Nullable<DateTime> CreateTime {
                get;
                set;
            }

            public Nullable<int> CreatorId {
                get;
                set;
            }

            public string CreatorName {
                get;
                set;
            }

            public string EmissionStandard {
                get;
                set;
            }

            public string EngineCylinder {
                get;
                set;
            }

            public int Id {
                get;
                set;
            }

            public bool IfOption {
                get;
                set;
            }

            public bool IfPurchasable {
                get;
                set;
            }

            public string ManualAutomatic {
                get;
                set;
            }

            public Nullable<int> ModifierId {
                get;
                set;
            }

            public string ModifierName {
                get;
                set;
            }

            public Nullable<DateTime> ModifyTime {
                get;
                set;
            }

            public string Name {
                get;
                set;
            }

            public Nullable<int> OrderCycle {
                get;
                set;
            }

            public string ParameterDescription {
                get;
                set;
            }

            public string Picture {
                get;
                set;
            }

            public int ProductLifeCycle {
                get;
                set;
            }

            public Nullable<int> PurchaseCycle {
                get;
                set;
            }

            public string Remark {
                get;
                set;
            }

            public byte[] RowVersion {
                get;
                set;
            }

            public int Status {
                get;
                set;
            }

            public string Version {
                get;
                set;
            }
        }
    }

    // MetadataTypeAttribute 将 ProductAffiProductCategoryMetadata 标识为类
    //，以携带 ProductAffiProductCategory 类的其他元数据。
    [MetadataTypeAttribute(typeof(ProductAffiProductCategory.ProductAffiProductCategoryMetadata))]
    public partial class ProductAffiProductCategory {

        // 通过此类可将自定义特性附加到
        //ProductAffiProductCategory 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProductAffiProductCategoryMetadata {

            // 元数据类不会实例化。
            private ProductAffiProductCategoryMetadata() {
            }

            public int Id {
                get;
                set;
            }

            public int ProductCategoryId {
                get;
                set;
            }

            public int ProductId {
                get;
                set;
            }

            public int RootCategoryId {
                get;
                set;
            }
        }
    }

    // MetadataTypeAttribute 将 ProductCategoryMetadata 标识为类
    //，以携带 ProductCategory 类的其他元数据。
    [MetadataTypeAttribute(typeof(ProductCategory.ProductCategoryMetadata))]
    public partial class ProductCategory {

        // 通过此类可将自定义特性附加到
        //ProductCategory 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProductCategoryMetadata {

            // 元数据类不会实例化。
            private ProductCategoryMetadata() {
            }

            public Nullable<int> AbandonerId {
                get;
                set;
            }

            public string AbandonerName {
                get;
                set;
            }

            public Nullable<DateTime> AbandonTime {
                get;
                set;
            }

            public string Code {
                get;
                set;
            }

            public Nullable<DateTime> CreateTime {
                get;
                set;
            }

            public Nullable<int> CreatorId {
                get;
                set;
            }

            public string CreatorName {
                get;
                set;
            }

            public int Id {
                get;
                set;
            }

            public Nullable<int> LayerNodeTypeId {
                get;
                set;
            }

            public Nullable<int> MarshallingSequence {
                get;
                set;
            }

            public Nullable<int> ModifierId {
                get;
                set;
            }

            public string ModifierName {
                get;
                set;
            }

            public Nullable<DateTime> ModifyTime {
                get;
                set;
            }

            public string Name {
                get;
                set;
            }

            public Nullable<int> ParentId {
                get;
                set;
            }

            public string Picture {
                get;
                set;
            }

            public int ProductCategoryLevel {
                get;
                set;
            }

            public string Remark {
                get;
                set;
            }

            public int RootCategoryId {
                get;
                set;
            }

            public byte[] RowVersion {
                get;
                set;
            }

            public int Status {
                get;
                set;
            }
        }
    }

    // MetadataTypeAttribute 将 TiledRegionMetadata 标识为类
    //，以携带 TiledRegion 类的其他元数据。
    [MetadataTypeAttribute(typeof(TiledRegion.TiledRegionMetadata))]
    public partial class TiledRegion {

        // 通过此类可将自定义特性附加到
        //TiledRegion 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TiledRegionMetadata {

            // 元数据类不会实例化。
            private TiledRegionMetadata() {
            }

            public string CityName {
                get;
                set;
            }

            public string CountyName {
                get;
                set;
            }

            public int Id {
                get;
                set;
            }

            public string ProvinceName {
                get;
                set;
            }

            public string RegionName {
                get;
                set;
            }
        }
    }
}
