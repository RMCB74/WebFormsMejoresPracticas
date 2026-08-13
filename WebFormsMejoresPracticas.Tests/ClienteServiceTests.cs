using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using WebFormsMejoresPracticas.Exceptions;
using WebFormsMejoresPracticas.Infrastructure.Database;
using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Repositories;
using WebFormsMejoresPracticas.Services;


using Moq;

using WebFormsMejoresPracticas.Tests.Fakes;


namespace WebFormsMejoresPracticas.Tests
{
    [TestClass]
    public class ClienteServiceTests
    {
        /// <summary>
        ///  unitaria
        /// </summary>
        [TestMethod]
        public void ObtenerPorId_IdCero_DebeLanzarArgumentException()
        {
            // Arrange
            var service = new ClienteService(null);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(
                () => service.ObtenerPorId(0));
        }

        /// <summary>
        ///  unitaria
        /// </summary>
        [TestMethod]
        public void Crear_ClienteSinNombre_DebeLanzarArgumentException()
        {
            // Arrange
            var service = new ClienteService(null);

            var cliente = new WebFormsMejoresPracticas.Models.Cliente
            {
                Nombre = ""
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(
                () => service.Crear(cliente));
        }

        [TestMethod]
        public void Conexion_BaseDatos_DebeSerExitosa()
        {
            // Arrange
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            var connectionFactory =
                new SqlConnectionFactory(connectionString);

            // Act
            using (var connection = connectionFactory.CreateConnection())
            {
                connection.Open();

                // Assert
                Assert.AreEqual(
                    System.Data.ConnectionState.Open,
                    connection.State);
            }
        }

        [TestMethod]
        public void Crear_Cliente_DebeInsertarEnBaseDatos()
        {
            // Arrange
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            var connectionFactory =
                new SqlConnectionFactory(connectionString);

            ILogger<ClienteRepository> logger =
                NullLogger<ClienteRepository>.Instance;

            var repository =
                new ClienteRepository(connectionFactory, logger);

            var service =
                new ClienteService(repository);

            var cliente = new Cliente
            {
                Nombre = "Cliente Prueba Integracion"
            };

            // Act
            int id = service.Crear(cliente);

            // Assert
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void Crear_Cliente_DebeInsertarYConsultarEnBaseDatos()
        {
            // Arrange
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            var connectionFactory =
                new SqlConnectionFactory(connectionString);

            ILogger<ClienteRepository> logger =
                NullLogger<ClienteRepository>.Instance;

            var repository =
                new ClienteRepository(connectionFactory, logger);

            var service =
                new ClienteService(repository);

            var cliente = new Cliente
            {
                Nombre = "Cliente Prueba Integracion " + Guid.NewGuid()
            };

            var generonom = cliente.Nombre;

            //var cliente = new Cliente
            //{
            //    Nombre = "Cliente Prueba Integracion"
            //};

            int id = 0;

            try
            {
                // Act
                id = service.Crear(cliente);

                // Assert
                Assert.IsTrue(id > 0);

                var clienteCreado = service.ObtenerPorId(id);

                Assert.IsNotNull(clienteCreado);
                Assert.AreEqual(id, clienteCreado.Id);

                Assert.AreEqual(
                generonom,
                clienteCreado.Nombre);


                //Assert.AreEqual(
                //    "Cliente Prueba Integracion",
                //    clienteCreado.Nombre);
            }
            finally
            {
                // Cleanup
                if (id > 0)
                {
                    service.Eliminar(id);
                }
            }
        }


        //avanzo https://chatgpt.com/share/6a7de68e-0e44-83e8-a07c-d8953c26254a  despues  pipelin

        [TestMethod]
        public void Actualizar_Cliente_DebeActualizarEnBaseDatos()
        {
            // Arrange
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            var connectionFactory =
                new SqlConnectionFactory(connectionString);

            ILogger<ClienteRepository> logger =
                NullLogger<ClienteRepository>.Instance;

            var repository =
                new ClienteRepository(connectionFactory, logger);

            var service =
                new ClienteService(repository);

            var cliente = new Cliente
            {
                Nombre = "Cliente Prueba Actualizar " + Guid.NewGuid()
            };

            int id = 0;

            try
            {
                // Crear
                id = service.Crear(cliente);

                Assert.IsTrue(id > 0);

                // Actualizar
                cliente.Id = id;
                cliente.Nombre = "Cliente Actualizado " + Guid.NewGuid();

                service.Actualizar(cliente);

                // Consultar nuevamente
                var clienteActualizado = service.ObtenerPorId(id);

                // Verificar
                Assert.IsNotNull(clienteActualizado);
                Assert.AreEqual(id, clienteActualizado.Id);
                Assert.AreEqual(
                    cliente.Nombre,
                    clienteActualizado.Nombre);
            }
            finally
            {
                // Cleanup
                if (id > 0)
                {
                    service.Eliminar(id);
                }
            }
        }


        [TestMethod]
        public void Eliminar_Cliente_DebeEliminarDeBaseDatos()
        {
            // Arrange
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            var connectionFactory =
                new SqlConnectionFactory(connectionString);

            ILogger<ClienteRepository> logger =
                NullLogger<ClienteRepository>.Instance;

            var repository =
                new ClienteRepository(connectionFactory, logger);

            var service =
                new ClienteService(repository);

            var cliente = new Cliente
            {
                Nombre = "Cliente Prueba Eliminar " + Guid.NewGuid()
            };

            int id = 0;

            // Crear cliente para la prueba
            id = service.Crear(cliente);

            try
            {
                // Act
                service.Eliminar(id);

                // Assert
                var clienteEliminado = service.ObtenerPorId(id);

                Assert.IsNull(clienteEliminado);
            }
            finally
            {
                // Cleanup de seguridad
                if (id > 0)
                {
                    var clienteExistente = service.ObtenerPorId(id);

                    if (clienteExistente != null)
                    {
                        service.Eliminar(id);
                    }
                }
            }
        }


        [TestMethod]
        public void Eliminar_ClienteConContactos_DebeLanzarClienteTieneContactosException()
        {
            // Arrange
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            var connectionFactory =
                new SqlConnectionFactory(connectionString);

            ILogger<ClienteRepository> clienteLogger =
                NullLogger<ClienteRepository>.Instance;

            ILogger<ContactoRepository> contactoLogger =
                NullLogger<ContactoRepository>.Instance;

            var clienteRepository =
                new ClienteRepository(
                    connectionFactory,
                    clienteLogger);

            var contactoRepository =
                new ContactoRepository(
                    connectionFactory,
                    contactoLogger);

            var clienteService =
                new ClienteService(clienteRepository);

            var cliente = new Cliente
            {
                Nombre = "Cliente Prueba FK " + Guid.NewGuid()
            };

            var contacto = new Contacto
            {
                TipoContactoId = 1,
                Valor = "5551234567"
            };

            int clienteId = 0;
            int contactoId = 0;

            try
            {
                // Crear cliente
                clienteId = clienteService.Crear(cliente);

                // Crear contacto relacionado
                contacto.ClienteId = clienteId;

                contactoRepository.Insertar(contacto);

                contactoId = contacto.Id;

                // Act + Assert
                Assert.ThrowsException<ClienteTieneContactosException>(
                    () => clienteService.Eliminar(clienteId));
            }
            finally
            {
                // Cleanup
                if (contactoId > 0)
                {
                    contactoRepository.Eliminar(contactoId);
                }

                if (clienteId > 0)
                {
                    var clienteExistente =
                        clienteService.ObtenerPorId(clienteId);

                    if (clienteExistente != null)
                    {
                        clienteService.Eliminar(clienteId);
                    }
                }
            }
        }


        //mock
        [TestMethod]
        public void Crear_ClienteValido_DebeRegresarIdDelRepository()
        {
            // Arrange
            var mockRepository =
                new Mock<IClienteRepository>();

            mockRepository
                .Setup(x => x.Crear(It.IsAny<Cliente>()))
                .Returns(100);

            var service =
                new ClienteService(mockRepository.Object);

            var cliente = new Cliente
            {
                Nombre = "Cliente Mock"
            };

            // Act
            int id = service.Crear(cliente);

            // Assert
            Assert.AreEqual(100, id);

            mockRepository.Verify(
                x => x.Crear(It.IsAny<Cliente>()),
                Times.Once);

        }


        [TestMethod]
        public void Crear_ClienteSinNombre_NoDebeLlamarAlRepository()
        {
            // Arrange
            var mockRepository =
                new Mock<IClienteRepository>();

            var service =
                new ClienteService(mockRepository.Object);

            var cliente = new Cliente
            {
                Nombre = ""
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(
                () => service.Crear(cliente));

            // Verificar que NO llegó al Repository
            mockRepository.Verify(
                x => x.Crear(It.IsAny<Cliente>()),
                Times.Never);
        }

        [TestMethod]
        public void Crear_CuandoRepositoryLanzaExcepcion_DebePropagarLaExcepcion()
        {
            // Arrange
            var mockRepository =
                new Mock<IClienteRepository>();

            mockRepository
                .Setup(x => x.Crear(It.IsAny<Cliente>()))
                .Throws(new Exception("Error simulado del Repository"));

            var service =
                new ClienteService(mockRepository.Object);

            var cliente = new Cliente
            {
                Nombre = "Cliente Mock"
            };

            // Act & Assert
            var exception =
                Assert.ThrowsException<Exception>(
                    () => service.Crear(cliente));

            Assert.AreEqual(
                "Error simulado del Repository",
                exception.Message);

            mockRepository.Verify(
                x => x.Crear(It.IsAny<Cliente>()),
                Times.Once);
        }
        //avanzo  https://chatgpt.com/share/6a7decf2-5b50-83e8-851d-5fe4d110c0e5


        [TestMethod]
        public void Crear_ClienteConFake_DebeCrearYConsultar()
        {
            // Arrange
            var repository =
                new ClienteRepositoryFake();

            var service =
                new ClienteService(repository);

            var cliente = new Cliente
            {
                Nombre = "Cliente Fake"
            };

            // Act
            int id = service.Crear(cliente);

            var clienteCreado =
                service.ObtenerPorId(id);

            // Assert
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(clienteCreado);
            Assert.AreEqual(
                "Cliente Fake",
                clienteCreado.Nombre);
        }


    }

}