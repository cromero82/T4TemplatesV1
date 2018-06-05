using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTemplatesTn
{
    public  class UtilidadesGenerador
    {
        public  string EntidadFormatoPresentacion(string entidad)
        {
            var entidadPresentacion = entidad.Substring(0, 1);
            for (int i = 0; i < entidad.Length; i++)
            {
                //if(entidad.Substring(i,1).i
                if (i > 0)
                {
                    if (char.IsLower(entidad[i]))
                    {
                        entidadPresentacion = string.Concat(entidadPresentacion, entidad[i]);
                    }
                    else
                    {
                        entidadPresentacion = string.Concat(entidadPresentacion, " ", entidad[i]);
                        //entidadPresentacion.Concat(""; entidad[i]);
                    }
                }
            }
            return entidadPresentacion;
        }
    }
}