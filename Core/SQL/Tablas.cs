using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQL
{


    /*Script de tablas*/

    /*
     * 
 
    ------------------- Nombre de base de datos por defecto del gestor postgresql
      create database postgres
      with owner postgres;

      comment on database postgres is 'default administrative connection database';
    ---------------------------


        create table employees
        (
            id         integer generated always as identity
                constraint employees_pk
                    primary key,
            first_name varchar(100),
            last_name  varchar(100),
            email_id   varchar(100)
        );

        alter table employees
            owner to postgres;

    --------------------------------------------------------------------------------------------------------------------------

        create table products
        (
            id          integer generated always as identity
                constraint product_key
                    primary key,
            name        varchar(100),
            description varchar(100),
            sku         varchar(100),
            unitprice   numeric,
            active      boolean
        );

        alter table products
            owner to postgres;


    
    --------------------------------------------------------------------------------------------------------------------------

        create table rates
        (
            id       integer generated always as identity
                constraint rates_pk
                    primary key,
            daterate date,
            ratecord numeric,
            rateusd  numeric
        );

        comment on column rates.daterate is 'fecha de tasa cambio';

        comment on column rates.ratecord is 'tasa en cordobas';

        comment on column rates.rateusd is 'tasa en dolares';

        alter table rates
            owner to postgres;

    
    --------------------------------------------------------------------------------------------------------------------------

        create table prices
        (
            id        integer generated always as identity
                constraint prices_pk
                    primary key,
            idrate    integer
                constraint prices_rates_id_fk
                    references rates,
            idproduct integer
                constraint "prices_products_Id_fk"
                    references products,
            pricecord numeric,
            priceusd  numeric
        );

        comment on column prices.id is 'clave primaria precios';

        alter table prices
            owner to postgres;

    
    --------------------------------------------------------------------------------------------------------------------------

        create table factura
        (
            id            integer generated always as identity
                constraint factura_pk
                    primary key,
            idcliente     integer,
            numerofactura integer,
            fechafactura  date,
            iva           numeric,
            subtotal      numeric,
            total         numeric
        );

        alter table factura
            owner to postgres;

    
    --------------------------------------------------------------------------------------------------------------------------

        create table detallefactura
        (
            id         integer generated always as identity
                constraint detallefactura_pk
                    primary key,
            idproducto integer,
            idfactura  integer,
            cantidad   integer
        );

        alter table detallefactura
            owner to postgres;


    
    --------------------------------------------------------------------------------------------------------------------------



    
        create view consultarproductosactivos(id, name, description, sku, preciocordprod, priceusdprod) as
        SELECT ps.id,
               ps.name,
               ps.description,
               ps.sku,
               ps.unitprice                     AS preciocordprod,
               (SELECT round(prices.priceusd, 4) AS priceusdprod
                FROM prices
                WHERE prices.idproduct = ps.id) AS priceusdprod
        FROM products ps
        WHERE ps.active = true;

        alter table consultarproductosactivos
            owner to postgres;


     --------------------------------------------------------------------------------------------------------------------------


        create view consultarproductosgeneral(id, name, description, sku, preciocordprod, rateday) as
        SELECT ps.id,
               ps.name,
               ps.description,
               ps.sku,
               ps.unitprice                AS preciocordprod,
               (SELECT r.ratecord AS rateday
                FROM prices p
                         JOIN rates r ON r.id = p.idrate
                WHERE p.idproduct = ps.id) AS rateday
        FROM products ps;

        alter table consultarproductosgeneral
            owner to postgres;

    --------------------------------------------------------------------------------------------------------------------------


        create view consultarfacturas
                    (id, idcliente, numerofactura, fechafactura, subtotal, iva, total, idproducto, cantidad) as
        SELECT f.id,
               f.idcliente,
               f.numerofactura,
               f.fechafactura,
               f.subtotal,
               f.iva,
               f.total,
               d.idproducto,
               d.cantidad
        FROM factura f
                 JOIN detallefactura d ON d.idfactura = f.numerofactura;

        alter table consultarfacturas
            owner to postgres;

     
     */


}
