using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RS181977_Desafio03.Controllers;
using RS181977_Desafio03.Models;
namespace RS181977_Desafio03.Tests.Controllers
{
    [TestClass]
    public class PedidosControllerTest
    {
        [TestMethod]
        public void AgregarPedidoNoRepetido()
        {
            // Arrange
            PedidosController controller = new PedidosController();
            var pedidos = new Pedidos()
            {
                id = 4,
                Clientes_id = 1,
                Productos_id=1,
                Cantidad=3
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(0, result);
        }



        [TestMethod]
        public void NoAgregarPedidoConIDRepetido()
        {
            // Arrange
            PedidosController controller = new PedidosController();
            var pedidos = new Pedidos()
            {
                id = 1,
                Clientes_id = 1,
                Productos_id = 1,
                Cantidad = 30,
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void NoAgregarPedidoConCantidadNegativa()
        {
            // Arrange
            PedidosController controller = new PedidosController();
            var pedidos = new Pedidos()
            {
                id = 1,
                Clientes_id = 1,
                Productos_id = 1,
                Cantidad = -30,
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConIdClienteVacio()
        {
            // Arrange
            PedidosController controller = new PedidosController();
            var pedidos = new Pedidos()
            {
                id = 5,
                Productos_id = 1,
                Cantidad = 30,

            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConIdProductoVacio()
        {

            // Arrange
            PedidosController controller = new PedidosController();
            var pedidos = new Pedidos()
            {
                id = 6,
                Clientes_id = 1,
                Cantidad = 30,

            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConCantidadVacio()
        {
            // Arrange
            PedidosController controller = new PedidosController();
            var pedidos = new Pedidos()
            {
                id = 8,
                Clientes_id = 1,
                Productos_id = 1,
          
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(5, result);

        }

    }
}
