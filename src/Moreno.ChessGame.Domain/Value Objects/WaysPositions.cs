using Moreno.ChessGame.Domain.Entities;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class WaysPositions
{
    public static IList<PieceAddressDto> GetLineWay(
        PieceAddressDto pieceAddressDto, IList<BoardSquare> boardSquares) =>
        boardSquares
        .Where(bs => bs.Column == pieceAddressDto.Column || bs.Row == pieceAddressDto.Row)
        .Select(bs => new PieceAddressDto(bs.Column, bs.Row)).ToList();

    public static IList<PieceAddressDto> GetEastDiagonal(PieceAddressDto pieceAddressDto, IList<BoardSquare> boardSquares)
    {
        var firstSquareOfTheBoard = boardSquares.FirstOrDefault();
        var isTheColumnTheVertexBounding = true;
        var isTheRowTheVertexBounding = false;
        var minIndex = (byte)pieceAddressDto.Column - (byte)BoardColumnEnum.A;
        var minIndexToRow = minIndex;

        if ((byte)pieceAddressDto.Row < minIndex)
        {
            minIndex = (byte)pieceAddressDto.Row;
            minIndexToRow = minIndex;
            isTheColumnTheVertexBounding = false;
            isTheRowTheVertexBounding = true;
        }

        var initialSquareOfTheDiagonal =
            new PieceAddressDto((BoardColumnEnum)((byte)pieceAddressDto.Column - minIndex),
                                (BoardRowEnum)((byte)pieceAddressDto.Row - minIndexToRow));

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

            if (!(square.Row == row && square.Column == column)) continue;

            eastDiagonal.Add(new(column, row));
            vertexIndex++;
        }

        return eastDiagonal;
    }
    public static IList<PieceAddressDto> GetWestDiagonal(PieceAddressDto pieceAddressDto, IList<BoardSquare> boardSquares)
    {
        var firstSquareOfTheBoard = boardSquares.LastOrDefault();
        var isTheColumnTheVertexBounding = false;
        var isTheRowTheVertexBounding = true;
        int minIndex = (byte)pieceAddressDto.Row;

        var distanceToLastColumn = (byte)firstSquareOfTheBoard.Column - (byte)pieceAddressDto.Column;

        if (distanceToLastColumn < minIndex)
        {
            minIndex = distanceToLastColumn;
            isTheColumnTheVertexBounding = true;
            isTheRowTheVertexBounding = false;
        }

        var initialSquareOfTheDiagonal =
            new PieceAddressDto((BoardColumnEnum)((byte)pieceAddressDto.Column + minIndex),
                                 (BoardRowEnum)((byte)pieceAddressDto.Row - minIndex));

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

            if (!(square.Row == row && square.Column == column)) continue;

            vertexIndex++;
            westDiagonal.Add(new(column, row));
        }

        return westDiagonal;
    }
}
