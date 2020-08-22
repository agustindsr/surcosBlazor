using FluentValidation;
using SurcosBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class UserClienteInfoValidator:AbstractValidator<UserClienteInfo>
    {
        public UserClienteInfoValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithMessage("La contraseña es requerida").MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres").MaximumLength(20).WithMessage("La contraseña no puede tener mas de 20 caracteres");
            RuleFor(p => p.Cliente.nombre).NotEmpty().WithMessage("El Nombre es requerido").MaximumLength(50).WithMessage("El nombre no puede tener mas de 50 caracteres");
            RuleFor(p => p.Cliente.email).NotEmpty().WithMessage("El Email es requerido");
            RuleFor(p => p.Cliente.celular).NotEmpty().WithMessage("El Celular es requerido");
            RuleFor(p => p.Cliente.Domicilio.calle).NotEmpty().WithMessage("La calle es requerida");
            RuleFor(p => p.Cliente.Domicilio.numero).NotEmpty().WithMessage("La el número es requerido");
            RuleFor(p => p.Cliente.Domicilio.ProvinciaId).NotEqual(0).WithMessage("Debes seleccionar una provincia");
            RuleFor(p => p.Cliente.Domicilio.DepartamentoId).NotEqual(0).WithMessage("Debes seleccionar una localidad");
            RuleFor(p => p.Cliente.Domicilio.Provincia).NotNull().WithMessage("Debes seleccionar una provincia");
            RuleFor(p => p.Cliente.Domicilio.Departamento).NotNull().WithMessage("Debes seleccionar una localidad");
        }
    }
}
