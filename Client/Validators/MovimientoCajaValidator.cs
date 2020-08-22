using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class MovimientoCajaValidator : AbstractValidator<MovimientoCaja>
    {
        public MovimientoCajaValidator()
        {
            RuleFor(x => x.CajaId).NotEqual(0).WithMessage("Todos los movimientos de tesoreria deben tener una caja asignada").NotNull().WithMessage("Todos los movimientos de tesoreria deben tener una caja asignada");
            RuleFor(x => x.totalMovimiento).GreaterThan(0).WithMessage("El importe de los movimientos de tesoreria tiene que ser mayor que cero");
        }
    }
}
