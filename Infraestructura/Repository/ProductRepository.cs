using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using static Dapper.SqlMapper;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration configuration;
        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Product entity)
        {
           entity.active = true;
            var sql = "Insert into Products (name,description,sku,active,unitprice) VALUES (@name,@description,@sku,@active,@unitprice)";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }


        public async Task<int> AddProductAsync(Product prod)
        {
            Price prc = new Price();
            Rate rt = new Rate();

            //insertar producto
            prod.active = true;
            var sql = "Insert into products (name,description,sku,active,unitprice) VALUES (@name,@description,@sku,@active,@unitprice)";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, prod);
                using (IDbTransaction transaccion = connection.BeginTransaction())
                {
                    // Obtener id del producto recién agregado
                    prod.id = connection.Query<int>("SELECT MAX(id) FROM products", null, transaccion).Single();

                    //buscar tasa de cambio
                    var sqlRate = "SELECT * FROM rates WHERE daterate = @daterate";
                    var ObjTasaCambio = await connection.QuerySingleOrDefaultAsync<Rate>(sqlRate, new { daterate = prod.DateRateProduct });
                 

                    //validar precio                  
                    var cambioUsd = prod.unitprice / ObjTasaCambio.ratecord ; 

                    // Agregar precio
                    var parametrosPrecio = new DynamicParameters();
                    parametrosPrecio.Add("@idrate", ObjTasaCambio.id);
                    parametrosPrecio.Add("@idproduct", prod.id);               
                    parametrosPrecio.Add("@pricecord", prod.unitprice);
                    parametrosPrecio.Add("@priceusd", cambioUsd);
                    var res = connection.Execute("INSERT INTO prices (idrate, idproduct, pricecord,priceusd) VALUES (@idrate, @idproduct, @pricecord, @priceusd)", parametrosPrecio, transaccion);

                    transaccion.Commit();
                }

                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var sql = "select * from products;";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        /// <summary>
        /// Consultar Activos
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductDTO>> GetActiveProductsAsync()
        {
            var sql = "select * from consultarproductosactivos;";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductDTO>(sql);
                return result.ToList();
            }
        }



        /// <summary>
        /// Consultar por descripcion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductDTO>> GetByDescriptionAsync(string name)
        {
            var sql = "select * from consultarproductosgeneral where description =@desc;";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductDTO>(sql, new { desc = name });
                return result.ToList();
            }
        }

        /// <summary>
        /// consultar por sku
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductDTO>> GetBySkuAsync(string name)
        {
            var sql = "select * from consultarproductosgeneral where sku=@sku;";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductDTO>(sql, new { sku = name });
                return result.ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            var sql = "SELECT * FROM Products WHERE Name = @name";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Name = name });
                return result;
            }
        }

       

        public async Task<int> UpdateAsync(Product entity)
        {
           
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

       
    }
}
