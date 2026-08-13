using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


using WebFormsMejoresPracticas.Infrastructure.Database;
using WebFormsMejoresPracticas.Models;


namespace WebFormsMejoresPracticas.Repositories
{
    public class TipoContactoRepository : ITipoContactoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ILogger<TipoContactoRepository> _logger;

        public TipoContactoRepository(
            IDbConnectionFactory connectionFactory,
            ILogger<TipoContactoRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public TipoContacto ObtenerPorId(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de tipo de contacto. Id: {TipoContactoId}",
                    id);

                TipoContacto tipoContacto = null;

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_TipoContacto_ObtenerPorId",
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
                            tipoContacto = new TipoContacto
                            {
                                Id = reader.GetInt32(
                                    reader.GetOrdinal("Id")),

                                Descripcion = reader.GetString(
                                    reader.GetOrdinal("Descripcion"))
                            };
                        }
                    }
                }

                _logger.LogInformation(
                    "Consulta de tipo de contacto finalizada. Id: {TipoContactoId}. Encontrado: {Encontrado}",
                    id,
                    tipoContacto != null);

                return tipoContacto;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al consultar tipo de contacto. Id: {TipoContactoId}",
                    id);

                throw;
            }
        }

        public List<TipoContacto> ObtenerTodos()
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de tipos de contacto.");

                var tiposContacto = new List<TipoContacto>();

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_TipoContacto_ObtenerTodos",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tiposContacto.Add(new TipoContacto
                            {
                                Id = reader.GetInt32(
                                    reader.GetOrdinal("Id")),

                                Descripcion = reader.GetString(
                                    reader.GetOrdinal("Descripcion"))
                            });
                        }
                    }
                }

                _logger.LogInformation(
                    "Consulta de tipos de contacto finalizada. Registros encontrados: {Cantidad}",
                    tiposContacto.Count);

                return tiposContacto;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al consultar los tipos de contacto.");

                throw;
            }
        }

        public int Crear(TipoContacto tipoContacto)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando creación de tipo de contacto. Descripción: {Descripcion}",
                    tipoContacto.Descripcion);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_TipoContacto_Crear",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@Descripcion",
                        SqlDbType.NVarChar,
                        50).Value = tipoContacto.Descripcion;

                    connection.Open();

                    int id = Convert.ToInt32(
                        command.ExecuteScalar());

                    _logger.LogInformation(
                        "Tipo de contacto creado correctamente. Id: {TipoContactoId}",
                        id);

                    return id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al crear tipo de contacto. Descripción: {Descripcion}",
                    tipoContacto?.Descripcion);

                throw;
            }
        }

        public void Actualizar(TipoContacto tipoContacto)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando actualización de tipo de contacto. Id: {TipoContactoId}",
                    tipoContacto.Id);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_TipoContacto_Actualizar",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@Id",
                        SqlDbType.Int).Value = tipoContacto.Id;

                    command.Parameters.Add(
                        "@Descripcion",
                        SqlDbType.NVarChar,
                        50).Value = tipoContacto.Descripcion;

                    connection.Open();

                    int registrosAfectados = command.ExecuteNonQuery();

                    _logger.LogInformation(
                        "Actualización de tipo de contacto finalizada. Id: {TipoContactoId}. Registros afectados: {RegistrosAfectados}",
                        tipoContacto.Id,
                        registrosAfectados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar tipo de contacto. Id: {TipoContactoId}",
                    tipoContacto?.Id);

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando eliminación de tipo de contacto. Id: {TipoContactoId}",
                    id);

                using (var connection = _connectionFactory.CreateConnection())
                using (var command = new SqlCommand(
                    "dbo.spr_TipoContacto_Eliminar",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        "@Id",
                        SqlDbType.Int).Value = id;

                    connection.Open();

                    int registrosAfectados = command.ExecuteNonQuery();

                    _logger.LogInformation(
                        "Eliminación de tipo de contacto finalizada. Id: {TipoContactoId}. Registros afectados: {RegistrosAfectados}",
                        id,
                        registrosAfectados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al eliminar tipo de contacto. Id: {TipoContactoId}",
                    id);

                throw;
            }
        }
    }
}
