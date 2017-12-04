using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CI.Data.Models
{
    public partial class CIContext
    {
        private UnitOfWork UnitOfWork { get; set; }

        public CIContext(UnitOfWork unitOfWork)
            : this()
        {
            this.UnitOfWork = unitOfWork;
        }

        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            Debug.Assert(null != this.UnitOfWork);

            var validationContextItems = new Dictionary<object, object>
                {
                    {"UnitOfWork", this.UnitOfWork}
                };

            return base.ValidateEntity(entityEntry, validationContextItems);
        }
    }

    public static class ValidationContextExtensions
    {
        public static UnitOfWork GetUnitOfWork(this ValidationContext validationContext)
        {
            return validationContext.Items["UnitOfWork"] as UnitOfWork;
        }
    }
}
