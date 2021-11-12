using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RS181977_Desafio03.Controllers;
using RS181977_Desafio03.Models;

namespace RS181977_Desafio03.Tests.Controllers
{
    [TestClass]
    public class ClientesControllerTest
    {
        [TestMethod]
        public void AgregarClienteNoRepetido()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "Carlos José",
                primerApellido = "Ruiz",
                segundoApellido = "Saz",
                Telefono = "12345678",
                Dui = "12345674-3",
                email = "carlos22@outlook.com",
            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(0, result);
        }



        [TestMethod]
        public void NoAgregarClienteConDUIRepetido()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "Carlos José",
                primerApellido = "Ruiz",
                segundoApellido = "Saz",
                Telefono = "12345678",
                Dui = "12345678-9",
                email = "carlos22@outlook.com",
            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void NoAgregarClienteConNombreVacio()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "",
            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NoAgregarClienteConPrimerApellidoVacio()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "Carlos",
                primerApellido=""
            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NoAgregarClienteConSegundoapellidoVacio()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "Carlos",
                primerApellido = "Ruiz",
                segundoApellido=""
            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void NoAgregarClienteConTelefonoVacio()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "Carlos",
                primerApellido = "Ruiz",
                segundoApellido = "Saz",
                Telefono="",

            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void NoAgregarClienteConEmailVacio()
        {
            // Arrange
            ClientesController controller = new ClientesController();
            var clientes = new Clientes()
            {
                Nombres = "Carlos",
                primerApellido = "Ruiz",
                segundoApellido = "Saz",
                Telefono = "12345678",
                email=""



            };
            // Act
            var result = controller.Agregar(clientes);
            // Assert
            Assert.AreEqual(6, result);
        }


    }
}
