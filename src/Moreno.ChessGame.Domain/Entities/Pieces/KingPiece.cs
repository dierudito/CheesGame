namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class KingPiece : Piece
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.King;
    public bool IsKingInCheck { get; private set; }
    public bool HasTheKingBeenCheck { get; private set; }
    public KingPiece(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public void PutTheKingInCheck()
    {
        IsKingInCheck = true;
        HasTheKingBeenCheck = true;
    }

    public void RemoveTheCheckKing()
    {
        IsKingInCheck = false;
    }

    public static KingPiece CreateWhiteKing() =>
        new(ColorEnum.White, new(BoardColumnEnum.E, BoardRowEnum.One));

    public static KingPiece CreateBlackKing() =>
        new(ColorEnum.Black, new(BoardColumnEnum.D, BoardRowEnum.Eight));

    public static IList<KingPiece> CreateAllKings() => new List<KingPiece>
    {
        CreateWhiteKing(),
        CreateBlackKing()
    };

    public override void MoveTo(PieceAddressDto pieceAddressDto)
    {
        if (!KingMoveVo.IsValid(this, pieceAddressDto))
        {
            AddErrorValidation("Incorrect Movement", "The King moved wrong");
            return;
        }
        base.MoveTo(pieceAddressDto);
    }
}