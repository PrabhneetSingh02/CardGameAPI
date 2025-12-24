namespace CardGameAPI.Models
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Face
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
        }

        public override string ToString()
        {
            return $"{Face} of {Suit}";
        }
    }
}
