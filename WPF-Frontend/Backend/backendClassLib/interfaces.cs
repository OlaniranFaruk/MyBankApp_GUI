namespace interfaces;
using transaction;

public interface ITransaction{
 //   public string name;

        public string getNumber();

        public double getBalance();

        public void setBalance(double newBalance);

        public void addNewTransaction(Transactions newTransaction);


}



