using Moreno.ChessGame.Domain.Dtos;
using Moreno.ChessGame.UnitaryTests.Shared.Mocks;

namespace Moreno.ChessGame.UnitaryTests.Domain.Entities;

public class PawnPieceEntityTest
{
    [Fact(DisplayName = "Should create white Pawn")]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldCreateWhitePawn()
    {
        // Arrange
        var expectedResponse =
            new PawnPieceEntity(ColorEnum.White, new(BoardColumnEnum.E, BoardRowEnum.Two));

        // Act
        var response = PawnPieceEntity.CreateWhitePawn(new(BoardColumnEnum.E, BoardRowEnum.Two));

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create black Pawn")]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldCreateBlackPawn()
    {
        // Arrange
        var expectedResponse =
            new PawnPieceEntity(ColorEnum.Black, new(BoardColumnEnum.E, BoardRowEnum.Seven));

        // Act
        var response = PawnPieceEntity.CreateBlackPawn(new(BoardColumnEnum.E, BoardRowEnum.Seven));

        // Assert
        response.ColorEnum.Should().Be(expectedResponse.ColorEnum);
        response.PieceAddressDto.Should().BeEquivalentTo(expectedResponse.PieceAddressDto);
    }

    [Fact(DisplayName = "Should create all Pawns")]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldCreateAllPawns()
    {
        // Arrange
        const int expectedCount = 16;

        // Act
        var response = PawnPieceEntity.CreateAllPawns();

        // Assert
        response.Should().HaveCount(expectedCount);
    }

    [Theory(DisplayName = "Should move to another address successfully")]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.E, BoardRowEnum.Three)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.E, BoardRowEnum.Four)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.E, BoardRowEnum.Six)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.E, BoardRowEnum.Five)]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldMoveToAnotherAddressSuccessfully(ColorEnum colorEnum,
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var pawn =
            new PawnPieceEntity(colorEnum, new(columnSource, rowSource));

        var board = BoardMock.Create();

        pawn.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        pawn.MoveTo(targetAddress);

        // Assert
        pawn.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        pawn.HasMoved.Should().BeTrue();
    }

    [Theory(DisplayName = "Shouldn't move two squares when it has already moved once.")]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Three, BoardColumnEnum.E, BoardRowEnum.Five)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.D, BoardRowEnum.Six, BoardColumnEnum.D, BoardRowEnum.Four)]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldMoveTwoSquaresWhenItHasAlreadyMovedOnce(ColorEnum colorEnum,
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var index = 1;
        if (colorEnum == ColorEnum.White) index = -1;
        var pawn =
            new PawnPieceEntity(colorEnum, new(columnSource, (BoardRowEnum)((byte)rowSource + index)));

        var board = BoardMock.Create();

        pawn.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnSource, rowSource);
        pawn.MoveTo(targetAddress);

        targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        pawn.MoveTo(targetAddress);

        // Assert
        pawn.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
    }

    [Theory(DisplayName = "Shouldn't move to wrong address")]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.E, BoardRowEnum.One)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.D, BoardRowEnum.Two)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.F, BoardRowEnum.Two)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.D, BoardRowEnum.One)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.F, BoardRowEnum.One)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.D, BoardRowEnum.Three)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.F, BoardRowEnum.Three)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.E, BoardRowEnum.Eight)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.D, BoardRowEnum.Seven)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.F, BoardRowEnum.Seven)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.D, BoardRowEnum.Eight)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.F, BoardRowEnum.Eight)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.D, BoardRowEnum.Six)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.F, BoardRowEnum.Six)]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldnotMoveToWrongAddress(ColorEnum colorEnum,
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var pawn =
            new PawnPieceEntity(colorEnum, new(columnSource, rowSource));

        var board = BoardMock.Create();

        pawn.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        pawn.MoveTo(targetAddress);

        // Assert
        pawn.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
    }

    [Theory(DisplayName = "Should moving to capture successfully")]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.D, BoardRowEnum.Three)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.F, BoardRowEnum.Three)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.D, BoardRowEnum.Six)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.F, BoardRowEnum.Six)]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldMovingToCaptureSuccessfully(ColorEnum colorEnum,
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var pawn =
            new PawnPieceEntity(colorEnum, new(columnSource, rowSource));

        var board = BoardMock.Create();

        pawn.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        pawn.MovingToCapture(targetAddress);

        // Assert
        pawn.PieceAddressDto.Should().BeEquivalentTo(targetAddress);
        pawn.HasMoved.Should().BeTrue();

    }

    [Theory(DisplayName = "Shouldn't moving to capture to wrong address")]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.E, BoardRowEnum.Three)]
    [InlineData(ColorEnum.White, BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.E, BoardRowEnum.Four)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.E, BoardRowEnum.Six)]
    [InlineData(ColorEnum.Black, BoardColumnEnum.E, BoardRowEnum.Seven, BoardColumnEnum.E, BoardRowEnum.Five)]
    [Trait("Pawn Piece", "Domain")]
    public void ShouldnotMovingToCaptureToWrongAddress(ColorEnum colorEnum,
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var pawn =
            new PawnPieceEntity(colorEnum, new(columnSource, rowSource));

        var board = BoardMock.Create();

        pawn.AddPieceOnTheBoard(board.Id, board);

        var targetAddress = new PieceAddressDto(columnTarget, rowTarget);

        // Act
        pawn.MovingToCapture(targetAddress);

        // Assert
        pawn.PieceAddressDto.Should().BeEquivalentTo(new PieceAddressDto(columnSource, rowSource));
    }
}
