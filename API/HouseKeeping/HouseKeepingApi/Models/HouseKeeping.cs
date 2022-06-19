using System.ComponentModel.DataAnnotations;

namespace HouseKeepingApi.Models
{
    public class HouseKeeping
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string TimeReq { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Feedback { get; set; }
        public string Complaint { get; set; }
        public string ServiceRequest { get; set; }
        public string ServiceIsApproved { get; set; }
    }
}
