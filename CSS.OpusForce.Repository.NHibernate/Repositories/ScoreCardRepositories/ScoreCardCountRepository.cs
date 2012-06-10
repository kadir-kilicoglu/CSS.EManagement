using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.ScoreCards;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ScoreCardCountRepository : Repository<ScoreCardCount, ScoreCardCountIdentifier>, IScoreCardCountRepository
    {
        public ScoreCardCountRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
