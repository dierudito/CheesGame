using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Value_Objects;

public static class PawnCaptureMoveVo
{
    public static bool IsValid(PieceEntity pieceEntity, PieceAddressDto targetAddress)
    {
        return pieceEntity.ColorEnum switch
        {
            ColorEnum.White =>
            targetAddress.Row == pieceEntity.PieceAddressDto.Row + 1 &&
            (targetAddress.Column == pieceEntity.PieceAddressDto.Column - 1 ||
            targetAddress.Column == pieceEntity.PieceAddressDto.Column + 1),
            ColorEnum.Black =>
            targetAddress.Row == pieceEntity.PieceAddressDto.Row - 1 &&
            (targetAddress.Column == pieceEntity.PieceAddressDto.Column - 1 ||
            targetAddress.Column == pieceEntity.PieceAddressDto.Column + 1),
            _ => false,
        };
    }
}