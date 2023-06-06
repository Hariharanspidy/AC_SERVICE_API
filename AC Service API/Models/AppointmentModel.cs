using System.ComponentModel.DataAnnotations;

namespace AC_Service_API.Models
{
    public class AppointmentModel
    {
        [Key]
        public int Id { get; set; }
        public string emailId { get; set; }   
        public string serviceName { get; set; }
        public string Date { get; set; }
        public string time { get; set; }
    }
}
