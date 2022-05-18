using ATM_Software;

Console.WriteLine("\tSimple ATM Software\n" +
                  "(#1) key to inter your card-number\n" +
                  "(any) key to Exterminate the Operation");
Console.Write("Enter Input: ");

string? input = Console.ReadLine();

Console.WriteLine(input);
if (input == "1")
{
    Console.WriteLine("#(1) key have been press \n" +
                      "*** Operation Loading ***\n");

    ManageCard card = new ManageCard();
    ManageBank manageBank = new ManageBank();
    Users user;
    Console.Write("*** Insert your Credit / Debit Card ***\n" +
                  "\n Enter Card Number: ");
    string userCardNumber = Console.ReadLine() ?? throw new Exception("Card Number Cannot be null!");
    if (userCardNumber.Equals(null))
    {
        Console.WriteLine("#(INVALID) key have been press\n" +
                          "*** Operation Exterminated ***");
        Environment.Exit(0);
    }

    bool validation = card.CheckCard(userCardNumber);
    if (validation == false)
    {
        Console.WriteLine(" You're a fraud! ");

        Environment.Exit(0);
    }

    Console.WriteLine(" Proceedings.. to your Pin number ");
    Console.Write("Enter your Pin: ");
    string? pin = Console.ReadLine() ?? throw new Exception("Pin number Cannot be null!");
    if (card.DoCheckPin(pin ?? "123") == false)
    {
        Console.WriteLine("Card Pin need to be [4 digits]");
        Environment.Exit(0);
    }
    user = new Users(userCardNumber, long.Parse(pin));
    Console.WriteLine("***User Card number Successful Inserted!***\n" +
                      " __________________________________");


START:
    card.ToBank();
    Console.WriteLine("|\t***Welcome to your Account!***|\n" +
                      "[1] Deposit \t [2] Withdraw \t [3] Check Balance " +
                      "\n\t\t [3] logout");
    int userInput = Convert.ToInt32(Console.ReadLine());
    if (userInput.Equals(1))
    {
        Console.Write("Enter the Amount: $");
        string? amount = Console.ReadLine() ?? throw new Exception("can't be null");
        bool success = manageBank.DoDeposit(amount);
        if (!success)
        {
            Console.WriteLine("The deposit must be less than $10,000");
        }
        else
        {
            Console.WriteLine("Deposit Success!");
        }
        goto START;
    }
    else if (userInput.Equals(2))
    {
        Console.Write("Enter the Amount: $");
        string? amount = Console.ReadLine() ?? throw new Exception("can't be null");
        bool success = manageBank.OnWithDraw(amount);
        if (!success)
        {
            Console.WriteLine("The withdraw must be less than $1,000");
            goto START;
        }
        else
        {
            Console.WriteLine("Withdraw Success!");

        }
        goto START;
    }



}
else
{
    Console.WriteLine("#(INVALID) key have been press\n" +
                      "***Operation Exterminated****");
}
