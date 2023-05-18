namespace Moreno.ChessGame.Domain.Entities;

public class Board : Entity
{
    public ICollection<BoardSquare> Squares { get; private set; }
    public ICollection<Piece> Pieces { get; private set; }

    public Board()
    {
        Squares = new List<BoardSquare>();
        Pieces = new List<Piece>();
    }

    public void AddSquare(BoardSquare squareEntity)
    {
        Squares.Add(squareEntity);
    }

    public void AddPiece(Piece pieceEntity)
    {
        Pieces.Add(pieceEntity);
    }
}
