using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHeroes.Models
{
    /**
     * Clase que nos representa un guerrero
     */
    [Table("Guerreros")]
    public class Guerrero : Personaje
    {
        public string ArmaPrincipal { get; set; } = string.Empty;
        public int Furia { get; set; }
    }

}
