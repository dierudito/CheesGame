using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class KnightPieceEntityTest
{
    [Fact(DisplayName = "Should create white Knight of Queen")]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.CreateWhiteKnightOfQueen))]
    public void ShouldCreateWhiteKnightOfQueen()
    {
        // Arrange
        var expectedResponse =
            new KnightPiece(ColorEnum.White, new(BoardColumnEnum.B, BoardRowEnum.One));

        // Act
        var response = KnightPiece.CreateWhiteKnightOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create white Knight of King")]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.CreateWhiteKnightOfKing))]
    public void ShouldCreateWhiteKnightOfKing()
    {
        // Arrange
        var expectedResponse =
            new KnightPiece(ColorEnum.White, new(BoardColumnEnum.G, BoardRowEnum.One));

        // Act
        var response = KnightPiece.CreateWhiteKnightOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create black Knight of Queen")]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.CreateBlackKnightOfQueen))]
    public void ShouldCreateBlackKnightOfQueen()
    {
        // Arrange
        var expectedResponse =
            new KnightPiece(ColorEnum.Black, new(BoardColumnEnum.G, BoardRowEnum.Eight));

        // Act
        var response = KnightPiece.CreateBlackKnightOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create black Knight of King")]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.CreateBlackKnightOfKing))]
    public void ShouldCreateBlackKnightOfKing()
    {
        // Arrange
        var expectedResponse =
            new KnightPiece(ColorEnum.Black, new(BoardColumnEnum.B, BoardRowEnum.Eight));

        // Act
        var response = KnightPiece.CreateBlackKnightOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create all Knights")]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.CreateAllKnights))]
    public void ShouldCreateAllKnights()
    {
        // Arrange
        const int expectedCount = 4;

        // Act
        var response = KnightPiece.CreateAllKnights();

        // Assert
        response.Should().HaveCount(expectedCount);
    }

    [Theory(DisplayName = "Should move to another address successfully")]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.One, BoardColumnEnum.C, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.One, BoardColumnEnum.A, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.D, BoardRowEnum.Seven)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.F, BoardRowEnum.Seven)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.C, BoardRowEnum.Six)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.G, BoardRowEnum.Six)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.C, BoardRowEnum.Four)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.G, BoardRowEnum.Four)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.D, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.F, BoardRowEnum.Three)]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.MoveTo))]
    public void ShouldMoveToAnotherAddressSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var knight =
            new KnightPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        knight.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        knight.MoveTo(targetAddress);

        // Assert
        knight.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        knight.HasMoved.Should().BeTrue();
    }

    [Theory(DisplayName = "Shouldn't move to wrong address")]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.One, BoardColumnEnum.B, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.D, BoardRowEnum.Eight)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Five, BoardColumnEnum.F, BoardRowEnum.Eight)]
    [Trait(nameof(KnightPiece), nameof(KnightPiece.MoveTo))]
    public void ShouldnotMoveToWrongAddress(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var knight =
            new KnightPiece(ColorEnum.White, new(columnSource, rowSource));

        var board = BoardMock.Create();

        knight.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        knight.MoveTo(targetAddress);

        // Assert
        knight.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
        knight.HasMoved.Should().BeFalse();
    }
}
