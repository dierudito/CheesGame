namespace Moreno.ChessGame.Domain.Services;

public class PawnService(IPawnRepository pawnRepository,
    IBoardRepository boardRepository) :
    BasePieceService<IBaseRepository<PawnPiece>, PawnPiece>(pawnRepository), IPawnService
{
    public override async Task<PawnPiece> MoveAsync(PawnPiece pawnPiece)
    {
        pawnPiece.ValidationResult =
            await new PawnIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(pawnPiece);

        return await base.MoveAsync(pawnPiece);
    }
}
