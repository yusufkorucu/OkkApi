using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OkkApi.Enums.Enums;

namespace OkkApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Job Property { get; set; }

        public Cins Gender { get; set; }
        public SpecialStat SpecialStatus { get; set; }
        public int Age { get; set; }
        public long TCKNO { get; set; }
        public string SpecialCode { get; set; }
        public List<Record> Record { get; set; }

    }
}
