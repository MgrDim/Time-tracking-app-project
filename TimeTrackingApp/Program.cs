namespace TimeTrackingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                var mainForm = new MainForm(loginForm.User);
                Application.Run(mainForm);
            }
        }
    }
}