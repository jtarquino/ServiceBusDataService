using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AWDataService
{
    public class AdventureWorksDataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public AdventureWorksDataContext()
            : base("name=AdventureWorksDataContext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public Product GetTenantById(string productId)
        {

            string tsql =
                @"SELECT ProductId, Color, Name FROM Production.Product WHERE ProductID =@productId";
            Product product = ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<Product>(tsql, new SqlParameter("@productId", productId)).FirstOrDefault();
            return product;
        }
    }
}
