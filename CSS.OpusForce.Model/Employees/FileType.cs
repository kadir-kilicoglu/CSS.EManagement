using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class FileType : EntityBase<int>, IAggregateRoot 
    {
        public FileType() 
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

    public interface IFileTypeRepository : IRepository<FileType, int>
    {
    }
}
