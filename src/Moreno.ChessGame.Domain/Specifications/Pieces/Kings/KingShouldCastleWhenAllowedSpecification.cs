using DomainValidation.Interfaces.Specification;

namespace Moreno.ChessGame.Domain.Specifications.Pieces.Kings;

public class KingShouldCastleWhenAllowedSpecification(IBoardRepository _boardRepository) :
    ISpecification<KingPiece>
{
    public async Task<bool> IsSatisfiedByAsync(KingPiece kingPiece)
    {
        if (kingPiece.LastPieceAddress is null) return true;
        if (GetDistanceTravelesByKing(kingPiece) < 2) return true;

        if (kingPiece.HasTheKingBeenCheck) return false;

        var kingsStartingPosition =
            (kingPiece.ColorEnum switch
            {
                ColorEnum.Black => KingPiece.CreateBlackKing(),
                ColorEnum.White => KingPiece.CreateWhiteKing(),
                _ => null
            })?.PieceAddressDto;

        if (kingsStartingPosition is null) return false;

        if (kingPiece.LastPieceAddress.Column != kingsStartingPosition.Column &&
             kingPiece.LastPieceAddress.Row != kingsStartingPosition.Row)
            return false;

        var board = await _boardRepository.GetByIdAsync(kingPiece.BoardId);
        var allPiecesOnTheBoard =
            board.Pieces
            .Where(boardPiece => !boardPiece.WasCaptured && boardPiece.Id != kingPiece.Id)
            .ToList();

        var wayTraveled = WayTraveled.GetWay(kingPiece, kingPiece.BoardEntity.Squares.ToList());
        var wayOfKing =
            wayTraveled.Where(way => way.Row != kingPiece.PieceAddressDto.Row &&
                                                   way.Column != kingPiece.PieceAddressDto.Column)
                       .ToList();

        foreach (var way in wayOfKing)
        {
            if (allPiecesOnTheBoard.Any(piece => piece.PieceAddressDto.Row == way.Row &&
                                                 piece.PieceAddressDto.Column == way.Column))
                return false;
        }

        var rooks = allPiecesOnTheBoard
                        .FindAll(piece => piece.ColorEnum == kingPiece.ColorEnum &&
                                          piece.PieceTypeEnum == PieceTypeEnum.Rook &&
                                          piece.PieceAddressDto.Row == kingPiece.PieceAddressDto.Row);

        if (rooks.Count == 0) return false;

        var nearestRook = GetNearestRook(rooks, kingPiece);
        return !nearestRook.HasMoved;
    }

    private static Piece GetNearestRook(List<Piece> rooks, KingPiece kingPiece)
    {

        var nearestRook = rooks.FirstOrDefault();

        if (rooks.Any(rook => rook.Id != nearestRook.Id))
        {
            var otherRook = rooks.FirstOrDefault(rook => rook.Id != nearestRook.Id);
            var distanceFromFirstRook =
                (byte)nearestRook.PieceAddressDto.Column - (byte)kingPiece.PieceAddressDto.Column;
            distanceFromFirstRook = distanceFromFirstRook < 0 ? distanceFromFirstRook * -1 : distanceFromFirstRook;
            var distanceFromLastRook =
                (byte)otherRook.PieceAddressDto.Column - (byte)kingPiece.PieceAddressDto.Column;
            distanceFromLastRook = distanceFromLastRook < 0 ? distanceFromLastRook * -1 : distanceFromLastRook;

            if (distanceFromLastRook < distanceFromFirstRook) nearestRook = otherRook;
        }

        return nearestRook;
    }

    private static int GetDistanceTravelesByKing(KingPiece kingPiece)
    {
        if (kingPiece.LastPieceAddress?.Row != kingPiece.PieceAddressDto.Row) return 0;
        var distance = 
            (byte)kingPiece.LastPieceAddress.Column - (byte)kingPiece.PieceAddressDto.Column;

        return distance < 0 ? distance * -1 : distance;
    }
}
