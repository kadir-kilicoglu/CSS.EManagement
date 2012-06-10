using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using CSS.Infrastructure.Querying;
using System.Collections.Generic;
using System;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public static class QueryTranslator
    {
        public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criteria)
        {
            BuildQueryFrom(query, criteria);

            if (query.OrderByProperty != null)
            {
                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName, !query.OrderByProperty.Desc));
            }

            return criteria;
        }

        private static void BuildQueryFrom(Query query, ICriteria criteria)
        {
            IList<ICriterion> critrions = new List<ICriterion>();

            if (query.Criteria != null)
            {
                foreach (Criterion c in query.Criteria)
                {
                    ICriterion criterion;

                    switch (c.criteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.NotEqual:
                            criterion = Expression.Not(Expression.Eq(c.PropertyName, c.Value));
                            break;
                        case CriteriaOperator.IsNull:
                            criterion = Expression.IsNull(c.PropertyName);
                            break;
                        case CriteriaOperator.IsEmpty:
                            criterion = Expression.IsEmpty(c.PropertyName);
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }

                    critrions.Add(criterion);
                }

                if (query.QueryOperator == QueryOperator.And)
                {
                    Conjunction andSubQuery = Expression.Conjunction();
                    foreach (ICriterion criterion in critrions)
                    {
                        andSubQuery.Add(criterion);
                    }

                    criteria.Add(andSubQuery);
                }
                else
                {
                    Disjunction orSubQuery = Expression.Disjunction();
                    foreach (ICriterion criterion in critrions)
                    {
                        orSubQuery.Add(criterion);
                    }
                    criteria.Add(orSubQuery);
                }

                foreach (Query sub in query.SubQueries)
                {
                    BuildQueryFrom(sub, criteria);
                }
            }
        }    
    }
}
