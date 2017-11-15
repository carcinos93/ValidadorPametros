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
    /// <summary>
    /// Clase que valida los datos 
    /// </summary>
    public class PersonaValidator : AbstractValidator<XElement>
    {
       /// <summary>
       /// Para validar persona juridica o natural, sin la necesidad de agregar el tipo de persona
       /// en el documento xml
       /// </summary>
       /// <param name="tipo"></param>
       /// <param name="tipoPersona"></param>
       /// <param name="descripcion"></param>
        public PersonaValidator(string tipoNatural, string tipoJuridico,int tipoPersona, string descripcion)
        {
            if (tipoPersona == 1)
            {
                setReglasNatural(tipoNatural, descripcion);
            }

            if (tipoPersona== 2) {
                setReglasJuridica(tipoJuridico, descripcion);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidadorPametros.Validators.PersonaValidator"/> class.
        /// </summary>
        /// <param name="tipo">El tipo de persona (sufijo para destinguir distintas persona)</param>
        /// <param name="tipoPersonaCampo">El nombre de campo que tiene el valor del tipo de persona</param>
        public PersonaValidator(string tipoNatural, string tipoJuridico, string tipoPersonaCampo, string descripcion)
        {
            ///SI LA PERSONA ES NATURAL
            When(x => x.Element(x.Name.Namespace + tipoPersonaCampo).Value == "1", () =>
            {
                setReglasNatural(tipoNatural, descripcion);
            });
          
            ///SI LA PERSONA ES JURIDICA
            When(x => x.Element(x.Name.Namespace + tipoPersonaCampo).Value == "2", () =>
            {
                setReglasJuridica(tipoJuridico, descripcion);
            });
        }
        /// <summary>
        /// Inicializa la validacion para persona natural
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="descripcion"></param>
        private void setReglasNatural(string tipo, string descripcion)
        {
            RuleSet("nombrePersona", () =>
            {
                RuleFor(x => x.Element(x.Name.Namespace + tipo + "primerNombre").Value)
                    .NotEmpty()
                    .WithName("primerNombre")
                    .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });

                RuleFor(x => x.Element(x.Name.Namespace + tipo + "primerApellido").Value)
                    .NotEmpty()
                    .WithName("primerApellido")
                    .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
            });
            //Domicilio
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "personaDomicilio").Value)
                    .NotEmpty()
                    .WithName("Domicilio")
                    .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });

            ///Numero de documento
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "numeroDocumento").Value)
                    .NotEmpty()
                    .WithName("numeroDocumento")
                    .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });

            //Fecha de nacimiento
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "fechaNacimiento").Value)
                .NotEmpty()
                .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); })
                .WithName("fechaNacimiento")
                .DateValidator("yyyy-MM-dd")
                .WithMessage((t) => { return "El campo {PropertyName} de " + descripcion + " no es una fecha valida, intente un formato valido {mask}"; });
            //Estado civil
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "codigoEstadoCivil").Value)
                .NotEmpty()
                .WithName("codigoEstadoCivil")
                .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
            ///Tipo de documento
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "codigoEstadoCivil").Value)
                .NotEmpty()
                .WithName("tipoDocumento")
                .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
        }

        /// <summary>
        /// Inicializa la validacion para persona juridica
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="descripcion"></param>
        private void setReglasJuridica(string tipo, string descripcion)
        {
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "razonSocial").Value)
                    .NotEmpty()
                    .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
            ///Domicilio comercial
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "domicilioComercial").Value)
                .NotEmpty()
                .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
            ///Actividad economica|
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "actividadEconomica").Value)
                .NotEmpty()
                .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
            ///Numero de identificacion 
            RuleFor(x => x.Element(x.Name.Namespace + tipo + "numeroIdentificacionT").Value)
                .NotEmpty()
                .WithMessage((t, s) => { return string.Format("El campo {{PropertyName}} de {0} es requerido", descripcion); });
        }
    }
}
