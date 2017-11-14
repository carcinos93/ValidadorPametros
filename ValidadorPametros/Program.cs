using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ValidadorPametros.Validators;
using FluentValidation.Validators;
using FluentValidation;
namespace ValidadorPametros
{
    class Program
    {
        static void Main(string[] args)
        {
           /* XElement elem = new XElement("detalleTransacciones");
            elem.Add(new XElement("tipoPersona", "2"));
            elem.Add(new XElement("PTprimerApellido", "Rodas"));
            elem.Add(new XElement("PTsegundoApellido", "Rodas"));
        |    elem.Add(new XElement("PTapellidoCasado", null));
            elem.Add(new XElement("PTprimerNombre", ""));
            elem.Add(new XElement("PTsegundoNombre", null));
            elem.Add(new XElement("PTnumeroDocumento", ""));
            elem.Add(new XElement("PTfechaNacimiento", ""));
            var validador = new PersonaDTOValidator("PT");
            var v = validador.Validate(elem, ruleSet: "default,nombrePersona");
           */
            XElement elem = new XElement("detalleTransacciones");
            elem.Add(new XElement("tipoPersona", "2"));
            elem.Add(new XElement("PJArazonSocial", "TELCOM S.A DE C.V."));
            elem.Add(new XElement("PJAdomicilioComercial", ""));
            elem.Add(new XElement("PJAactividadEconomica", null));
            elem.Add(new XElement("PJAnumeroIdentificacionT", null));
            var validador = new PersonaValidator("PJA", "tipoPersona","Persona juridica A");
            var v = validador.Validate(elem);
            foreach (ValidationFailure s in v.Errors)
            {
                Console.WriteLine("Error en {0}, causa : {1}", s.PropertyName, s.ErrorMessage);
            }
            Console.ReadLine();
        }
    }
}
