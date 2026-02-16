using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace GestorHeroes.Models
{
    /**
     * Clase que nos representa un personaje
     */
    [Table("Personajes")]
    public class Personaje
    {
        //Atributo de forma de una clave primaria
        [Key]
        public int Id { get; set; }

        //Atributo con una longitud máxima de caracteres
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        //Atributo que incluye un rango de valores
        [Range(1, 100)]
        public int Nivel { get; set; }

        //Atributo que representa una fecha y hora
        [Required]
        public DateTime FechaCreacion { get; set; }

        //Atributo que representa una relación con otra entidad
        public string? Gremio { get; set; }

        //Atributo que representa una colección de objetos relacionados
        public JsonDocument? Rasgos { get; set; }
    }

}
