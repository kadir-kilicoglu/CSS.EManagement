using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Employees {
    
    public class EmployeeFile : EntityBase<int>, IAggregateRoot 
    {
        public EmployeeFile() 
        { 
        }

        public virtual Employee Employee { get; set; }
        public virtual FileType FileType { get; set; }
        public virtual FileStatus FileStatus { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEmployeeFileRepository : IRepository<EmployeeFile, int>
    {
    }
}
