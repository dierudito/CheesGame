using Moq;
using Moq.AutoMock;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Services;
using Moreno.ChessGame.UnitaryTests.Shared.Builders;

namespace Moreno.ChessGame.UnitaryTests.Domain.Services;

public class BishopServiceTest
{
    private readonly Mock<IBishopRepository> _bishopRepository;
    private readonly Mock<IBoardRepository> _boardRepository;
    private readonly BishopService _service;

    public BishopServiceTest()
    {
        var mocker = new AutoMocker();
        _bishopRepository = mocker.GetMock<IBishopRepository>();
        _boardRepository = mocker.GetMock<IBoardRepository>();
        _service = mocker.CreateInstance<BishopService>();
    }

    [Theory(DisplayName = "Should move successfully")]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.H, BoardRowEnum.Six)]
    [Trait(nameof(BishopService), nameof(BishopService.MoveAsync))]
    public async Task ShouldMoveSuccessfully(BoardColumnEnum column, BoardRowEnum row)
    {
        // Arrange
        var bishopPiece = BishopPiece.CreateWhiteBishopOfQueen();
        var board = BoardBuilder.New().WithPiece(bishopPiece).Build();

        bishopPiece.AddPieceOnTheBoard(board.Id, board);

        bishopPiece.MoveTo(new(column, row));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(bishopPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _bishopRepository.Verify(repository => repository.UpdateAsync(It.IsAny<BishopPiece>()), Times.Once);
    }

    [Theory(DisplayName = "Should move successfully when there's opponent's piece on target")]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.H, BoardRowEnum.Six)]
    [Trait(nameof(BishopService), nameof(BishopService.MoveAsync))]
    public async Task ShouldMoveSuccessfullyWhenThereIsOpponentsPieceOnTarget(BoardColumnEnum column, BoardRowEnum row)
    {
        // Arrange
        var opponentsBishopPiece = new BishopPiece(ColorEnum.Black, new(column, row));
        var bishopPiece = BishopPiece.CreateWhiteBishopOfQueen();
        var board = 
            BoardBuilder.New().WithPiece(bishopPiece).WithPiece(opponentsBishopPiece).Build();

        bishopPiece.AddPieceOnTheBoard(board.Id, board);
        opponentsBishopPiece.AddPieceOnTheBoard(board.Id, board);

        bishopPiece.MoveTo(new(column, row));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(bishopPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _bishopRepository.Verify(repository => repository.UpdateAsync(It.IsAny<BishopPiece>()), Times.Once);
    }

    [Fact(DisplayName = "Shouldn't move when there are other pieces in the way")]
    [Trait(nameof(BishopService), nameof(BishopService.MoveAsync))]
    public async Task ShouldnotMoveWhenThereAreOtherPiecesInTheWay()
    {
        // Arrange
        var pieceInTheWay = new PawnPiece(ColorEnum.White, new(BoardColumnEnum.B, BoardRowEnum.Two));
        var bishopPiece = BishopPiece.CreateWhiteBishopOfQueen();
        var board = BoardBuilder.New().WithPiece(bishopPiece).WithPiece(pieceInTheWay).Build();

        bishopPiece.AddPieceOnTheBoard(board.Id, board);
        pieceInTheWay.AddPieceOnTheBoard(board.Id, board);

        bishopPiece.MoveTo(new(BoardColumnEnum.A, BoardRowEnum.Three));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(bishopPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _bishopRepository.Verify(repository => repository.UpdateAsync(It.IsAny<BishopPiece>()), Times.Never);
    }

    [Theory(DisplayName = "Shouldn't move successfully when there's own piece is on target")]
    [InlineData(BoardColumnEnum.A, BoardRowEnum.Three)]
    [InlineData(BoardColumnEnum.H, BoardRowEnum.Six)]
    [Trait(nameof(BishopService), nameof(BishopService.MoveAsync))]
    public async Task ShouldnotMoveWhenThereIsOwnPieceIsOnTarget(BoardColumnEnum column, BoardRowEnum row)
    {
        // Arrange
        var ownOtherPiece = new PawnPiece(ColorEnum.White, new(column, row));
        var bishopPiece = BishopPiece.CreateWhiteBishopOfQueen();
        var board =
            BoardBuilder.New().WithPiece(bishopPiece).WithPiece(ownOtherPiece).Build();

        bishopPiece.AddPieceOnTheBoard(board.Id, board);
        ownOtherPiece.AddPieceOnTheBoard(board.Id, board);

        bishopPiece.MoveTo(new(column, row));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(bishopPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _bishopRepository.Verify(repository => repository.UpdateAsync(It.IsAny<BishopPiece>()), Times.Never);
    }
}
