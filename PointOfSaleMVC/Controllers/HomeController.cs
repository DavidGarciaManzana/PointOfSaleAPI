using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PointOfSaleAPI.Models;
using PointOfSaleMVC.Models;
using System.Diagnostics;

namespace PointOfSaleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        } 
        public async Task<IActionResult> Purchase()
        {
            var url = "https://localhost:7037/api/";
            var httpClient = new HttpClient();


         //   _logger.LogWarning(url + "employee");
            var json = await httpClient.GetStringAsync(url + "employee");
            var employeeList = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            var json2 = await httpClient.GetStringAsync(url + "customer");
            var customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(json2);
            List<EmployeeModel> listOfEmployees = new List<EmployeeModel>();
            listOfEmployees = employeeList;

            List<CustomerModel> listOfCustomers = new List<CustomerModel>();
            listOfCustomers = customerList;

            MultipleGetModel objViewModel = new MultipleGetModel();
            objViewModel.MultipleEmployeeModel = listOfEmployees;
            objViewModel.MultipleCustomerModel = listOfCustomers;
            return View(objViewModel) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}