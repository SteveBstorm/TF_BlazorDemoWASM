using Microsoft.AspNetCore.Components;

namespace BlazorDemoWASM.Pages.Demos.Demo2
{
    public class Demo2Base : ComponentBase
    {
        public List<Item> ListItem { get; set; }
        private int Counter = 0;
        public Demo2Base()
        {
            ListItem = new List<Item>();
            for(int i = 0; i < 50; i++)
            {
                ListItem.Add(new Item
                {
                    Id = ++Counter,
                    Content = Guid.NewGuid().ToString()
                });
            }
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
