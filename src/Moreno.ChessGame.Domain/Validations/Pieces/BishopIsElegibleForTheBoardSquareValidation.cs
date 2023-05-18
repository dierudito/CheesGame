using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Bishops;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class BishopIsElegibleForTheBoardSquareValidation :
    Validator<BishopPiece>
{
    public BishopIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var bishopInAllowedSquare = new BishopShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("bishopInAllowedSquare", new Rule<BishopPiece>(bishopInAllowedSquare, "Bishop can't go to this square of the board"));
    }
}
