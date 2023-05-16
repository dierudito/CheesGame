using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Knights;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class KnightIsElegibleForTheBoardSquareValidation :
    Validator<PieceEntity>
{
    public KnightIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var knightInAllowedSquare = new KnightShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("knightInAllowedSquare", new Rule<PieceEntity>(knightInAllowedSquare, "Knight can't go to this square of the board"));
    }
}
