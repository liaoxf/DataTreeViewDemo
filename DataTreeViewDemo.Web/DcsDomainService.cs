
namespace DataTreeViewDemo.Web {
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;


    // 使用 DcSEntities 上下文实现应用程序逻辑。
    // TODO: 将应用程序逻辑添加到这些方法中或其他方法中。
    // TODO: 连接身份验证(Windows/ASP.NET Forms)并取消注释以下内容，以禁用匿名访问
    //还可考虑添加角色，以根据需要限制访问。
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DcsDomainService : LinqToEntitiesDomainService<DcSEntities> {

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“Products”查询添加顺序。
        public IQueryable<Product> GetProducts() {
            return this.ObjectContext.Products;
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“ProductAffiProductCategories”查询添加顺序。
        public IQueryable<ProductAffiProductCategory> GetProductAffiProductCategories() {
            return this.ObjectContext.ProductAffiProductCategories;
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“ProductCategories”查询添加顺序。
        public IQueryable<ProductCategory> GetProductCategories() {
            return this.ObjectContext.ProductCategories;
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“TiledRegions”查询添加顺序。
        public IQueryable<TiledRegion> GetTiledRegions() {
            return this.ObjectContext.TiledRegions;
        }
    }
}


