using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities.Base;

public abstract class PieceEntity : Entity
{
    public PieceTypeEnum PieceTypeEnum { get; private set; }
    public ColorEnum ColorEnum { get; private set; }
    public Guid BoardId { get; private set; }
    public PieceAddressDto PieceAddressDto { get; private set; }
    public PieceAddressDto LastPieceAddress { get; private set; }
    public bool HasMoved { get; private set; }
    public bool WasCaptured { get; private set; }
    public virtual BoardEntity BoardEntity { get; private set; }


    public PieceEntity(
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
    public virtual void AddPieceOnTheBoard(Guid boardId, BoardEntity boardEntity)
    {
        BoardId = boardId;
        BoardEntity = boardEntity;
    }
}