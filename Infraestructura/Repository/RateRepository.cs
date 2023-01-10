using Application.Interface;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public class RateRepository : IRateRepository
    {
        private readonly IConfiguration configuration;

        public RateRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Rate entity)
        {
            var sql = "Insert into rates (daterate,ratecord,rateusd) VALUES (@daterate,@ratecord,@rateusd)";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM rates WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Rate>> GetAllAsync()
        {
            var sql = "SELECT * FROM rates";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Rate>(sql);
                return result.ToList();
            }
        }

        public async Task<Rate> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM rates WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Rate>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Rate entity)
        {
            var sql = "UPDATE rates SET daterate = @daterate, ratecord = @ratecord, rateusd = @rateusd  WHERE Id = @id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<Rate> GetByDateRateAsync(DateTime fch)
        {
            var sql = "SELECT * FROM rates WHERE daterate = @daterate";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Rate>(sql, new { daterate = fch });
                return result;
            }
        }

        public async Task<IReadOnlyList<Rate>> GetByMonthRateAsync(DateTime initfch, DateTime finalfch)
        {
            var sql = "SELECT * FROM rates WHERE daterate >= @initdate and daterate <=@finaldate";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Rate>(sql, new { initdate = initfch, finaldate = finalfch });
                return result.ToList();
            }
        }

       
    }
}
