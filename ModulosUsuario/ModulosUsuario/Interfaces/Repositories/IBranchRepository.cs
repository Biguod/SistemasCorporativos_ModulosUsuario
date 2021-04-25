using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetAll();
        Branch Create(Branch branch);

        Branch Update(Branch branch);

        Branch GetById(int branchId);

        void Delete(Branch branch);
    }
}
