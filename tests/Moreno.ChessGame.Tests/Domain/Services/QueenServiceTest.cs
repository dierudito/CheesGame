using Moq.AutoMock;
using Moq;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Services;
using Moreno.ChessGame.UnitaryTests.Shared.Builders;

namespace Moreno.ChessGame.UnitaryTests.Domain.Services;

public class QueenServiceTest
{
    private readonly Mock<IQueenRepository> _queenRepository;
    private readonly Mock<IBoardRepository> _boardRepository;
    private readonly QueenService _service;

    public QueenServiceTest()
    {
        var mocker = new AutoMocker();
        _queenRepository = mocker.GetMock<IQueenRepository>();
        _boardRepository = mocker.GetMock<IBoardRepository>();
        _service = mocker.CreateInstance<QueenService>();
    }

    [Fact(DisplayName = "Should move successfully")]
    [Trait(nameof(QueenService), nameof(QueenService.MoveAsync))]
    public async Task ShouldMoveSuccessfully()
    {
        // Arrange
        var pawnPiece = PawnPiece.CreateWhitePawn(new(BoardColumnEnum.D, BoardRowEnum.Two));
        var queenPiece = QueenPiece.CreateWhiteQueen();
        var board = BoardBuilder.New().WithPiece(pawnPiece).WithPiece(queenPiece).Build();

        pawnPiece.AddPieceOnTheBoard(board.Id, board);
        queenPiece.AddPieceOnTheBoard(board.Id, board);

        pawnPiece.SetAsCaptured();
        queenPiece.MoveTo(new(BoardColumnEnum.D, BoardRowEnum.Two));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(queenPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _queenRepository.Verify(repository => repository.UpdateAsync(It.IsAny<QueenPiece>()), Times.Once);
    }

    [Fact(DisplayName = "Shouldn't move to an occupied square")]
    [Trait(nameof(QueenService), nameof(QueenService.MoveAsync))]
    public async Task ShouldnotMoveToAnOccupiedSquare()
    {
        // Arrange
        var pawnPiece = PawnPiece.CreateWhitePawn(new(BoardColumnEnum.D, BoardRowEnum.Two));
        var queenPiece = QueenPiece.CreateWhiteQueen();
        var board = BoardBuilder.New().WithPiece(pawnPiece).WithPiece(queenPiece).Build();

        pawnPiece.AddPieceOnTheBoard(board.Id, board);
        queenPiece.AddPieceOnTheBoard(board.Id, board);

        queenPiece.MoveTo(new(BoardColumnEnum.D, BoardRowEnum.Two));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(queenPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _queenRepository.Verify(repository => repository.UpdateAsync(It.IsAny<QueenPiece>()), Times.Never);
    }
}
