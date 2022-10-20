namespace creditcard;
using bankcards;
using customer;
using System.Text.Json;
using transaction;
using interfaces;
public class Creditcard:BankCard, ITransaction {

        

        public List<Transactions> _transactions{get; set;} = new List<Transactions>();
        public int _cvcCode{get; set;}
        public double _balance{get; set;}
        public Creditcard( int pin, Customer customer, double balance)
            :base( pin, customer){
                _cvcCode = base._cardNumber % 987;

                _balance = balance;
        }

          public static void Transaction(ITransaction from, ITransaction to, double amount)
    {
        double newBalance = from.getBalance() - amount;
        from.setBalance(newBalance);

        newBalance = to.getBalance() + amount;
        to.setBalance(newBalance);

        Transactions newTransac;

        newTransac.from = from.getNumber();
        newTransac.to = to.getNumber();
        newTransac.amount = amount;
        newTransac.TransactionDate = new DateTime();

        from.addNewTransaction(newTransac);
        to.addNewTransaction(newTransac);

    }


    public void addNewTransaction(Transactions newTransaction)
    {
        this._transactions.Add(newTransaction);
    }

        public string getNumber()
        {
            return base._cardNumber.ToString();
        }
        public double getBalance()
        {
            return this._balance;
        }
        public void setBalance(double newBalance)
        {
            this._balance  = newBalance;
        }

        public double withdrawMoney(int amnt)
        {
            _balance -= amnt;
            return _balance;
        }

        public Boolean deleteCreditCard()
        {
            if(_balance == 0)
            {
                return true;
            }

            return false;
        }
            new public string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
}