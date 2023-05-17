using Moreno.ChessGame.Domain.Entities.Pieces;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services;
using Moreno.ChessGame.Domain.Services.Base;
using Moreno.ChessGame.Domain.Validations.Pieces;

namespace Moreno.ChessGame.Domain.Services;

public class QueenService(IBaseRepository<QueenPieceEntity> baseRepository,
    IBoardRepository boardRepository) :
    BasePieceService<QueenPieceEntity>(baseRepository), IQueenService
{
    public override async Task<QueenPieceEntity> MoveAsync(QueenPieceEntity QueenPieceEntity)
    {
        QueenPieceEntity.ValidationResult =
            await new QueenIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(QueenPieceEntity);

        return await base.MoveAsync(QueenPieceEntity);
    }
}
