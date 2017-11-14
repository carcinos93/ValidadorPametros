using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Validators;
using FluentValidation;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
namespace ValidadorPametros.Validators
{
    public class JuridicaDTOValidator : AbstractValidator<XElement>
    {
       
    }

    /// <summary>
    /// Clase que valida los datos 
    /// </summary>
    public class PersonaValidator : AbstractValidator<XElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidadorPametros.Validators.PersonaValidator"/> class.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="tipoPersonaCampo"></param>
        public PersonaValidator(string tipo, string tipoPersonaCampo, string descripcion)
        {
            ///SI LA PERSONA ES NATURAL
            When(x => x.Element(x.Name.Namespace + tipoPersonaCampo).Value == "1", () =>
            {    
                RuleSet("nombrePersona", () =>
                {
                    RuleFor(x => x.Element(x.Name.Namespace + tipo + "primerNombre").Value).NotEmpty().WithName("primerNombre");
                    RuleFor(x => x.Element(x.Name.Namespace + tipo + "segundoNombre").Value).NotEmpty().WithName("segundoNombre");
                    RuleFor(x => x.Element(x.Name.Namespace + tipo + "primerApellido").Value).NotEmpty().WithName("primerApellido");
                   
                });
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "numeroDocumento").Value).NotEmpty().WithName("numeroDocumento");
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "fechaNacimiento").Value).NotEmpty().DateValidator("yyyy-MM-dd");
            });
           
             
            ///SI LA PERSONA ES JURIDICA
            When(x => x.Element(x.Name.Namespace + tipoPersonaCampo).Value == "2", () =>
            {
                ///Razon social
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "razonSocial").Value)
                    .NotEmpty()
                    .WithMessage((t, s) => { return string.Format("El campo {0} de {1} es requerido","razonSocial",descripcion); });
                ///Domicilio comercial
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "domicilioComercial").Value)
                    .NotEmpty()
                    .WithMessage((t, s) => { return string.Format("El campo {0} de {1} es requerido", "domicilioComercial",descripcion); });
                ///Actividad economica|
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "actividadEconomica").Value)
                    .NotEmpty()
                    .WithMessage((t, s) => { return string.Format("El campo {0} de {1} es requerido", "actividadEconomica", descripcion); });
                ///Numero de identificacion 
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "numeroIdentificacionT").Value)
                    .NotEmpty()
                    .WithMessage((t, s) => { return string.Format("El campo {0} de {1} es requerido", "numeroIdentificacionT",descripcion); });


            });
        }
    }
}
