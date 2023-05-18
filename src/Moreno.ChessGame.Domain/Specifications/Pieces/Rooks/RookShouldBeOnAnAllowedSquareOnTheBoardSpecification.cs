using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Rooks;

public class RookShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<RookPiece>
{
    public async Task<bool> IsSatisfiedByAsync(RookPiece rook) =>
        await new PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(_boardRepository)
            .IsSatisfiedByAsync(rook);
}