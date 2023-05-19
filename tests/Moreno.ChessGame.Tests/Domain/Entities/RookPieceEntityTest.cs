using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class RookPieceEntityTest
{
    [Fact(DisplayName = "Should create white Rook of Queen")]
    [Trait(nameof(RookPiece), "Create Rook")]
    public void ShouldCreateWhiteRookOfQueen()
    {
        // Arrange
        var expectedResponse =
            new RookPiece(ColorEnum.White, new(BoardColumnEnum.A, BoardRowEnum.One));

        // Act
        var response = RookPiece.CreateWhiteRookOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create white Rook of King")]
    [Trait(nameof(RookPiece), "Create Rook")]
    public void ShouldCreateWhiteRookOfKing()
    {
        // Arrange
        var expectedResponse =
            new RookPiece(ColorEnum.White, new(BoardColumnEnum.H, BoardRowEnum.One));

        // Act
        var response = RookPiece.CreateWhiteRookOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create black Rook of Queen")]
    [Trait(nameof(RookPiece), "Create Rook")]
    public void ShouldCreateBlackRookOfQueen()
    {
        // Arrange
        var expectedResponse =
            new RookPiece(ColorEnum.Black, new(BoardColumnEnum.H, BoardRowEnum.Eight));

        // Act
        var response = RookPiece.CreateBlackRookOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create black Rook of King")]
    [Trait(nameof(RookPiece), "Create Rook")]
    public void ShouldCreateBlackRookOfKing()
    {
        // Arrange
        var expectedResponse =
            new RookPiece(ColorEnum.Black, new(BoardColumnEnum.A, BoardRowEnum.Eight));

        // Act
        var response = RookPiece.CreateBlackRookOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create all Rooks")]
    [Trait(nameof(RookPiece), "Create Rook")]
    public void ShouldCreateAllRooks()
    {
        // Arrange
        const int expectedCount = 4;

        // Act
        var response = RookPiece.CreateAllRooks();

        // Assert
        response.Should().HaveCount(expectedCount);
    }

    [Theory(DisplayName = "Should move to another address successfully")]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.A, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.A, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.H, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.D, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.D, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.D, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.A, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.C, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.E, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.H, BoardRowEnum.Three)]
    [Trait(nameof(RookPiece), nameof(RookPiece.MoveTo))]
    public void ShouldMoveToAnotherAddressSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var rook =
            new RookPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        rook.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        rook.MoveTo(targetAddress);

        // Assert
        rook.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        rook.HasMoved.Should().BeTrue();
    }

    [Theory(DisplayName = "Shouldn't move to wrong address")]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.One, BoardColumnEnum.H, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.C, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.C, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.C, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.A, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.C, BoardRowEnum.Six)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.E, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.D, BoardRowEnum.Three, BoardColumnEnum.H, BoardRowEnum.Four)]
    [Trait(nameof(RookPiece), nameof(RookPiece.MoveTo))]
    public void ShouldnotMoveToWrongAddress(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var rook =
            new RookPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        rook.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        rook.MoveTo(targetAddress);

        // Assert
        rook.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
        rook.HasMoved.Should().BeFalse();
    }
}
