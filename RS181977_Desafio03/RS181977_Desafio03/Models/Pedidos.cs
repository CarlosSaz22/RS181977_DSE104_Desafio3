using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS181977_Desafio03.Models
{
    public class Pedidos
    {
        [Key]
        public int id { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Ingrese un número entero")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo cantidad debe ser mayor a 0")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo cantidad requerido")]
        public int Cantidad { get; set; }

        [ForeignKey("Clientes")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        [Display(Name = "Cliente")]
        public int Clientes_id { get; set; }
        public virtual Clientes Clientes { get; set; }

        [ForeignKey("Productos")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        [Display(Name = "Producto")]
        public int Productos_id { get; set; }
        public virtual Productos Productos { get; set; }


        public static List<Pedidos> Listar()
        {
            var ListaPedidos = new List<Pedidos>();
            ListaPedidos.Add(new Pedidos()
            {
              id=1,
              Clientes_id=1,
              Productos_id=1,
              Cantidad=30,
            });
            ListaPedidos.Add(new Pedidos()
            {
                id = 2,
                Clientes_id = 1,
                Productos_id = 1,
                Cantidad = 35,
            });
            return ListaPedidos;
        }
    }
}