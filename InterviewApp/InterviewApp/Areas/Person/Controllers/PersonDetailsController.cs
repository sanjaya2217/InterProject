using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Net;
using InterviewApp.Filter;
using InterviewApp.Models;
using InterviewApp.Areas.Person.Models;
using NToastNotify;

namespace InterviewApp.Areas.Person.Controllers
{

    [Area("Person")]
    public class PersonDetailsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IToastNotification _toastNotification;

        //Initialize logger
        Logger _logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }
        public PersonDetailsController(IConfiguration configuration, IToastNotification toastNotification)
        {
            _config = configuration;
            _toastNotification = toastNotification;
        }

       
        [HttpPost]
        [AppException] //Log exception.
        public async Task<ActionResult> Index(PersonEntity _personEntity)
        {
            if (ModelState.IsValid == true) //is model valid
            {
                //API call to save data
                _logger.Info(AppConsts.apiExecutionStart);
                APIResult _apiResponse = await HelperFile.sendDataToServer(_config.GetValue<string>("APIUrl")
                    + AppConsts.saveDataToServer, _personEntity, false);

                if (_apiResponse.statuscode == HttpStatusCode.OK) //Check if data is saved
                {
                    ModelState.Clear(); //Clear model
                    ViewBag.SuccessMessage = AppConsts.successSavingDetails;
                    _toastNotification.AddSuccessToastMessage( AppConsts.successSavingDetails);
                    return View(AppConsts.personDetails);
                }
                _logger.Info(AppConsts.apiExecutionEnd);
            }
            else //model not valid
            {
                ViewBag.ErrorMessage = AppConsts.enterAllFields;
                _logger.Error(AppConsts.enterAllFields);
            }
            _toastNotification.AddErrorToastMessage(AppConsts.errorSavingDetails);
           return View();
        }
    }
}
