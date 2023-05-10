using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Entities;

public class BoardEntity : Entity
{
    public ICollection<BoardSquare> Squares { get; private set; }

    public BoardEntity()
    {
        Squares = new List<BoardSquare>();
    }

    public void AddSquare (BoardSquare square)
    {
        Squares.Add(square);
    }
}
