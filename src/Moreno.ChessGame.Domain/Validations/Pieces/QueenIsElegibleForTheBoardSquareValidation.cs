using Moreno.ChessGame.Domain.Specifications.Pieces.Queens;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class QueenIsElegibleForTheBoardSquareValidation :
    Validator<QueenPiece>
{
    public QueenIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var queenInAllowedSquare = new QueenShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("queenInAllowedSquare", new Rule<QueenPiece>(queenInAllowedSquare, "Queen can't go to this square of the board"));
    }
}
