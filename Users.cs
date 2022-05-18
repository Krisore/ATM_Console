namespace ATM_Software
{
    internal class Users
    {
        private string _Card { get; } = String.Empty;
        private long _Pin { get; }

        public Users(string card, long pin)
        {
            this._Card = card;
            this._Pin = pin;
        }

    }
}
