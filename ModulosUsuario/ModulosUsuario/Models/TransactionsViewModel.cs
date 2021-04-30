using System.Collections.Generic;

namespace ModulosUsuario.Models
{
    public class TransactionsViewModel
    {
        public Stock Stock { get; set; }
        public List<ProductTransaction> ProductTransactions { get; set; }
        public List<MaterialTransaction> MaterialTransactions { get; set; }
        public List<ToolsTransaction> ToolsTransactions { get; set; }
    }
}
