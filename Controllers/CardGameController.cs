using CardGameAPI.Models;
using CardGameAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardGameController : ControllerBase
    {
        private readonly CardGameService _cardGameService;

        public CardGameController(CardGameService cardGameService)
        {
            _cardGameService = cardGameService;
        }

        /// <summary>
        /// Draw a card from the top of the deck
        /// </summary>
        /// <returns>The drawn card or null if deck is empty</returns>
        [HttpGet("drawcard")]
        public ActionResult<Card> DrawCard()
        {
            var card = _cardGameService.DrawCard();
            if (card == null)
            {
                return NotFound(new { message = "No cards left in the deck" });
            }
            return Ok(card);
        }

        /// <summary>
        /// Shuffle the current deck
        /// </summary>
        /// <returns>Success message</returns>
        [HttpPost("shuffle")]
        public ActionResult Shuffle()
        {
            _cardGameService.Shuffle();
            return Ok(new { message = "Deck shuffled successfully" });
        }

        /// <summary>
        /// Restart the game with a fresh deck
        /// </summary>
        /// <returns>Success message</returns>
        [HttpPost("restart")]
        public ActionResult Restart()
        {
            _cardGameService.Restart();
            return Ok(new { message = "Game restarted with a fresh deck" });
        }

        /// <summary>
        /// Show all cards currently in the deck
        /// </summary>
        /// <returns>List of all cards in the deck</returns>
        [HttpGet("show")]
        public ActionResult<List<Card>> ShowDeck()
        {
            var deck = _cardGameService.ShowDeck();
            return Ok(new { count = deck.Count, cards = deck });
        }

        /// <summary>
        /// Put a specific card back into the deck
        /// </summary>
        /// <param name="suit">The suit of the card</param>
        /// <param name="face">The face of the card</param>
        /// <returns>Success or error message</returns>
        [HttpPost("putcard")]
        public ActionResult PutCard([FromQuery] Suit suit, [FromQuery] Face face)
        {
            var result = _cardGameService.PutCard(suit, face);
            if (!result)
            {
                return BadRequest(new { message = "Card already exists in the deck" });
            }
            return Ok(new { message = $"{face} of {suit} added to the deck" });
        }
    }
}
