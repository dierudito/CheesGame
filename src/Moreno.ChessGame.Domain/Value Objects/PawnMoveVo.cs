namespace Moreno.ChessGame.Domain.Value_Objects;

public static class PawnMoveVo
{
    public static bool IsValid(Piece pieceEntity, PieceAddressDto targetAddress)
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
        PieceAddressDto pieceAddressDto, IList<BoardSquare> boardSquares) =>
        boardSquares
        .Where(bs => bs.Column == pieceAddressDto.Column)
        .Select(bs => new PieceAddressDto(bs.Column, bs.Row)).ToList();

}

file static class ToWhitePieces
{
    public static bool IsValid(
        IList<PieceAddressDto> wayPiece, bool hasMoved, PieceAddressDto sourceAddress, PieceAddressDto targetAddress)
    {
        var possibleWays =
            wayPiece.Where(wp => wp.Row == sourceAddress.Row + 1 ||
                                (!hasMoved && wp.Row == sourceAddress.Row + 2));

        return possibleWays.Any(pw => pw.Row == targetAddress.Row);
    }
}

file static class ToBlackPieces
{
    public static bool IsValid(
        IList<PieceAddressDto> wayPiece, bool hasMoved, PieceAddressDto sourceAddress, PieceAddressDto targetAddress)
    {
        var possibleWays =
            wayPiece.Where(wp => wp.Row == sourceAddress.Row - 1 ||
                                (!hasMoved && wp.Row == sourceAddress.Row - 2));

        return possibleWays.Any(pw => pw.Row == targetAddress.Row);
    }
}
