using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Interfaces.Services;

public interface IPieceService
{
    Task<PieceEntity> MoveAsync(PieceEntity pieceEntity);
    Task<PieceEntity> CaptureAsync(PieceEntity pieceEntity);
}