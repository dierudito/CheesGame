using Moreno.ChessGame.Domain.Entities;
using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.UnitaryTests.Shared.Mocks;

public static class BoardMock
{
    public static BoardEntity Create()
    {
        var entity = new BoardEntity();
        var squares = CreateSquares(entity.Id);

        foreach (var square in squares)
        {
            entity.AddSquare(square);
        }

        return entity;
    }

    private static List<BoardSquareEntity> CreateSquares(Guid boardId) =>
        new List<BoardSquareEntity>
        {
            new(boardId, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.One),
            new(boardId, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.One),
            new(boardId, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.One),
            new(boardId, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.One),
            new(boardId, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.One),
            new(boardId, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.One),
            new(boardId, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.One),
            new(boardId, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.One),

            new(boardId, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Two),
            new(boardId, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Two),
            new(boardId, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Two),
            new(boardId, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Two),
            new(boardId, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two),
            new(boardId, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Two),
            new(boardId, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Two),
            new(boardId, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Two),

            new(boardId, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Three),
            new(boardId, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Three),
            new(boardId, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Three),
            new(boardId, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Three),
            new(boardId, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Three),
            new(boardId, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Three),
            new(boardId, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Three),
            new(boardId, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Three),

            new(boardId, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Four),
            new(boardId, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Four),
            new(boardId, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Four),
            new(boardId, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Four),
            new(boardId, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Four),
            new(boardId, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Four),
            new(boardId, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Four),
            new(boardId, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Four),

            new(boardId, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Five),
            new(boardId, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Five),
            new(boardId, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Five),
            new(boardId, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Five),
            new(boardId, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Five),
            new(boardId, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Five),
            new(boardId, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Five),
            new(boardId, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Five),

            new(boardId, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Six),
            new(boardId, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Six),
            new(boardId, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Six),
            new(boardId, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Six),
            new(boardId, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Six),
            new(boardId, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Six),
            new(boardId, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Six),
            new(boardId, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Six),

            new(boardId, ColorEnum.Black, BoardColumnEnum.A, BoardRowEnum.Seven),
            new(boardId, ColorEnum.White, BoardColumnEnum.B, BoardRowEnum.Seven),
            new(boardId, ColorEnum.Black, BoardColumnEnum.C, BoardRowEnum.Seven),
            new(boardId, ColorEnum.White, BoardColumnEnum.D, BoardRowEnum.Seven),
            new(boardId, ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven),
            new(boardId, ColorEnum.White, BoardColumnEnum.F, BoardRowEnum.Seven),
            new(boardId, ColorEnum.Black, BoardColumnEnum.G, BoardRowEnum.Seven),
            new(boardId, ColorEnum.White, BoardColumnEnum.H, BoardRowEnum.Seven),

            new(boardId, ColorEnum.White, BoardColumnEnum.A, BoardRowEnum.Eight),
            new(boardId, ColorEnum.Black, BoardColumnEnum.B, BoardRowEnum.Eight),
            new(boardId, ColorEnum.White, BoardColumnEnum.C, BoardRowEnum.Eight),
            new(boardId, ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Eight),
            new(boardId, ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Eight),
            new(boardId, ColorEnum.Black, BoardColumnEnum.F, BoardRowEnum.Eight),
            new(boardId, ColorEnum.White, BoardColumnEnum.G, BoardRowEnum.Eight),
            new(boardId, ColorEnum.Black, BoardColumnEnum.H, BoardRowEnum.Eight)
        };
}
