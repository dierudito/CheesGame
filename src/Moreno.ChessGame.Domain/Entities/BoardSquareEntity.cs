using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class BoardSquareEntity : Entity
{
    public Guid BoardId { get; private set; }
    public ColorEnum Color { get; private set; }
    public BoardColumnEnum Column { get; private set; }
    public BoardRowEnum Row { get; private set; }
}
