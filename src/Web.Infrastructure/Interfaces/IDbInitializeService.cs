using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Infrastructure.Interfaces
{
    public interface IDbInitializeService
    {
        void Migrate();
        void Seed();
    }
}
