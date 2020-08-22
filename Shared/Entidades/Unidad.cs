using System.ComponentModel.DataAnnotations;

namespace SurcosBlazor.Shared.Entidades
{
    public class Unidad
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }



        public override bool Equals(object obj)
        {
            if (obj is Unidad p2)
            {
                return Id == p2.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}