namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Instance.Initialize();
            Application.Instance.Run(args);
        }
    }
}
