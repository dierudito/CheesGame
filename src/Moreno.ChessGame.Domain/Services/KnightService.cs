using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services;
using Moreno.ChessGame.Domain.Services.Base;
using Moreno.ChessGame.Domain.Validations.Pieces;

namespace Moreno.ChessGame.Domain.Services;

public class KnightService(IBaseRepository<KnightPieceEntity> baseRepository,
    IBoardRepository boardRepository) :
    BasePieceService<KnightPieceEntity>(baseRepository), IKnightService
{
    public override async Task<KnightPieceEntity> MoveAsync(KnightPieceEntity KnightPieceEntity)
    {
        KnightPieceEntity.ValidationResult =
            await new KnightIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(KnightPieceEntity);

        return await base.MoveAsync(KnightPieceEntity);
    }
}
