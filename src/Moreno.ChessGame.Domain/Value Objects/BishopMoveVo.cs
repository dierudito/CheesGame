using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Value_Objects;

public class BishopMoveVo
{
    public static bool IsValid(PieceEntity pieceEntity, PieceAddressDto targetAddress)
    {
        var (eastWay, westWay) =
            WaysPiece.GetWays(pieceEntity.PieceAddressDto, pieceEntity.BoardEntity.Squares.ToList());

        return eastWay.Any(ew => ew.Column == targetAddress.Column && ew.Row == targetAddress.Row) ||
               westWay.Any(ew => ew.Column == targetAddress.Column && ew.Row == targetAddress.Row);
    }
}


file static class WaysPiece
{
    public static (IList<PieceAddressDto> east, IList<PieceAddressDto> west) GetWays(
        PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares) =>
        (WaysPositions.GetEastDiagonal(pieceAddressDto, boardSquares),
         WaysPositions.GetWestDiagonal(pieceAddressDto, boardSquares));
}