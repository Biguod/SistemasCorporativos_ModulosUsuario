using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class BranchService : IBranchService
    {
        public readonly IBranchRepository branchRepository;
        public BranchService(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }

        public IEnumerable<Branch> GetBranches()
        {
            return branchRepository.GetAll();
        }

        public void DeleteBranch(int branchId)
        {
            var branch = branchRepository.GetById(branchId);
            if (branch.BranchId == 0)
                return; //throw exception aqui !!!

            branchRepository.Delete(branch);
        }

        public Branch GetBranchById(int branchId)
        {
            var branch = branchRepository.GetById(branchId);
            
            return branch;
        }

        public Branch CreateOrEditBranch(Branch branch)
        {
            if(branch.BranchId == 0)
            {
                return CreateBranch(branch);
            }
            return UpdateBranch(branch);
        }

        private Branch CreateBranch(Branch branch)
        {
            branchRepository.Create(branch);
            return branch;
        }

        private Branch UpdateBranch(Branch branch)
        {
            branchRepository.Update(branch);
            return branch;
        }
    }
}
