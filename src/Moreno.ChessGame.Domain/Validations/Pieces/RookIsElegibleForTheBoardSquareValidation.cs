using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Rooks;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class RookIsElegibleForTheBoardSquareValidation :
    Validator<RookPieceEntity>
{
    public RookIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var rookInAllowedSquare = new RookShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("rookInAllowedSquare", new Rule<RookPieceEntity>(rookInAllowedSquare, "Rook can't go to this square of the board"));
    }
}