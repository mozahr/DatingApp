using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
<<<<<<< HEAD
    //this class in an extention class to override httpResponse to add additional header
    //to the reponse.
=======
>>>>>>> 6cb9c64912fc455099c9da9218d434a790e4bb00
    public static class Extenstions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
<<<<<<< HEAD
            //this method is used to add Application-Error to header with value of message.
            response.Headers.Add("Application-Error", message);
            //those 2 methods are to allows the first one to be display.
=======
            response.Headers.Add("Application-Error", message);
>>>>>>> 6cb9c64912fc455099c9da9218d434a790e4bb00
            response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
            response.Headers.Add("Access-Control-Allow-origin", "*");
        }
    }
}