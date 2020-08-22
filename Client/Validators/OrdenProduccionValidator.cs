using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class OrdenProduccionValidator : AbstractValidator<OrdenProduccion>
    {
        public OrdenProduccionValidator(DetalleOrdenProduccionValidator detalleOrdenProduccionValidator)
        {
            RuleFor(p => p.DepositoId).NotEqual(0).WithMessage("El Email es requerido");
            RuleFor(x => x.detallesOrdenProduccion).ForEach(y => y.SetValidator(detalleOrdenProduccionValidator));
        }
    }
}
