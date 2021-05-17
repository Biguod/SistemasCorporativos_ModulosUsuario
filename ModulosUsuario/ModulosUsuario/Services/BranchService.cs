using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class BranchService : IBranchService
    {
        public readonly IBranchRepository branchRepository;
        public readonly IStockRepository stockRepository;
        public BranchService(IBranchRepository branchRepository, IStockRepository stockRepository)
        {
            this.branchRepository = branchRepository;
            this.stockRepository = stockRepository;
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

        public Branch GetBranchByDescription(string description)
        {
            var branch = branchRepository.GetByDescription(description);

            return branch;
        }

        public Branch CreateOrEditBranch(Branch branch)
        {
            try
            {
                if (branch.BranchId == 0 && branch.Description.ToUpper() == GetBranchByDescription(branch.Description).Description.ToUpper())
                {
                    return CreateBranch(branch);
                }
                return UpdateBranch(branch);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        private Branch CreateBranch(Branch branch)
        {
            branch = branchRepository.Create(branch);

            var stock = new Stock { BranchId = branch.BranchId, StockId = 0 };
            stockRepository.Create(stock);

            return branch;
        }

        private Branch UpdateBranch(Branch branch)
        {
            return branchRepository.Update(branch);
        }
    }
}
