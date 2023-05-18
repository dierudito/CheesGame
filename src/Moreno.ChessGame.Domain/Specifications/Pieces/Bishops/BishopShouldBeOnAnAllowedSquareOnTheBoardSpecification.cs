using DomainValidation.Interfaces.Specification;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Bishops;

public class BishopShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<BishopPiece>
{
    public async Task<bool> IsSatisfiedByAsync(BishopPiece bishop) =>
        await new PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(_boardRepository)
            .IsSatisfiedByAsync(bishop);
}
