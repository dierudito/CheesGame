using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Interfaces.Services.Base;

public interface IBasePieceService<T> where T : PieceEntity
{
    Task<T> MoveAsync(T pieceEntity);
    Task<T> CaptureAsync(T pieceEntity);
}
