 
//using Model.BL.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class PersonaVM
    {
		public int Id { get; set; }		
		/// <summary>
        /// Definicion FK TdocumentoId
        /// </summary>
		[DisplayName("Tdocumento Id")]
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
        public int TdocumentoId { get; set; }
		
		[DisplayName("Tdocumento Id")]
		public string Tdocumento { get; set; }

		[DisplayName("Num Doc")]		
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
		[MaxLength(20, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]       
        public string NumDoc { get; set; }

		[DisplayName("Primer Nombre")]		
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
		[MaxLength(10, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]       
        public string PrimerNombre { get; set; }

		[DisplayName("Segundo Nombre")]       
        public string SegundoNombre { get; set; }

		[DisplayName("Primer Apellido")]		
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
		[MaxLength(10, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]       
        public string PrimerApellido { get; set; }

		[DisplayName("Segundo Apellido")]       
        public string SegundoApellido { get; set; }

		[DisplayName("Fecha Nacimiento")]
		public DateTime FechaNacimiento { get; set; }

		[DisplayName("Direccion")]		
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
		[MaxLength(100, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]       
        public string Direccion { get; set; }

		[DisplayName("Telefono")]		
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
		[MaxLength(20, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]       
        public string Telefono { get; set; }
		
		/// <summary>
        /// Definicion FK TmunicipioId
        /// </summary>
		[DisplayName("Tmunicipio Id")]
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
        public int TmunicipioId { get; set; }
		
		[DisplayName("Tmunicipio Id")]
		public string Tmunicipio { get; set; }

		[DisplayName("Correo Electronico")]		
		[Required(ErrorMessage = "el campo {0} es obligatorio")]
		[MaxLength(30, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]       
        public string CorreoElectronico { get; set; }

		[DisplayName("Telefono 2")]       
        public string Telefono2 { get; set; }

		[DisplayName("Modo Registro")]       
        public string ModoRegistro { get; set; }

		[DisplayName("Estado registro")]
		public int Estregistro { get; set; }

		[DisplayName("Documento anexo")]
		public int ArchivoID { get; set; }
	}
}
