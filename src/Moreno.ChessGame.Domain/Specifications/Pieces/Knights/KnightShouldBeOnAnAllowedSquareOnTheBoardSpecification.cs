namespace Moreno.ChessGame.Domain.Specifications.Pieces.Knights;

public class KnightShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<Piece>
{
    public async Task<bool> IsSatisfiedByAsync(Piece knight)
    {
        var board = await _boardRepository.GetByIdAsync(knight.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces.Where(piece => !piece.WasCaptured && piece.Id != knight.Id);

        var pieceInTheSquare =
            allPiecesOnTheBoard
                .FirstOrDefault(piece => piece.PieceAddressDto.Row == knight.PieceAddressDto.Row &&
                                         piece.PieceAddressDto.Column == knight.PieceAddressDto.Column);

        return pieceInTheSquare is null ||
               pieceInTheSquare.ColorEnum != knight.ColorEnum;
    }
}