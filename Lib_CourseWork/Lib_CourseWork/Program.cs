using Microsoft.EntityFrameworkCore;

namespace Lib_CourseWork
{
    internal static class Program
    {
        public static Form1 f1; // переменная, которая будет содержать ссылку на форму Form1
        public static Form5 f5; // переменная, которая будет содержать ссылку на форму Form5
        public static Form3 f3;
        /// <summary>
        ///  Главная точка входа в приложение
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var dbContext = new libraryContext())
            {
                dbContext.Database.Migrate();
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form7());
        }
    }
}