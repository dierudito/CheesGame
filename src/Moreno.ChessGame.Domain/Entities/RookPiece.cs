using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class RookPiece : PieceEntity
{
    private const PieceTypeEnum PieceTypeEnum = PieceTypeEnum.Rook;
    public RookPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(PieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static RookPiece CreateWhiteRookOfQueen() =>
        new( ColorEnum.White, new(BoardColumnEnum.A, BoardRowEnum.One));

    public static RookPiece CreateWhiteRookOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.H, BoardRowEnum.One));

    public static RookPiece CreateBlackRookOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.H, BoardRowEnum.Eight));

    public static RookPiece CreateBlackRookOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.A, BoardRowEnum.Eight));

    public static IList<RookPiece> CreateAllRooks() => new List<RookPiece>
    {
        RookPiece.CreateWhiteRookOfQueen(),
        RookPiece.CreateWhiteRookOfKing(),
        RookPiece.CreateBlackRookOfQueen(),
        RookPiece.CreateBlackRookOfKing()
    };
}