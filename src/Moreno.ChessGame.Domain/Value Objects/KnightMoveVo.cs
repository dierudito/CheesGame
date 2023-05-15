﻿using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class KnightMoveVo
{
    public static bool IsValid(PieceEntity pieceEntity, PieceAddressDto targetAddress)
    {
        var waysPiece =
            WaysPiece.GetWays(pieceEntity.PieceAddressDto, pieceEntity.BoardEntity.Squares.ToList());

        return waysPiece.Any(wp => wp.Row == targetAddress.Row && wp.Column == targetAddress.Column);
    }
}

file static class WaysPiece
{
    public static IList<PieceAddressDto> GetWays(
        PieceAddressDto pieceAddressDto, IList<BoardSquareEntity> boardSquares) =>
        boardSquares
        .Where(bs => (bs.Row == pieceAddressDto.Row + 2 && 
                     (bs.Column == pieceAddressDto.Column - 1 || bs.Column == pieceAddressDto.Column + 1)) ||
                     (bs.Row == pieceAddressDto.Row - 2 &&
                     (bs.Column == pieceAddressDto.Column - 1 || bs.Column == pieceAddressDto.Column + 1)) ||
                     (bs.Row == pieceAddressDto.Row + 1 &&
                     (bs.Column == pieceAddressDto.Column - 2 || bs.Column == pieceAddressDto.Column + 2)) ||
                     (bs.Row == pieceAddressDto.Row - 1 &&
                     (bs.Column == pieceAddressDto.Column - 2 || bs.Column == pieceAddressDto.Column + 2)))
        .Select(bs => new PieceAddressDto(bs.Column, bs.Row)).ToList();

}