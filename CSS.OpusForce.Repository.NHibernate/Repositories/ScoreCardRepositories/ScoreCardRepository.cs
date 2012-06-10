using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.ScoreCards;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ScoreCardRepository : Repository<ScoreCard, int>, IScoreCardRepository
    {
        public ScoreCardRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
