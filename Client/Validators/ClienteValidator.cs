using FluentValidation;
using SurcosBlazor.Shared;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class ClienteValidator:AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(p => p.nombre).NotEmpty().WithMessage("El Nombre es requerido").MaximumLength(50).WithMessage("El nombre no puede tener mas de 50 caracteres");
            RuleFor(p => p.email).NotEmpty().WithMessage("El Email es requerido");
            RuleFor(p => p.celular).NotEmpty().WithMessage("El Celular es requerido");
            RuleFor(p => p.Domicilio.Provincia).NotNull().WithMessage("Tienes que seleccionar una provincia");
            RuleFor(p => p.Domicilio.Departamento).NotNull().WithMessage("Tienes que seleccionar un departamento");

            RuleFor(p => p.Domicilio.calle).NotEmpty().WithMessage("La calle es requerida");
            RuleFor(p => p.Domicilio.numero).NotEmpty().WithMessage("La el número es requerido");

        }
    }
}
