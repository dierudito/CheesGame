using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Interfaces.Repositories;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Knights;

public class KnightShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<PieceEntity>
{
    public async Task<bool> IsSatisfiedByAsync(PieceEntity knight)
    {
        var board = await _boardRepository.GetByIdAsync(knight.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces.Where(piece => !piece.WasCaptured && piece.Id != knight.Id);

        var pieceInTheSquare =
            allPiecesOnTheBoard
                .FirstOrDefault(piece => piece.PieceAddressDto.Row == knight.PieceAddressDto.Row &&
                                         piece.PieceAddressDto.Column == knight.PieceAddressDto.Column);

        return pieceInTheSquare is null ||
               pieceInTheSquare.ColorEnum != knight.ColorEnum;
    }
}