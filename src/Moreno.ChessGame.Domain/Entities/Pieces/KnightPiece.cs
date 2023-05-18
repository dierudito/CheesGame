namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class KnightPiece : Piece
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

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!KnightMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The Knight moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}