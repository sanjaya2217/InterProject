using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using NLog;
using Repository.Interfaces;
using Repository.Classes;
using InterviewAPI.Filter;
using InterviewAPI.Models;
using System.ComponentModel;

namespace InterviewAPI.Controllers
{
    public class PersonController : ControllerBase
    {
        //Variable Section
        private readonly IConfiguration _config;
        private readonly IPersonRepository _iPerson;
        Logger _logger = LogManager.GetCurrentClassLogger();
        string filePath = string.Empty;
        //Constructor to initialize the variables using dependency. 
        public PersonController(IConfiguration config, IPersonRepository person)
        {
            _config = config; _iPerson = person;
        }

        //Method to save data
        [HttpPost]
        [Route("api/SaveDetails")]
        [Produces("application/json")]
        [AppException] //For error logging 
        public async Task<JsonResult> SaveDetails([FromBody] PersonEntity _personEntity)
        {
            if (_personEntity!= null && ModelState.IsValid )
            {
                filePath = _config.GetValue<string>("FilePath") + DateTime.Now.ToString("ddMMyyyy") + _config.GetValue<string>("Extension");
                _logger.Info(AppConst.StartExecution); // Execution start log
                string _serPersonDetails = System.Text.Json.JsonSerializer.Serialize(_personEntity);
                //Save Data
                if (await _iPerson.SaveDataToFile(_serPersonDetails, filePath))
                {
                    //Send Response
                    return new JsonResult(new APIResult
                    {
                        statuscode = AppConst.OkStatusCode,message = AppConst.SuccessMsg,
                        timestamp = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    });
                }
                _logger.Info(AppConst.EndExecution); // Execution ends log
                return new JsonResult(new APIResult
                {
                    statuscode = AppConst.BadStatusCode, message = AppConst.ErrorSavingDetail, 
                    timestamp =  Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
            }
            else
            {
                _logger.Error(AppConst.ErrorSavingDetail); //Log error
                 return new JsonResult(new APIResult
                {
                    statuscode = AppConst.BadStatusCode, message = AppConst.JSONNotValidMessage,timestamp = 
                    Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
            }
        }
    }
}
