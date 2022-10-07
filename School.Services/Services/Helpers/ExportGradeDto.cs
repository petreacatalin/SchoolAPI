using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Services.Helpers
{
    public class ExportGradeDto
    {
        public double Score { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Student { get; set; }
        public string Professor { get; set; }
        public string Class { get; set; }
        public int Credits { get; set; }
    }
}
