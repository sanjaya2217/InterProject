using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using InterviewAPI.Controllers;
using InterviewAPI.Models;
using Repository.Classes;
using System.Net;
using Newtonsoft.Json;

namespace InterviewAPIIntegrationTesting
{
    public class APITest
    {
        //Initialize the objects using fakeiteasy
        IConfiguration _configuration = A.Fake<IConfiguration>();
        PersonEntity _personEntity = A.Fake<PersonEntity>();
        PersonEntity _personEntityRes = A.Fake<PersonEntity>();
        IPersonRepository _iPerson = A.Fake<PersonRepository>();
        string? filePath, actualResult, expectedResult;

        [SetUp]
        public void Setup()
        {
            //Set the config values
            filePath = "D:\\JSON" + DateTime.Now.ToString("ddMMyyyy") + ".txt";

            var myConfiguration = new Dictionary<string, string>
            {
                {"FilePath", "D:\\JSON"  }, {"Extension", ".txt" }

            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
            .Build();

            //Set the entity
            _personEntity = new PersonEntity { FirstName = "Sanjay", LastName = "Kumar" };

        }

        [Test]
        public void SaveData_Success()
        {

            //Delete the existing file
            File.Delete(filePath);

            PersonController _personCon = new PersonController(_configuration, _iPerson);
            
            //Expected result
            expectedResult = JsonConvert.SerializeObject(_personEntity);

            //Get the response 
            APIResult? _resCon = (APIResult)_personCon.SaveDetails(_personEntity).Result.Value;
            
            if (_resCon.statuscode == HttpStatusCode.OK)
            {
                actualResult = File.Exists(filePath)? File.ReadAllText(filePath).Replace(Environment.NewLine, ""): string.Empty;
            }

            //Check the actual & expected result
            Assert.That(actualResult, Is.EqualTo(expectedResult));


        }

        [Test]
        public void SaveData_Failure()
        {
            var _personCon = new PersonController(_configuration, _iPerson);

            //Expected Behaviour
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest;

            //Get the response 
            APIResult _resCon = (APIResult)_personCon.SaveDetails(null).Result.Value;

            //Check the response 
            Assert.That(_resCon.statuscode, Is.EqualTo(httpStatusCode));
        }
    }
}