namespace ATM_Software
{
    internal class Card : BankAccount
    {
        protected string _CardType { get; set; }
        protected string _CardNumber { get; set; }
        protected long _Pin { get; set; }
        public void ToBank()
        {

            BankOwner(_CardType, _CardNumber.Trim(), _Pin);

        }
    }
    internal class ManageCard : Card
    {
        public bool CheckCard(string cardNumber)
        {
            if (IsValid(cardNumber))
            {
                long number = long.Parse(cardNumber.Trim());
                do
                {
                    number /= 10;
                } while (number > 100);

                if ((number / 10 == 5) && (0 < number % 10 && number % 10 < 6))
                {
                    _CardNumber = cardNumber;
                    _CardType = "MASTERCARD";
                    return true;
                }
                else if ((number / 10 == 3) && (number % 10 == 4 || number % 10 == 7))
                {
                    _CardNumber = cardNumber;
                    _CardType = "AMERICAN CARD";
                    return true;
                }
                else if (number / 10 == 4)
                {
                    _CardNumber = cardNumber;
                    _CardType = "VISA";
                    return true;
                }
            }
            return false;

        }
        public bool IsValid(string cardNumber)
        {
            cardNumber.Trim();
            if (13 < cardNumber.Length || 16 > cardNumber.Length)
            {
                if (DoCheckSum(cardNumber) != 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public long DoCheckSum(string cardNumber)
        {
            string card = cardNumber.Trim();
            long sum = 0;
            long digit;
            long number = long.Parse(card);
            for (int i = 0; number != 0; number /= 10)
            {
                if (i % 2 == 0)
                {
                    sum += number % 10;
                }
                else
                {
                    digit = 2 * ((int)number % 10);
                    sum += digit / 10 + digit % 10;
                }
            }
            return sum % 10;
        }
        public bool DoCheckPin(string pin)
        {
            if (pin.Length != 4)
            {
                return false;
            }
            _Pin = long.Parse(pin);
            return true;
        }

    }
}

