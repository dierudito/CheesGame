namespace Moreno.ChessGame.Domain.Services;

public class BishopService(IBishopRepository bishopRepository,
    IBoardRepository boardRepository) :
    BasePieceService<IBaseRepository<BishopPiece>, BishopPiece>(bishopRepository), IBishopService
{
    public override async Task<BishopPiece> MoveAsync(BishopPiece bishopPieceEntity)
    {
        bishopPieceEntity.ValidationResult =
            await new BishopIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(bishopPieceEntity);

        return await base.MoveAsync(bishopPieceEntity);
    }
}
