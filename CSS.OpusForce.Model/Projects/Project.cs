using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Companies;
using CSS.OpusForce.Model.OperationCenters;

namespace CSS.OpusForce.Model.Projects 
{
    
    public class Project : EntityBase<int>, IAggregateRoot 
    {
        public Project() 
        {
			OperationCenters = new List<OperationCenter>();
        }

        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual Company Company { get; set; }
        public virtual IList<OperationCenter> OperationCenters { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual System.DateTime StartDate { get; set; }
        public virtual System.Nullable<System.DateTime> EndDate { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IProjectRepository : IRepository<Project, int>
    {
    }
}
