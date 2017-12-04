using System.Data.Entity;
//using CI.Data.Models.Mapping;

namespace CI.Data.Models
{
    public partial class CIContext : DbContext
    {
        static CIContext()
        {
            Database.SetInitializer<CIContext>(null);
        }

        public CIContext()
            : base("Name=CIContext")
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Car> Car { get; set; }

        #region Commented code for ref.
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new UsersMap());
        //    modelBuilder.Configurations.Add(new CarMap());
        //}
        #endregion
    }

}
