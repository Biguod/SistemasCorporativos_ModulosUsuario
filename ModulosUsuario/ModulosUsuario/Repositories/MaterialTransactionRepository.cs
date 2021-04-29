using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Repositories
{
    public class MaterialTransactionRepository : IMaterialTransactionRepository
    {
        private readonly DatabaseContext context;

        public MaterialTransactionRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public MaterialTransaction Create(MaterialTransaction materialTransaction)
        {
            context.Add(materialTransaction);
            context.SaveChanges();
            return materialTransaction;
        }

        public IEnumerable<MaterialTransaction> GetAll()
        {
            return context.MaterialTransaction.ToList();
        }

        public MaterialTransaction GetById(int materialTransactionId)
        {
            return context.MaterialTransaction.Find(materialTransactionId);
        }

        public IEnumerable<MaterialTransaction> GetByMaterialId(int materialId)
        {
            return context.MaterialTransaction.Where(w => w.MaterialId == materialId).ToList();
        }

        public MaterialTransaction Update(MaterialTransaction materialTransaction)
        {
            context.Update(materialTransaction);
            context.SaveChanges();
            return materialTransaction;
        }
    }
}
