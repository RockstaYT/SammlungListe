namespace SammlungsListe.OwnProperties
{
    public class SingleCard
    {
        private string _enCardName;
        private string _cardId;
        private string _priceLow;
        private string _priceMid;
        private string _cardCount;

        private string EnCardName
        {
            get
            {
                return _enCardName;
            }
            set
            {
                _enCardName = value;
            }
        }
        private string CardId
        {
            get
            {
                return _cardId;
            }
            set
            {
                _cardId = value;
            }
        }
        private string PriceLow
        {
            get
            {
                return _priceLow;
            }
            set
            {
                _priceLow = value;
            }
        }
        private string PriceMid
        {
            get
            {
                return _priceMid;
            }
            set
            {
                _priceMid = value;
            }
        }
        private string CardCount
        {
            get
            {
                return _cardCount;
            }
            set
            {
                _cardCount = value;
            }
        }

        public SingleCard(string enCardName, string cardId, string priceLow, string priceMid, string cardCount)
        {
            EnCardName = enCardName;
            CardId = cardId;
            PriceLow = priceLow;
            PriceMid = priceMid;
            CardCount = cardCount;
        }
    }
}
