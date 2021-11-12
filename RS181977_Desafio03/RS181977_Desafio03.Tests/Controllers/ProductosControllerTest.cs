using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RS181977_Desafio03.Controllers;
using RS181977_Desafio03.Models;

namespace RS181977_Desafio03.Tests.Controllers
{
    [TestClass]
    public class ProductosControllerTest
    {
        [TestMethod]
        public void AgregarProductoNoRepetido()
        {
            // Arrange
            ProductosController controller = new ProductosController();
            var productos = new Productos()
            {
                id = 3,
                NombreProducto = "Jarabe",
                Descripción = "Jarabe para la tos",
                Stock = 20,
                PrecioUnitario = 5
            };
            // Act
            var result = controller.Agregar(productos);
            // Assert
            Assert.AreEqual(0, result);
        }



        [TestMethod]
        public void NoAgregarProductoConIDRepetido()
        {
            // Arrange
            ProductosController controller = new ProductosController();
            var productos = new Productos()
            {
                id = 1,
                NombreProducto = "Jarabe",
                Descripción = "Jarabe para la tos",
                Stock = 20,
                PrecioUnitario = 5
            };
            // Act
            var result = controller.Agregar(productos);
            // Assert
            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void NoAgregarProductoConNombreVacio()
        {
            // Arrange
            ProductosController controller = new ProductosController();
            var productos = new Productos()
            {
                id = 1,
                NombreProducto = "",
              
            };
            // Act
            var result = controller.Agregar(productos);
            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NoAgregarProductoConDescripciónVacio()
        {
            // Arrange
            ProductosController controller = new ProductosController();
            var productos = new Productos()
            {
                id = 1,
                NombreProducto = "Jarabe",
                Descripción = "",
                
            };
            // Act
            var result = controller.Agregar(productos);
            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NoAgregarProductoConStockNegativo()
        {
         
            // Arrange
            ProductosController controller = new ProductosController();
            var productos = new Productos()
            {
                id = 8,
                NombreProducto = "Jarabe",
                Descripción = "Jarabe para la tos",
                Stock = -1,
              
            };
            // Act
            var result = controller.Agregar(productos);
            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void NoAgregarProductoConPrecioNegativo()
        {
            // Arrange
            ProductosController controller = new ProductosController();
            var productos = new Productos()
            {
                id = 6,
                NombreProducto = "Jarabe",
                Descripción = "Jarabe para la tos",
                Stock = 20,
                PrecioUnitario = -3
            };
            // Act
            var result = controller.Agregar(productos);
            // Assert
            Assert.AreEqual(5, result);

        }

      


    }
}
