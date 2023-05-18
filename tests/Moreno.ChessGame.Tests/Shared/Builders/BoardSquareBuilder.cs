using Bogus;
using Moreno.ChessGame.Domain.Entities;

namespace Moreno.ChessGame.UnitaryTests.Shared.Builders;

public class BoardSquareBuilder
{
    public Guid BoardId { get; private set; }
    public ColorEnum Color { get; private set; }
    public BoardColumnEnum Column { get; private set; }
    public BoardRowEnum Row { get; private set; }

    public BoardSquareBuilder()
    {
        var faker = new Faker();

        WithBoardId(Guid.NewGuid());
        WithColor (faker.PickRandom<ColorEnum>());
        WithColumn (faker.PickRandom<BoardColumnEnum>());
        WithRow (faker.PickRandom<BoardRowEnum>());
    }

    public BoardSquareBuilder WithBoardId(Guid boardId)
    {
        BoardId = boardId;
        return this;
    }
    public BoardSquareBuilder WithColor(ColorEnum color)
    {
        Color = color;
        return this;
    }
    public BoardSquareBuilder WithColumn(BoardColumnEnum column)
    {
        Column = column;
        return this;
    }
    public BoardSquareBuilder WithRow(BoardRowEnum row)
    {
        Row = row;
        return this;
    }

    public static BoardSquareBuilder New() => new();

    public BoardSquare Build() => new(
        BoardId,
        Color,
        Column,
        Row
    );
}
