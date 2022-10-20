namespace currentaccounts;
using accounts;
using bankcards;
using customer;
using System.Text.Json;
using transaction;
using interfaces;

public class CurrentAccount: Account, ITransaction, IComparable<CurrentAccount>{
    public List<BankCard> _associatedBankCards {get; set;}= new List<BankCard>();
    public List<Transactions> _transactions{get; set;} = new List<Transactions>();

    public CurrentAccount( double balance, Customer AcctAccess, BankCard associatedBankCards)
                         : base( balance, AcctAccess){
        
//        associatedBankCards.MyHandler += withdrawMoney;

        var randomGenerator = new Random();
        var randomRest = randomGenerator.Next(1000000, 9999999);

        var randomGenerator2 = new Random();
        var randomRest2 = randomGenerator.Next(100, 999);

        string GenerateAccNr = randomRest2.ToString() + randomRest;

        base._acctNr = GenerateAccNr.ToString();
        this._associatedBankCards.Add(associatedBankCards);
    }

    public int CompareTo(CurrentAccount ca)
    {
        if(Int32.Parse(this._acctNr) > Int32.Parse(ca._acctNr))
            return 1;
        return 0;
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

    public void addBankCard(BankCard bc)
    {
        _associatedBankCards.Add(bc);
    }

    public double withdrawMoney(int amnt)
    {
        base._balance -= amnt;
        return base._balance;
    }

    public double depositMoney(int amnt)
    {
        base._balance += amnt;
        return base._balance;
    }

    public int removeBankCard(int cardNr)
    {
        foreach(BankCard c in _associatedBankCards)
        {
            if (cardNr == c._cardNumber)
            {
                _associatedBankCards.Remove(c);
                return 1;
            }
        }
        return -1;
    }

    new public string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}