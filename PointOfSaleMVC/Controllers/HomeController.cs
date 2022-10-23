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
            var multipleviewModel = new GetMultipleModel();
            var url = "https://localhost:7037/api/";
            var httpClient = new HttpClient();


         //   _logger.LogWarning(url + "employee");
         //Realizo los Gets
            var json = await httpClient.GetStringAsync(url + "employee");
            var employeeList = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            var customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(await httpClient.GetStringAsync(url + "customer"));
            var countrylist = JsonConvert.DeserializeObject<List<CountryModel>>(await httpClient.GetStringAsync(url + "country"));
            var locationList = JsonConvert.DeserializeObject<List<LocationModel>>(await httpClient.GetStringAsync(url + "location"));
            
        //Guardo en cada elemento del modelo sus respectivos gets 
            multipleviewModel.EmployeeList = employeeList;
            multipleviewModel.CustomerList = customerList;
            multipleviewModel.CountryList = countrylist;
            multipleviewModel.LocationList = locationList;
            //Retorno el modelo padre a la vista, al cual se accedera poniendo un punto despues del modelo (Model.MultipleCustomerModel)
            return View(multipleviewModel) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}