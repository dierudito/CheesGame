using Moreno.ChessGame.Domain.Specifications.Pieces.Pawns;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class PawnIsElegibleForTheBoardSquareValidation :
    Validator<PawnPiece>
{
    public PawnIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var pawnInAllowedSquare = new PawnShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("pawnInAllowedSquare", new Rule<PawnPiece>(pawnInAllowedSquare, "Pawn can't go to this square of the board"));
    }
}
