using Application.Interface;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly IConfiguration configuration;
        public PriceRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// guardar datos de precios
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(Price entity)
        {
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                 connection.Open();

                var parametros = new DynamicParameters();
                parametros.Add("@idproduct", entity.idproduct);
                parametros.Add("@idrate", entity.idrate);
                parametros.Add("@pricecord", entity.pricecord);
                parametros.Add("@priceusd", entity.priceusd);
                var result =  connection.Execute("INSERT INTO prices (idproduct,idrate, pricecord, priceusd) VALUES (@IdProducto,@idrate ,@pricecord, @priceusd)", parametros);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Price>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Price> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Price entity)
        {
            throw new NotImplementedException();
        }
    }
}
