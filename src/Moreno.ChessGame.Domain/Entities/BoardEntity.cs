using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Entities;

public class BoardEntity : Entity
{
    public ICollection<BoardSquareEntity> Squares { get; private set; }

    public BoardEntity()
    {
        Squares = new List<BoardSquareEntity>();
    }

    public void AddSquare (BoardSquareEntity squareEntity)
    {
        Squares.Add(squareEntity);
    }
}
