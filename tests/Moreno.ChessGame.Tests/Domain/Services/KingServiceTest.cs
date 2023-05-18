using Moq;
using Moq.AutoMock;
using Moreno.ChessGame.Domain.Interfaces.Repositories;
using Moreno.ChessGame.Domain.Services;
using Moreno.ChessGame.UnitaryTests.Shared.Builders;

namespace Moreno.ChessGame.UnitaryTests.Domain.Services;

public class KingServiceTest
{
    private readonly Mock<IKingRepository> _kingRepository;
    private readonly Mock<IBoardRepository> _boardRepository;
    private readonly KingService _service;

    public KingServiceTest()
    {
        var mocker = new AutoMocker();
        _kingRepository = mocker.GetMock<IKingRepository>();
        _boardRepository = mocker.GetMock<IBoardRepository>();
        _service = mocker.CreateInstance<KingService>();
    }

    [Theory(DisplayName = "Should move successfully")]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.E, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.F, BoardRowEnum.Two)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.D, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One, BoardColumnEnum.F, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.D, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.E, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.Two, BoardColumnEnum.F, BoardRowEnum.One)]
    [Trait(nameof(KingService), nameof(KingService.MoveAsync))]
    public async Task ShouldMoveSuccessfully(BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var kingPiece = new KingPiece(ColorEnum.White, new(columnSource, rowSource));
        var board = BoardBuilder.New().WithPiece(kingPiece).Build();

        kingPiece.AddPieceOnTheBoard(board.Id, board);

        kingPiece.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(kingPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _kingRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KingPiece>()), Times.Once);
    }

    [Fact(DisplayName = "Shouldn't move to an occupied square")]
    [Trait(nameof(KingService), nameof(KingService.MoveAsync))]
    public async Task ShouldnotMoveToAnOccupiedSquare()
    {
        // Arrange
        var otherPiece = PawnPiece.CreateWhitePawn(new(BoardColumnEnum.D, BoardRowEnum.Two));
        var kingPiece = new KingPiece(ColorEnum.White, new(BoardColumnEnum.E, BoardRowEnum.One));
        var board = BoardBuilder.New().WithPiece(kingPiece).WithPiece(otherPiece, false).Build();

        otherPiece.AddPieceOnTheBoard(board.Id, board);
        kingPiece.AddPieceOnTheBoard(board.Id, board);

        kingPiece.MoveTo(new(BoardColumnEnum.D, BoardRowEnum.Two));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(kingPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _kingRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KingPiece>()), Times.Never);
    }

    [Theory(DisplayName = "Should castle successfully")]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One,
                BoardColumnEnum.C, BoardRowEnum.One,
                BoardColumnEnum.A, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.E, BoardRowEnum.One,
                BoardColumnEnum.G, BoardRowEnum.One,
                BoardColumnEnum.H, BoardRowEnum.One)]
    [Trait(nameof(KingService), nameof(KingService.MoveAsync))]
    public async Task ShouldCastleSuccessfully(
        BoardColumnEnum columnSource, BoardRowEnum rowSource,
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget,
        BoardColumnEnum columnRook, BoardRowEnum rowRook)
    {
        // Arrange
        var rookPiece = new RookPiece(ColorEnum.White, new(columnRook, rowRook));
        var kingPiece = new KingPiece(ColorEnum.White, new(columnSource, rowSource));
        var board = BoardBuilder.New().WithPiece(kingPiece).WithPiece(rookPiece, false).Build();

        rookPiece.AddPieceOnTheBoard(board.Id, board);
        kingPiece.AddPieceOnTheBoard(board.Id, board);

        kingPiece.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(kingPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _kingRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KingPiece>()), Times.Once);
    }

    [Theory(DisplayName = "Should castle successfully when there are two rooks")]
    [InlineData(BoardColumnEnum.C, BoardRowEnum.One)]
    [InlineData(BoardColumnEnum.G, BoardRowEnum.One)]
    [Trait(nameof(KingService), nameof(KingService.MoveAsync))]
    public async Task ShouldCastleSuccessfullyWhenThereAreTwoRooks(
        BoardColumnEnum columnTarget, BoardRowEnum rowTarget)
    {
        // Arrange
        var rookPieceOfQueen = RookPiece.CreateWhiteRookOfQueen();
        var rookPieceOfKing = RookPiece.CreateWhiteRookOfKing();
        var kingPiece = KingPiece.CreateWhiteKing();
        var board =
            BoardBuilder
            .New()
            .WithPiece(kingPiece)
            .WithPiece(rookPieceOfQueen, false)
            .WithPiece(rookPieceOfKing, false)
            .Build();

        rookPieceOfQueen.AddPieceOnTheBoard(board.Id, board);
        rookPieceOfKing.AddPieceOnTheBoard(board.Id, board);
        kingPiece.AddPieceOnTheBoard(board.Id, board);

        kingPiece.MoveTo(new(columnTarget, rowTarget));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(kingPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeTrue();
        _kingRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KingPiece>()), Times.Once);
    }

    [Fact(DisplayName = "Shouldn't castle when rook has moved")]
    [Trait(nameof(KingService), nameof(KingService.MoveAsync))]
    public async Task ShouldnotCastleWhenRookHasMoved()
    {
        // Arrange
        var rookPieceOfQueen = RookPiece.CreateWhiteRookOfQueen();
        var rookPieceOfKing = RookPiece.CreateWhiteRookOfKing();
        var kingPiece = KingPiece.CreateWhiteKing();
        var board =
            BoardBuilder
            .New()
            .WithPiece(kingPiece)
            .WithPiece(rookPieceOfQueen, false)
            .WithPiece(rookPieceOfKing, false)
            .Build();

        rookPieceOfQueen.AddPieceOnTheBoard(board.Id, board);
        rookPieceOfKing.AddPieceOnTheBoard(board.Id, board);
        kingPiece.AddPieceOnTheBoard(board.Id, board);

        rookPieceOfQueen.MoveTo(new(BoardColumnEnum.B, BoardRowEnum.One));

        kingPiece.MoveTo(new(BoardColumnEnum.C, BoardRowEnum.One));
        _boardRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(board);

        // Act
        var result = await _service.MoveAsync(kingPiece);

        // Assert
        result.ValidationResult.IsValid.Should().BeFalse();
        _kingRepository.Verify(repository => repository.UpdateAsync(It.IsAny<KingPiece>()), Times.Never);
    }
}
