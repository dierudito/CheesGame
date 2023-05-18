using Moreno.ChessGame.Domain.Entities;

namespace Moreno.ChessGame.Domain.Value_Objects
{
    public static class WayTraveled
    {
        public static IList<PieceAddressDto> GetWay(Piece pieceEntity, IList<BoardSquare> boardSquares)
        {
            var eastDiagonalWay = WaysPositions.GetEastDiagonal(pieceEntity.LastPieceAddress, boardSquares);

            if (eastDiagonalWay.Any(ew => ew.Column == pieceEntity.PieceAddressDto.Column &&
                                          ew.Row == pieceEntity.PieceAddressDto.Row))
            {
                return (pieceEntity.LastPieceAddress.Row < pieceEntity.PieceAddressDto.Row &&
                        pieceEntity.LastPieceAddress.Column < pieceEntity.PieceAddressDto.Column)
                             ? eastDiagonalWay.Where(east => east.Row < pieceEntity.PieceAddressDto.Row &&
                                                     east.Column < pieceEntity.PieceAddressDto.Column &&
                                                     east.Row >= pieceEntity.LastPieceAddress.Row &&
                                                     east.Column >= pieceEntity.PieceAddressDto.Column).ToList()
                             : eastDiagonalWay.Where(east => east.Row > pieceEntity.PieceAddressDto.Row &&
                                                     east.Column > pieceEntity.PieceAddressDto.Column &&
                                                     east.Row <= pieceEntity.LastPieceAddress.Row &&
                                                     east.Column <= pieceEntity.PieceAddressDto.Column).ToList();
            }

            var westDiagonalWay = WaysPositions.GetWestDiagonal(pieceEntity.LastPieceAddress, boardSquares);

            if (westDiagonalWay.Any(ew => ew.Column == pieceEntity.PieceAddressDto.Column &&
                                          ew.Row == pieceEntity.PieceAddressDto.Row))
                return (pieceEntity.LastPieceAddress.Row < pieceEntity.PieceAddressDto.Row &&
                        pieceEntity.LastPieceAddress.Column > pieceEntity.PieceAddressDto.Column)
                             ? westDiagonalWay.Where(west => west.Row <= pieceEntity.PieceAddressDto.Row &&
                                                     west.Column >= pieceEntity.PieceAddressDto.Column &&
                                                     west.Row > pieceEntity.LastPieceAddress.Row &&
                                                     west.Column < pieceEntity.LastPieceAddress.Column).ToList()
                             : westDiagonalWay.Where(east => east.Row > pieceEntity.LastPieceAddress.Row &&
                                                     east.Column < pieceEntity.LastPieceAddress.Column &&
                                                     east.Row >= pieceEntity.PieceAddressDto.Row &&
                                                     east.Column <= pieceEntity.PieceAddressDto.Column).ToList();

            var lineWay = WaysPositions.GetLineWay(pieceEntity.LastPieceAddress, boardSquares);

            if (lineWay.Any(ew => ew.Column == pieceEntity.PieceAddressDto.Column &&
                                          ew.Row == pieceEntity.PieceAddressDto.Row))
            {
                if (pieceEntity.LastPieceAddress.Row == pieceEntity.PieceAddressDto.Row &&
                        pieceEntity.LastPieceAddress.Column > pieceEntity.PieceAddressDto.Column)
                    return lineWay.Where(line => line.Row == pieceEntity.PieceAddressDto.Row &&
                                                 line.Row == pieceEntity.LastPieceAddress.Row &&
                                                 line.Column > pieceEntity.LastPieceAddress.Column &&
                                                 line.Column <= pieceEntity.PieceAddressDto.Column).ToList();

                if (pieceEntity.LastPieceAddress.Row == pieceEntity.PieceAddressDto.Row &&
                        pieceEntity.LastPieceAddress.Column < pieceEntity.PieceAddressDto.Column)
                    return lineWay.Where(line => line.Row == pieceEntity.PieceAddressDto.Row &&
                                                 line.Row == pieceEntity.LastPieceAddress.Row &&
                                                 line.Column < pieceEntity.LastPieceAddress.Column &&
                                                 line.Column >= pieceEntity.PieceAddressDto.Column).ToList();

                if (pieceEntity.LastPieceAddress.Row > pieceEntity.PieceAddressDto.Row &&
                        pieceEntity.LastPieceAddress.Column == pieceEntity.PieceAddressDto.Column)
                    return lineWay.Where(line => line.Row >= pieceEntity.PieceAddressDto.Row &&
                                                 line.Row < pieceEntity.LastPieceAddress.Row &&
                                                 line.Column == pieceEntity.LastPieceAddress.Column &&
                                                 line.Column == pieceEntity.PieceAddressDto.Column).ToList();

                if (pieceEntity.LastPieceAddress.Row < pieceEntity.PieceAddressDto.Row &&
                        pieceEntity.LastPieceAddress.Column == pieceEntity.PieceAddressDto.Column)
                    return lineWay.Where(line => line.Row <= pieceEntity.PieceAddressDto.Row &&
                                                 line.Row > pieceEntity.LastPieceAddress.Row &&
                                                 line.Column == pieceEntity.LastPieceAddress.Column &&
                                                 line.Column == pieceEntity.PieceAddressDto.Column).ToList();
            }

            return new List<PieceAddressDto>();
        }
    }
}
