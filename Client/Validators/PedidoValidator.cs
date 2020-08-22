using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class PedidoValidator:AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(p => p.nombreCliente).NotEmpty().WithMessage("El Nombre es requerido").MaximumLength(50).WithMessage("El nombre no puede tener mas de 50 caracteres");
            RuleFor(p => p.apellidoCliente).NotEmpty().WithMessage("El Apellido es requerido").MaximumLength(50).WithMessage("El apellido no puede tener mas de 50 caracteres");

            RuleFor(p => p.emailCliente).NotEmpty().WithMessage("El Email no puede estar vacío");
            RuleFor(p => p.celularCliente).NotEmpty().WithMessage("El Celular es requerido");
            RuleFor(p => p.Domicilio.calle).NotEmpty().WithMessage("La calle es requerida");
            RuleFor(p => p.Domicilio.numero).NotEmpty().WithMessage("La el número de domicilio es requerido");
            RuleFor(p => p.VendedorId).GreaterThan(0).WithMessage("Tienes que seleccionar un vendedor");
            RuleFor(p => p.fechaEntrega).GreaterThan(DateTime.Now.AddDays(-1)).WithMessage("El día de entrega debe ser posterior a la fecha del pedido");
            RuleFor(p => p.total).GreaterThan(0).WithMessage("El precio total es incorrecto");

        }
    }
}
