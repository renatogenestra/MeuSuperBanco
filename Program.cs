using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuperBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MeuSuperBanco.ContaBanco ObjConta = new ContaBanco("Renato", 100000);
            //Abrindo a conta
            Console.WriteLine($"A conta {ObjConta.numero} de {ObjConta.Dono} foi criada com saldo {ObjConta.Saldo} às {ObjConta.dateTime}");

            //Fazendo um Depósito
            try
            {
                ObjConta.Depositar(100, DateTime.Now, "Recebi Um Pagamento");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch
            {
                Console.WriteLine($"Depósito Não Realizado");
            }

            try
            {
                //Fazendo um Saque
                ObjConta.Sacar(289, DateTime.Now, "Fiz Um Pagamento");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch
            {
                Console.WriteLine($"Saque Não Realizado");
            }

            //imprimindo o extrato
            Console.WriteLine(ObjConta.PegarMovimentacao());
            Console.WriteLine($"Saldo atual em {DateTime.Now.ToShortDateString()} é de R$ {ObjConta.Saldo}");


        }
    }
}
