using Application.Interface;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infraestructura.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IConfiguration configuration;
        public FacturaRepository(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Factura entity)
        {
            entity.fechafactura = DateTime.Now;
            var sql = "Insert into factura (idcliente,numerofactura,fechafactura,iva,subtotal,total) VALUES (@idcliente,@numerofactura,@fechafactura,@iva,@subtotal,@total)";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM factura WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Factura>> GetAllAsync()
        {
            var sql = "SELECT * FROM factura";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Factura>(sql);
                return result.ToList();
            }
        }

        public async Task<Factura> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM factura WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Factura>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<FacturaDTO>> ObtenerFacturasAsync()
        {
            var sql = "select * from consultarfacturas";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<FacturaDTO>(sql);
                return result.ToList();
            }
        }

        public async Task<int> UpdateAsync(Factura entity)
        {
            var sql = "UPDATE factura SET numerofactura = @numerofactura, fechafactura = @fechafactura  WHERE id = @id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
