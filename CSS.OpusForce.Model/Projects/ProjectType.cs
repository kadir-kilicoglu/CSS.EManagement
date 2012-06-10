using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Projects 
{
    
    public class ProjectType : EntityBase<int>, IAggregateRoot 
    {
        public ProjectType() 
        {
			Projects = new List<Project>();
        }

        public virtual IList<Project> Projects { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IProjectTypeRepository : IRepository<ProjectType, int>
    {
    }
}
