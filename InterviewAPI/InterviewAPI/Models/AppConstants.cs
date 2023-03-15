using System.ComponentModel;
using System.Net;

namespace InterviewAPI.Models
{
    //Application Constants
    public static class AppConst
    {
        public static readonly string StartExecution = "Execution Starts";
        public static readonly string EndExecution = "Execution Ends";
        public static readonly string ErrorSavingDetail = "Error Ocurred";
        public static readonly HttpStatusCode OkStatusCode = HttpStatusCode.OK;
        public static readonly string SuccessMsg = "Data Saved";
        public static readonly HttpStatusCode BadStatusCode = HttpStatusCode.BadRequest;
        public static readonly string BadReqMsg = "Bad Request";
        public static readonly string JSONNotValidMessage = "Invalid JSON";

    }
}
