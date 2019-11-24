using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void BankAccount_TesteParaVerificarUpdateDoSaldo()
        {
            // Cen�rio
            double balancoInicial = 200;
            double valorSaque = 180;
            double resultado = 20;
            BankAccount contaBancaria = new BankAccount("Geralt de Rivia", balancoInicial);

            // A��o
            contaBancaria.Saque(valorSaque);

            // Resultado Esperado
            double balancoAtual = contaBancaria.Balance;
            Assert.AreEqual(resultado, balancoAtual, 0.001, "O saldo est� com o valor incorreto");
        }
        [TestMethod]
        public void BankAccount_TesteSaqueSuperiorAoSaldo()
        {
            // Cen�rio
            double balancoInicial = 10.00;
            double valorSaque = 20.00;
            BankAccount contaBancaria = new BankAccount("Geralt de Rivia", balancoInicial);

            // A��o
            try
            {
                contaBancaria.Saque(valorSaque);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Resultado
                StringAssert.Contains(e.Message, BankAccount.SaqueInvalido_supeior_ao_Saldo);
            }
        }
        [TestMethod]
        public void BankAccount_TesteSaqueInferior_a_Zero()
        {
            // Cen�rio
            double balancoInicial = 10.00;
            double valorSaque = -20.0;
            BankAccount contaBancaria = new BankAccount("Geralt de Rivia", balancoInicial);

            // A��o
            try
            {
                contaBancaria.Saque(valorSaque);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Resultado
                StringAssert.Contains(e.Message, BankAccount.SaqueInvalido_enferior_a_Zero);
            }
        }
    }
}
