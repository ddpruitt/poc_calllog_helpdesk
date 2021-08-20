using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoC.CallLogMvc.Web02.Data.Models
{
    public class CallStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        [Display(Name = "Status")]
        public string Name { get; set; }

        public List<CallLog> CallLogs { get; set; }

        public CallStatus()
        {
            CallLogs = new List<CallLog>();
        }
    }
}