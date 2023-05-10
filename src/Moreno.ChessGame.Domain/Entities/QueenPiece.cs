using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class QueenPiece : PieceEntity
{
    private const PieceTypeEnum PieceTypeEnum = PieceTypeEnum.Queen;
    public QueenPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(PieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static QueenPiece CreateWhiteQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.D, BoardRowEnum.One));

    public static QueenPiece CreateBlackQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.E, BoardRowEnum.Eight));

    public static IList<QueenPiece> CreateAllQueens() => new List<QueenPiece>
    {
        QueenPiece.CreateWhiteQueen(),
        QueenPiece.CreateBlackQueen()
    };
}