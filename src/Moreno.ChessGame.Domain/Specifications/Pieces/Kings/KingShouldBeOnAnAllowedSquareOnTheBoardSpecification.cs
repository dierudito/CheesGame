using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Kings;

public class KingShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<KingPiece>
{
    public async Task<bool> IsSatisfiedByAsync(KingPiece king) =>
        await new PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(_boardRepository)
            .IsSatisfiedByAsync(king);
}
