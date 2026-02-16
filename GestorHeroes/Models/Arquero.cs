using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHeroes.Models
{
    /**
     * Clase que nos representa un arquero
     */
    [Table("Arqueros")]
    public class Arquero : Personaje
    {
        public double Precision { get; set; }
        public bool TieneMascota { get; set; }
    }

}
