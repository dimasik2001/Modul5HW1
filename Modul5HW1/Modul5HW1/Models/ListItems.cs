using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Models
{
    public class ListItems<T>
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }
        public Support Support { get; set; }
    }
}
