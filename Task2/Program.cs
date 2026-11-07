using System;
using System.Text;

namespace Task2
{
    public class BankAccount
    {

        private string _accountNumber;
        private decimal _balance;


        public string AccountNumber
        {
            get => _accountNumber;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 10)
                    throw new ArgumentException("Номер має містити 10 символів.");
                _accountNumber = value;
            }
        }


        public decimal Balance => _balance;
        
        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            if (initialBalance < 0)
                throw new ArgumentException("Баланс не може бути від'ємним.");
            _balance = initialBalance;
        }
        
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума поповнення має бути більшою за 0.");
            _balance += amount;
        }
        
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума зняття має бути більшою за 0.");
            if (amount > _balance)
                throw new InvalidOperationException("Недостатньо коштів на рахунку!");
            _balance -= amount;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            BankAccount acc = new BankAccount("UA12345678", 500);
            acc.Deposit(200);
            acc.Withdraw(100);
            Console.WriteLine($"Рахунок: {acc.AccountNumber}, Баланс: {acc.Balance} грн");
            
            try
            {
                acc.Withdraw(1000); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}