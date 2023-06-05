namespace BlazorDemoWASM.Pages.Exo.Exo1
{
    public partial class Quizz
    {
        public string Username { get; set; }
        public bool QuizzIsFinished { get; set; }

        public List<string> Answers { get; set; }
        public Quizz()
        {
            Answers = new List<string>();
        }

        public void ReceiveAnswer(string response)
        {
            Answers.Add(response);
        }

        public void NotifiedEndGame()
        {
            QuizzIsFinished = true;
        }
    }
}
