using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities
{
    public class SampleEntity : BaseEntity<int>
    {
        public int Age { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
    }
}
