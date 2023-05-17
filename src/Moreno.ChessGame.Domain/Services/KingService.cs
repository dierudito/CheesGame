using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services;
using Moreno.ChessGame.Domain.Services.Base;
using Moreno.ChessGame.Domain.Validations.Pieces;

namespace Moreno.ChessGame.Domain.Services;

public class KingService(IBaseRepository<KingPieceEntity> baseRepository,
    IBoardRepository boardRepository) :
    BasePieceService<KingPieceEntity>(baseRepository), IKingService
{
    public override async Task<KingPieceEntity> MoveAsync(KingPieceEntity KingPieceEntity)
    {
        KingPieceEntity.ValidationResult =
            await new KingIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(KingPieceEntity);

        return await base.MoveAsync(KingPieceEntity);
    }
}
