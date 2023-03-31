using System;
public class Compiler
{
    private int _ID;
    private string _password;
    private string _fullName="";
    private float _rate;
    private int _hoursWorked;
    private string _payType;
    private string _userRole;
    private int _groupID;
    private string _timeSubmitted;
    private string _timeApproved;
    private string _timePaid;
    private float _monthEarnedAmount;
    private string _userActive;
    private int _userSelection;
    private int USERPASSWORD=1;
    private int FIRSTNAME=2;
    private int LASTNAME=3;
    private int RATE=4;
    private int HOURSWORKED=5;
    private int PAYTYPE=6;
    private int USERROLE=7;
    private int GROUPID=8;
    private int TIMESUBMITTED=9;
    private int TIMEAPPROVED=10;
    private int TIMEPAID=11;
    private int MONTHEARNEDAMOUNT=12;
    private int USERACTIVE=13;
    //initiate classes to be used
    Load load = new Load();
    Save save = new Save();
    HR HR = new HR();
    ApplicationAdministrator appAdmin = new ApplicationAdministrator();
    Manager manager = new Manager();
    BaseEmployee employee = new BaseEmployee();
    

    //Takes User ID and password and verifies the entries match the user list. will only allow 3 attempts.
    public string Login()
    {
        int loginAttempt=0;
        string lookupPassword="";
        bool checkID = false;
        bool repeatLoop = true;

        load.LoadDict();
        
        do
        {
            // asks for and stores user ID
            Console.WriteLine("Welcome to the Paperless Payroll Application: Please login.");
            Console.Write("Please enter your User ID: ");
            _ID=int.Parse(Console.ReadLine());
            loginAttempt+=1;

            // Checks if entered ID exists in the User List
            checkID=load.CheckID(_ID);
            if (checkID)
            {
                Console.Write("Please endter your password: ");
                _password = Console.ReadLine();
                
                //checks if passwords match and if the user is active
                lookupPassword=load.GetValue(_ID, USERPASSWORD);
                _userActive = load.GetValue(_ID, USERACTIVE);
                    if (_password == lookupPassword && _userActive=="yes")
                    {
                        //If both are true then loads all unconfirmed fields from the user list to the compiler for possible future modifications.
                        string firstName=load.GetValue(_ID, FIRSTNAME);
                        string lastName=load.GetValue(_ID, LASTNAME);
                        _fullName=$"{firstName} {lastName}";
                        _rate=int.Parse(load.GetValue(_ID, RATE));
                        _payType=load.GetValue(_ID, PAYTYPE);
                        _userRole=load.GetValue(_ID, USERROLE);
                        _groupID=int.Parse(load.GetValue(_ID, GROUPID));
                        _timeSubmitted=load.GetValue(_ID, TIMESUBMITTED);
                        _timeApproved=load.GetValue(_ID, TIMEAPPROVED);
                        _timePaid=load.GetValue(_ID, TIMEPAID);
                        _monthEarnedAmount=int.Parse(load.GetValue(_ID, MONTHEARNEDAMOUNT));
                        _hoursWorked=int.Parse(load.GetValue(_ID, HOURSWORKED));

                        //triggers the repeat loop while logic to change so we can get out of the do While loop
                        repeatLoop = false;
                    }
                    //if user is disabled then they will get this displayed
                    else if (_userActive == "no")
                    {
                        Console.WriteLine("Entered User Account has been disabled, please contact your IT Administrator.");
                                Thread.Sleep(5000);
                    }
                    
                    else if (_password != lookupPassword)
                    {
                        Console.WriteLine("Entered Password does not match saved password.");
                        Thread.Sleep(5000);
                    }
            }
            else
            {
                Console.WriteLine($"Entered ID - {_ID} does not exist.");
                Thread.Sleep(5000);
            }
            
            //If you fail to login on the 3rd attempt you will get this error.
            if (loginAttempt >= 3)
            {
                //triggers the repeat loop while logic to change so we can get out of the do While loop
                if (_password != lookupPassword || checkID == false || _userRole == "no")
                {
                    repeatLoop=false;
                    Console.Write("3 failed login attempts, please contact your IT Administrator");
                    Thread.Sleep(5000);
                }
            }
            Console.Clear();
        }
        while (repeatLoop);
        return _userRole;
    } 

    public void HRMenu()
    {
        
        do
        {
            MainMenuHeader();
            _userSelection=HR.MainMenu();

            if (_userSelection == 1)
            {
                EnterTime();
            }

            else if (_userSelection == 2)
            {
                HR.PayTimesheets();
            }

            else if (_userSelection == 3)
            {
                ChangePassword();
            }
            else if (_userSelection == 4)
            {
                QuitMessage();
            }
            InvalidMenuSelectionCheck(1, 4);

        }
        while (_userSelection!=5);
    }

    public void ApplicationAdministratorMenu()
    {
        do
        {
            MainMenuHeader();
            _userSelection=appAdmin.MainMenu();

            if (_userSelection == 1)
            {
                EnterTime();
            }
            else if (_userSelection == 2)
            {
                appAdmin.ReviewUserTimeStatus();
            }
            else if (_userSelection == 3)
            {
                appAdmin.AddNewUser();
            }
            else if (_userSelection == 4)
            {
                appAdmin.ChangeUserGroupOrRole();
            }
            else if (_userSelection == 5)
            {
                appAdmin.DeactivateUser();
            }
            else if (_userSelection == 6)
            {
                appAdmin.ResetUserPassword();
            }
            else if (_userSelection == 7)
            {
                ChangePassword();
            }
            else if (_userSelection == 8)
            {
                QuitMessage();
            }
            InvalidMenuSelectionCheck(1, 8);
        }
        while (_userSelection!=8);
    }

    public void ManagerMenu()
    {
        do
        {
            MainMenuHeader();
            _userSelection=manager.MainMenu();

            if (_userSelection == 1)
            {
                EnterTime();
            }

            else if (_userSelection == 2)
            {
                manager.ApproveTime(_groupID);
            }

            else if (_userSelection == 3)
            {
                ChangePassword();
            }
            else if (_userSelection == 4)
            {
                QuitMessage();
            }
            InvalidMenuSelectionCheck(1, 4);

        }
        while (_userSelection!=5);
    }
      
    public void BaseEmployeeMenu()
    {
        do
        {
            MainMenuHeader();
            _userSelection=employee.MainMenu();
            if (_userSelection == 1 )
            {
                EnterTime();
            }
            else if (_userSelection == 2)
            {
                ChangePassword();
            }
            else if (_userSelection == 3)
            {
                QuitMessage();
            }
            InvalidMenuSelectionCheck(1, 3);
        }
        
        while (_userSelection!=3);
    }
    
    //begining of private methods used repeatedly throughout this class
    
    //Generates personalized headder to show above the main menue after loggin in
    private void MainMenuHeader()
    {
        Console.Clear();
        Console.WriteLine($"name:{_fullName}");
        Console.WriteLine($"Role: {_userRole}");
        Console.WriteLine($"Department ID: {_groupID}");
        Console.WriteLine("Main Menu");
    }
    //Updates user input for time worked and pay earned for the month and saaves to UserList csv file
    private void EnterTime()
    {
        Console.WriteLine("How many regular whole hours did you work this month?");
        _hoursWorked=int.Parse(Console.ReadLine());
        if (_payType == "Salary")
        {
            _monthEarnedAmount=_rate;
        }
        else if (_payType ==  "Hourly")
        {
            _monthEarnedAmount=_rate*_hoursWorked;
        }
        save.RelayChangeDictValue(_ID, MONTHEARNEDAMOUNT,$"{_monthEarnedAmount}");
        Console.WriteLine("Please enter the Month you are submitting this timesheet for.");
        _timeSubmitted=Console.ReadLine();
        save.RelayChangeDictValue(_ID, TIMESUBMITTED,_timeSubmitted);
    }
    //Updates user password
    private void ChangePassword()
    {
        string password1;
        string password2;
        //Create new password
        do
        {
            Console.Clear();
            Console.Write("Please enter your new password (must contain at least 8 characters): ");
            password1=Console.ReadLine();
            Console.Write("Please re-enter your new password: ");
            password2=Console.ReadLine();
            if (password1.Length < 8)
            {
                Console.Write("Your entered password must be atleast 8 characters long.");
                Thread.Sleep(5000);
            }
            else if (password1==password2)
            {
                Console.Write("Your password has been reset");
                Thread.Sleep(5000);
            }
            else
            {
                Console.WriteLine("Passwords do not match");
            }
        }
        while (password1 != password2 && password1.Length < 8);
        //save new password to user list
        save.RelayChangeDictValue(_ID, USERPASSWORD, _password);
    }
    //Displays invalid menu selection
    private void InvalidMenuSelectionCheck(int one, int two)
    {
        if (_userSelection < one || _userSelection > two)
        {
            Console.WriteLine("Selected number was not one of the Menue options.");
            Thread.Sleep(3000);
        }
    }
    //Display exit message
    private void QuitMessage()
    {
        save.RelaySaveUserListCSV();
        Console.WriteLine("Thank you for using the Paperless Payroll Application. Have a great day!");
        Thread.Sleep(6000);
    }
    
}