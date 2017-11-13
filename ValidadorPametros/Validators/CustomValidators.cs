using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorPametros.Validators
{
    public static class MyValidatorExtensions
    {
        /// <summary>
        /// Validador de fechas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TElement> DateValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, string mask)
        {
            return ruleBuilder.SetValidator(new DateValidator(mask));
        }

       
    }

 
    public class DateValidator : PropertyValidator
    {
        private string _mask;
        public DateValidator(string mask)
            : base("{PropertyValue} no es una fecha valida, intente un formato valido {mask}")
        {
            _mask = mask;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {

            DateTime fecha;
            if (!DateTime.TryParseExact(context.PropertyValue.ToString(), this._mask,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                context.MessageFormatter.AppendArgument("mask", _mask);

                return false;
            }
            return true;
        }

    }
}
