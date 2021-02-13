using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Asthma_Calc
{
    public class MedicineInfo
    {
        [Key]
        public int MedicineId { get; set; }
        public int TotalPortion { get; set; }
        public int UsedPortion { get; set; }
        public string MedicineName { get; set; }
    }
}
