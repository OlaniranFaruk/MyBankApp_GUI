using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using customer;
using currentaccounts;
using savings;
using bankcards;
using accounts;
using creditcard;

namespace WPF_Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<CurrentAccount> listOfCurrentAccounts{get; set;}  = new ObservableCollection<CurrentAccount>();
        public ObservableCollection<String> listOfCurrentAccountsNr{get; set;}  = new ObservableCollection<String>();
        

        public static Customer c1 = new Customer("Faruk", "0467283315",new DateTime(2000, 10, 12), Customer.Gender.MALE, Customer.contactMethods.PHONE|Customer.contactMethods.WHATSAPP);
        public static Customer c2 = new Customer("Gbenga", "0456789412", new DateTime(2020,02, 10), Customer.Gender.FEMALE );

        public static BankCard bc1 = new BankCard(2612, c1);
        public static BankCard bc2 = new BankCard(1234, c2);
        public static Creditcard cc1 = new Creditcard(3453, c2, 2345.76 );

        CurrentAccount ca1 = new CurrentAccount(200, c1, bc1);
        CurrentAccount ca2 = new CurrentAccount(400,  c2, bc2);
        CurrentAccount ca3 = new CurrentAccount(600, c1, bc2);
//        listCurrentAccount.Add(ca1);
//        listCurrentAccount.Sort();

        SavingsAccount sa1 = new SavingsAccount(1005.43, c2);

        public MainWindow()
        {
            InitializeComponent();
            listOfCurrentAccounts.Add(ca1);
            listOfCurrentAccounts.Add(ca2);
            listOfCurrentAccounts.Add(ca3);

            listOfCurrentAccountsNr.Add(ca1.getAcctNr());
            listOfCurrentAccountsNr.Add(ca2.getAcctNr());
            listOfCurrentAccountsNr.Add(ca3.getAcctNr());

            AddCurrentAccount.Click += AddCurrentAccountToList;
            ShowAccount.Click += showMessageBox;

            DataContext = this;
        }

        public void AddCurrentAccountToList (object sender, RoutedEventArgs e)
        {
            CurrentAccount ca = new CurrentAccount(700, c2, bc1);
            listOfCurrentAccountsNr.Add(ca.getAcctNr());
            listOfCurrentAccounts.Add(ca);
        }
        public void showMessageBox(object sender, RoutedEventArgs e)
        {
            String selectedAcct = ListAccount.SelectedItems[0].ToString();
            for (int i = 0; i < listOfCurrentAccounts.Count; i++)
            {
                if(listOfCurrentAccounts[i].getAcctNr() == selectedAcct)
                {
                    MessageBox.Show(listOfCurrentAccounts[i].ToString());
                }
            }
            

        }
    }
}
