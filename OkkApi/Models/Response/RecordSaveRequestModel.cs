using System;
using static OkkApi.Enums.Enums;

namespace OkkApi.Models
{
    public class RecordSaveRequestModel
    {
        public int Id { get; set; }
        public DateTime LoginLogoutDate { get; set; }
        public int DurationTime { get; set; }
        public string DataPulse { get; set; }
        public HastaStat HStatus { get; set; }

        public long TCKNO { get; set; }
    }
}
