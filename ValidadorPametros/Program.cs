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
            XElement elem = new XElement("detalleTransacciones");
            elem.Add(new XElement("tipoPersona", "1"));
            elem.Add(new XElement("PTprimerApellido", ""));
            elem.Add(new XElement("PTsegundoApellido", ""));
            elem.Add(new XElement("PTapellidoCasado", null));
            elem.Add(new XElement("PTprimerNombre", ""));
            elem.Add(new XElement("PTsegundoNombre", null));
            elem.Add(new XElement("PTnumeroDocumento", ""));
            elem.Add(new XElement("PTfechaNacimiento", ""));
            elem.Add(new XElement("PTpersonaDomicilio", ""));
            elem.Add(new XElement("PTcodigoEstadoCivil", ""));
            elem.Add(new XElement("PTtipoDocumento", ""));

            elem.Add(new XElement("codigoColaborador", ""));
            elem.Add(new XElement("cargoColaborador", ""));
            elem.Add(new XElement("PSidMunicipio", ""));
            elem.Add(new XElement("PSidDepartamento", ""));
            elem.Add(new XElement("fechaTransaccion", null));
            //var validador = new PersonaValidator("PT", "tipoPersona","Persona fisica"); 
            var validador = new TransaccionEfectivoValidator();
            var v = validador.Validate(elem, ruleSet: "default,nombrePersona");
          
        
            /*elem.Add(new XElement("tipoPersona", "2"));
            elem.Add(new XElement("PJArazonSocial", "TELCOM S.A DE C.V."));
            elem.Add(new XElement("PJAdomicilioComercial", ""));
            elem.Add(new XElement("PJAactividadEconomica", null));
            elem.Add(new XElement("PJAnumeroIdentificacionT", null));
            var validador = new PersonaValidator("PJA", "tipoPersona","Persona juridica A");
            var v = validador.Validate(elem);*/
            foreach (ValidationFailure s in v.Errors)
            {
                Console.WriteLine("Error en {0}", s.ErrorMessage);
            }
            Console.ReadLine();
        }
    }
}
