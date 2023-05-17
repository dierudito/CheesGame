using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services;
using Moreno.ChessGame.Domain.Services.Base;
using Moreno.ChessGame.Domain.Validations.Pieces;

namespace Moreno.ChessGame.Domain.Services;

public class RookService(IBaseRepository<RookPieceEntity> baseRepository,
    IBoardRepository boardRepository) :
    BasePieceService<RookPieceEntity>(baseRepository), IRookService
{
    public override async Task<RookPieceEntity> MoveAsync(RookPieceEntity RookPieceEntity)
    {
        RookPieceEntity.ValidationResult =
            await new RookIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(RookPieceEntity);

        return await base.MoveAsync(RookPieceEntity);
    }
}