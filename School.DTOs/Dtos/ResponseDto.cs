using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Dtos
{
    public class Response<T> where T : class
    {
        public string Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
