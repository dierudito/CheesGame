namespace Moreno.ChessGame.Domain.Specifications.Pieces.Pawns;

public class PawnShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<PawnPiece>
{
    public async Task<bool> IsSatisfiedByAsync(PawnPiece pawn)
    {
        var board = await _boardRepository.GetByIdAsync(pawn.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces.Where(piece => !piece.WasCaptured && piece.Id != pawn.Id).ToList();

        var wayTraveled = WayTraveled.GetWay(pawn, pawn.BoardEntity.Squares.ToList());

        foreach (var way in wayTraveled)
        {
            if (allPiecesOnTheBoard.Any(piece => piece.PieceAddressDto.Row == way.Row &&
                                                 piece.PieceAddressDto.Column == way.Column))
                return false;
        }

        var wayOfPawn =
            wayTraveled.Where(way => way.Row != pawn.PieceAddressDto.Row &&
                                                   way.Column != pawn.PieceAddressDto.Column)
                       .ToList();

        return !allPiecesOnTheBoard
                    .Any(piece => piece.PieceAddressDto.Row == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column == pawn.PieceAddressDto.Column) ||
                allPiecesOnTheBoard
                    .Any(piece => piece.ColorEnum != pawn.ColorEnum &&
                                 ((piece.PieceAddressDto.Row + 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column + 1 == pawn.PieceAddressDto.Column) ||
                                  (piece.PieceAddressDto.Row - 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column - 1 == pawn.PieceAddressDto.Column) ||
                                  (piece.PieceAddressDto.Row + 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column - 1 == pawn.PieceAddressDto.Column) ||
                                  (piece.PieceAddressDto.Row - 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column + 1 == pawn.PieceAddressDto.Column)));
    }
}