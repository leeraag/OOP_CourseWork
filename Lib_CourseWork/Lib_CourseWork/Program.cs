namespace Lib_CourseWork
{
    internal static class Program
    {
        public static Form1 f1; // ����������, ������� ����� ��������� ������ �� ����� Form1
        public static Form5 f5; // ����������, ������� ����� ��������� ������ �� ����� Form5
        public static Form3 f3;
        /// <summary>
        ///  ������� ����� ����� � ����������
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form7());
        }
    }
}