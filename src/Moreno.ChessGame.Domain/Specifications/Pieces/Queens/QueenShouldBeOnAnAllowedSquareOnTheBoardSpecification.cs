using DomainValidation.Interfaces.Specification;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Queens;

public class QueenShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<QueenPiece>
{
    public async Task<bool> IsSatisfiedByAsync(QueenPiece queen) =>
        await new PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(_boardRepository)
            .IsSatisfiedByAsync(queen);
}
