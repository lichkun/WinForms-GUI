namespace AuthorAndBooks
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                IModel model = new Model();
                Form1 form1 = new Form1();
                Presenter presenter = new Presenter(model, form1);
                Application.Run(form1);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}