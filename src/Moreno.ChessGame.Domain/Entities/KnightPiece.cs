using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class KnightPiece : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Knight;
    public KnightPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static KnightPiece CreateWhiteKnightOfQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.B, BoardRowEnum.One));

    public static KnightPiece CreateWhiteKnightOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.G, BoardRowEnum.One));

    public static KnightPiece CreateBlackKnightOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.G, BoardRowEnum.Eight));

    public static KnightPiece CreateBlackKnightOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.B, BoardRowEnum.Eight));

    public static IList<KnightPiece> CreateAllKnights() => new List<KnightPiece>
    {
        CreateWhiteKnightOfQueen(),
        CreateWhiteKnightOfKing(),
        CreateBlackKnightOfQueen(),
        CreateBlackKnightOfKing()
    };
}