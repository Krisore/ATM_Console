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
                      "***Operation Loading ***");

    ManageCard card = new ManageCard();
    Users user;
    Console.Write("Enter Card Number: ");
    string? userCardNumber = Console.ReadLine();
    if (userCardNumber.Equals(null))
    {
        Console.WriteLine("#(INVALID) key have been press\n" +
                          "***Operation Exterminated****");
        Environment.Exit(0);
    }

    bool validation = card.CheckCard(userCardNumber);
    if (!validation)
    {
        Console.WriteLine("You're a fraund!");
        Environment.Exit(0);
    }

    Console.WriteLine("Proceedings.. to your Pin number");
    Console.Write("Enter your Pin: ");
    string? pin = Console.ReadLine();
    user = new Users(userCardNumber, Convert.ToInt64(pin));
    Console.WriteLine("User Card number Successfull Inserted!");



}
else
{
    Console.WriteLine("#(INVALID) key have been press\n" +
                      "***Operation Exterminated****");
}
