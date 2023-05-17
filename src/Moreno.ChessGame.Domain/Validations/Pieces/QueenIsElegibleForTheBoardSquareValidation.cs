using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Queens;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class QueenIsElegibleForTheBoardSquareValidation :
    Validator<QueenPieceEntity>
{
    public QueenIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var queenInAllowedSquare = new QueenShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("queenInAllowedSquare", new Rule<QueenPieceEntity>(queenInAllowedSquare, "Queen can't go to this square of the board"));
    }
}
