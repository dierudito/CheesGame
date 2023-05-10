using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class KingPiece : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.King;
    public KingPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static KingPiece CreateWhiteKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.E, BoardRowEnum.One));

    public static KingPiece CreateBlackKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.D, BoardRowEnum.Eight));

    public static IList<KingPiece> CreateAllQueens() => new List<KingPiece>
    {
        CreateWhiteKing(),
        CreateBlackKing()
    };
}