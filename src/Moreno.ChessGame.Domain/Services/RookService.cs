namespace Moreno.ChessGame.Domain.Services;

public class RookService(IRookRepository rookRepository,
    IBoardRepository boardRepository) :
    BasePieceService<IBaseRepository<RookPiece>, RookPiece>(rookRepository), IRookService
{
    public override async Task<RookPiece> MoveAsync(RookPiece rookPieceEntity)
    {
        rookPieceEntity.ValidationResult =
            await new RookIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(rookPieceEntity);

        return await base.MoveAsync(rookPieceEntity);
    }
}