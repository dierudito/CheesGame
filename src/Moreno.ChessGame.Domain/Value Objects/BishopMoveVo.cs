using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

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
        (GetEastDiagonal(pieceAddressDto, boardSquares), GetWestDiagonal(pieceAddressDto, boardSquares));

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
}