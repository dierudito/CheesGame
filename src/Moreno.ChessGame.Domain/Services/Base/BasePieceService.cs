using Moreno.ChessGame.Domain.Interfaces.Services.Base;

namespace Moreno.ChessGame.Domain.Services.Base;

public abstract class BasePieceService<TRepository, TEntity>
    (TRepository baseRepository) :
    IBasePieceService<TEntity>
    where TRepository : IBaseRepository<TEntity>
    where TEntity : Piece
{
    public virtual async Task<TEntity> CaptureAsync(TEntity pieceEntity)
    {
        if (pieceEntity.ValidationResult.IsValid)
            await baseRepository.UpdateAsync(pieceEntity);
        return pieceEntity;
    }

    public virtual async Task<TEntity> MoveAsync(TEntity pieceEntity)
    {
        if (pieceEntity.ValidationResult.IsValid)
            await baseRepository.UpdateAsync(pieceEntity);
        return pieceEntity;
    }
}
