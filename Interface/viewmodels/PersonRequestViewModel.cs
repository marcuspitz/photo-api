using Microsoft.AspNetCore.Http;
using System;

namespace Interface.viewmodels
{
    public class PersonRequestViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public IFormFile Picture { get; set; }
    }
}
