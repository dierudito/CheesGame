using FluentValidation;
using Moreno.ChessGame.Domain.Entities.Base;

namespace Moreno.ChessGame.Domain.Validations;

public class PieceValidation<T> : AbstractValidator<T> where T : Piece
{
}
