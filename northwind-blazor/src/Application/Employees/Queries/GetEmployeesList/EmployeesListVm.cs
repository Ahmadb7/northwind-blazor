using System.Collections.Generic;

namespace northwind_blazor.Application.Employees.Queries.GetEmployeesList
{
    public class EmployeesListVm
    {
        public IList<EmployeeLookupDto> Employees { get; set; }
    }
}
 