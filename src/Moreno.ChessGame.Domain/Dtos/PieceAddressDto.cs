using Moreno.ChessGame.Domain.Enums;

namespace Moreno.ChessGame.Domain.Dtos;

public record PieceAddressDto(BoardColumnEnum Column, BoardRowEnum Row);