using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
       ICongTyRepository CongTy { get; }
       Task Save();
    }
}
