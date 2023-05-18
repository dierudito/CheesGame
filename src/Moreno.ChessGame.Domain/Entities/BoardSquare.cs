namespace Moreno.ChessGame.Domain.Entities;

public class BoardSquare : Entity
{
    public Guid BoardId { get; private set; }
    public ColorEnum Color { get; private set; }
    public BoardColumnEnum Column { get; private set; }
    public BoardRowEnum Row { get; private set; }

    public BoardSquare(Guid boardId, ColorEnum color, BoardColumnEnum column, BoardRowEnum row)
    {
        BoardId = boardId;
        Color = color;
        Column = column;
        Row = row;
    }
}
