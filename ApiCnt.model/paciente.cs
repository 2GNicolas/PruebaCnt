using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCnt.model
{
    public class paciente
    {
        public string numeroDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public double peso { get; set; }
        public double estatura { get; set; }
        public int fumador { get; set; }
        public int yearsFumando { get; set; }
        public int dieta { get; set; }
        public int pesoEstatura { get; set; }
        public int prioridad { get; set; }
        public double riesgo { get; set; }
        public string direccion { get; set; }
        public string estadoPaciente { get; set; }

        

    }
}
