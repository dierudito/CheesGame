using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Pawns;

public class PawnShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<PawnPieceEntity>
{
    public async Task<bool> IsSatisfiedByAsync(PawnPieceEntity pawn)
    {
        var board = await _boardRepository.GetByIdAsync(pawn.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces.Where(piece => !piece.WasCaptured && piece.Id != piece.Id);

        var wayTraveled = WayTraveled.GetWay(pawn, pawn.BoardEntity.Squares.ToList());
        var wayOfPawn =
            wayTraveled.Where(way => way.Row != pawn.PieceAddressDto.Row &&
                                                   way.Column != pawn.PieceAddressDto.Column)
                       .ToList();

        foreach (var way in wayOfPawn)
        {
            if (allPiecesOnTheBoard.Any(piece => piece.PieceAddressDto.Row == way.Row &&
                                                 piece.PieceAddressDto.Column == way.Column))
                return false;
        }

        return !allPiecesOnTheBoard
                    .Any(piece => piece.PieceAddressDto.Row == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column == pawn.PieceAddressDto.Column) ||
                allPiecesOnTheBoard
                    .Any(piece => piece.ColorEnum != pawn.ColorEnum &&
                                 ((piece.PieceAddressDto.Row + 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column + 1 == pawn.PieceAddressDto.Column) ||
                                  (piece.PieceAddressDto.Row - 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column - 1 == pawn.PieceAddressDto.Column)) ||
                                  (piece.PieceAddressDto.Row + 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column - 1 == pawn.PieceAddressDto.Column) ||
                                  (piece.PieceAddressDto.Row - 1 == pawn.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column + 1 == pawn.PieceAddressDto.Column)));
    }
}