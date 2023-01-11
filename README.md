# WebAppTest
Proyecto backend



El siguiente proyecto esta desarrollado con las siguientes tecnologias:
* C# --> Net 6 LTS.
* Dapper --> para el acceso a datos.
* Npgsql --> para conexion a la base de datos.
* Sql --> PostgreSql version 11, BDName --> postgres(base de datos por defecto del gestor).
* Estructura --> patron repositorio.



EL proyecto fue elaborado en VS2022 de tipo web api Net 6, utilizando como base de datos PostgreSql 11.
Estructura ---> la solucion Cuenta con 4 capas (Aplicacion,Core {scripts de base de datos} ,Infraestructura, WebApi{aca pueden encontrar los controladores}  ).

appsettings.json ---> conexion BD.

Ejecucion ---> Abrir aplicacion, restaurar scripts sql.
