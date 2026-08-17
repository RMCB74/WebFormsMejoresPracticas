using Moq;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;
using WebFormsSoapService.Services;
using WebFormsSoapService.Tests.Fakes;

namespace WebFormsSoapService.Tests
{
    [TestClass]
    public class ClienteServiceTests
    {
        [TestMethod]
        public void Crear_ClienteSinNombre_DebeLanzarExcepcion()
        {
            // Arrange
            var repository = new ClienteRepositoryFake();
            var service = new ClienteServiceImpl(repository);

            var cliente = new Cliente
            {
                Nombre = ""
            };

            // Act
            try
            {
                service.Crear(cliente);

                Assert.Fail("Se esperaba una ArgumentException.");
            }
            catch (ArgumentException)
            {
                // Correcto: la validación funcionó.
            }
        }


        [TestMethod]
        public void Crear_ClienteSinNombre_DebeLanzarExcepcion_Mock()
        {
            // Arrange
            var repositoryMock = new Mock<IClienteRepository>();

            var service = new ClienteServiceImpl(repositoryMock.Object);

            var cliente = new Cliente
            {
                Nombre = ""
            };

            // Act
            try
            {
                service.Crear(cliente);

                Assert.Fail("Se esperaba una ArgumentException.");
            }
            catch (ArgumentException)
            {
                // Correcto
            }
        }

        [TestMethod]
        public void Crear_ClienteValido_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<IClienteRepository>();

            repositoryMock
                .Setup(r => r.Crear(It.IsAny<Cliente>()))
                .Returns(10);

            var service = new ClienteServiceImpl(repositoryMock.Object);

            var cliente = new Cliente
            {
                Nombre = "Cliente de prueba"
            };

            // Act
            int id = service.Crear(cliente);

            // Assert
            Assert.AreEqual(10, id);

            repositoryMock.Verify(
                r => r.Crear(It.IsAny<Cliente>()),
                Times.Once);
        }


        [TestMethod]
        public void Actualizar_ClienteValido_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<IClienteRepository>();

            repositoryMock
                .Setup(r => r.Actualizar(It.IsAny<Cliente>()))
                .Returns(true);

            var service = new ClienteServiceImpl(repositoryMock.Object);

            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "Cliente actualizado"
            };

            // Act
            bool resultado = service.Actualizar(cliente);

            // Assert
            Assert.IsTrue(resultado);

            repositoryMock.Verify(
                r => r.Actualizar(It.IsAny<Cliente>()),
                Times.Once);
        }

        [TestMethod]
        public void ObtenerPorId_ClienteExistente_DebeRegresarCliente()
        {
            // Arrange
            var repositoryMock = new Mock<IClienteRepository>();

            var clienteEsperado = new Cliente
            {
                Id = 1,
                Nombre = "Cliente de prueba"
            };

            repositoryMock
                .Setup(r => r.ObtenerPorId(1))
                .Returns(clienteEsperado);

            var service = new ClienteServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerPorId(1);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
            Assert.AreEqual("Cliente de prueba", resultado.Nombre);

            repositoryMock.Verify(
                r => r.ObtenerPorId(1),
                Times.Once);
        }

        [TestMethod]
        public void ObtenerTodos_DebeRegresarClientes()
        {
            // Arrange
            var repositoryMock = new Mock<IClienteRepository>();

            var clientesEsperados = new List<Cliente>
            {
                new Cliente
                {
                    Id = 1,
                    Nombre = "Cliente 1"
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "Cliente 2"
                }
            };

            repositoryMock
                .Setup(r => r.ObtenerTodos())
                .Returns(clientesEsperados);

            var service = new ClienteServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.HasCount(2, resultado);

            Assert.AreEqual(1, resultado[0].Id);
            Assert.AreEqual("Cliente 1", resultado[0].Nombre);

            Assert.AreEqual(2, resultado[1].Id);
            Assert.AreEqual("Cliente 2", resultado[1].Nombre);

            repositoryMock.Verify(
                r => r.ObtenerTodos(),
                Times.Once);
        }

        [TestMethod]
        public void Eliminar_ClienteExistente_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<IClienteRepository>();

            repositoryMock
                .Setup(r => r.Eliminar(1))
                .Returns(true);

            var service = new ClienteServiceImpl(repositoryMock.Object);

            // Act
            bool resultado = service.Eliminar(1);

            // Assert
            Assert.IsTrue(resultado);

            repositoryMock.Verify(
                r => r.Eliminar(1),
                Times.Once);

        }
        [TestClass]
        public class ContactoServiceTests
        {
            [TestMethod]
            public void Crear_ContactoNulo_DebeLanzarExcepcion()
            {
                // Arrange
                var repositoryMock = new Mock<IContactoRepository>();
                var service = new ContactoServiceImpl(repositoryMock.Object);

                // Act
                try
                {
                    service.Crear(null);

                    Assert.Fail("Se esperaba una ArgumentException.");
                }
                catch (ArgumentException)
                {
                    // Correcto
                }
            }
        }

        [TestMethod]
        public void Crear_ContactoSinCliente_DebeLanzarExcepcion()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();
            var service = new ContactoServiceImpl(repositoryMock.Object);

            var contacto = new Contacto
            {
                ClienteId = 0,
                TipoContactoId = 1,
                Valor = "correo@prueba.com"
            };

            // Act
            try
            {
                service.Crear(contacto);

                Assert.Fail("Se esperaba una ArgumentException.");
            }
            catch (ArgumentException)
            {
                // Correcto
            }
        }

        [TestMethod]
        public void Crear_ContactoSinTipoContacto_DebeLanzarExcepcion()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();
            var service = new ContactoServiceImpl(repositoryMock.Object);

            var contacto = new Contacto
            {
                ClienteId = 1,
                TipoContactoId = 0,
                Valor = "correo@prueba.com"
            };

            // Act
            try
            {
                service.Crear(contacto);

                Assert.Fail("Se esperaba una ArgumentException.");
            }
            catch (ArgumentException)
            {
                // Correcto
            }
        }

        [TestMethod]
        public void Crear_ContactoSinValor_DebeLanzarExcepcion()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();
            var service = new ContactoServiceImpl(repositoryMock.Object);

            var contacto = new Contacto
            {
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = ""
            };

            // Act
            try
            {
                service.Crear(contacto);

                Assert.Fail("Se esperaba una ArgumentException.");
            }
            catch (ArgumentException)
            {
                // Correcto
            }
        }

        [TestMethod]
        public void Crear_ContactoValido_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            repositoryMock
                .Setup(r => r.Crear(It.IsAny<Contacto>()))
                .Returns(20);

            var service = new ContactoServiceImpl(repositoryMock.Object);

            var contacto = new Contacto
            {
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = "correo@prueba.com"
            };

            // Act
            int resultado = service.Crear(contacto);

            // Assert
            Assert.AreEqual(20, resultado);

            repositoryMock.Verify(
                r => r.Crear(It.IsAny<Contacto>()),
                Times.Once);
        }

        [TestMethod]
        public void Actualizar_ContactoValido_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            repositoryMock
                .Setup(r => r.Actualizar(It.IsAny<Contacto>()))
                .Returns(true);

            var service = new ContactoServiceImpl(repositoryMock.Object);

            var contacto = new Contacto
            {
                Id = 1,
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = "correo@actualizado.com"
            };

            // Act
            bool resultado = service.Actualizar(contacto);

            // Assert
            Assert.IsTrue(resultado);

            repositoryMock.Verify(
                r => r.Actualizar(It.IsAny<Contacto>()),
                Times.Once);
        }


        [TestMethod]
        public void ObtenerPorId_ContactoExistente_DebeRegresarContacto()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            var contactoEsperado = new Contacto
            {
                Id = 1,
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = "correo@prueba.com"
            };

            repositoryMock
                .Setup(r => r.ObtenerPorId(1))
                .Returns(contactoEsperado);

            var service = new ContactoServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerPorId(1);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
            Assert.AreEqual(1, resultado.ClienteId);
            Assert.AreEqual("correo@prueba.com", resultado.Valor);

            repositoryMock.Verify(
                r => r.ObtenerPorId(1),
                Times.Once);
        }


        [TestMethod]
        public void ObtenerTodos_DebeRegresarContactos()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            var contactosEsperados = new List<Contacto>
                {
                    new Contacto
                    {
                        Id = 1,
                        ClienteId = 1,
                        TipoContactoId = 1,
                        Valor = "correo@prueba.com"
                    },
                    new Contacto
                    {
                        Id = 2,
                        ClienteId = 1,
                        TipoContactoId = 2,
                        Valor = "5551234567"
                    }
                };

            repositoryMock
                .Setup(r => r.ObtenerTodos())
                .Returns(contactosEsperados);

            var service = new ContactoServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("correo@prueba.com", resultado[0].Valor);
            Assert.AreEqual("5551234567", resultado[1].Valor);

            repositoryMock.Verify(
                r => r.ObtenerTodos(),
                Times.Once);
        }


        [TestMethod]
        public void Eliminar_ContactoExistente_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            repositoryMock
                .Setup(r => r.Eliminar(1))
                .Returns(true);

            var service = new ContactoServiceImpl(repositoryMock.Object);

            // Act
            bool resultado = service.Eliminar(1);

            // Assert
            Assert.IsTrue(resultado);

            repositoryMock.Verify(
                r => r.Eliminar(1),
                Times.Once);
        }


        [TestMethod]
        public void Crear_ContactoValido_DebeCrearContacto_Fake()
        {
            // Arrange
            var repository = new ContactoRepositoryFake();
            var service = new ContactoServiceImpl(repository);

            var contacto = new Contacto
            {
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = "fake@prueba.com"
            };

            // Act
            int resultado = service.Crear(contacto);

            // Assert
            Assert.AreEqual(1, resultado);
        }


        [TestMethod]
        public void Crear_TipoContactoValido_DebeCrearTipoContacto_Fake()
        {
            // Arrange
            var repository = new TipoContactoRepositoryFake();
            var service = new TipoContactoServiceImpl(repository);

            var tipoContacto = new TipoContacto
            {
                Descripcion = "Correo"
            };

            // Act
            int resultado = service.Crear(tipoContacto);

            // Assert
            Assert.AreEqual(1, resultado);
        }


        [TestMethod]
        public void Crear_TipoContactoValido_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<ITipoContactoRepository>();

            repositoryMock
                .Setup(r => r.Crear(It.IsAny<TipoContacto>()))
                .Returns(5);

            var service = new TipoContactoServiceImpl(repositoryMock.Object);

            var tipoContacto = new TipoContacto
            {
                Descripcion = "Correo"
            };

            // Act
            int resultado = service.Crear(tipoContacto);

            // Assert
            Assert.AreEqual(5, resultado);

            repositoryMock.Verify(
                r => r.Crear(It.IsAny<TipoContacto>()),
                Times.Once);

        }

        [TestMethod]
        public void Actualizar_TipoContactoValido_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<ITipoContactoRepository>();

            repositoryMock
                .Setup(r => r.Actualizar(It.IsAny<TipoContacto>()))
                .Returns(true);

            var service = new TipoContactoServiceImpl(repositoryMock.Object);

            var tipoContacto = new TipoContacto
            {
                Id = 1,
                Descripcion = "Correo actualizado"
            };

            // Act
            bool resultado = service.Actualizar(tipoContacto);

            // Assert
            Assert.IsTrue(resultado);

            repositoryMock.Verify(
                r => r.Actualizar(It.IsAny<TipoContacto>()),
                Times.Once);
        }


        [TestMethod]
        public void ObtenerPorId_TipoContactoExistente_DebeRegresarTipoContacto()
        {
            // Arrange
            var repositoryMock = new Mock<ITipoContactoRepository>();

            var tipoEsperado = new TipoContacto
            {
                Id = 1,
                Descripcion = "Correo"
            };

            repositoryMock
                .Setup(r => r.ObtenerPorId(1))
                .Returns(tipoEsperado);

            var service = new TipoContactoServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerPorId(1);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
            Assert.AreEqual("Correo", resultado.Descripcion);

            repositoryMock.Verify(
                r => r.ObtenerPorId(1),
                Times.Once);
        }

        [TestMethod]
        public void ObtenerTodos_DebeRegresarTiposContacto()
        {
            // Arrange
            var repositoryMock = new Mock<ITipoContactoRepository>();

                    var tiposEsperados = new List<TipoContacto>
            {
                new TipoContacto
                {
                    Id = 1,
                    Descripcion = "Correo"
                },
                new TipoContacto
                {
                    Id = 2,
                    Descripcion = "Teléfono"
                }
            };

            repositoryMock
                .Setup(r => r.ObtenerTodos())
                .Returns(tiposEsperados);

            var service = new TipoContactoServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("Correo", resultado[0].Descripcion);
            Assert.AreEqual("Teléfono", resultado[1].Descripcion);

            repositoryMock.Verify(
                r => r.ObtenerTodos(),
                Times.Once); 

        }

        [TestMethod]
        public void Eliminar_TipoContactoExistente_DebeLlamarAlRepositorio()
        {
            // Arrange
            var repositoryMock = new Mock<ITipoContactoRepository>();

            repositoryMock
                .Setup(r => r.Eliminar(1))
                .Returns(true);

            var service = new TipoContactoServiceImpl(repositoryMock.Object);

            // Act
            bool resultado = service.Eliminar(1);

            // Assert
            Assert.IsTrue(resultado);

            repositoryMock.Verify(
                r => r.Eliminar(1),
                Times.Once);
        }


        [TestMethod]
        public void ObtenerPorCliente_DebeRegresarContactosDto()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            var contactos = new List<Contacto>
                {
                    new Contacto
                    {
                        Id = 1,
                        ClienteId = 10,
                        TipoContactoId = 1,
                        Valor = "correo@prueba.com"
                    },
                    new Contacto
                    {
                        Id = 2,
                        ClienteId = 10,
                        TipoContactoId = 2,
                        Valor = "5551234567"
                    }
                };

            repositoryMock
                .Setup(r => r.ObtenerPorCliente(10))
                .Returns(contactos);

            var service = new ContactoServiceImpl(repositoryMock.Object);

            // Act
            var resultado = service.ObtenerPorCliente(10);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);

            Assert.IsNotNull(resultado);
            Assert.HasCount(2, resultado);


            Assert.AreEqual("correo@prueba.com", resultado[0].Valor);
            Assert.AreEqual("5551234567", resultado[1].Valor);

            repositoryMock.Verify(
                r => r.ObtenerPorCliente(10),
                Times.Once);
        }


        [TestMethod]
        public void ObtenerPorCliente_DebeRegresarContactosDto_Fake()
        {
            // Arrange
            var repository = new ContactoRepositoryFake();
            var service = new ContactoServiceImpl(repository);

            // Act
            var resultado = service.ObtenerPorCliente(10);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual("fake@prueba.com", resultado[0].Valor);
            Assert.AreEqual("5551234567", resultado[1].Valor);


        }


        [TestMethod]
        public void Actualizar_ContactoSinId_DebeLanzarExcepcion()
        {
            // Arrange
            var repositoryMock = new Mock<IContactoRepository>();

            var service = new ContactoServiceImpl(repositoryMock.Object);

            var contacto = new Contacto
            {
                Id = 0,
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = "correo@prueba.com"
            };

            // Act + Assert
            try
            {
                service.Actualizar(contacto);

                Assert.Fail("Se esperaba una ArgumentException.");
            }
            catch (ArgumentException)
            {
                // Correcto
            }


        }


    }
}