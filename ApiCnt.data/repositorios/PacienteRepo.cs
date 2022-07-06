using ApiCnt.model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCnt.data.repositorios
{
    public class PacienteRepo : Ipacientes
    {
        private MySQLConfig _connectionString;
        public PacienteRepo(MySQLConfig connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<paciente>> GetallPacientes(string parametro)
        {
            var db = dbConnection();
            var sql = "";
            if (parametro == "prioridad") {
                sql = @"SELECT  p.numeroDocumento, p.nombres, p.apellidos, p.sexo, p.edad, p.peso, p.estatura, p.fumador, p.yearsFumando, p.dieta, p.pesoEstatura, p.prioridad, p.riesgo, p.direccion, e.estadoPaciente FROM paciente as p join estado as e on p.numeroDocumento = e.documento where e.estadoPaciente = 'Pendiente' order by prioridad DESC";
            }else if (parametro == "riesgo"){
                sql = @"SELECT  p.numeroDocumento, p.nombres, p.apellidos, p.sexo, p.edad, p.peso, p.estatura, p.fumador, p.yearsFumando, p.dieta, p.pesoEstatura, p.prioridad, p.riesgo, p.direccion, e.estadoPaciente FROM paciente as p join estado as e on p.numeroDocumento = e.documento where e.estadoPaciente = 'Pendiente' order by riesgo DESC";
            }
            

            return await db.QueryAsync<paciente>(sql, new { });
        }

       

        public async Task<bool> UpdateEstadoPaciente(string documento)
        {
            var db = dbConnection();

            var sql = @"update estado as e join paciente as p on e.documento = p.numeroDocumento set estadoPaciente = 'Atendido' where documento = @Documento";

            var result = await db.ExecuteAsync(sql, new { Documento = documento });

            return result > 0;
        }

        public async Task<bool> DetelePaciente(string documento)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM paciente WHERE numeroDocumento = @Documento";

            var result = await db.ExecuteAsync(sql, new { Documento = documento });

            return result > 0;
        }

        public async Task<bool> InsertPaciente(paciente p)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO paciente (numeroDocumento, nombres, apellidos, sexo, edad, peso, estatura, fumador, yearsFumando, dieta, pesoEstatura, prioridad, riesgo, direccion)
                        values(@NumeroDocumento, @Nombres, @Apellidos, @Sexo, @Edad, @Peso, @Estatura, @Fumador, @YearsFumando, @Dieta, @PesoEstatura, @Prioridad, @Riesgo, @Direccion) ";

            var result = await db.ExecuteAsync(sql, new { p.numeroDocumento, p.nombres, p.apellidos, p.sexo, p.edad, p.peso, p.estatura, p.fumador, p.yearsFumando, p.dieta, p.pesoEstatura, p.prioridad, p.riesgo, p.direccion});
            Console.WriteLine(sql);
            return result > 0;
        }

        public async Task<IEnumerable<paciente>> Fumador()
        {
            var db = dbConnection();
            var sqlf = @"SELECT  p.numeroDocumento, p.nombres, p.apellidos, p.sexo, p.edad, p.peso, p.estatura, p.fumador, p.yearsFumando, p.dieta, p.pesoEstatura, p.prioridad, p.riesgo, p.direccion, e.estadoPaciente FROM paciente as p join estado as e on p.numeroDocumento = e.documento where e.estadoPaciente = 'Pendiente' and p.fumador = 1 ORDER BY p.prioridad DESC LIMIT 1";
            
            return await db.QueryAsync<paciente>(sqlf, new { }); ;
        }
        public async Task<IEnumerable<paciente>> Menor()
        {
            var db = dbConnection();
            
            var sqlMe = @"SELECT  p.numeroDocumento, p.nombres, p.apellidos, p.sexo, p.edad, p.peso, p.estatura, p.fumador, p.yearsFumando, p.dieta, p.pesoEstatura, p.prioridad, p.riesgo, p.direccion, e.estadoPaciente FROM paciente as p join estado as e on p.numeroDocumento = e.documento where e.estadoPaciente = 'Pendiente'  ORDER BY p.edad ASC LIMIT 1";
            
            return await db.QueryAsync<paciente>(sqlMe, new { }); ;
        }
        public async Task<IEnumerable<paciente>> Mayor()
        {
            var db = dbConnection();
            
            var sqlMa = @"SELECT  p.numeroDocumento, p.nombres, p.apellidos, p.sexo, p.edad, p.peso, p.estatura, p.fumador, p.yearsFumando, p.dieta, p.pesoEstatura, p.prioridad, p.riesgo, p.direccion, e.estadoPaciente FROM paciente as p join estado as e on p.numeroDocumento = e.documento where e.estadoPaciente = 'Pendiente'  ORDER BY p.edad DESC LIMIT 1";
            return await db.QueryAsync<paciente>(sqlMa, new { }); ;
        }
    }
}
