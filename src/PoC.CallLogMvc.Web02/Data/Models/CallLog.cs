using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoC.CallLogMvc.Web02.Data.Models
{
    public class CallLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Caller { get; set; }
        public string Title { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }

        public int CallStatusId { get; set; }

        [Display(Name = "Status")]
        public CallStatus CallStatus { get; set; }

        public DateTime WhenCreated { get; set; }

        public CallLog()
        {
            WhenCreated = DateTime.UtcNow;
        }
    }
}