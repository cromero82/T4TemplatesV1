﻿ 
using ControlB.Utilidades;
using Services.BL;
using System;
using System.Reflection;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Model;

namespace ControlB.Areas.General.Controllers
{
    public class PersonaController   : UtilController
    {
        PersonaBL entityBL = new PersonaBL();
        String EntityName = "Persona";
        Object ModelEmpy = new PersonaVM();

        /// <summary>
        /// Obtiene una lista de Personas para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros kendoGrid en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetList([Kendo.Mvc.UI.DataSourceRequest]DataSourceRequest request)
        {
            var jresult = entityBL.GetList(request);
            return EvaluarResultadoListaGenerico(jresult, request, "Error consultando Personas: ");
        }

        /// <summary>
        /// Vista de edición (Crear y Editar) Persona
        /// </summary>
        /// <param name="id"> id de registro</param>
        /// <param name="accionCrud"> acción que se va a realizar en la vista: Crear o Editar</param>
        /// <returns>Vista para accion crear o editar</returns>
        [Authorize]
        public ActionResult PersonaView(long? id, string accionCrud)
        {
            ViewBag.Accion = accionCrud;
            if (accionCrud == "Insertar")
            {
                return PartialView("PersonaView", ModelEmpy);
            }
            else
            {
                var jresult = entityBL.Get((long)id);
                return ManejadorRetornoVista(jresult, ModelEmpy);
            } 
        }        

        /// <summary>
        /// Inserta Persona   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsPersona(PersonaVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("PersonaView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Insert(model));
        }

        public ActionResult UpdGenPersona(PersonaVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("PersonaView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Update(model));
        }

        /// <summary>
        /// Elimina Persona
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost]
        [Authorize]
        public ActionResult DelPersona(int id)
        {
            // Acceso a la capa de negocio y result
            return Json(entityBL.Delete(id));
        }
    }
}

