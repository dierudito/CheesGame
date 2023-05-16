using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class KnightPieceEntityTest
{
    [Fact(DisplayName = "Should create white Knight of Queen")]
    [Trait("Knight Piece", "Domain")]
    public void ShouldCreateWhiteKnightOfQueen()
    {
        // Arrange
        var expectedResponse =
            new KnightPieceEntity(ColorEnum.White, new(BoardColumnEnum.B, BoardRowEnum.One));

        // Act
        var response = KnightPieceEntity.CreateWhiteKnightOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create white Knight of King")]
    [Trait("Knight Piece", "Domain")]
    public void ShouldCreateWhiteKnightOfKing()
    {
        // Arrange
        var expectedResponse =
            new KnightPieceEntity(ColorEnum.White, new(BoardColumnEnum.G, BoardRowEnum.One));

        // Act
        var response = KnightPieceEntity.CreateWhiteKnightOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create black Knight of Queen")]
    [Trait("Knight Piece", "Domain")]
    public void ShouldCreateBlackKnightOfQueen()
    {
        // Arrange
        var expectedResponse =
            new KnightPieceEntity(ColorEnum.Black, new(BoardColumnEnum.G, BoardRowEnum.Eight));

        // Act
        var response = KnightPieceEntity.CreateBlackKnightOfQueen();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create black Knight of King")]
    [Trait("Knight Piece", "Domain")]
    public void ShouldCreateBlackKnightOfKing()
    {
        // Arrange
        var expectedResponse =
            new KnightPieceEntity(ColorEnum.Black, new(BoardColumnEnum.B, BoardRowEnum.Eight));

        // Act
        var response = KnightPieceEntity.CreateBlackKnightOfKing();

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }
    [Fact(DisplayName = "Should create all Knights")]
    [Trait("Knight Piece", "Domain")]
    public void ShouldCreateAllKnights()
    {
        // Arrange
        const int expectedCount = 4;

        // Act
        var response = KnightPieceEntity.CreateAllKnights();

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
    [Trait("Knight Piece", "Domain")]
    public void ShouldMoveToAnotherAddressSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var knight =
            new KnightPieceEntity(ColorEnum.White, new(columnSource, rowSource));

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
    [Trait("Knight Piece", "Domain")]
    public void ShouldnotMoveToWrongAddress(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var knight =
            new KnightPieceEntity(ColorEnum.White, new(columnSource, rowSource));

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
