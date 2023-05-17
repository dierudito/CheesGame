using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Pawns;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class PawnIsElegibleForTheBoardSquareValidation :
    Validator<PawnPieceEntity>
{
    public PawnIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var pawnInAllowedSquare = new PawnShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("pawnInAllowedSquare", new Rule<PawnPieceEntity>(pawnInAllowedSquare, "Pawn can't go to this square of the board"));
    }
}
