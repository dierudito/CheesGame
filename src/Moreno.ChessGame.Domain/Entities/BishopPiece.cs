using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class BishopPiece : PieceEntity
{
    private const PieceTypeEnum PieceTypeEnum = PieceTypeEnum.Bishop;
    public BishopPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) : base(PieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static BishopPiece CreateWhiteBishopOfQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.C, BoardRowEnum.One));

    public static BishopPiece CreateWhiteBishopOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.F, BoardRowEnum.One));

    public static BishopPiece CreateBlackBishopOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.F, BoardRowEnum.Eight));

    public static BishopPiece CreateBlackBishopOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.C, BoardRowEnum.Eight));

    public static IList<BishopPiece> CreateAllBishops() => new List<BishopPiece>
    {
        BishopPiece.CreateWhiteBishopOfQueen(),
        BishopPiece.CreateWhiteBishopOfKing(),
        BishopPiece.CreateBlackBishopOfQueen(),
        BishopPiece.CreateBlackBishopOfKing()
    };
}