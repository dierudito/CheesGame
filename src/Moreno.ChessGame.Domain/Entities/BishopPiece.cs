using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class BishopPiece : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Bishop;
    public BishopPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) : base(_pieceTypeEnum, colorEnum, pieceAddressDto)
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
        CreateWhiteBishopOfQueen(),
        CreateWhiteBishopOfKing(),
        CreateBlackBishopOfQueen(),
        CreateBlackBishopOfKing()
    };
}