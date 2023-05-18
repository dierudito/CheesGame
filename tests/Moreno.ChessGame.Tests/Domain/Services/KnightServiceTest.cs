using Moq.AutoMock;
using Moq;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Services;
using Moreno.ChessGame.UnitaryTests.Shared.Builders;

namespace Moreno.ChessGame.UnitaryTests.Domain.Services;

public class KnightServiceTest
{
    private readonly Mock<IKnightRepository> _knightRepository;
    private readonly Mock<IBoardRepository> _boardRepository;
    private readonly KnightService _service;

    public KnightServiceTest()
    {
        var mocker = new AutoMocker();
        _knightRepository = mocker.GetMock<IKnightRepository>();
        _boardRepository = mocker.GetMock<IBoardRepository>();
        _service = mocker.CreateInstance<KnightService>();
    }

    [Fact(DisplayName = "Should move successfully")]
    [Trait(nameof(KnightService), nameof(KnightService.MoveAsync))]
    public async Task ShouldMoveSuccessfully()
    {
        // Arrange
        var knightPiece = KnightPiece.CreateWhiteKnightOfKing();
        var board = BoardBuilder.New().WithPiece(knightPiece).Build();

        knightPiece.AddPieceOnTheBoard(board.Id, board);

        knightPiece.MoveTo(new(BoardColumnEnum.F, BoardRowEnum.Three));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(knightPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _knightRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KnightPiece>()), Times.Once);
    }

    [Fact(DisplayName = "Should move successfully when there's opponent's piece on target")]
    [Trait(nameof(KnightService), nameof(KnightService.MoveAsync))]
    public async Task ShouldMoveSuccessfullyWhenThereIsOpponentsPieceOnTarget()
    {
        // Arrange
        var otherPiece = PawnPiece.CreateBlackPawn(new(BoardColumnEnum.F, BoardRowEnum.Three));
        var knightPiece = KnightPiece.CreateWhiteKnightOfKing();
        var board = BoardBuilder.New().WithPiece(knightPiece).WithPiece(otherPiece, false).Build();

        otherPiece.AddPieceOnTheBoard(board.Id, board);
        knightPiece.AddPieceOnTheBoard(board.Id, board);

        knightPiece.MoveTo(new(BoardColumnEnum.F, BoardRowEnum.Three));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(knightPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _knightRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KnightPiece>()), Times.Once);
    }

    [Fact(DisplayName = "Shouldn't move to an occupied square")]
    [Trait(nameof(KnightService), nameof(KnightService.MoveAsync))]
    public async Task ShouldnotMoveToAnOccupiedSquare()
    {
        // Arrange
        var otherPiece = PawnPiece.CreateWhitePawn(new(BoardColumnEnum.F, BoardRowEnum.Three));
        var knightPiece = KnightPiece.CreateWhiteKnightOfKing();
        var board = BoardBuilder.New().WithPiece(knightPiece).WithPiece(otherPiece, false).Build();

        otherPiece.AddPieceOnTheBoard(board.Id, board);
        knightPiece.AddPieceOnTheBoard(board.Id, board);

        knightPiece.MoveTo(new(BoardColumnEnum.F, BoardRowEnum.Three));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(knightPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _knightRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KnightPiece>()), Times.Never);
    }
}
