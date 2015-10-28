using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Services.Impl.v1.Exceptions
{
    public class TooManyComponentsException : Exception
    {
        public int QuantityOfComponents { get; private set; }

        public TooManyComponentsException(int quantityOfComponents = 3)
            : base(string.Format("A aeronave já possui {0} peças ou mais atreladas.", quantityOfComponents))
        {
            QuantityOfComponents = quantityOfComponents;
        }

        public TooManyComponentsException(string message, int quantityOfComponents)
            : base(message)
        {
            QuantityOfComponents = quantityOfComponents;
        }

        public TooManyComponentsException(string message, Exception innerException, int quantityOfComponents)
            : base(message, innerException)
        {
            QuantityOfComponents = quantityOfComponents;
        }
    }
}
