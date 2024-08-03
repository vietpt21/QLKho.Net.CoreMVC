using QLKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository.IRepository
{
    public interface IKhoRepository : IRepository<Kho>
    {
        Task<Kho> Update(Kho obj);
    }
}
