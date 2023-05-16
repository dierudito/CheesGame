using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Value_Objects;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Bishops;

public class PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<PieceEntity>
{
    public async Task<bool> IsSatisfiedByAsync(PieceEntity piece)
    {
        var board = await _boardRepository.GetByIdAsync(piece.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces.Where(piece => !piece.WasCaptured && piece.Id != piece.Id);

        var wayTraveled = WayTraveled.GetWay(piece, piece.BoardEntity.Squares.ToList());
        var wayOfBishop =
            wayTraveled.Where(way => way.Row != piece.PieceAddressDto.Row &&
                                                   way.Column != piece.PieceAddressDto.Column)
                       .ToList();

        foreach (var way in wayOfBishop)
        {
            if (allPiecesOnTheBoard.Any(piece => piece.PieceAddressDto.Row == way.Row &&
                                                 piece.PieceAddressDto.Column == way.Column))
                return false;
        }

        return allPiecesOnTheBoard
                    .Any(piece => piece.PieceAddressDto.Row == piece.PieceAddressDto.Row &&
                                  piece.PieceAddressDto.Column == piece.PieceAddressDto.Column &&
                                  piece.ColorEnum == piece.ColorEnum);
    }
}