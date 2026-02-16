using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GestorHeroes.Data
{
    public class PersonajeDTO
    {
        //Atributo con una longitud máxima de caracteres
        public string Nombre { get; set; } = string.Empty;

        //Atributo que incluye un rango de valores
        public int Nivel { get; set; }

        //Atributo que representa una relación con otra entidad
        public string? Gremio { get; set; }

        //Atributo que representa una colección de objetos relacionados
        public JsonDocument? Rasgos { get; set; }
        public double? Precision { get; set; }
        public bool? TieneMascota { get; set; }
        public string? ArmaPrincipal { get; set; } = string.Empty;
        public int? Furia { get; set; }
        public string? Deidad { get; set; } = string.Empty;
        public int? PuntosSanacion { get; set; }
        public int? Mana { get; set; }
        public string? ElementoPrincipal { get; set; } = string.Empty;
    }
}
