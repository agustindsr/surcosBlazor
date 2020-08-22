using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class DetalleOrdenProduccionValidator : AbstractValidator<DetalleOrdenProduccion>
    {
        public DetalleOrdenProduccionValidator()
        {
            RuleFor(x => x.ProductoPresentacionId).NotEqual(0).WithMessage("Debes seleccionar un producto en todos los detalles de la orden");
            RuleFor(x => x.cantidad).GreaterThan(0).WithMessage("La cantidad tiene que ser mayor que cero");
        }
    }
}
