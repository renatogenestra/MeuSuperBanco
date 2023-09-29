using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuperBanco
{
    public class ContaBanco
    {
        public int numero { get; }
        public string Dono { get; set; }

        //Criando o Array TodasTansacoes do TIPO Transacao (com base na classe Transacao.cs)
        private List<Transacao> TodasTansacoes = new List<Transacao>();

        public decimal Saldo 
        { 
            get 
            { 
                decimal saldo = 0;
                foreach (var item in TodasTansacoes) 
                {
                    saldo += item.Valor;
                }
                return saldo;
            } 
        }
        //testando fazero mesmo com o OBS
        public string Observacao
        {
            get {
                string LastObs = "";
                foreach (var item in TodasTansacoes)
                {
                    LastObs = item.Obs;
                }
                return LastObs;
            }
        }
        
        public DateTime dateTime { get; set; }

        //gerando o numero da conta aleatorio
        Random randNum = new Random();

       

        public ContaBanco(string nomeDono, decimal valor)
        {
            this.Dono = nomeDono;
            this.dateTime = DateTime.Now;
            this.numero = randNum.Next(100000, 999999);
            Depositar(valor, dateTime, "Saldo Inicial");

        }

        public void Depositar(decimal valor, DateTime data, string Obs) 
        {
            if (valor<= 0)
            {
               throw new ArgumentOutOfRangeException(nameof(valor), "Não aceitamos depósitos de valor 0 ou negativo");
            }

            //instanciando objeto Trans na função Transacao
            Transacao Trans = new Transacao(valor, data, Obs);
            //Adicionando as informações de Trans dentro do Array Todasransacoes
            TodasTansacoes.Add(Trans);

        }
        public void Sacar(decimal valor, DateTime data, string Obs) 
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não aceitamos saques de valor 0 ou negativo");
            }
            else if (Saldo - valor < 0) {
                throw new InvalidOperationException("Esta operação não é permitida");
            }
            //instanciando objeto Trans na funcao Transacao
            Transacao Trans = new Transacao(-valor, data, Obs);
            TodasTansacoes.Add(Trans);
        }

        public string PegarMovimentacao() 
        {
            var movimentacoes = new StringBuilder();
            movimentacoes.AppendLine("Data\t\tValor\t\tObservações");
            foreach (var item in TodasTansacoes)
            {
                movimentacoes.AppendLine($"{item.Data.ToShortDateString()}\t{item.Valor}\t\t{item.Obs}");
            }
            return movimentacoes.ToString();
        
        }
    }
}
