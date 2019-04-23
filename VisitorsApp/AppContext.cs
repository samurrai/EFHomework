namespace VisitorsApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }
        public DbSet<Visitor> Visitors { get; set; }    
    }
}