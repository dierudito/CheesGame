namespace Moreno.ChessGame.Domain.Specifications.Pieces.Rooks;

public class RookShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<RookPiece>
{
    public async Task<bool> IsSatisfiedByAsync(RookPiece rook) =>
        await new PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(_boardRepository)
            .IsSatisfiedByAsync(rook);
}