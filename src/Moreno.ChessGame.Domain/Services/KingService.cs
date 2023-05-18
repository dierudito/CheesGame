namespace Moreno.ChessGame.Domain.Services;

public class KingService(IKingRepository baseRepository,
    IBoardRepository boardRepository) :
    BasePieceService<IBaseRepository<KingPiece>, KingPiece>(baseRepository), IKingService
{
    public override async Task<KingPiece> MoveAsync(KingPiece KingPieceEntity)
    {
        KingPieceEntity.ValidationResult =
            await new KingIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(KingPieceEntity);

        return await base.MoveAsync(KingPieceEntity);
    }
}
