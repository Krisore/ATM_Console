using ATM_Software;
using static System.Console;

ManageCard manage = new ManageCard();
ManageBank manageBank = new ManageBank();
Write("Enter Card Number: ");
string userCardNumber = ReadLine() ?? throw new Exception("Card Number can't be Null!");
Write("Enter Card Pin: ");
string userPinNumber = ReadLine() ?? throw new Exception("Card Pin can't be Null!");

WriteLine("Checking Credentials....");
Thread.Sleep(3000);
if (DoChecking(userCardNumber, userPinNumber))
{
    WriteLine("[^^v] -- Valid Credentials [/]\n\n" +
              "Proceedings to your Account[o_o]\n\n");
    Thread.Sleep(3000);
    ManageUser();
}
else
{
    WriteLine("Invalid [X] Operation \n System will Exterminate\n");
    Environment.Exit(0);
}



bool DoChecking(string userCardNumberm, string userPinNumber)
{
    if (manage.DoCheckPin(userPinNumber) && manage.CheckCard(userCardNumber))
    {
        return true;
    }

    return false;
}

void ManageUser()
{
    START:
    manage.ToBank();
    Write("\t|^^v Welcome to Simple --|\n");
    Write("\t--Automated Teller Machine--\n" +
          "(1) Deposit -- (2) Withdraw -- (3) Log-out\n");
    int input = Convert.ToInt32(ReadLine());
    switch (input)
    {
        case 1:
            Write("[DEPOSIT] \n Enter amount of : $ ");
            string amount = ReadLine() ?? throw new Exception("can't be null");
            manageBank.DoDeposit(amount);
            goto START;
        case 2:
            Write(" [WITHDRAWING]\n Enter amount of : ");
            amount = ReadLine() ?? throw new Exception("Can't be null");
            manageBank.OnWithDraw(amount);
            goto START;
        case 3:
            WriteLine("System Concede...");
            Thread.Sleep(3000);
            Environment.Exit(0);
            break;
    }
    goto START;
}