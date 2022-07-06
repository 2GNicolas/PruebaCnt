using ApiCnt.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplication.Models
{
    public class metodosComplementarios
    {
        public paciente PrioridadYRiesgo(paciente p)
        {
            if (p.edad >= 1 & p.edad < 15)
            {
                if (p.edad >= 1 & p.edad < 5)
                {
                    p.prioridad = p.pesoEstatura + 3;
                }
                else if (p.edad > 6 & p.edad < 12)
                {
                    p.prioridad = p.pesoEstatura + 2;
                }
                else if (p.edad > 13 & p.edad < 15)
                {
                    p.prioridad = p.pesoEstatura + 1;
                }
            }
            else if (p.edad > 16 & p.edad < 40)
            {
                if (p.fumador == 1)
                {
                    p.prioridad = (p.yearsFumando / 4) + 2;
                }
                else
                {
                    p.prioridad = 2;
                }
            }
            else if (p.edad >= 41)
            {
                if (p.dieta == 1)
                {
                    if (p.edad >= 60 & p.edad <= 100)
                    {
                        p.prioridad = (p.edad / 20) + 4;
                    }
                    else
                    {
                        p.prioridad = (p.edad / 30) + 3;
                    }
                }
                else
                {
                    p.prioridad = (p.edad / 30) + 3;
                }
            }

            if (p.edad>=1&p.edad<=40)
            {

                var r = ((double)p.edad* (double)p.prioridad) / 100;
                p.riesgo = r;
            }
            else if (p.edad < 41)
            {
                var r = (((double)p.edad*(double)p.prioridad )/ 100) + 3;
                p.riesgo = r;
            }
            return p;
        }
    }

    
}
