using System.Data.Entity;

namespace CalcWebApplication.Db
{
    class CalcDbInitializer : DropCreateDatabaseIfModelChanges<CalcContext>
    {
        protected override void Seed(CalcContext context)
        {
            context.Users.Add(new MyUser { Login = "admin", Password = "1234" });

            base.Seed(context);
        }
    }
}
