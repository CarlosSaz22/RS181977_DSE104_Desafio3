using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RS181977_Desafio03.Models
{
    public class Clientes
    {
        [Key]
        public int id { get; set; }


        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo nombres requerido")]
        public String Nombres { get; set; }

        [Display(Name = "Primer apellido")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo primer apellido requerido")]
        public String primerApellido { get; set; }

        [Display(Name = "Segundo apellido")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo segundo apellido requerido")]
        public String segundoApellido { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Ingrese un número de teléfono válido. Formato XXXXXXXX")]
        [MinLength(length: 8)]
        [MaxLength(length: 8)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo teléfono requerido")]
        public string Telefono { get; set; }

        [RegularExpression("(^[0-9]{8})-([0-9]$)", ErrorMessage = "Ingrese un DUI válido. Formato XXXXXXXX-X")]
        [MinLength(length: 10)]
        [MaxLength(length: 10)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo DUI requerido")]
        public string Dui { get; set; }


        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo correo requerido")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El correo no cumple con el formato correcto")]
        public string email { get; set; }

        public static List<Clientes> Listar()
        {
            var ListaClientes = new List<Clientes>();
            ListaClientes.Add(new Clientes()
            {
                Nombres = "Carlos José",
                primerApellido = "Ruiz",
                segundoApellido="Saz",
                Telefono="12345678",
                Dui = "12345678-9",
                email = "carlos22@outlook.com",
            
            });
            ListaClientes.Add(new Clientes()
            {
                Nombres = "Carlos Josue",
                primerApellido = "Ruiz",
                segundoApellido = "Saz",
                Telefono = "12345672",
                Dui = "12345678-1",
                email = "carlos222@outlook.com",
            });
            return ListaClientes;
        }


    }
}