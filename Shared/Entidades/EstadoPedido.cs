using System;

namespace SurcosBlazor.Shared.Entidades
{
    public class EstadoPedido : IEquatable<EstadoPedido>
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public bool Equals(EstadoPedido other)
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