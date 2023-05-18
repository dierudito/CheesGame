using DomainValidation.Interfaces.Specification;

namespace Moreno.ChessGame.Domain.Specifications.Pieces;

public class PieceShouldBeOnAnAllowedSquareOnTheBoardSpecification(IBoardRepository _boardRepository) :
    ISpecification<Piece>
{
    public async Task<bool> IsSatisfiedByAsync(Piece piece)
    {
        var board = await _boardRepository.GetByIdAsync(piece.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces.Where(boardPiece => !boardPiece.WasCaptured && boardPiece.Id != piece.Id).ToList();

        var wayTraveled = WayTraveled.GetWay(piece, piece.BoardEntity.Squares.ToList());
        var wayOfBishop =
            wayTraveled.Where(way => way.Row != piece.PieceAddressDto.Row &&
                                                   way.Column != piece.PieceAddressDto.Column)
                       .ToList();

        foreach (var way in wayOfBishop)
        {
            if (allPiecesOnTheBoard.Any(piece => piece.PieceAddressDto.Row == way.Row &&
                                                 piece.PieceAddressDto.Column == way.Column))
                return false;
        }

        return !allPiecesOnTheBoard
                    .Any(boardPiece => boardPiece.PieceAddressDto.Row == piece.PieceAddressDto.Row &&
                                  boardPiece.PieceAddressDto.Column == piece.PieceAddressDto.Column &&
                                  boardPiece.ColorEnum == piece.ColorEnum);
    }
}