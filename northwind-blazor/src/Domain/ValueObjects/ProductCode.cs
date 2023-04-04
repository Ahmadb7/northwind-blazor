using northwind_blazor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace northwind_blazor.Domain.ValueObjects
{
    public class ProductCodeVo : ValueObject
    {
        public ProductCodeVo(string code)
        {
            this.Value = code;
        }

        public string Value { get; init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
    public class NameEn : ValueObject
    {
        public NameEn(string value)
        {
            if (!Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
                throw new Exception("Input is not English");

            this.Value = value;
        }

        public string Value { get; init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public class NameFa : ValueObject
    {
        public NameFa(string value)
        {
            if (!Regex.IsMatch(value, "^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]+$"))
                throw new Exception("Input is not Farsi");

            this.Value = value;
        }

        public string Value { get; init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
