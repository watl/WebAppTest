using Application.Interface;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infraestructura.Repository
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly IConfiguration configuration;
        public DetalleFacturaRepository(IConfiguration configuration) 
        {
          this.configuration = configuration;
        }


        public async Task<int> AgregarDetalleFacturaAsync(DetalleFactura dt)
        {
            Factura fc = new Factura();
            Product prd= new Product();
            decimal total = 0;
            decimal subtotal = 0;
            decimal iva = 0;
      

            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
               

                connection.Open();

      

                var sql = "Insert into detallefactura (idproducto,idfactura,cantidad) VALUES (@idproducto,@idfactura,@cantidad)";
                var result = await connection.ExecuteAsync(sql, dt);
                using (IDbTransaction transaccion = connection.BeginTransaction())
                {
                    //obtener detalle ingresado
                    var sqlDetalleFact = "SELECT * FROM detallefactura WHERE idfactura = @id";
                    var listaProductos = await connection.QueryAsync<DetalleFactura>(sqlDetalleFact, new { id = dt.idfactura });

                    //consulta productos
                    var sqlProd = "SELECT * FROM product WHERE id = @id";

                 
                    foreach (var producto in listaProductos)
                    {
                        //Obtener producto                
                        var ObjProducto = await connection.QuerySingleOrDefaultAsync<Product>(sqlProd, new { id = dt.idproducto });
                    
                      
                        subtotal += ((decimal)producto.cantidad * ObjProducto.unitprice);
                        iva += subtotal * (decimal)0.15;
                        total += subtotal + iva;
                    }

                    //actualizar informacion en tabla Factura por numeroFactura.
                    var sqlUpdateFact = "UPDATE factura SET subtotal = @value1, iva = @value2,  total = @value3  WHERE id = @Id";
                    var resultUpdate = await connection.ExecuteAsync(sql, new { value1 = subtotal, value2 = iva, value3 = total , id = dt.idfactura });





                }
                return result;
            }
        
        }

        public Task<int> AddAsync(DetalleFactura entity)
        {
            throw new NotImplementedException();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM detallefactura WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<DetalleFactura>> GetAllAsync()
        {
            var sql = "SELECT * FROM detallefactura";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<DetalleFactura>(sql);
                return result.ToList();
            }
        }

        public async Task<DetalleFactura> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM detallefactura WHERE Id = @Id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<DetalleFactura>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(DetalleFactura entity)
        {
            var sql = "UPDATE detallefactura SET idproducto = @idproducto, idfactura = @idfactura  WHERE id = @id";
            using (var connection = new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
