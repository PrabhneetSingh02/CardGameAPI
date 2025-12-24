using CardGameAPI.Models;
using System.Runtime.InteropServices;

namespace CardGameAPI.Services
{
    public class CardGameService
    {
        private List<Card> _deck = new List<Card>();
        private List<Card> _originalDeck = new List<Card>();

        public CardGameService()
        {
            InitializeDeck();
            _originalDeck = new List<Card>(_deck);
        }

        private void InitializeDeck()
        {
            _deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    _deck.Add(new Card(suit, face));
                }
            }
        }

        public Card? DrawCard()
        {
            if (_deck.Count == 0)
            {
                return null;
            }

            var card = _deck[0];
            _deck.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(_deck));
        }

        public void Restart()
        {
            _deck = new List<Card>(_originalDeck);
        }

        public List<Card> ShowDeck()
        {
            return new List<Card>(_deck);
        }

        public bool PutCard(Suit suit, Face face)
        {
            var card = new Card(suit, face);
            
            // Check if card already exists in the deck
            if (_deck.Any(c => c.Suit == suit && c.Face == face))
            {
                return false;
            }

            _deck.Add(card);
            return true;
        }
    }
}
