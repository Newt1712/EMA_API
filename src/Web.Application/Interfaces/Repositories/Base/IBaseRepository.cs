using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T, TId> : IReadRepository<T, TId>, IWriteRepository<T, TId> where T : BaseEntity<TId>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
