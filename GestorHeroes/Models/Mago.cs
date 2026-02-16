using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHeroes.Models
{
    /**
     * Clase que nos representa un mago
     */
    [Table("Magos")]
    public class Mago : Personaje
    {
        public int Mana { get; set; }
        public string ElementoPrincipal { get; set; } = string.Empty;
    }

}
