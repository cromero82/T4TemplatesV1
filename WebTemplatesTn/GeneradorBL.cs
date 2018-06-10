 
//using Model.BL.Tipos;
using Kendo.Mvc.Extensions;
using Model;
using Model.General;
using System;
using System.Data.Entity;
using System.Linq;

namespace Services.BL
{
    public class PersonaBL : ClaseBL
    {
		// Contexto de base de datos (EF)
        private ControlcBDEntities db = new ControlcBDEntities();
        Jresult jresult = new Jresult();
        private string entidad = "Persona";

		public Jresult GetList(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            try
            {
                var queryable = db.GenPersona.Where(f => f.Estregistro == 1).Select(r => new PersonaVM
                {                    
					Id = r.Id,
					TdocumentoId = r.TdocumentoId,
					Tdocumento = r.Tdocumento == null ? "" : r.Tdocumento.Nombre,
					NumDoc = r.NumDoc
					PrimerNombre = r.PrimerNombre
					SegundoNombre = r.SegundoNombre
					PrimerApellido = r.PrimerApellido
					SegundoApellido = r.SegundoApellido
					FechaNacimiento = r.FechaNacimiento
					Direccion = r.Direccion
					Telefono = r.Telefono
					TmunicipioId = r.TmunicipioId,
					Tmunicipio = r.Tmunicipio == null ? "" : r.Tmunicipio.Nombre,
					CorreoElectronico = r.CorreoElectronico
					Telefono2 = r.Telefono2
					ModoRegistro = r.ModoRegistro
					Estregistro = r.Estregistro
					ArchivoID = r.ArchivoID
                    
                });

                #region Aplicacion Filtro kendo
                return AplicadorFiltrosKendo(jresult, filtrosComponenteKendo, queryable);
                #endregion
            }
            #region Manejador Excepcion
            catch (Exception ex) { return ManejadorExcepciones(ex, jresult, entidad); }
            #endregion
        }

	}
}
