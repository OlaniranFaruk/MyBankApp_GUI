namespace customer;
using System.Text.Json;

public delegate void CustomerDelegate();
public class Customer
{

    public enum Gender {
        MALE = 1,
        FEMALE,
        OTHERS
    }

    public enum contactMethods {
        PHONE = 1,
        EMAIL,
        WHATSAPP
    }

    public void constructMessage (String title, String message)
    {
        System.Console.WriteLine($"Contact via {this._contact}: {title}, Dear {getGenderTitle()} {this._name}, {message} ");
    }

    public string getGenderTitle(){
        switch (this._gender)
        {
            case Gender.MALE:
                return "Mister";
            case Gender.FEMALE:
                return "Madame";
            case Gender.OTHERS:
                return "";
            
        }
        return null;
    }
    public  int id { get; set;}
    public string _name {get; set;}
    public string _phone_nr {get; set;}
    public DateTime _DOB {get; set;}
    private static int current_id{get; set;} = 1;
    public contactMethods _contact{get; set;}

    public Gender _gender {get; set;}


    public void sendWelcomePackage( CustomerDelegate CD)
    {
        CD.Invoke();
    }

    public void sendEmail()
    {
        System.Console.WriteLine("Welcome");
        System.Console.WriteLine("50% off coupon");
           if (calculateAge() < 18)
        {
            System.Console.WriteLine("User younger than 18 gets Chocolates");
        }
        else
        {
            System.Console.WriteLine("Users older than 18 get Wine");
        }
    }
   
    

    public Customer( string name  , string phone_nr  , DateTime DOB, Gender gender, contactMethods contact = contactMethods.EMAIL )
    {
    

            this._name = name;
            this._phone_nr = phone_nr;
            this._DOB = DOB;

            this.id = current_id;
            this._gender = gender;
            this._contact = contact;
            current_id++;

            CustomerDelegate newDel = sendEmail;
            

            sendWelcomePackage(newDel);
    }
    public int calculateAge()
    {
        DateTime today = DateTime.Now;
        int age = 0;
        age = today.Year - this._DOB.Year;

        return age;
    }

    public Customer()
    {
        //console ask for details
    }



    public Customer get()
    {
        return this;
    }
    public void set(Customer c)
    {
        id = c.id;
        _name = c._name;
        _phone_nr = c._phone_nr;
        _DOB = c._DOB;
    }

    new public string ToString()
    {
       return JsonSerializer.Serialize(this);

    }


    

    
}
