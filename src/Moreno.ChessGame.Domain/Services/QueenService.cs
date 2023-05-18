namespace Moreno.ChessGame.Domain.Services;

public class QueenService(IQueenRepository queenRepository,
    IBoardRepository boardRepository) :
    BasePieceService<IBaseRepository<QueenPiece>, QueenPiece>(queenRepository), IQueenService
{
    public override async Task<QueenPiece> MoveAsync(QueenPiece queenPiece)
    {
        queenPiece.ValidationResult =
            await new QueenIsElegibleForTheBoardSquareValidation(boardRepository)
            .ValidateAsync(queenPiece);

        return await base.MoveAsync(queenPiece);
    }
}
