﻿using FluentValidation;

namespace CleanOnionNetwork.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede ir en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");
            RuleFor(p => p.Url)
               .NotEmpty().WithMessage("{Url} no puede ir en blanco");
        }
    }
}
