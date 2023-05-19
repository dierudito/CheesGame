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
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.One));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.One));

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Two));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Two));

        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Three));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Three));

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Four));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Four));

        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Five));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Five));

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Six));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Six));

        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Seven));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Seven));

        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Eight));
        WithSquare(new(_board.Id, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Eight));
    }

    public BoardBuilder WithPiece(Piece piece, bool overlap = false)
    {
        if (overlap || Pieces == null) Pieces = new List<Piece>();
        Pieces.Add(piece);
        return this;
    }

    public BoardBuilder WithSquare(BoardSquare square, bool overlap = false)
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

    public BoardBuilder WithAllTheChessPieces()
    {

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

        WithPiece(whiteRookOfQueen);
        WithPiece(whiteKnightOfQueen);
        WithPiece(whiteBishopOfQueen);
        WithPiece(whiteQueen);
        WithPiece(whiteKing);
        WithPiece(whiteRookOfKing);
        WithPiece(whiteKnightOfKing);
        WithPiece(whiteBishopOfKing);
        WithPiece(blackRookOfQueen);
        WithPiece(blackKnightOfQueen);
        WithPiece(blackBishopOfQueen);
        WithPiece(blackQueen);
        WithPiece(blackKing);
        WithPiece(blackRookOfKing);
        WithPiece(blackKnightOfKing);
        WithPiece(blackBishopOfKing);
        if (whitePawnA is not null) WithPiece(whitePawnA);
        if (whitePawnB is not null) WithPiece(whitePawnB);
        if (whitePawnC is not null) WithPiece(whitePawnC);
        if (whitePawnD is not null) WithPiece(whitePawnD);
        if (whitePawnE is not null) WithPiece(whitePawnE);
        if (whitePawnF is not null) WithPiece(whitePawnF);
        if (whitePawnG is not null) WithPiece(whitePawnG);
        if (whitePawnH is not null) WithPiece(whitePawnH);
        if (blackPawnA is not null) WithPiece(blackPawnA);
        if (blackPawnB is not null) WithPiece(blackPawnB);
        if (blackPawnC is not null) WithPiece(blackPawnC);
        if (blackPawnD is not null) WithPiece(blackPawnD);
        if (blackPawnE is not null) WithPiece(blackPawnE);
        if (blackPawnF is not null) WithPiece(blackPawnF);
        if (blackPawnG is not null) WithPiece(blackPawnG);
        if (blackPawnH is not null) WithPiece(blackPawnH);

        return this;
    }
}
