using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class FileStatus : EntityBase<int>, IAggregateRoot 
    {
        public FileStatus() 
        {
			EmployeeFiles = new List<EmployeeFile>();
        }
        
        public virtual IList<EmployeeFile> EmployeeFiles { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IFileStatusRepository : IRepository<FileStatus, int>
    {
    }
}
