namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class QueenPiece : Piece
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Queen;
    public QueenPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static QueenPiece CreateWhiteQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.D, BoardRowEnum.One));

    public static QueenPiece CreateBlackQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.E, BoardRowEnum.Eight));

    public static IList<QueenPiece> CreateAllQueens() => new List<QueenPiece>
    {
        CreateWhiteQueen(),
        CreateBlackQueen()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!QueenMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Queen moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}