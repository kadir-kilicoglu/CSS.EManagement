using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

using Calendar = CSS.OpusForce.Model.Calendars.Calendar;

namespace CSS.OpusForce.Services.Implementations
{
    public class CalendarServices : ICalendarServices
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarDayRepository _calendarDayRepository;
        private readonly ICalendarDayTypeRepository _calendarDayTypeRepistory;
        private readonly IUnitOfWork _unitOfWork;

        public CalendarServices(ICalendarRepository calendarRepository,
            ICalendarDayRepository calendarDayRepository,
            ICalendarDayTypeRepository calendarDayTypeRepository,
            IUnitOfWork unitOfWork)
        {
            _calendarRepository = calendarRepository;
            _calendarDayRepository = calendarDayRepository;
            _calendarDayTypeRepistory = calendarDayTypeRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*               Calendar Implementations                */
        /*********************************************************/
        #region Calendar Implementations
        public CreateCalendarResponse CreateCalendar(CreateCalendarRequest request)
        {
            CreateCalendarResponse response = new CreateCalendarResponse();
            response.ExceptionState = false;

            Calendar calendar = new Calendar();
            calendar.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            calendar.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<Calendar>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_calendarRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir takvim zaten var. Lütfen takvim adını benzersiz bir isim olarak düzenleyin.";

                response.Calendar = calendar.ConvertToCalendarView();

                return response;
            }

            object identityToken = _calendarRepository.Add(calendar);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Takvim kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.Calendar = _calendarRepository.FindBy((int)identityToken).ConvertToCalendarView();

            return response;
        }

        public ReadCalendarResponse ReadCalendar(ReadCalendarRequest request)
        {
            ReadCalendarResponse response = new ReadCalendarResponse();
            response.ExceptionState = false;

            response.Calendar = _calendarRepository.FindBy(request.Id).ConvertToCalendarView();

            return response;
        }

        public UpdateCalendarResponse UpdateCalendar(UpdateCalendarRequest request)
        {
            UpdateCalendarResponse response = new UpdateCalendarResponse();
            response.ExceptionState = false;

            Calendar calendar = new Calendar();
            calendar.Id = request.Id;
            calendar.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            calendar.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (calendar.Name != _calendarRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<Calendar>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_calendarRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir takvim zaten var. Lütfen takvim adını benzersiz bir isim olarak düzenleyin.";

                    response.Calendar = calendar.ConvertToCalendarView();

                    return response;
                }
            }

            _calendarRepository.Save(calendar);
            _unitOfWork.Commit();

            response.Calendar = calendar.ConvertToCalendarView();

            return response;
        }

        public DeleteCalendarResponse DeleteCalendar(DeleteCalendarRequest request)
        {
            // UNDONE : Prevent Deletion
            DeleteCalendarResponse response = new DeleteCalendarResponse();
            response.ExceptionState = false;            

            _calendarRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.Calendars = _calendarRepository.FindAll().ConvertToCalendarSummaryView();

            return response;
        }

        public ListCalendarsResponse ListCalendars(ListCalendarsRequest request)
        {
            ListCalendarsResponse response = new ListCalendarsResponse();
            response.ExceptionState = false;

            response.Calendars = _calendarRepository.FindAll().ConvertToCalendarSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*           CalendarDayType Implementations             */
        /*********************************************************/
        #region CalendarDayType Implementations
        public CreateCalendarDayTypeResponse CreateCalendarDayType(CreateCalendarDayTypeRequest request)
        {
            CreateCalendarDayTypeResponse response = new CreateCalendarDayTypeResponse();
            response.ExceptionState = false;

            CalendarDayType calendarDayType = new CalendarDayType();
            calendarDayType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            calendarDayType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<CalendarDayType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_calendarDayTypeRepistory.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir gün türü zaten var. Lütfen gün türü adını benzersiz bir isim olarak düzenleyin.";

                response.CalendarDayType = calendarDayType.ConvertToCalendarDayTypeView();

                return response;
            }

            object identityToken = _calendarDayTypeRepistory.Add(calendarDayType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Gün türü kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.CalendarDayType = _calendarDayTypeRepistory.FindBy((int)identityToken).ConvertToCalendarDayTypeView();

            return response;
        }

        public ReadCalendarDayTypeResponse ReadCalendarDayType(ReadCalendarDayTypeRequest request)
        {
            ReadCalendarDayTypeResponse response = new ReadCalendarDayTypeResponse();
            response.ExceptionState = false;

            response.CalendarDayType = _calendarDayTypeRepistory.FindBy(request.Id).ConvertToCalendarDayTypeView();

            return response;
        }

        public UpdateCalendarDayTypeResponse UpdateCalendarDayType(UpdateCalendarDayTypeRequest request)
        {
            UpdateCalendarDayTypeResponse response = new UpdateCalendarDayTypeResponse();
            response.ExceptionState = false;

            CalendarDayType calendarDayType = new CalendarDayType();
            calendarDayType.Id = request.Id;
            calendarDayType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            calendarDayType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (calendarDayType.Name != _calendarDayTypeRepistory.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<CalendarDayType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_calendarDayTypeRepistory.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir gün türü zaten var. Lütfen gün türü adını benzersiz bir isim olarak düzenleyin.";

                    response.CalendarDayType = calendarDayType.ConvertToCalendarDayTypeView();

                    return response;
                }
            }

            _calendarDayTypeRepistory.Save(calendarDayType);
            _unitOfWork.Commit();

            response.CalendarDayType = calendarDayType.ConvertToCalendarDayTypeView();

            return response;
        }

        public DeleteCalendarDayTypeResponse DeleteCalendarDayType(DeleteCalendarDayTypeRequest request)
        {
            DeleteCalendarDayTypeResponse response = new DeleteCalendarDayTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<CalendarDay>(c => c.CalendarDayType.Id, request.Id, CriteriaOperator.Equal));
            if (_calendarDayRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini gün türünü kullanan günler var. Lütfen önce bu günleri silip ya da düzenleyip tekrar deneyin.";
                response.CalendarDayTypes = _calendarDayTypeRepistory.FindAll().ConvertToCalendarDayTypeSummaryView();

                return response;
            }

            _calendarDayTypeRepistory.Remove(request.Id);
            _unitOfWork.Commit();

            response.CalendarDayTypes = _calendarDayTypeRepistory.FindAll().ConvertToCalendarDayTypeSummaryView();

            return response;
        }

        public ListCalendarDayTypesResponse ListCalendarDayTypes(ListCalendarDayTypesRequest request)
        {
            ListCalendarDayTypesResponse response = new ListCalendarDayTypesResponse();
            response.ExceptionState = false;

            response.CalendarDayTypes = _calendarDayTypeRepistory.FindAll().ConvertToCalendarDayTypeSummaryView();

            return response;
        }
        #endregion        
    }
}
