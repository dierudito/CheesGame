﻿namespace Moreno.ChessGame.Domain.Value_Objects;

public static class QueenMoveVo
{
    public static bool IsValid(Piece pieceEntity, PieceAddressDto targetAddress)
    {
        var (eastDiagonalWay, westDiagonalWay, lineWay) =
            WaysPiece.GetWays(pieceEntity.PieceAddressDto, pieceEntity.BoardEntity.Squares.ToList());

        var possibleColumnLineWays =
            lineWay
            .Where(pdw => pdw.Row != pieceEntity.PieceAddressDto.Row &&
                          pdw.Column == pieceEntity.PieceAddressDto.Column)
            .ToList();

        var possibleRowLineWays =
            lineWay
            .Where(pdw => pdw.Row == pieceEntity.PieceAddressDto.Row &&
                          pdw.Column != pieceEntity.PieceAddressDto.Column)
            .ToList();

        return possibleColumnLineWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column == targetAddress.Column) ||
               possibleRowLineWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column == targetAddress.Column) ||
               eastDiagonalWay.Any(ew => ew.Column == targetAddress.Column && ew.Row == targetAddress.Row) ||
               westDiagonalWay.Any(ew => ew.Column == targetAddress.Column && ew.Row == targetAddress.Row);
    }
}


file static class WaysPiece
{
    public static (
        IList<PieceAddressDto> eastDiagonal,
        IList<PieceAddressDto> westDiagonal,
        IList<PieceAddressDto> line)
        GetWays(
        PieceAddressDto pieceAddressDto, IList<BoardSquare> boardSquares) =>
        (WaysPositions.GetEastDiagonal(pieceAddressDto, boardSquares),
         WaysPositions.GetWestDiagonal(pieceAddressDto, boardSquares),
         WaysPositions.GetLineWay(pieceAddressDto, boardSquares));
}