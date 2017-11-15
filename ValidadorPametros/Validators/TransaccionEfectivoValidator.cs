using System.Text;
using System.Threading.Tasks;
using FluentValidation.Validators;
using FluentValidation;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace ValidadorPametros.Validators
{
    public class TransaccionEfectivoValidator : AbstractValidator<XElement>
    {
        public TransaccionEfectivoValidator()
        {
            //Codigo colaborador
            RuleFor(x => x.Element(x.Name.Namespace + "cargoColaborador").Value)
                .NotEmpty()
                .WithName("cargoColaborador")
                .WithMessage("El campo {PropertyName} es requerido");
            //Cargo colaborador
            RuleFor(x => x.Element(x.Name.Namespace + "codigoColaborador").Value)
                .NotEmpty()
                .WithName("codigoColaborador")
                .WithMessage("El campo {PropertyName} es requerido");
            //Id municipio
            RuleFor(x => x.Element(x.Name.Namespace + "PSidMunicipio").Value)
                .NotEmpty()
                .WithName("idMunicipio")
                .WithMessage("El campo {PropertyName} de la agencia es requerido ");
            ///Id departamento
            RuleFor(x => x.Element(x.Name.Namespace + "PSidDepartamento").Value)
                .NotEmpty()
                .WithName("idDepartamento")
                .WithMessage("El campo {PropertyName} de la agencia es requerido");
            //fechaTransaccion
            RuleFor(x => x.Element(x.Name.Namespace + "fechaTransaccion").Value)
                    .NotEmpty()
                    .WithMessage("El campo {PropertyName} es requerido")
                    .WithName("fechaTransaccion")
                    .DateValidator("yyyy-MM-dd")
                    .WithMessage("El campo {PropertyName} no es una fecha valida, intente un formato valido {mask}");
            //objetivoEfectivo
            RuleFor(x => x.Element(x.Name.Namespace + "PSidDepartamento").Value)
                    .NotEmpty()
                    .WithName("idDepartamento")
                    .WithMessage("El campo {PropertyName} de la agencia es requerido");
            ///Se valida persona fisica (la persona fisica es natural)
            RuleFor(x => x).SetValidator(new PersonaValidator("PT","",1, "Persona fisica"));
            ///Se valida a la persona natural o juridica (lista b)
            //RuleFor(x => x).SetValidator(new PersonaValidator("PB", "PJB", "tipoPersonaB", "Persona B"));
            //RuleFor(x => x).SetValidator(new PersonaValidator("PC", "PJC", "tipoPersonaB", "Persona C"));
        }
    }
}
