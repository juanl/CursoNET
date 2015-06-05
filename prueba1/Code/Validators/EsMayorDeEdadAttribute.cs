using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba1.Code.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EsMayorDeEdadAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// Gets the minimum value for the range
        /// </summary>
        private DateTime Maximum { get; set; }

        private const string lessThanErrorMessage = "{0} debe ser mayor de edad (18 años).";

        private bool allowEquality;

        public bool AllowEquality
        {
            get { return this.allowEquality; }
            set
            {
                this.allowEquality = value;
                this.ErrorMessage = lessThanErrorMessage;
            }
        }

        public EsMayorDeEdadAttribute()
                : base(() => lessThanErrorMessage)
            {
            this.Maximum = DateTime.Now.AddYears(-18);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Validate our properties and create the conversion function
            if (value == null)
            {
                return null;
            }
            string s = value as string;
            if (s != null && String.IsNullOrEmpty(s))
            {
                return null;
            }

            IComparable min = (IComparable)this.Maximum;
            if (this.allowEquality)
            {
                if (min.CompareTo(value) <= 0)
                    return new ValidationResult(lessThanErrorMessage);
            }
            else
            {
                if (min.CompareTo(value) < 0)
                    return new ValidationResult(lessThanErrorMessage);
            }

            return null;

        }

        /// <summary>
        /// Override of <see cref="ValidationAttribute.FormatErrorMessage"/>
        /// </summary>
        /// <remarks>This override exists to provide a formatted message describing the minimum and maximum values</remarks>
        /// <param name="name">The user-visible name to include in the formatted message.</param>
        /// <returns>A localized string describing the minimum and maximum values</returns>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is ill-formed.</exception>
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.Maximum);
        }

        public static string FormatPropertyForClientValidation(object property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mcv = new ModelClientValidationRule();
            mcv.ValidationType = "esmayordeedad";
            mcv.ErrorMessage = FormatErrorMessage(metadata.DisplayName);
            mcv.ValidationParameters["allowequality"] = allowEquality;
            return new List<ModelClientValidationRule> { mcv };
        }
    }
}