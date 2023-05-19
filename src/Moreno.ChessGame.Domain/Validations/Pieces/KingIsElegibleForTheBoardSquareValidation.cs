using Moreno.ChessGame.Domain.Specifications.Pieces.Kings;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class KingIsElegibleForTheBoardSquareValidation :
    Validator<KingPiece>
{
    public KingIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var kingInAllowedSquare = new KingShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);
        var canKingCastle = new KingShouldCastleWhenAllowedSpecification(boardRepository);
        var kingSafe = new KingShouldSafeSpecification(boardRepository);

        Add("kingInAllowedSquare", new Rule<KingPiece>(kingInAllowedSquare, "King can't go to this square of the board"));
        Add("canKingCastle", new Rule<KingPiece>(canKingCastle, "King can't castle"));
        Add("kingSafe", new Rule<KingPiece>(kingSafe, "The king isn't safe on this square of the board"));
    }
}
