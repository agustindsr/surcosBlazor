﻿using FluentValidation;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Validators
{
    public class ReciboCobranzasValidator : AbstractValidator<ReciboCobranzas>
    {
        public ReciboCobranzasValidator(MovimientoCajaValidator movimientoValidator)
        {
            RuleFor(x => x.ClienteId).NotEmpty().WithMessage("Debes seleccionar un cliente");
            RuleFor(x => x.totalComprobante - x.totalImputado).GreaterThan(0).WithMessage("El total imputado no puede ser mayor que el total del recibo");
            RuleFor(x => x.totalComprobante).GreaterThan(0).WithMessage("El importe del recibo tiene que ser mayor que cero");
            RuleFor(x => x.movimientosCaja).ForEach(y => y.SetValidator(movimientoValidator));
        }
    }
}
