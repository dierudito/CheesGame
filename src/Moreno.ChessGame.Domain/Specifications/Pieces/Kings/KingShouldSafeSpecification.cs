namespace Moreno.ChessGame.Domain.Specifications.Pieces.Kings;

// TODO - 
public class KingShouldSafeSpecification(IBoardRepository _boardRepository) :
    ISpecification<KingPiece>
{
    public async Task<bool> IsSatisfiedByAsync(KingPiece kingPiece)
    {
        return true;
    }
}
