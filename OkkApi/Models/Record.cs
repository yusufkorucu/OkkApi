using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OkkApi.Enums.Enums;

namespace OkkApi.Models
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime LoginLogoutDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int DurationTime { get; set; }
        public string DataPulse { get; set; }
        public HastaStat HStatus { get; set; }

        public User Users { get; set; }
    }
}
