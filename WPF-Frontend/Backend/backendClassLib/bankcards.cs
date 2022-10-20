namespace bankcards;
using customer;
using System.Text.Json;

//public delegate void MyEventHandler(object obj);
public class BankCard
{
//    public event MyEventHandler MyHandler;
    public int _cardNumber{get; set;}
    public int _pin{get; set;}
    public Customer _cardOwner{get; set;}

    // public void WithdrawMoney(){
    //     MyHandler(this);
    // }

    public BankCard( int pin, Customer cardOwner)
    {
        var randomGenerator = new Random();
        var randomRest = randomGenerator.Next(10000000, 99999999);

        this._cardNumber = randomRest;
        this._pin = pin;
        this._cardOwner = cardOwner;
    }

    public BankCard get()
    {
        return this;
    }
    public void set(BankCard bc)
    {
        _cardNumber = bc._cardNumber;
        _pin = bc._pin;
        _cardOwner = bc._cardOwner;
    }

    new public string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}