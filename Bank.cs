using System;
using ATM_Software;

namespace ATM_Software
{
    internal class BankAccount
    {

        protected string? _Deposit { get; set; }
        protected string? _Withdraw { get; set; }
        private string? _CardNumber { get; set; }
        private string? _CardType { get; set; }
        public long _Pin { get; set; }

        public BankAccount(string? cardType, string? cardNumber, long Pin)
        {
            this._CardNumber = cardNumber!;
            this._CardType = cardType!;
            this._Pin = Pin!;
        }

        public BankAccount()
        {

        }


        protected List<BankAccount> Owners = new List<BankAccount>();

        public void BankOwner(string cardNumber, string cardtype, long pin)
        {
            _CardNumber = cardNumber.Trim();
            _CardType = cardtype;
            _Pin = pin;
            Owners.Add(new BankAccount(_CardType, _CardNumber, _Pin));
            Console.WriteLine($" Card Number: [{_CardNumber}]\n Card Account: [{_CardType}]\n Card Pin: [{_Pin}]\n");
        }
    }

}

class ManageBank : BankAccount
{
    public bool DoDeposit(string amount)
    {
        Console.WriteLine();
        if (Convert.ToDecimal(amount) > 10000)
        {
            return false;
        }
        decimal deposit = Convert.ToDecimal(amount) + Convert.ToDecimal(_Deposit);
        _Deposit = deposit.ToString();
        Console.WriteLine($"$[UPDATE:]---{DateTime.Now}");
        Console.WriteLine($"Balance: ${_Deposit}");
        return true;
    }

    public bool OnWithDraw(string amount)
    {
        if (Convert.ToDecimal(amount) > Convert.ToDecimal(_Deposit))
        {
            return false;
        }
        decimal withdraw = Convert.ToDecimal(_Deposit) - Convert.ToDecimal(amount);
        _Deposit = withdraw.ToString();
        Console.WriteLine($"$[UPDATE:]---{DateTime.Now}");
        Console.WriteLine($"Balance: ${_Deposit}");
        return withdraw <= 1000;

    }
}
