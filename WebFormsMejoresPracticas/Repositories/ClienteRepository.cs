using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


using WebFormsMejoresPracticas.Infrastructure.Database;
using WebFormsMejoresPracticas.Models;
 
namespace WebFormsMejoresPracticas.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ILogger<ClienteRepository> _logger;
 

        public ClienteRepository(
                        IDbConnectionFactory connectionFactory,
                        ILogger<ClienteRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public Cliente ObtenerPorId(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de cliente. Id: {ClienteId}",
                    id);

                Cliente cliente = null;

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_Cliente_ObtenerPorId",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@Id",
                        SqlDbType.Int).Value = id;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                Id = reader.GetInt32(
                                    reader.GetOrdinal("Id")),

                                Nombre = reader.GetString(
                                    reader.GetOrdinal("Nombre"))
                            };
                        }
                    }
                }

                _logger.LogInformation(
                    "Consulta de cliente finalizada. Id: {ClienteId}. Encontrado: {Encontrado}",
                    id,
                    cliente != null);

                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al consultar cliente. Id: {ClienteId}",
                    id);

                throw;
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de clientes.");

                var clientes = new List<Cliente>();

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand("dbo.spr_Cliente_ObtenerTodos",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = reader.GetInt32(
                                    reader.GetOrdinal("Id")),

                                Nombre = reader.GetString(
                                    reader.GetOrdinal("Nombre"))
                            });
                        }
                    }
                }

                _logger.LogInformation(
                    "Consulta de clientes finalizada. Registros encontrados: {Cantidad}",
                    clientes.Count);

                return clientes;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al consultar los clientes.");

                throw;
            }
        }

        public int Crear(Cliente cliente)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando creación de cliente. Nombre: {Nombre}",
                    cliente.Nombre);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand("dbo.spr_Cliente_Crear",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Nombre",SqlDbType.NVarChar,100).Value = cliente.Nombre;

                    connection.Open();

                    int id = Convert.ToInt32(
                        command.ExecuteScalar());

                    _logger.LogInformation(
                        "Cliente creado correctamente. Id: {ClienteId}",
                        id);

                    return id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error al crear cliente. Nombre: {Nombre}",
                            cliente?.Nombre
                            );

                throw;
            }
        }
        public void Actualizar(Cliente cliente)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando actualización de cliente. Id: {ClienteId}",
                    cliente.Id);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand("dbo.spr_Cliente_Actualizar",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id",SqlDbType.Int).Value = cliente.Id;

                    command.Parameters.Add("@Nombre",SqlDbType.NVarChar,100).Value = cliente.Nombre;

                    connection.Open();

                    int registrosAfectados = command.ExecuteNonQuery();

                    _logger.LogInformation(
                        "Actualización de cliente finalizada. Id: {ClienteId}. Registros afectados: {RegistrosAfectados}",
                        cliente.Id,
                        registrosAfectados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar cliente. Id: {ClienteId}",
                    cliente?.Id);

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando eliminación de cliente. Id: {ClienteId}",
                    id);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand("dbo.spr_Cliente_Eliminar",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id",SqlDbType.Int).Value = id;

                    connection.Open();

                    int registrosAfectados = command.ExecuteNonQuery();

                    _logger.LogInformation(
                        "Eliminación de cliente finalizada. Id: {ClienteId}. Registros afectados: {RegistrosAfectados}",
                        id,
                        registrosAfectados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al eliminar cliente. Id: {ClienteId}",
                    id);

                throw;
            }
        }
    }
}