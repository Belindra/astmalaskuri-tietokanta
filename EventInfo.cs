using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Asthma_Calc
{
    public class EventInfo
    {
        [Key]
        public int EventId { get; set; }
        public int MedicineId { get; set; }
        public int UsedPortionNow{ get; set; }
        public DateTime Date { get; set; }
    }
}
