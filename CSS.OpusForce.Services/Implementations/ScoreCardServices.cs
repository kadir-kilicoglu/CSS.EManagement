using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.ScoreCards;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class ScoreCardServices : IScoreCardServices
    {
        private readonly IScoreCardVarianceRepository _scoreCardVarianceRepository;
        private readonly IVarianceTypeRepository _scoreCardVarianceTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScoreCardServices(IScoreCardVarianceRepository scoreCardVarianceRepository,
            IVarianceTypeRepository scoreCardVarianceTypeRepository,
            IUnitOfWork unitOfWork)
        {
            _scoreCardVarianceRepository = scoreCardVarianceRepository;
            _scoreCardVarianceTypeRepository = scoreCardVarianceTypeRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*       ScoreCardVarianceType Implementations           */
        /*********************************************************/
        #region ScoreCardVarianceType Implementations
        public CreateScoreCardVarianceTypeResponse CreateScoreCardVarianceType(CreateScoreCardVarianceTypeRequest request)
        {
            CreateScoreCardVarianceTypeResponse response = new CreateScoreCardVarianceTypeResponse();
            response.ExceptionState = false;

            VarianceType scoreCardVarianceType = new VarianceType();
            scoreCardVarianceType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            scoreCardVarianceType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<VarianceType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_scoreCardVarianceTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir varyans tipi zaten var. Lütfen varyans tipi adını benzersiz bir isim olarak düzenleyin.";

                response.ScoreCardVarianceType = scoreCardVarianceType.ConvertToScoreCardVarianceTypeView();

                return response;
            }

            object identityToken = _scoreCardVarianceTypeRepository.Add(scoreCardVarianceType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Varyans tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.ScoreCardVarianceType = _scoreCardVarianceTypeRepository.FindBy((int)identityToken).ConvertToScoreCardVarianceTypeView();

            return response;
        }

        public ReadScoreCardVarianceTypeResponse ReadScoreCardVarianceType(ReadScoreCardVarianceTypeRequest request)
        {
            ReadScoreCardVarianceTypeResponse response = new ReadScoreCardVarianceTypeResponse();
            response.ExceptionState = false;

            response.ScoreCardVarianceType = _scoreCardVarianceTypeRepository.FindBy(request.Id).ConvertToScoreCardVarianceTypeView();

            return response;
        }

        public UpdateScoreCardVarianceTypeResponse UpdateScoreCardVarianceType(UpdateScoreCardVarianceTypeRequest request)
        {
            UpdateScoreCardVarianceTypeResponse response = new UpdateScoreCardVarianceTypeResponse();
            response.ExceptionState = false;

            VarianceType scoreCardVarianceType = new VarianceType();
            scoreCardVarianceType.Id = request.Id;
            scoreCardVarianceType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            scoreCardVarianceType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (scoreCardVarianceType.Name != _scoreCardVarianceTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<VarianceType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_scoreCardVarianceTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir varyans tipi zaten var. Lütfen varyans tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.ScoreCardVarianceType = scoreCardVarianceType.ConvertToScoreCardVarianceTypeView();

                    return response;
                }
            }

            _scoreCardVarianceTypeRepository.Save(scoreCardVarianceType);
            _unitOfWork.Commit();

            response.ScoreCardVarianceType = scoreCardVarianceType.ConvertToScoreCardVarianceTypeView();

            return response;
        }

        public DeleteScoreCardVarianceTypeResponse DeleteScoreCardVarianceType(DeleteScoreCardVarianceTypeRequest request)
        {
            DeleteScoreCardVarianceTypeResponse response = new DeleteScoreCardVarianceTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<ScoreCardVariance>(c => c.VarianceType.Id, request.Id, CriteriaOperator.Equal));
            if (_scoreCardVarianceRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini varyans tipini kullanan puantaj varyansları var. Lütfen önce bu puantaj varyanslarını silip ya da düzenleyip tekrar deneyin.";
                response.ScoreCardVarianceTypes = _scoreCardVarianceTypeRepository.FindAll().ConvertToScoreCardVarianceTypeSummaryView();

                return response;
            }

            _scoreCardVarianceTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.ScoreCardVarianceTypes = _scoreCardVarianceTypeRepository.FindAll().ConvertToScoreCardVarianceTypeSummaryView();

            return response;
        }

        public ListScoreCardVarianceTypesResponse ListScoreCardVarianceTypes(ListScoreCardVarianceTypesRequest request)
        {
            ListScoreCardVarianceTypesResponse response = new ListScoreCardVarianceTypesResponse();
            response.ExceptionState = false;

            response.ScoreCardVarianceTypes = _scoreCardVarianceTypeRepository.FindAll().ConvertToScoreCardVarianceTypeSummaryView();

            return response;
        }
        #endregion
    }
}
