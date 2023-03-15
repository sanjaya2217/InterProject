using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
namespace Repository.Classes
{
    public class PersonRepository : IPersonRepository
    {
        //Method to save the file
        public async Task<Boolean> SaveDataToFile(string _serPersonEntity, string filePath)
        {
            try
            {
                PersonDetails objPerson = new PersonDetails();
                return await objPerson.SaveDataToFile(_serPersonEntity, filePath);
                
            }
            catch (Exception ex)
            {

                return false;
            }
           
           
        }

    }
}
