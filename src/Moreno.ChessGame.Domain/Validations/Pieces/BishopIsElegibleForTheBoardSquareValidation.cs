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
