using Microsoft.AspNetCore.Components;

namespace BlazorDemoWASM.Pages.Exo.Exo1
{
    public partial class Questions
    {
        [Parameter]
        public string Username { get; set; }

        [Parameter]
        public EventCallback NotifyEndGame { get; set; }
        [Parameter]
        public EventCallback<string> NotifyAnswer { get; set; }

        public List<string> QuestionList { get; set; }
        public int Counter { get; set; }
        public string CurrentQuestion { get; set; }

        public Questions()
        {
            QuestionList = new List<string>();
            Counter = 0;
            QuestionList.Add("Vous avez bien manger ?");
            QuestionList.Add("Pas trop mal à la tête ?");
            QuestionList.Add("il fait trop chaud ?");

            CurrentQuestion = QuestionList[Counter];
            Counter++;
        }

        public void Answer(string resp)
        {
            NotifyAnswer.InvokeAsync(resp);
            if(Counter >= QuestionList.Count)
            {
                CurrentQuestion = "";
                NotifyEndGame.InvokeAsync();
            }
            else
            {
                CurrentQuestion = QuestionList[Counter];
            }
            Counter++;
        }
    }
}
