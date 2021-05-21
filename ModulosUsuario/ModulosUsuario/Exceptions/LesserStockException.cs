using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Exceptions
{
    public class LesserStockException : Exception
    {
        public LesserStockException()
        {
            //Console.WriteLine("Número de venda maior que a quantidade em estoque! 2");

        }

        public LesserStockException(string message) : base(message)
        {
            //Console.WriteLine("Número de venda maior que a quantidade em estoque! 2");

        }

        public LesserStockException(string message, Exception innerException) : base(message, innerException)
        {
           // Console.WriteLine("Número de venda maior que a quantidade em estoque! 1");
        }

        public LesserStockException(string message, string message1) : base(message)
        {
            //Console.WriteLine("Número de venda maior que a quantidade em estoque! 2");
        }

        public override string Message
        {
            get
            {
                return "Número de venda maior que a quantidade em estoque!";
            }
        }
    }
}
