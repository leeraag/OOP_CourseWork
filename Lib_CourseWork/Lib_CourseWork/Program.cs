namespace Lib_CourseWork
{
    internal static class Program
    {
        public static Form1 f1; // переменная, которая будет содержать ссылку на форму Form1
        public static Form5 f5; // переменная, которая будет содержать ссылку на форму Form5
        public static Form3 f3;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form7());
        }
    }
}