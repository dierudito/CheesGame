using Moreno.ChessGame.Domain.Entities;

namespace Moreno.ChessGame.Domain.Interfaces.Services;

public interface IBoardService
{
    Task<BoardEntity> CreateAsync(BoardEntity boardEntity);
}
