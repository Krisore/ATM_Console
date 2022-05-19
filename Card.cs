namespace ATM_Software
{
    internal class Card : BankAccount
    {
        protected string? CardType { get; set; }
        protected string? CardNumber { get; set; }
        protected long Pin { get; set; }
        public void ToBank()
        {
            string _cardType = CardType;
            string _cardNumber = CardNumber;
            long _pin = Pin;
            BankOwner(_cardNumber, _cardType.Trim(), _pin);

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
                    CardNumber = cardNumber;
                    CardType = "MASTERCARD";
                    return true;
                }
                else if ((number / 10 == 3) && (number % 10 == 4 || number % 10 == 7))
                {
                    CardNumber = cardNumber;
                    CardType = "AMERICAN CARD";
                    return true;
                }
                else if (number / 10 == 4)
                {
                    CardNumber = cardNumber;
                    CardType = "VISA";
                    return true;
                }
            }
            return false;

        }
        public bool IsValid(string cardNumber)
        {
            var trim = cardNumber.Trim();
            if (13 < trim.Length || 16 > trim.Length)
            {
                if (DoCheckSum(trim) != 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public long DoCheckSum(string cardNumber)
        {
            string trim = cardNumber.Trim();
            long sum = 0;
            long digit;
            long number = long.Parse(trim);
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
            this.Pin = long.Parse(pin);
            return true;
        }

    }
}

