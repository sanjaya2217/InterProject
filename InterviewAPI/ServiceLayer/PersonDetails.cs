namespace ServiceLayer
{
   
    public class PersonDetails
    {

        //Method Save Data
        public async Task<Boolean> SaveDataToFile( string _serPersonEntity, string filePath)
        {
            try
            {
                lock (filePath)
                {
                    using (StreamWriter outputFile = System.IO.File.AppendText(filePath))
                        _ = outputFile.WriteLineAsync(_serPersonEntity);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}