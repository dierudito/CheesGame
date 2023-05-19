using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class QueenPieceEntityTest
{
    [Fact(DisplayName = "Should create white Queen")]
    [Trait(nameof(QueenPiece), "Create Queen")]
    public void ShouldCreateWhiteQueen()
    {
        // Arrange
        var expectedResponse =
            new QueenPiece(ColorEnum.White, new(BoardColumnEnum.D, BoardRowEnum.One));

        // Act
        var response = QueenPiece.CreateWhiteQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create black Queen")]
    [Trait(nameof(QueenPiece), "Create Queen")]
    public void ShouldCreateBlackQueen()
    {
        // Arrange
        var expectedResponse =
            new QueenPiece(ColorEnum.Black, new(BoardColumnEnum.E, BoardRowEnum.Eight));

        // Act
        var response = QueenPiece.CreateBlackQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create all Queens")]
    [Trait(nameof(QueenPiece), "Create Queen")]
    public void ShouldCreateAllQueens()
    {
        // Arrange
        const int expectedCount = 2;

        // Act
        var response = QueenPiece.CreateAllQueens();

        // Assert
        response.Should().HaveCount(expectedCount);
    }

    [Theory(DisplayName = "Should move to another address successfully")]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.C, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.E, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.C, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.E, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.A, BoardRowEnum.Four)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.H, BoardRowEnum.Five)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.A, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.H, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.D, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.F, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.B, BoardRowEnum.One)]
    [Trait(nameof(QueenPiece), nameof(QueenPiece.MoveTo))]
    public void ShouldMoveToAnotherAddressSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var queen =
            new QueenPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        queen.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        queen.MoveTo(targetAddress);

        // Assert
        queen.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        queen.HasMoved.Should().BeTrue();
    }

    [Theory(DisplayName = "Shouldn't move to wrong address")]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.F, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.A, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.Four)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.G, BoardRowEnum.Five)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.One, BoardColumnEnum.C, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.C, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.E, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.G, BoardRowEnum.One)]
    [Trait(nameof(QueenPiece), nameof(QueenPiece.MoveTo))]
    public void ShouldnotMoveToWrongAddress(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var queen =
            new QueenPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        queen.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        queen.MoveTo(targetAddress);

        // Assert
        queen.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
        queen.HasMoved.Should().BeFalse();
    }
}
