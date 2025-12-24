# CardGameAPI

ASP.NET Core 8.0 Web API for a Card Game with a 52-card deck. This API provides RESTful endpoints to manage a deck of cards, including drawing cards, shuffling, restarting, showing the deck, and adding cards back.

## Features

- **52-Card Deck**: Standard deck with 4 suits (Hearts, Diamonds, Clubs, Spades) and 13 faces (Ace through King)
- **5 RESTful Endpoints**: Draw card, Shuffle, Restart, Show deck, Put card
- **Singleton Service**: CardGameService maintains game state across requests
- **Swagger/OpenAPI**: Interactive API documentation
- **ASP.NET Core 8.0**: Modern web API framework

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/PrabhneetSingh02/CardGameAPI.git
cd CardGameAPI
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Build the Project

```bash
dotnet build
```

### 4. Run the Application

```bash
dotnet run
```

The API will start and be available at:
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001
- **Swagger UI**: https://localhost:5001/swagger

## Project Structure

```
CardGameAPI/
├── Controllers/
│   └── CardGameController.cs    # API endpoints
├── Models/
│   └── Card.cs                   # Card, Suit, and Face definitions
├── Services/
│   └── CardGameService.cs        # Game logic and deck management
├── Program.cs                    # Application entry point with DI
├── appsettings.json              # Configuration settings
├── CardGameAPI.csproj            # Project file
└── README.md                     # This file
```

## API Endpoints

### Base URL
```
https://localhost:5001/api/CardGame
```

### 1. Draw Card
**GET** `/api/CardGame/drawcard`

Draws a card from the top of the deck.

**Response**:
```json
{
  "suit": "Hearts",
  "face": "Ace"
}
```

**Error Response** (when deck is empty):
```json
{
  "message": "No cards left in the deck"
}
```

### 2. Shuffle Deck
**POST** `/api/CardGame/shuffle`

Shuffles the current deck randomly.

**Response**:
```json
{
  "message": "Deck shuffled successfully"
}
```

### 3. Restart Game
**POST** `/api/CardGame/restart`

Resets the deck to its original state with all 52 cards.

**Response**:
```json
{
  "message": "Game restarted with a fresh deck"
}
```

### 4. Show Deck
**GET** `/api/CardGame/show`

Shows all cards currently in the deck.

**Response**:
```json
{
  "count": 52,
  "cards": [
    {
      "suit": "Hearts",
      "face": "Ace"
    },
    {
      "suit": "Hearts",
      "face": "Two"
    },
    ...
  ]
}
```

### 5. Put Card
**POST** `/api/CardGame/putcard?suit={suit}&face={face}`

Adds a specific card back into the deck.

**Parameters**:
- `suit`: Hearts | Diamonds | Clubs | Spades
- `face`: Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King

**Example**:
```
POST /api/CardGame/putcard?suit=Hearts&face=Ace
```

**Response**:
```json
{
  "message": "Ace of Hearts added to the deck"
}
```

**Error Response** (when card already exists):
```json
{
  "message": "Card already exists in the deck"
}
```

## Models

### Card
```csharp
public class Card
{
    public Suit Suit { get; set; }
    public Face Face { get; set; }
}
```

### Suit Enum
```csharp
public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}
```

### Face Enum
```csharp
public enum Face
{
    Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
}
```

## Example Usage

### Using cURL

```bash
# Draw a card
curl -X GET "https://localhost:5001/api/CardGame/drawcard" -k

# Shuffle the deck
curl -X POST "https://localhost:5001/api/CardGame/shuffle" -k

# Restart the game
curl -X POST "https://localhost:5001/api/CardGame/restart" -k

# Show all cards
curl -X GET "https://localhost:5001/api/CardGame/show" -k

# Put a card back
curl -X POST "https://localhost:5001/api/CardGame/putcard?suit=Hearts&face=Ace" -k
```

### Using PowerShell

```powershell
# Draw a card
Invoke-RestMethod -Uri "https://localhost:5001/api/CardGame/drawcard" -Method Get

# Shuffle the deck
Invoke-RestMethod -Uri "https://localhost:5001/api/CardGame/shuffle" -Method Post

# Restart the game
Invoke-RestMethod -Uri "https://localhost:5001/api/CardGame/restart" -Method Post

# Show all cards
Invoke-RestMethod -Uri "https://localhost:5001/api/CardGame/show" -Method Get

# Put a card back
Invoke-RestMethod -Uri "https://localhost:5001/api/CardGame/putcard?suit=Hearts&face=Ace" -Method Post
```

## Testing with Swagger

1. Navigate to `https://localhost:5001/swagger` after running the application
2. You'll see all available endpoints with interactive documentation
3. Click on any endpoint to expand it
4. Click "Try it out" to test the endpoint
5. Fill in any required parameters
6. Click "Execute" to send the request
7. View the response below

## Configuration

The application uses `appsettings.json` for configuration:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Development

### Building for Production

```bash
dotnet publish -c Release -o ./publish
```

### Running Tests (if added)

```bash
dotnet test
```

## Technologies Used

- **ASP.NET Core 8.0**: Web API framework
- **C# 12**: Programming language
- **Swagger/Swashbuckle**: API documentation
- **Dependency Injection**: Singleton service pattern

## Design Decisions

1. **Singleton Service**: `CardGameService` is registered as a singleton to maintain deck state across all requests
2. **Immutable Original Deck**: A copy of the original deck is kept to enable restart functionality
3. **REST Principles**: Clear, resource-based endpoints following REST conventions
4. **Error Handling**: Appropriate HTTP status codes (200, 400, 404) for different scenarios
5. **Query Parameters**: Used for `putcard` endpoint to allow easy specification of card attributes

## License

This project is created for educational purposes.

## Author

Prabhneet Singh

## Acknowledgments

Problem Statement 25 Assignment - ASP.NET Core Web API Card Game
