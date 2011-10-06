namespace Me.Web.Mvc.Infrastructure.EntityFramework
{
    #region

    using System.Collections.Generic;
    using System.Data.Entity;

    using Models;

    #endregion

    public class Seeder : DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db db)
        {
        }
    }
}