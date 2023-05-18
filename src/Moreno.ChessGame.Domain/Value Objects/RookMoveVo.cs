using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class RookMoveVo
{
    public static bool IsValid(Piece pieceEntity, PieceAddressDto targetAddress)
    {
        var waysPiece =
            WaysPiece.GetWays(pieceEntity.PieceAddressDto, pieceEntity.BoardEntity.Squares.ToList());

        if (!waysPiece.Any(wp => wp.Row == targetAddress.Row && wp.Column == targetAddress.Column))
            return false;

        var possibleColumnWays =
            waysPiece
            .Where(pdw => pdw.Row != pieceEntity.PieceAddressDto.Row &&
                          pdw.Column == pieceEntity.PieceAddressDto.Column)
            .ToList();

        var possibleRowWays =
            waysPiece
            .Where(pdw => pdw.Row == pieceEntity.PieceAddressDto.Row &&
                          pdw.Column != pieceEntity.PieceAddressDto.Column)
            .ToList();

        return possibleColumnWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column == targetAddress.Column) ||
               possibleRowWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column == targetAddress.Column);
    }
}

file static class WaysPiece
{
    public static IList<PieceAddressDto> GetWays(
        PieceAddressDto pieceAddressDto, IList<BoardSquare> boardSquares) =>
        WaysPositions.GetLineWay(pieceAddressDto, boardSquares);

}