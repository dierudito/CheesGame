using Moreno.ChessGame.Domain.Entities;

namespace Moreno.ChessGame.Domain.Interfaces.Services;

public interface IBoardService
{
    Task<Board> CreateAsync(Board boardEntity);
}
