using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using WebFormsMejoresPracticas.Infrastructure.Database;
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ILogger<ContactoRepository> _logger;

        public ContactoRepository(
            IDbConnectionFactory connectionFactory,
            ILogger<ContactoRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public List<Contacto> ObtenerTodos()
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de contactos.");

                var contactos = new List<Contacto>();

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_Contacto_ObtenerTodos",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contactos.Add(new Contacto
                            {
                                Id = reader.GetInt32(
                                    reader.GetOrdinal("Id")),

                                ClienteId = reader.GetInt32(
                                    reader.GetOrdinal("ClienteId")),

                                TipoContactoId = reader.GetInt32(
                                    reader.GetOrdinal("TipoContactoId")),

                                Valor = reader.GetString(
                                    reader.GetOrdinal("Valor")),

                                ClienteNombre = reader.GetString(
                                    reader.GetOrdinal("ClienteNombre")),

                                TipoContactoDescripcion = reader.GetString(
                                    reader.GetOrdinal("TipoContactoDescripcion"))
                            });
                        }
                    }
                }

                _logger.LogInformation(
                    "Consulta de contactos finalizada. Registros encontrados: {Cantidad}",
                    contactos.Count);

                return contactos;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al consultar los contactos.");

                throw;
            }
        }

        public Contacto ObtenerPorId(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de contacto. Id: {ContactoId}",
                    id);

                Contacto contacto = null;

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_Contacto_ObtenerPorId",
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
                            contacto = new Contacto
                            {
                                Id = reader.GetInt32(
                                    reader.GetOrdinal("Id")),

                                ClienteId = reader.GetInt32(
                                    reader.GetOrdinal("ClienteId")),

                                TipoContactoId = reader.GetInt32(
                                    reader.GetOrdinal("TipoContactoId")),

                                Valor = reader.GetString(
                                    reader.GetOrdinal("Valor"))
                            };
                        }
                    }
                }

                _logger.LogInformation(
                    "Consulta de contacto finalizada. Id: {ContactoId}. Encontrado: {Encontrado}",
                    id,
                    contacto != null);

                return contacto;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al consultar contacto. Id: {ContactoId}",
                    id);

                throw;
            }
        }

        public void Insertar(Contacto contacto)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando creación de contacto. ClienteId: {ClienteId}",
                    contacto.ClienteId);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_Contacto_Crear",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@ClienteId",
                        SqlDbType.Int).Value = contacto.ClienteId;

                    command.Parameters.Add(
                        "@TipoContactoId",
                        SqlDbType.Int).Value = contacto.TipoContactoId;

                    command.Parameters.Add(
                        "@Valor",
                        SqlDbType.NVarChar, 200).Value = contacto.Valor;

                    connection.Open();

                    int id = Convert.ToInt32(
                        command.ExecuteScalar());

                    contacto.Id = id;

                    _logger.LogInformation(
                        "Contacto creado correctamente. Id: {ContactoId}",
                        id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al crear contacto. ClienteId: {ClienteId}",
                    contacto?.ClienteId);

                throw;
            }
        }
        public void Actualizar(Contacto contacto)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando actualización de contacto. Id: {ContactoId}",
                    contacto.Id);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_Contacto_Actualizar",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@Id",
                        SqlDbType.Int).Value = contacto.Id;

                    command.Parameters.Add(
                        "@ClienteId",
                        SqlDbType.Int).Value = contacto.ClienteId;

                    command.Parameters.Add(
                        "@TipoContactoId",
                        SqlDbType.Int).Value = contacto.TipoContactoId;

                    command.Parameters.Add(
                        "@Valor",
                        SqlDbType.NVarChar, 200).Value = contacto.Valor;

                    connection.Open();

                    int registrosAfectados =
                        command.ExecuteNonQuery();

                    _logger.LogInformation(
                        "Actualización de contacto finalizada. Id: {ContactoId}. Registros afectados: {RegistrosAfectados}",
                        contacto.Id,
                        registrosAfectados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar contacto. Id: {ContactoId}",
                    contacto?.Id);

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando eliminación de contacto. Id: {ContactoId}",
                    id);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_Contacto_Eliminar",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@Id",
                        SqlDbType.Int).Value = id;

                    connection.Open();

                    int registrosAfectados =
                        command.ExecuteNonQuery();

                    _logger.LogInformation(
                        "Eliminación de contacto finalizada. Id: {ContactoId}. Registros afectados: {RegistrosAfectados}",
                        id,
                        registrosAfectados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al eliminar contacto. Id: {ContactoId}",
                    id);

                throw;
            }
        }
    }
}