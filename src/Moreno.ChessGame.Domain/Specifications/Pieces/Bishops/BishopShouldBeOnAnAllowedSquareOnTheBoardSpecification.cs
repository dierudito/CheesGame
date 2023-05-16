using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Bishops;

public class BishopShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<BishopPieceEntity>
{
    public async Task<bool> IsSatisfiedByAsync(BishopPieceEntity bishop) =>
        await new PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(_boardRepository)
            .IsSatisfiedByAsync(bishop);
}
