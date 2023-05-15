using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Entities.Pieces;

public class QueenPieceEntity : PieceEntity
{
    private const PieceTypeEnum _pieceTypeEnum = PieceTypeEnum.Queen;
    public QueenPieceEntity(ColorEnum colorEnum, PieceAddressDto pieceAddressDto) :
        base(_pieceTypeEnum, colorEnum, pieceAddressDto)
    {
    }

    public static QueenPieceEntity CreateWhiteQueen() =>
        new(ColorEnum.White, new(BoardColumnEnum.D, BoardRowEnum.One));

    public static QueenPieceEntity CreateBlackQueen() =>
        new(ColorEnum.Black, new(BoardColumnEnum.E, BoardRowEnum.Eight));

    public static IList<QueenPieceEntity> CreateAllQueens() => new List<QueenPieceEntity>
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