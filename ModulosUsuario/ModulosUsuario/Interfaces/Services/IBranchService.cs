using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IBranchService
    {
        IEnumerable<Branch> GetBranches();
        Branch CreateOrEditBranch(Branch branch);
        void DeleteBranch(int branchId);
        Branch GetBranchById(int branchId);
    }
}
