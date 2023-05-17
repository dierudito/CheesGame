using Moreno.ChessGame.Domain.Entities.Base;
using Moreno.ChessGame.Domain.Interfaces.Repositories.Base;
using Moreno.ChessGame.Domain.Interfaces.Services.Base;

namespace Moreno.ChessGame.Domain.Services.Base;

public abstract class BasePieceService<T>(IBaseRepository<T> baseRepository) :
    IBasePieceService<T>
    where T : PieceEntity
{
    public virtual async Task<T> CaptureAsync(T pieceEntity)
    {
        if(pieceEntity.ValidationResult.IsValid)
            await baseRepository.UpdateAsync(pieceEntity);
        return pieceEntity;
    }

    public virtual async Task<T> MoveAsync(T pieceEntity)
    {
        if (pieceEntity.ValidationResult.IsValid) 
            await baseRepository.UpdateAsync(pieceEntity);
        return pieceEntity;
    }
}
