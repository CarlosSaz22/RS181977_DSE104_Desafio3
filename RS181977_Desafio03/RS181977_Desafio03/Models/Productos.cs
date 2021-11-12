using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RS181977_Desafio03.Models
{
    public class Productos
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nombre del producto")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo nombre del producto requerido")]
        public String NombreProducto { get; set; }

        [Display(Name = "Descripción del producto")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo descripción del producto requerido")]
        public String Descripción { get; set; }

      

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Ingrese un número entero")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo stock debe ser mayor a 0")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo stock requerido")]
        public int Stock { get; set; }

     [Display(Name = "Precio unitario")]
        [Range(0.0, float.MaxValue, ErrorMessage = "El campo precio unitario debe ser mayor a 0")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo precio unitario requerido")]
        public float PrecioUnitario { get; set; }

        public static List<Productos> Listar()
        {
            var ListaProductos = new List<Productos>();
            ListaProductos.Add(new Productos()
            {
                    id=1,
                    NombreProducto="Jarabe",
                    Descripción="Jarabe para la tos",
                    Stock=20,
                    PrecioUnitario=5
            });
            ListaProductos.Add(new Productos()
            {
                id = 2,
                NombreProducto = "Vitaminas",
                Descripción = "Vitaminas para la jóvenes",
                Stock = 50,
                PrecioUnitario = 10
            });
            return ListaProductos;
        }

    
    }
}