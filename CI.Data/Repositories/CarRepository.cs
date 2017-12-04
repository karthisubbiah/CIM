using CI.Data.Models;

namespace CI.Data.Repositories
{
    public class CarRepository : GenericRepository<Car>
    {
        internal CarRepository(CIContext context, UnitOfWork unitOfWork) : base(context, unitOfWork) { }

        #region commented code for future ref.
        //public override void Delete(Guid id)
        //{
        //    base.Delete(id);

        //    foreach (var pspaClass in dbContext.DpiPspaClasses.Where(c => c.DpiPspaGradeId == id))
        //    {
        //        unitOfWork.ClassRepository.Delete(pspaClass.Id);
        //    }
        //}
        #endregion        
    }
}