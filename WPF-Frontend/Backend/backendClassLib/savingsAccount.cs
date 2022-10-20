namespace savings;
using accounts;
using customer;
using System.Text.Json;
using transaction;
using interfaces;

public class SavingsAccount: Account, ITransaction{

    public List<Transactions> _transactions{get; set;} = new List<Transactions>();
    
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
            return base._acctNr;
        }
        public double getBalance()
        {
            return this._balance;
        }
        public void setBalance(double newBalance)
        {
            this._balance  = newBalance;
        }
    public SavingsAccount( double balance, Customer AcctAccess ) 
                : base( balance, AcctAccess)
    {
        var randomGenerator = new Random();
        var randomRest = randomGenerator.Next(1000000, 9999999);
        string GenerateAccNr = "123"+ randomRest;

        base._acctNr = GenerateAccNr.ToString();

        DateOnly today = new DateOnly();

        if ((today.Year - AcctAccess._DOB.Year) < 12)
        {
            this._balance += 50;
//            System.Console.WriteLine(balance);
        }

        
    }

    new public string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    

}