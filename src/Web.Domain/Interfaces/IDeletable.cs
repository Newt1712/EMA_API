using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Interfaces
{
    public interface IDeletable
    {
        DateTime DeletedAt { get; set; }

        string DeletedBy { get; set; }
    }
}
