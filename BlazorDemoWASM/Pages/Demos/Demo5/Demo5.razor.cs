namespace BlazorDemoWASM.Pages.Demos.Demo5
{
    public partial class Demo5
    {
        public Game NewGame { get; set; }
        public Demo5()
        {
            NewGame = new Game();
        }

        public void Validate()
        {
            Console.WriteLine(NewGame.Name);
        }
    }
}
