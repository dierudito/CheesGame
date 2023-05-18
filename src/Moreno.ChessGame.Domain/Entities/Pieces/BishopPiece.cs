namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class BishopPiece : Piece
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Bishop;
    public BishopPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
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

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!BishopMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Bishop moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}