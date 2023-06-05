using System.ComponentModel.DataAnnotations;

namespace BlazorDemoWASM.Pages.Demos.Demo5
{
    public class Personne
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
    }
}
