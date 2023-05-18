namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class RookPiece : Piece
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Rook;
    public RookPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static RookPiece CreateWhiteRookOfQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.A, BoardRowEnum.One));

    public static RookPiece CreateWhiteRookOfKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.H, BoardRowEnum.One));

    public static RookPiece CreateBlackRookOfQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.H, BoardRowEnum.Eight));

    public static RookPiece CreateBlackRookOfKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.A, BoardRowEnum.Eight));

    public static IList<RookPiece> CreateAllRooks() => new List<RookPiece>
    {
        CreateWhiteRookOfQueen(),
        CreateWhiteRookOfKing(),
        CreateBlackRookOfQueen(),
        CreateBlackRookOfKing()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!RookMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Rook moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}