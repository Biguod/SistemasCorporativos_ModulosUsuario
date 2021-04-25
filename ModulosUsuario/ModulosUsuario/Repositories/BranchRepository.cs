using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DatabaseContext context;
        public BranchRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public IEnumerable<Branch> GetAll()
        {
            return context.Branch.ToList();
        }

        public Branch Create(Branch branch)
        {
            context.Add(branch);
            context.SaveChanges();
            return branch;
        }

        public Branch Update(Branch branch)
        {
            context.Update(branch);
            context.SaveChanges();
            return branch;
        }

        public Branch GetById(int branchId)
        {
            var branch = context.Branch.Find(branchId);
            if (branch == null)
                branch = new Branch();
            return branch;
        }

        public void Delete(Branch branch)
        {
            context.Remove(branch);
            context.SaveChanges();
        }
    }
}
