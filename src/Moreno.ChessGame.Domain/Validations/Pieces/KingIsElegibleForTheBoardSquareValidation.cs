using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Kings;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class KingIsElegibleForTheBoardSquareValidation :
    Validator<KingPieceEntity>
{
    public KingIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var kingInAllowedSquare = new KingShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("kingInAllowedSquare", new Rule<KingPieceEntity>(kingInAllowedSquare, "King can't go to this square of the board"));
    }
}
