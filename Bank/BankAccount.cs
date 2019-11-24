using System;

namespace BankAccountNS
{
    public class BankAccount
    {
        private readonly string m_costumerName;
        private double m_balance;
        public const string SaqueInvalido_supeior_ao_Saldo = " O valor do saque exece o saldo atual";
        public const string SaqueInvalido_enferior_a_Zero = " O valor do saque é menor que zero";
        private BankAccount() {}

        public BankAccount(string costumerName, double balance)
        {
            m_costumerName = costumerName;
            m_balance = balance;
        }
        public string CostumerName
        {
            get { return m_costumerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }

        public void Saque(double quantidade)
        {
            //Caso eu não adiciona o a exceção ArgumentOutOfRangeException o teste apresentará falhas

            if (quantidade > m_balance)
                throw new ArgumentOutOfRangeException(SaqueInvalido_supeior_ao_Saldo);

            if (quantidade < 0)
                throw new ArgumentOutOfRangeException(SaqueInvalido_enferior_a_Zero);

            //Codigo errado m_balance += quantidade;
            //Refatoração aplicada com sucesso
            m_balance -= quantidade;
        }
        
        public void Deposito(double quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentOutOfRangeException("Quantidade");

            m_balance += quantidade;
        }

        public static void Main()
        {
            double balancoAtual = 500.00;
            double valorSaque = 50;
            double valorDeposito = 25;
            double resultadoExperado = 475;

            var contaBancaria = new BankAccount("Geralt de Rivia", balancoAtual);
            contaBancaria.Saque(valorSaque);
            contaBancaria.Deposito(valorDeposito);

            Console.WriteLine("Balanço atual da conta ${0}", contaBancaria.Balance);
            Console.WriteLine(resultadoExperado == contaBancaria.Balance);
        }

    }
}
