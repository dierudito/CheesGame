using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class BishopPieceEntity : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Bishop;
    public BishopPieceEntity(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static BishopPieceEntity CreateWhiteBishopOfQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.C, BoardRowEnum.One));

    public static BishopPieceEntity CreateWhiteBishopOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.F, BoardRowEnum.One));

    public static BishopPieceEntity CreateBlackBishopOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.F, BoardRowEnum.Eight));

    public static BishopPieceEntity CreateBlackBishopOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.C, BoardRowEnum.Eight));

    public static IList<BishopPieceEntity> CreateAllBishops() => new List<BishopPieceEntity>
    {
        CreateWhiteBishopOfQueen(),
        CreateWhiteBishopOfKing(),
        CreateBlackBishopOfQueen(),
        CreateBlackBishopOfKing()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!BishopMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Bishop moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}