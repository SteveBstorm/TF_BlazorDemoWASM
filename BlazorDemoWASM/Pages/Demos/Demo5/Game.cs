using System.ComponentModel.DataAnnotations;

namespace BlazorDemoWASM.Pages.Demos.Demo5
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ce que tu veux")]
        public string Name { get; set; }
        [MinLength(3)]
        public string Genre { get; set; }
        [Range(1, 8)]
        public int MinPlayer { get; set; }
        [ValidateComplexType]

        public Personne Createur { get; set; }

        public Game()
        {
            Createur = new Personne();
        }
    }
}
