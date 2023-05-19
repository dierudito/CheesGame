namespace Moreno.ChessGame.Domain.Value_Objects;

public static class PawnCaptureMoveVo
{
    public static bool IsValid(Piece pieceEntity, PieceAddressDto targetAddress)
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