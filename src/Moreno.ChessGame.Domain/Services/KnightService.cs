namespace Moreno.ChessGame.Domain.Services;

public class KnightService(IKnightRepository knightRepository,
    IBoardRepository boardRepository) :
    BasePieceService<IBaseRepository<KnightPiece>, KnightPiece>(knightRepository), IKnightService
{
    public override async Task<KnightPiece> MoveAsync(KnightPiece knightPieceEntity)
    {
        knightPieceEntity.ValidationResult =
            await new KnightIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(knightPieceEntity);

        return await base.MoveAsync(knightPieceEntity);
    }
}
