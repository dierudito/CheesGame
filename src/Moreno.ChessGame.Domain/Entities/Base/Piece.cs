namespace Moreno.ChessGame.Domain.Entities.Base;

public abstract class Piece : Entity
{
    public PieceTypeEnum PieceTypeEnum { get; private set; }
    public ColorEnum ColorEnum { get; private set; }
    public Guid BoardId { get; private set; }
    public PieceAddressDto PieceAddressDto { get; private set; }
    public PieceAddressDto? LastPieceAddress { get; private set; }
    public bool HasMoved { get; private set; }
    public bool WasCaptured { get; private set; }
    public virtual Board BoardEntity { get; private set; }


    public Piece(
        PieceTypeEnum pieceTypeEnum, ColorEnum colorEnum, PieceAddressDto pieceAddressDto)
    {
        PieceTypeEnum = pieceTypeEnum;
        ColorEnum = colorEnum;
        PieceAddressDto = pieceAddressDto;
    }

    public virtual void MoveTo(PieceAddressDto pieceAddressDto)
    {
        LastPieceAddress = PieceAddressDto;
        PieceAddressDto = pieceAddressDto;
        HasMoved = true;
    }

    public virtual void SetAsCaptured()
    {
        WasCaptured = true;
    }
    public virtual void AddPieceOnTheBoard(Guid boardId, Board boardEntity)
    {
        BoardId = boardId;
        BoardEntity = boardEntity;
    }
}