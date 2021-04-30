namespace ModulosUsuario.Models
{
    public class TransactionListViewModel
    {
        public Stock Stock { get; set; }
        public int TotalProductTransactions { get; set; }
        public int TotalMaterialTransactions { get; set; }
        public int TotalToolsTransactions { get; set; }
    }
}
