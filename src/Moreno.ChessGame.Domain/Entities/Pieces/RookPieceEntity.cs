using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class RookPieceEntity : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Rook;
    public RookPieceEntity(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static RookPieceEntity CreateWhiteRookOfQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.A, BoardRowEnum.One));

    public static RookPieceEntity CreateWhiteRookOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.H, BoardRowEnum.One));

    public static RookPieceEntity CreateBlackRookOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.H, BoardRowEnum.Eight));

    public static RookPieceEntity CreateBlackRookOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.A, BoardRowEnum.Eight));

    public static IList<RookPieceEntity> CreateAllRooks() => new List<RookPieceEntity>
    {
        CreateWhiteRookOfQueen(),
        CreateWhiteRookOfKing(),
        CreateBlackRookOfQueen(),
        CreateBlackRookOfKing()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!RookMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Rook moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}