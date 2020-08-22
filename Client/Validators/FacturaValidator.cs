using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class FacturaValidator:AbstractValidator<Factura>
    {
        public FacturaValidator()
        {
            RuleFor(p => p.nombreCliente).NotEmpty().WithMessage("El Nombre es requerido").MaximumLength(50).WithMessage("El nombre no puede tener mas de 50 caracteres");
            RuleFor(p => p.emailCliente).NotEmpty().WithMessage("El Email no puede estar vacío").EmailAddress().WithMessage("El Email es incorrecto");
            RuleFor(p => p.celularCliente).NotEmpty().WithMessage("El Celular es requerido");
            RuleFor(p => p.Domicilio.calle).NotEmpty().WithMessage("La calle es requerida");
            RuleFor(p => p.Domicilio.numero).NotEmpty().WithMessage("La el número de domicilio es requerido");
            RuleFor(p => p.VendedorId).GreaterThan(0).WithMessage("Tienes que seleccionar un vendedor");
            RuleFor(p => p.fechaEntrega).GreaterThan(DateTime.Now.AddDays(-1)).WithMessage("El día de entrega debe ser posterior a la fecha de la factura");
            RuleFor(p => p.totalComprobante).GreaterThan(0).WithMessage("El precio total es incorrecto");
            RuleFor(p => p.ClienteId).NotNull().NotEqual(0).WithMessage("Debes seleccionar un cliente");
            RuleFor(p => p.DepositoId).NotNull().WithMessage("Debes seleccionar un deposito").NotEqual(0).WithMessage("Debes seleccionar un deposito");

            RuleFor(p => p.TipoComprobanteId).NotNull().WithMessage("Debes seleccionar un Tipo de Comprobante").NotEqual(0).WithMessage("Debes seleccionar un Tipo de Comprobante");

        }
    }
}
