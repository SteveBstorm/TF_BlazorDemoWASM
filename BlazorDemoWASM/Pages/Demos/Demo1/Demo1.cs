namespace BlazorDemoWASM.Pages.Demos.Demo1
{
    public partial class Demo1
    {
        public int MyValue { get; set; }

        public void ChangeValue()
        {
            MyValue = 42;
        }

        public void ChangeValue(int value)
        {
            MyValue = value;
        }
    }
}
