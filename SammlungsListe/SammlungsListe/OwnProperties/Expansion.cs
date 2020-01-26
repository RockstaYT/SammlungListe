namespace SammlungsListe.OwnProperties
{
    using System.Collections.Generic;
    public class Expansion
    {
        private List<SingleCard> _singleCards;
        private List<string> _languages;
        private string _expansionName;

        public List<SingleCard> SingleCards
        {
            get
            {
                return _singleCards;
            }
            set
            {
                _singleCards = value;
            }
        }

        public List<string> Languages
        {
            get
            {
                return _languages;
            }
            set
            {
                _languages = value;
            }
        }

        public string ExpansionName
        {
            get
            {
                return _expansionName;
            }
            set
            {
                _expansionName = value;
            }
        }

        public Expansion(string expansionName, List<SingleCard> singleCards, List<string> languages)
        {
            ExpansionName = expansionName;
            SingleCards = singleCards;
            Languages = languages;
        }

        public void AddCard(SingleCard singleCard)
        {
            SingleCards.Add(singleCard);
        }
    }
}
