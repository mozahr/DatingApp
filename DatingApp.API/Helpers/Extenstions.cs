using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    //this class in an extention class to override httpResponse to add additional header
    //to the reponse.
    public static class Extenstions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            //this method is used to add Application-Error to header with value of message.
            response.Headers.Add("Application-Error", message);
            //those 2 methods are to allows the first one to be display.
            response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
            response.Headers.Add("Access-Control-Allow-origin", "*");
        }
        // this is a method to allow us to add an extention method for calculation of the age of the user.
        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if(theDateTime.AddYears(age) > DateTime.Today)
            age--;

            return age;
        }
    }
}