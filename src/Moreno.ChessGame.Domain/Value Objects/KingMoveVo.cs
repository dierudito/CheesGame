using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class KingMoveVo
{
    public static bool IsValid(PieceEntity pieceEntity, PieceAddressDto targetAddress)
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

        return possibleColumnLineWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column+1 == targetAddress.Column) ||
               possibleColumnLineWays.Any(pcw => pcw.Row == targetAddress.Row && pcw.Column - 1 == targetAddress.Column) || 
               possibleColumnLineWays.Any(pcw => !pieceEntity.HasMoved && 
                                                 pcw.Row == targetAddress.Row && pcw.Column + 2 == targetAddress.Column) ||
               possibleColumnLineWays.Any(pcw => !pieceEntity.HasMoved &&
                                                 pcw.Row == targetAddress.Row && pcw.Column - 2 == targetAddress.Column) ||
               possibleRowLineWays.Any(pcw => pcw.Row+1 == targetAddress.Row && pcw.Column == targetAddress.Column) ||
               possibleRowLineWays.Any(pcw => pcw.Row - 1 == targetAddress.Row && pcw.Column == targetAddress.Column) ||
               eastDiagonalWay.Any(ew => ew.Column+1 == targetAddress.Column && ew.Row+1 == targetAddress.Row) ||
               eastDiagonalWay.Any(ew => ew.Column - 1 == targetAddress.Column && ew.Row - 1 == targetAddress.Row) ||
               westDiagonalWay.Any(ew => ew.Column+1 == targetAddress.Column && ew.Row-1 == targetAddress.Row) ||
               westDiagonalWay.Any(ew => ew.Column - 1 == targetAddress.Column && ew.Row + 1 == targetAddress.Row);
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
        (GetEastDiagonal(pieceAddressDto, boardSquares),
         GetWestDiagonal(pieceAddressDto, boardSquares),
         GetLineWay(pieceAddressDto, boardSquares));

    private static IList<PieceAddressDto> GetEastDiagonal(PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares)
    {
        var firstSquareOfTheBoard = boardSquares.FirstOrDefault();
        var isTheColumnTheVertexBounding = true;
        var isTheRowTheVertexBounding = false;
        var minIndex = (byte)pieceAddressDto.Column;

        if ((byte)pieceAddressDto.Row < minIndex)
        {
            minIndex = (byte)pieceAddressDto.Row;
            isTheColumnTheVertexBounding = false;
            isTheRowTheVertexBounding = true;
        }
        minIndex++;

        var initialSquareOfTheDiagonal =
            new PieceAddressDto(pieceAddressDto.Column - minIndex, pieceAddressDto.Row - minIndex);

        var newBoardSquaresToDiagonal =
            boardSquares.Where(bs => (isTheColumnTheVertexBounding &&
                                      bs.Column >= initialSquareOfTheDiagonal.Column) ||
                                     (isTheRowTheVertexBounding &&
                                     bs.Row >= initialSquareOfTheDiagonal.Row))
            .ToList();

        var eastDiagonal = new List<PieceAddressDto>();
        byte vertexIndex = 0;

        foreach (var square in newBoardSquaresToDiagonal)
        {
            var column = (BoardColumnEnum)((byte)initialSquareOfTheDiagonal.Column + vertexIndex);
            var row = (BoardRowEnum)((byte)initialSquareOfTheDiagonal.Row + vertexIndex);
            vertexIndex++;

            if (square.Row == row && square.Column == column) eastDiagonal.Add(new(column, row));
        }

        return eastDiagonal;
    }
    private static IList<PieceAddressDto> GetWestDiagonal(PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares)
    {
        var firstSquareOfTheBoard = boardSquares.FirstOrDefault();
        var isTheColumnTheVertexBounding = false;
        var isTheRowTheVertexBounding = true;
        var minIndex = (byte)pieceAddressDto.Row;

        var distanceToLastColumn = firstSquareOfTheBoard.Column - pieceAddressDto.Column;

        if (distanceToLastColumn < minIndex)
        {
            minIndex = distanceToLastColumn;
            isTheColumnTheVertexBounding = true;
            isTheRowTheVertexBounding = false;
        }
        minIndex++;

        var initialSquareOfTheDiagonal =
            new PieceAddressDto(pieceAddressDto.Column + minIndex, pieceAddressDto.Row - minIndex);

        var newBoardSquaresToDiagonal =
            boardSquares.Where(bs => (isTheColumnTheVertexBounding &&
                                      bs.Column <= initialSquareOfTheDiagonal.Column) ||
                                     (isTheRowTheVertexBounding &&
                                     bs.Row >= initialSquareOfTheDiagonal.Row))
            .ToList();

        var westDiagonal = new List<PieceAddressDto>();
        byte vertexIndex = 0;

        foreach (var square in newBoardSquaresToDiagonal)
        {
            var column = (BoardColumnEnum)((byte)initialSquareOfTheDiagonal.Column - vertexIndex);
            var row = (BoardRowEnum)((byte)initialSquareOfTheDiagonal.Row + vertexIndex);
            vertexIndex++;

            if (square.Row == row && square.Column == column) westDiagonal.Add(new(column, row));
        }

        return westDiagonal;
    }

    private static IList<PieceAddressDto> GetLineWay(
        PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares) =>
        boardSquares
        .Where(bs => bs.Column == pieceAddressDto.Column || bs.Row == pieceAddressDto.Row)
        .Select(bs => new PieceAddressDto(bs.Column, bs.Row)).ToList();
}