using System;
using FluentValidation;
using Weelo.PropertyManagement.Aplication.Dtos;

namespace Weelo.PropertyManagement.Api.ModelState
{
    public class ImageDtoValidator : AbstractValidator<ImageDto>
    {
        public ImageDtoValidator()
        {
            RuleFor(o => o.InernalCode).NotEmpty().MaximumLength(30).MinimumLength(4);
            RuleFor(o => o.File).NotEmpty().Must(ValidateImage);
        }
        private bool ValidateImage(string img)
        {
            Span<byte> buffer = new(new byte[img.Length]);
            return (Convert.TryFromBase64String(img, buffer, out _));
        }
    }
}
