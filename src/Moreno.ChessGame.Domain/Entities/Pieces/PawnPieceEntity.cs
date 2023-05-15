using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class PawnPieceEntity : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Pawn;
    public PawnPieceEntity(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static PawnPieceEntity CreateWhitePawn(PieceAddressDto pieceAddressDto) =>
        new(ColorEnum.White, pieceAddressDto);

    public static PawnPieceEntity CreateBlackPawn(PieceAddressDto pieceAddressDto) =>
        new(ColorEnum.Black, pieceAddressDto);

    public static IList<PawnPieceEntity> CreateAllPawns()
    {
        var paws = new List<PawnPieceEntity>();

        for (var i = BoardColumnEnum.A; i <= BoardColumnEnum.H; i++)
        {
            var addressWhitePawn = new PieceAddressDto(i, BoardRowEnum.Two);
            var addressBlackPawn = new PieceAddressDto(i, BoardRowEnum.Seven);

            paws.Add(new(ColorEnum.White, addressWhitePawn));
            paws.Add(new(ColorEnum.Black, addressBlackPawn));
        }

        return paws;
    }

    public void MovingToCapture(PieceAddressDto pieceAddressDto)
    {
        if(!PawnCaptureMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Pawn moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!PawnMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Pawn moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}