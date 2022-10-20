namespace accounts;
using customer;

abstract public class Account
{
  //  private Customer _acctOwner{get; set;}
    public string _acctNr {get; set;}
    public double _balance{get; set;}
    public List<Customer> _AcctAccess = new List<Customer>();

  

    public static Boolean checkAccountNum(string accntNum)
    {
        const int accntNumLen = 10;
        if (accntNum.Length == accntNumLen && int.TryParse(accntNum, out int numeric) )
        {
            return true;
        }
        return false;
    }

    public Customer this[int index]
    {
       get{

                foreach (Customer c in _AcctAccess)
                {
                    if (c.id == index)
                    {
                        return c;
                    }
                }

            return null;
                
       }
    } 

    public Account(  double balance, Customer AcctAccess)
    {
        
//        this._acctNr = acctNr;
        this._balance = balance;
        this._AcctAccess.Add(AcctAccess) ;

        // for (int i = 0; i < AcctAccess.Count; i++)
        // {
            
        //     _AcctAccess[i].set(AcctAccess[i]);
        // }
    }

    public void addCustomer(Customer c)
    {
        _AcctAccess.Add(c);
    }

    public Boolean deleteAccount()
    {
        if(_balance == 0)
        {
            return true;
        }
        return false;
    }
    public string getAcctNr()
    {
        return this._acctNr;
    }
    
    

}