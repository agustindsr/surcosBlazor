using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class ProveedorValidatior : AbstractValidator<Proveedor>
    {
        public ProveedorValidatior()
        {
            RuleFor(p => p.razonSocial).NotEmpty().WithMessage("La Razon Social es requerida").MaximumLength(50).WithMessage("La Razon Social no puede tener mas de 50 caracteres");
            RuleFor(p => p.cuit).NotEmpty().WithMessage("El cuit es requerido");
            RuleFor(p => p.Domicilio.Provincia).NotNull().WithMessage("Tienes que seleccionar una provincia");
            RuleFor(p => p.Domicilio.Departamento).NotNull().WithMessage("Tienes que seleccionar un departamento");

            RuleFor(p => p.Domicilio.calle).NotEmpty().WithMessage("La calle es requerida");
            RuleFor(p => p.Domicilio.numero).NotEmpty().WithMessage("La el número es requerido");
        }
    }
}
