using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class BishopPieceEntityTest
{
    [Fact(DisplayName = "Should create white Bishop of Queen")]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.CreateWhiteBishopOfQueen))]
    public void ShouldCreateWhiteBishopOfQueen()
    {
        // Arrange
        var expectedResponse =
            new BishopPiece(ColorEnum.White, new(BoardColumnEnum.C, BoardRowEnum.One));

        // Act
        var response = BishopPiece.CreateWhiteBishopOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create white Bishop of King")]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.CreateWhiteBishopOfKing))]
    public void ShouldCreateWhiteBishopOfKing()
    {
        // Arrange
        var expectedResponse =
            new BishopPiece(ColorEnum.White, new(BoardColumnEnum.F, BoardRowEnum.One));

        // Act
        var response = BishopPiece.CreateWhiteBishopOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create black Bishop of Queen")]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.CreateBlackBishopOfQueen))]
    public void ShouldCreateBlackBishopOfQueen()
    {
        // Arrange
        var expectedResponse =
            new BishopPiece(ColorEnum.Black, new(BoardColumnEnum.F, BoardRowEnum.Eight));

        // Act
        var response = BishopPiece.CreateBlackBishopOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create black Bishop of King")]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.CreateBlackBishopOfKing))]
    public void ShouldCreateBlackBishopOfKing()
    {
        // Arrange
        var expectedResponse =
            new BishopPiece(ColorEnum.Black, new(BoardColumnEnum.C, BoardRowEnum.Eight));

        // Act
        var response = BishopPiece.CreateBlackBishopOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create all Bishops")]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.CreateAllBishops))]
    public void ShouldCreateAllBishops()
    {
        // Arrange
        const int expectedCount = 4;

        // Act
        var response = BishopPiece.CreateAllBishops();

        // Assert
        response.Should().HaveCount(expectedCount);
    }

    [Theory(DisplayName = "Should move to another address successfully")]
    [InlineData(BoardColumnEnum.C, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Four, BoardColumnEnum.G, BoardRowEnum.Seven)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Five, BoardColumnEnum.H, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.Two, BoardColumnEnum.G, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.G, BoardRowEnum.Eight, BoardColumnEnum.A, BoardRowEnum.Two)]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.MoveTo))]
    public void ShouldMoveToAnotherAddressSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var bishop =
            new BishopPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        bishop.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        bishop.MoveTo(targetAddress);

        // Assert
        bishop.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        bishop.HasMoved.Should().BeTrue();
    }

    [Theory(DisplayName = "Shouldn't move to wrong address")]
    [InlineData(BoardColumnEnum.C, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Four, BoardColumnEnum.G, BoardRowEnum.Six)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Five, BoardColumnEnum.H, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.Two, BoardColumnEnum.G, BoardRowEnum.Seven)]
    [InlineData(BoardColumnEnum.G, BoardRowEnum.Eight, BoardColumnEnum.A, BoardRowEnum.Three)]
    [Trait(nameof(BishopPiece), nameof(BishopPiece.MoveTo))]
    public void ShouldnotMoveToWrongAddress(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var bishop =
            new BishopPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        bishop.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        bishop.MoveTo(targetAddress);

        // Assert
        bishop.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
        bishop.HasMoved.Should().BeFalse();
    }
}
