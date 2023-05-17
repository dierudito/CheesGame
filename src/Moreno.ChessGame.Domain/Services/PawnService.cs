using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services;
using Moreno.ChessGame.Domain.Services.Base;
using Moreno.ChessGame.Domain.Validations.Pieces;

namespace Moreno.ChessGame.Domain.Services;

public class PawnService(IBaseRepository<PawnPieceEntity> baseRepository,
    IBoardRepository boardRepository) :
    BasePieceService<PawnPieceEntity>(baseRepository), IPawnService
{
    public override async Task<PawnPieceEntity> MoveAsync(PawnPieceEntity PawnPieceEntity)
    {
        PawnPieceEntity.ValidationResult =
            await new PawnIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(PawnPieceEntity);

        return await base.MoveAsync(PawnPieceEntity);
    }
}
