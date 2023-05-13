using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class PawnMoveVo
{
    public static bool IsValid(PieceEntity pieceEntity, PieceAddressDto targetAddress)
    {
        var waysPiece = 
            WaysPiece.GetWays(pieceEntity.PieceAddressDto, pieceEntity.BoardEntity.Squares.ToList());

        if (!waysPiece.Any(wp => wp.Row == targetAddress.Row && wp.Column == targetAddress.Column))
            return false;

        return pieceEntity.ColorEnum switch
        {
            ColorEnum.White => 
            ToWhitePieces.IsValid(
                waysPiece, pieceEntity.HasMoved, pieceEntity.PieceAddressDto, targetAddress),
            ColorEnum.Black => 
            ToBlackPieces.IsValid(
                waysPiece, pieceEntity.HasMoved, pieceEntity.PieceAddressDto, targetAddress),
            _ => false,
        };
    }
}

file static class WaysPiece
{
    public static IList<PieceAddressDto> GetWays(
        PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares) =>
        boardSquares
        .Where(bs => bs.Column == pieceAddressDto.Column)
        .Select(bs => new PieceAddressDto(bs.Column, bs.Row)).ToList();
    
}

file static class ToWhitePieces
{
    public static bool IsValid(
        IList<PieceAddressDto> wayPiece, bool hasMoved, PieceAddressDto sourceAddress, PieceAddressDto targetAddress)
    {
        var possibleWays = wayPiece.Where(wp => wp.Row > sourceAddress.Row);

        if (possibleWays.Any(pw => pw.Row + 1 == targetAddress.Row)) return true;
        if (!hasMoved && possibleWays.Any(pw => pw.Row + 2 == targetAddress.Row)) return true;
        return false;
    }
}

file static class ToBlackPieces
{
    public static bool IsValid(
        IList<PieceAddressDto> wayPiece, bool hasMoved, PieceAddressDto sourceAddress, PieceAddressDto targetAddress)
    {
        var possibleWays = wayPiece.Where(wp => wp.Row > sourceAddress.Row);

        if (possibleWays.Any(pw => pw.Row - 1 == targetAddress.Row)) return true;
        if (!hasMoved && possibleWays.Any(pw => pw.Row - 2 == targetAddress.Row)) return true;
        return false;
    }
}
