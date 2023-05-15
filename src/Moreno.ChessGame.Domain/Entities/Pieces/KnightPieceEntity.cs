using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class KnightPieceEntity : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Knight;
    public KnightPieceEntity(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static KnightPieceEntity CreateWhiteKnightOfQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.B, BoardRowEnum.One));

    public static KnightPieceEntity CreateWhiteKnightOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.G, BoardRowEnum.One));

    public static KnightPieceEntity CreateBlackKnightOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.G, BoardRowEnum.Eight));

    public static KnightPieceEntity CreateBlackKnightOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.B, BoardRowEnum.Eight));

    public static IList<KnightPieceEntity> CreateAllKnights() => new List<KnightPieceEntity>
    {
        CreateWhiteKnightOfQueen(),
        CreateWhiteKnightOfKing(),
        CreateBlackKnightOfQueen(),
        CreateBlackKnightOfKing()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!KnightMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Knight moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}