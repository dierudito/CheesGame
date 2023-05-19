using Moreno.ChessGame.Domain.Specifications.Pieces.Rooks;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class RookIsElegibleForTheBoardSquareValidation :
    Validator<RookPiece>
{
    public RookIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var rookInAllowedSquare = new RookShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("rookInAllowedSquare", new Rule<RookPiece>(rookInAllowedSquare, "Rook can't go to this square of the board"));
    }
}