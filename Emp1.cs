using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRegistration.Models

{
    public class Emp1
    {
        public string Firstname { get; set; }

       
        public string Lastname { get; set; }

   
        public string? Dateofbirth { get; set; }


        public string Hobbies { get; set; }

       


        public string Gender { get; set; }


        public string State { get; set; }


        public int StateID { get; set; }
      


        public string City { get; set; }

        public int CityID { get; set; }

    }
}
