using System;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateProjectRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectStatusId { get; set; }
        public int ProjectTypeId { get; set; }
        public int CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public System.Nullable<DateTime> EndDate { get; set; }
    }
}
