using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price{ get; set; }

        public string Url { get; set; }

        public Pizza(int id,string nome, string? description, string? img, double price)
        {
            Id = id;
            Name = nome;
            Description = description;
            Url = img;
            Price = price;
        }

        public Pizza()
        {
        }
    }
}
