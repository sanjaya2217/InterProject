using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        //Method to save the file
        public Task<Boolean> SaveDataToFile(string _receivedPersonEntity,string filePath);
    }
}
