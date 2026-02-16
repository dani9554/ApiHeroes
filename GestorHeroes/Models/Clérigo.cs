using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHeroes.Models
{
    /**
     * Clase que nos representa un clérigo
     */
    [Table("Clerigos")]
    public class Clerigo : Personaje
    {
        public string Deidad { get; set; } = string.Empty;
        public int PuntosSanacion { get; set; }
    }

}
