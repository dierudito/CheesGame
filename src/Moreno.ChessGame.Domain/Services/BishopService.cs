using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services;
using Moreno.ChessGame.Domain.Services.Base;
using Moreno.ChessGame.Domain.Validations.Pieces;

namespace Moreno.ChessGame.Domain.Services;

public class BishopService(IBaseRepository<BishopPieceEntity> baseRepository, 
    IBoardRepository boardRepository) :
    BasePieceService<BishopPieceEntity>(baseRepository), IBishopService
{
    public override async Task<BishopPieceEntity> MoveAsync(BishopPieceEntity BishopPieceEntity)
    {
        BishopPieceEntity.ValidationResult =
            await new BishopIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(BishopPieceEntity);

        return await base.MoveAsync(BishopPieceEntity);
    }
}
