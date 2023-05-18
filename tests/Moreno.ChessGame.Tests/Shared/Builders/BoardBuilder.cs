using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.UnitaryTests.Shared.Builders;

public class BoardBuilder
{
    private readonly Board _board;
    public ICollection<BoardSquare> Squares { get; private set; }
    public ICollection<Piece> Pieces { get; private set; }

    public BoardBuilder()
    {
        _board = new();
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.One), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.One), false);

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Two), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Two), false);

        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Three), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Three), false);

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Four), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Four), false);

        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Five), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Five), false);

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Six), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Six), false);

        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Seven), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Seven), false);

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Eight), false);
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Eight), false);

        var whiteRookOfQueen = RookPiece.CreateWhiteRookOfQueen();
        var whiteKnightOfQueen = KnightPiece.CreateWhiteKnightOfQueen();
        var whiteBishopOfQueen = BishopPiece.CreateWhiteBishopOfQueen();
        var whiteQueen = QueenPiece.CreateWhiteQueen();
        var whiteKing = KingPiece.CreateWhiteKing();
        var whiteRookOfKing = RookPiece.CreateWhiteRookOfKing();
        var whiteKnightOfKing = KnightPiece.CreateWhiteKnightOfKing();
        var whiteBishopOfKing = BishopPiece.CreateWhiteBishopOfKing();
        var allPawns = PawnPiece.CreateAllPawns();
        var blackRookOfQueen = RookPiece.CreateBlackRookOfQueen();
        var blackKnightOfQueen = KnightPiece.CreateBlackKnightOfQueen();
        var blackBishopOfQueen = BishopPiece.CreateBlackBishopOfQueen();
        var blackQueen = QueenPiece.CreateBlackQueen();
        var blackKing = KingPiece.CreateBlackKing();
        var blackRookOfKing = RookPiece.CreateBlackRookOfKing();
        var blackKnightOfKing = KnightPiece.CreateBlackKnightOfKing();
        var blackBishopOfKing = BishopPiece.CreateBlackBishopOfKing();
        var whitePawnA = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.A);
        var whitePawnB = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.B);
        var whitePawnC = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.C);
        var whitePawnD = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.D);
        var whitePawnE = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.E);
        var whitePawnF = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.F);
        var whitePawnG = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.G);
        var whitePawnH = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.White && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.H);
        var blackPawnA = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.A);
        var blackPawnB = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.B);
        var blackPawnC = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.C);
        var blackPawnD = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.D);
        var blackPawnE = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.E);
        var blackPawnF = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.F);
        var blackPawnG = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.G);
        var blackPawnH = allPawns.FirstOrDefault(pawn => pawn.ColorEnum == ColorEnum.Black && 
                                                 pawn.PieceAddressDto.Column == BoardColumnEnum.H);


        whiteRookOfQueen.AddPieceOnTheBoard(_board.Id, _board);
        whiteKnightOfQueen.AddPieceOnTheBoard(_board.Id, _board);
        whiteBishopOfQueen.AddPieceOnTheBoard(_board.Id, _board);
        whiteQueen.AddPieceOnTheBoard(_board.Id, _board);
        whiteKing.AddPieceOnTheBoard(_board.Id, _board);
        whiteRookOfKing.AddPieceOnTheBoard(_board.Id, _board);
        whiteKnightOfKing.AddPieceOnTheBoard(_board.Id, _board);
        whiteBishopOfKing.AddPieceOnTheBoard(_board.Id, _board);
        blackRookOfQueen.AddPieceOnTheBoard(_board.Id, _board);
        blackKnightOfQueen.AddPieceOnTheBoard(_board.Id, _board);
        blackBishopOfQueen.AddPieceOnTheBoard(_board.Id, _board);
        blackQueen.AddPieceOnTheBoard(_board.Id, _board);
        blackKing.AddPieceOnTheBoard(_board.Id, _board);
        blackRookOfKing.AddPieceOnTheBoard(_board.Id, _board);
        blackKnightOfKing.AddPieceOnTheBoard(_board.Id, _board);
        blackBishopOfKing.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnA?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnB?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnC?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnD?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnE?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnF?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnG?.AddPieceOnTheBoard(_board.Id, _board);
        whitePawnH?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnA?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnB?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnC?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnD?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnE?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnF?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnG?.AddPieceOnTheBoard(_board.Id, _board);
        blackPawnH?.AddPieceOnTheBoard(_board.Id, _board);

        WithPiece(whiteRookOfQueen, false);
        WithPiece(whiteKnightOfQueen, false);
        WithPiece(whiteBishopOfQueen, false);
        WithPiece(whiteQueen, false);
        WithPiece(whiteKing, false);
        WithPiece(whiteRookOfKing, false);
        WithPiece(whiteKnightOfKing, false);
        WithPiece(whiteBishopOfKing, false);
        WithPiece(blackRookOfQueen, false);
        WithPiece(blackKnightOfQueen, false);
        WithPiece(blackBishopOfQueen, false);
        WithPiece(blackQueen, false);
        WithPiece(blackKing, false);
        WithPiece(blackRookOfKing, false);
        WithPiece(blackKnightOfKing, false);
        WithPiece(blackBishopOfKing, false);
        if (whitePawnA is not null) WithPiece(whitePawnA, false);
        if (whitePawnB is not null) WithPiece(whitePawnB, false);
        if (whitePawnC is not null) WithPiece(whitePawnC, false);
        if (whitePawnD is not null) WithPiece(whitePawnD, false);
        if (whitePawnE is not null) WithPiece(whitePawnE, false);
        if (whitePawnF is not null) WithPiece(whitePawnF, false);
        if (whitePawnG is not null) WithPiece(whitePawnG, false);
        if (whitePawnH is not null) WithPiece(whitePawnH, false);
        if (blackPawnA is not null) WithPiece(blackPawnA, false);
        if (blackPawnB is not null) WithPiece(blackPawnB, false);
        if (blackPawnC is not null) WithPiece(blackPawnC, false);
        if (blackPawnD is not null) WithPiece(blackPawnD, false);
        if (blackPawnE is not null) WithPiece(blackPawnE, false);
        if (blackPawnF is not null) WithPiece(blackPawnF, false);
        if (blackPawnG is not null) WithPiece(blackPawnG, false);
        if (blackPawnH is not null) WithPiece(blackPawnH, false);
    }

    public BoardBuilder WithPiece(Piece piece, bool overlap = true)
    {
        if (overlap || Pieces == null) Pieces = new List<Piece>();
        Pieces.Add(piece);
        return this;
    }

    public BoardBuilder WithSquare(BoardSquare square, bool overlap = true)
    {
        if (overlap || Squares == null) Squares = new List<BoardSquare>();
        Squares.Add(square);
        return this;
    }

    public static BoardBuilder New() => new();

    public Board Build()
    {
        foreach (var square in Squares)
        {
            _board.AddSquare(square);
        }

        foreach (var piece in Pieces)
        {
            _board.AddPiece(piece);
        }

        return _board;
    }
}
