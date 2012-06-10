using System.Collections.Generic;

namespace CSS.Infrastructure.Domain
{
    public abstract class EntityBase<TId>
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected abstract void Validate();

        public virtual TId Id { get; set; }

        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            // Clear broken rules list prior to validate
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return (entity != null
                && entity is EntityBase<TId>
                && this == (EntityBase<TId>)entity) || 
                (entity == null && this == null);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> baseEntity, EntityBase<TId> referenceEntity)
        {
            if ((object)baseEntity == null && (object)referenceEntity == null)
            {
                return true;
            }
            if ((object)baseEntity == null || (object)referenceEntity == null)
            {
                return false;
            }

            if (baseEntity.Id.ToString() == referenceEntity.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> baseEntity, EntityBase<TId> referenceEntity)
        {
            return(!(baseEntity == referenceEntity));
        }
    }

    
}