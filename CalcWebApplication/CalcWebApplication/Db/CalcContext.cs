using System.Data.Entity;

namespace CalcWebApplication.Db
{
    public class CalcContext : DbContext
    {
        public CalcContext() 
            : base("name=SuperCalc")
        {
            Database.SetInitializer(new CalcDbInitializer());
        }

        public virtual DbSet<MyUser> Users { get; set; }
    }
}
