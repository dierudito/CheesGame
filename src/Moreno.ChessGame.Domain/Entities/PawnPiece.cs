using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Entities;

public class PawnPiece : PieceEntity
{
    private const PieceTypeEnum PieceTypeEnum = PieceTypeEnum.Pawn;
    public PawnPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(PieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static PawnPiece CreateWhitePawn(PieceAddressDto pieceAddressDto) =>
        new(ColorEnum.White, pieceAddressDto);

    public static PawnPiece CreateBlackPawn(PieceAddressDto pieceAddressDto) =>
        new(ColorEnum.Black, pieceAddressDto);

    public static IList<PawnPiece> CreateAllPawns()
    {
        var paws = new List<PawnPiece>();

        for (byte i = BoardColumnEnum.A; i <= BoardColumnEnum.H; i++)
        {
            var addressWhitePawn = new PieceAddressDto((BoardColumnEnum)i, BoardRowEnum.Two);
            var addressBlackPawn = new PieceAddressDto((BoardColumnEnum)i, BoardRowEnum.Seven);

            paws.Add(new PawnPiece(ColorEnum.White, addressWhitePawn));
            paws.Add(new PawnPiece(ColorEnum.Black, addressBlackPawn));
        }
    }
}