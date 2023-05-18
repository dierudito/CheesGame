using Moq;
using Moq.AutoMock;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Services;
using Moreno.ChessGame.UnitaryTests.Shared.Builders;

namespace Moreno.ChessGame.UnitaryTests.Domain.Services;

public class PawnServiceTest
{
    private readonly Mock<IPawnRepository> _pawnRepository;
    private readonly Mock<IBoardRepository> _boardRepository;
    private readonly PawnService _service;

    public PawnServiceTest()
    {
        var mocker = new AutoMocker();
        _pawnRepository = mocker.GetMock<IPawnRepository>();
        _boardRepository = mocker.GetMock<IBoardRepository>();
        _service = mocker.CreateInstance<PawnService>();
    }

    [Theory(DisplayName = "Should move white pawn successfully")]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Two, BoardColumnEnum.B, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Two, BoardColumnEnum.B, BoardRowEnum.Four)]
    [Trait("Pawn Piece", "Service")]
    public async Task ShouldMoveWhitePawnSuccessfully(BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var pawnPiece = PawnPiece.CreateWhitePawn(new(columnSource, rowSource));
        var board = BoardBuilder.New().WithPiece(pawnPiece).Build();

        pawnPiece.AddPieceOnTheBoard(board.Id, board);

        pawnPiece.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(pawnPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _pawnRepository.Verify(repository => repository.UpdateAsync(It.IsAny<PawnPiece>()), Times.Once);
    }

    [Theory(DisplayName = "Should move black pawn successfully")]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Seven, BoardColumnEnum.B, BoardRowEnum.Six)]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Seven, BoardColumnEnum.B, BoardRowEnum.Five)]
    [Trait("Pawn Piece", "Service")]
    public async Task ShouldMoveBlackPawnSuccessfully(BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var pawnPiece = PawnPiece.CreateBlackPawn(new(columnSource, rowSource));
        var board = BoardBuilder.New().WithPiece(pawnPiece).Build();

        pawnPiece.AddPieceOnTheBoard(board.Id, board);

        pawnPiece.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(pawnPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _pawnRepository.Verify(repository => repository.UpdateAsync(It.IsAny<PawnPiece>()), Times.Once);
    }

    [Theory(DisplayName = "Shouldn't move white pawn to an occupied square")]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Two, BoardColumnEnum.B, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Two, BoardColumnEnum.B, BoardRowEnum.Four)]
    [Trait("Pawn Piece", "Service")]
    public async Task ShouldnotMoveWhitePawnToAnOccupiedSquare(BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var otherPawnPiece = PawnPiece.CreateWhitePawn(new(columnTarget, rowTarget));
        var pawnPieceToMove = PawnPiece.CreateWhitePawn(new(columnSource, rowSource));
        var board =
            BoardBuilder.New().WithPiece(pawnPieceToMove).WithPiece(otherPawnPiece, false).Build();

        pawnPieceToMove.AddPieceOnTheBoard(board.Id, board);
        otherPawnPiece.AddPieceOnTheBoard(board.Id, board);

        pawnPieceToMove.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(pawnPieceToMove);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _pawnRepository.Verify(repository => repository.UpdateAsync(It.IsAny<PawnPiece>()), Times.Never);
    }

    [Theory(DisplayName = "Shouldn't move black pawn to an occupied square")]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Seven, BoardColumnEnum.B, BoardRowEnum.Six)]
    [InlineData(BoardColumnEnum.B, BoardRowEnum.Seven, BoardColumnEnum.B, BoardRowEnum.Five)]
    [Trait("Pawn Piece", "Service")]
    public async Task ShouldnotMoveBlackPawnToAnOccupiedSquare(BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var otherPawnPiece = PawnPiece.CreateBlackPawn(new(columnTarget, rowTarget));
        var pawnPieceToMove = PawnPiece.CreateBlackPawn(new(columnSource, rowSource));
        var board =
            BoardBuilder.New().WithPiece(pawnPieceToMove).WithPiece(otherPawnPiece, false).Build();

        pawnPieceToMove.AddPieceOnTheBoard(board.Id, board);
        otherPawnPiece.AddPieceOnTheBoard(board.Id, board);

        pawnPieceToMove.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(pawnPieceToMove);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _pawnRepository.Verify(repository => repository.UpdateAsync(It.IsAny<PawnPiece>()), Times.Never);
    }
}
