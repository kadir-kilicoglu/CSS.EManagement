using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.ScoreCards;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ScoreCardVarianceRepository : Repository<ScoreCardVariance, int>, IScoreCardVarianceRepository
    {
        public ScoreCardVarianceRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}