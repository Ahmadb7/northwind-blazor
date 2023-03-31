using northwind_blazor.Application.Common.Interfaces;

namespace northwind_blazor.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
