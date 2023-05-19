using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class KingPieceEntityTest
{
    [Fact(DisplayName = "Should create white King")]
    [Trait(nameof(KingPiece), "Create King")]
    public void ShouldCreateWhiteKing()
    {
        // Arrange
        var expectedResponse =
            new KingPiece(ColorEnum.White, new(BoardColumnEnum.E, BoardRowEnum.One));

        // Act
        var response = KingPiece.CreateWhiteKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create black King")]
    [Trait(nameof(KingPiece), "Create King")]
    public void ShouldCreateBlackKing()
    {
        // Arrange
        var expectedResponse =
            new KingPiece(ColorEnum.Black, new(BoardColumnEnum.D, BoardRowEnum.Eight));

        // Act
        var response = KingPiece.CreateBlackKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create all Kings")]
    [Trait(nameof(KingPiece), "Create King")]
    public void ShouldCreateAllKings()
    {
        // Arrange
        const int expectedCount = 2;

        // Act
        var response = KingPiece.CreateAllKings();

        // Assert
        response.Should().HaveCount(expectedCount);
    }

    [Theory(DisplayName = "Should move to another address successfully")]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.E, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.F, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.F, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.C, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.G, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.F, BoardRowEnum.Four)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.E, BoardRowEnum.Four)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.D, BoardRowEnum.Four)]
    [Trait(nameof(KingPiece), nameof(KingPiece.MoveTo))]
    public void ShouldMoveToAnotherAddressSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var king =
            new KingPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        king.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        king.MoveTo(targetAddress);

        // Assert
        king.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        king.HasMoved.Should().BeTrue();
    }

    [Theory(DisplayName = "Shouldn't move to wrong address")]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.C, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.E, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.F, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.G, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.H, BoardRowEnum.One)]
    [Trait(nameof(KingPiece), nameof(KingPiece.MoveTo))]
    public void ShouldnotMoveToWrongAddress(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var king =
            new KingPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        king.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        king.MoveTo(targetAddress);

        // Assert
        king.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
        king.HasMoved.Should().BeFalse();
    }

    [Theory(DisplayName = "Shouldn't move to wrong address when already moved")]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.G, BoardRowEnum.One)]
    [Trait(nameof(KingPiece), nameof(KingPiece.MoveTo))]
    public void ShouldnotMoveToWrongAddressWhenAlreadyMoved(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var king =
            new KingPiece(ColorEnum.White, new(columnSource, rowSource - 1));

        var board = BoardMock.Create();

        king.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnSource, rowSource);
        king.MoveTo(targetAddress);

        targetAddress = new(columnTarget, rowTarget);

        // Act
        king.MoveTo(targetAddress);

        // Assert
        king.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
    }
}
