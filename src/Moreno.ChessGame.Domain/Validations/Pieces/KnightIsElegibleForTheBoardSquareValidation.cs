﻿using DomainValidation.Validation;
using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Specifications.Pieces.Knights;

namespace Moreno.ChessGame.Domain.Validations.Pieces;

public class KnightIsElegibleForTheBoardSquareValidation :
    Validator<KnightPieceEntity>
{
    public KnightIsElegibleForTheBoardSquareValidation(IBoardRepository boardRepository)
    {
        var knightInAllowedSquare = new KnightShouldBeOnAnAllowedSquareOnTheBoardSpecification(boardRepository);

        Add("knightInAllowedSquare", new Rule<KnightPieceEntity>(knightInAllowedSquare, "Knight can't go to this square of the board"));
    }
}
