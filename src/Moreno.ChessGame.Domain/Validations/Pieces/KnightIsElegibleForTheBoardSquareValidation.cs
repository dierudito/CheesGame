using Moreno.ChessGame.Domain.Specifications.Pieces.Knights;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class KnightIsElegibleForTheBoardSquareValidation :
    Validator<KnightPiece>
{
    public KnightIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var knightInAllowedSquare = new KnightShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("knightInAllowedSquare", new Rule<KnightPiece>(knightInAllowedSquare, "Knight can't go to this square of the board"));
    }
}
