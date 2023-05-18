namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class PawnPiece : Piece
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Pawn;
    public PawnPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static PawnPiece CreateWhitePawn(PieceAddressDto pieceAddressDto) =>
        new(ColorEnum.White, pieceAddressDto);

    public static PawnPiece CreateBlackPawn(PieceAddressDto pieceAddressDto) =>
        new(ColorEnum.Black, pieceAddressDto);

    public static IList<PawnPiece> CreateAllPawns()
    {
        var paws = new List<PawnPiece>();

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
        if (!PawnCaptureMoveVo.IsValid(this, pieceAddressDto))
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