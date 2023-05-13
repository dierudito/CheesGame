using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Entities;

public class BoardEntity : Entity
{
    public ICollection<BoardSquareEntity> Squares { get; private set; }
    public ICollection<PieceEntity> Pieces { get; private set; }

    public BoardEntity()
    {
        Squares = new List<BoardSquareEntity>();
        Pieces = new List<PieceEntity>();
    }

    public void AddSquare (BoardSquareEntity squareEntity)
    {
        Squares.Add(squareEntity);
    }

    public void AddPiece(PieceEntity pieceEntity)
    {
        Pieces.Add(pieceEntity);
    }
}
