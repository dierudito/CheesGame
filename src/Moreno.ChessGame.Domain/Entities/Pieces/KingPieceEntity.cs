using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class KingPieceEntity : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.King;
    public bool IsKingInCheck { get; private set; }
    public KingPieceEntity(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public void SetIsKingInCheck(bool isKingInCheck)
    {
        IsKingInCheck = isKingInCheck;
    }

    public static KingPieceEntity CreateWhiteKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.E, BoardRowEnum.One));

    public static KingPieceEntity CreateBlackKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.D, BoardRowEnum.Eight));

    public static IList<KingPieceEntity> CreateAllQueens() => new List<KingPieceEntity>
    {
        CreateWhiteKing(),
        CreateBlackKing()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!KingMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The King moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}