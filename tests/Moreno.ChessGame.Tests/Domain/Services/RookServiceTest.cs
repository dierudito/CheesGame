using Moq.AutoMock;
using Moq;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Services;
using Moreno.ChessGame.UnitaryTests.Shared.Builders;

namespace Moreno.ChessGame.UnitaryTests.Domain.Services;

public class RookServiceTest
{
    private readonly Mock<IRookRepository> _rookRepository;
    private readonly Mock<IBoardRepository> _boardRepository;
    private readonly RookService _service;

    public RookServiceTest()
    {
        var mocker = new AutoMocker();
        _rookRepository = mocker.GetMock<IRookRepository>();
        _boardRepository = mocker.GetMock<IBoardRepository>();
        _service = mocker.CreateInstance<RookService>();
    }

    [Fact(DisplayName = "Should move successfully")]
    [Trait(nameof(RookService), nameof(RookService.MoveAsync))]
    public async Task ShouldMoveSuccessfully()
    {
        // Arrange
        var rookPiece = RookPiece.CreateWhiteRookOfQueen();
        var board = BoardBuilder.New().WithPiece(rookPiece).Build();

        rookPiece.AddPieceOnTheBoard(board.Id, board);

        rookPiece.MoveTo(new(BoardColumnEnum.A, BoardRowEnum.Two));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(rookPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _rookRepository.Verify(repository => repository.UpdateAsync(It.IsAny<RookPiece>()), Times.Once);
    }
}