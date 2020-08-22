using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurcosBlazor.Shared.Entidades
{
    public class TipoListaPrecio : IEquatable<TipoListaPrecio>
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }

        public virtual List<TipoListaPrecioCategoriaCliente> TipoListaPrecioCategoriaClientes { get; set; }
        public virtual List<TipoListaPrecioProvincia> TipoListaPrecioProvincias { get; set; }
        public decimal minimoDeCompra { get; set; } = 0.00M;
        public virtual List<ListaPrecios> ListasPrecios { get; set; }
        public bool Equals(TipoListaPrecio other)
        {
            if (nombre == other.nombre)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashNombre = nombre == null ? 0 : nombre.GetHashCode();

            return hashNombre;
        }

    }
}