using ApiCnt.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCnt.data.repositorios
{
    public interface Ipacientes
    {
        Task<IEnumerable<paciente>> GetallPacientes(string parametro);
        Task<bool> InsertPaciente(paciente p);
        Task<bool> UpdateEstadoPaciente(string documento);
        Task<bool> DetelePaciente(string documento);
        Task<IEnumerable<paciente>> Fumador();
        Task<IEnumerable<paciente>> Menor();
        Task<IEnumerable<paciente>> Mayor();

    }
}
