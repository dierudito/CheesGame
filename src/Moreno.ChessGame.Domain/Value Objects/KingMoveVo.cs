using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class KingMoveVo
{
    public static bool IsValid(PieceEntity pieceEntity, PieceAddressDto targetAddress)
    {
        var (eastDiagonalWay, westDiagonalWay, lineWay) =
            WaysPiece.GetWays(pieceEntity.PieceAddressDto, pieceEntity.BoardEntity.Squares.ToList());

        var possibleEastDiagonalWays =
            eastDiagonalWay
            .Where(eastWay => (eastWay.Column == pieceEntity.PieceAddressDto.Column + 1 &&
                            eastWay.Row == pieceEntity.PieceAddressDto.Row + 1) ||
                           (eastWay.Column == pieceEntity.PieceAddressDto.Column - 1 &&
                            eastWay.Row == pieceEntity.PieceAddressDto.Row - 1));

        var possibleWestDiagonalWays =
            westDiagonalWay
            .Where(westWay => (westWay.Column == pieceEntity.PieceAddressDto.Column - 1 &&
                            westWay.Row == pieceEntity.PieceAddressDto.Row + 1) ||
                           (westWay.Column == pieceEntity.PieceAddressDto.Column + 1 &&
                            westWay.Row == pieceEntity.PieceAddressDto.Row - 1));

        var possibleColumnLineWays =
            lineWay
            .Where(pdw => pdw.Column == pieceEntity.PieceAddressDto.Column &&
                          (pdw.Row == pieceEntity.PieceAddressDto.Row + 1 ||
                           pdw.Row == pieceEntity.PieceAddressDto.Row - 1));

        var possibleRowLineWays =
            lineWay
            .Where(pdw => pdw.Row == pieceEntity.PieceAddressDto.Row &&
                          (pdw.Column == pieceEntity.PieceAddressDto.Column - 1 ||
                           pdw.Column == pieceEntity.PieceAddressDto.Column + 1 ||
                           (!pieceEntity.HasMoved && (pdw.Column == pieceEntity.PieceAddressDto.Column - 2 ||
                                                      pdw.Column == pieceEntity.PieceAddressDto.Column + 2))));

        var possibleWays =
            possibleEastDiagonalWays
                .Concat(possibleWestDiagonalWays)
                    .Concat(possibleColumnLineWays)
                        .Concat(possibleRowLineWays).ToList();

        return possibleWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column == targetAddress.Column);
    }
}


file static class WaysPiece
{
    public static (
        IList<PieceAddressDto> eastDiagonal,
        IList<PieceAddressDto> westDiagonal,
        IList<PieceAddressDto> line)
        GetWays(
        PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares) =>
        (WaysPositions.GetEastDiagonal(pieceAddressDto, boardSquares),
         WaysPositions.GetWestDiagonal(pieceAddressDto, boardSquares),
         WaysPositions.GetLineWay(pieceAddressDto, boardSquares));
}