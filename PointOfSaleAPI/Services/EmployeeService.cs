using PointOfSaleAPI.Context;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
            private PointOfSaleContext context;
            public EmployeeService(PointOfSaleContext context)
            {
                this.context = context;
            }

            public IEnumerable<EmployeeModel> Get()
            {
                return context.EmployeeModels;
            }

            public async Task Save(EmployeeModel employeeParameter)
            {
                context.Add(employeeParameter);
                await context.SaveChangesAsync();
            }

            public async Task Update(int EmployeeId, EmployeeModel employeeParameter)
            {
                var actualEmployee = context.EmployeeModels.Find(EmployeeId);
                if (actualEmployee != null)
                {
                actualEmployee.EmployeeId = EmployeeId;
                actualEmployee.FirstName = employeeParameter.FirstName;
                actualEmployee.LastName = employeeParameter.LastName;
                actualEmployee.Email = employeeParameter?.Email;
                actualEmployee.Phone = employeeParameter?.Phone;
                actualEmployee.HireDate = employeeParameter?.HireDate;
                actualEmployee.ManagerId = employeeParameter.ManagerId;
                actualEmployee.JobTitle = employeeParameter?.JobTitle;

                    await context.SaveChangesAsync();
                }
            }
            public async Task Delete(int EmployeeId)
            {
                var actualEmployee = context.EmployeeModels.Find(EmployeeId);
                if (actualEmployee != null)
                {
                    context.Remove(actualEmployee);

                    await context.SaveChangesAsync();
                }
            }


        }
       
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> Get();
        Task Save(EmployeeModel employeeParameter);
        Task Update(int EmployeeId, EmployeeModel employeeParameter);
        Task Delete(int EmployeeId);
    }

}
