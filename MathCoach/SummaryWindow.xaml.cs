using MathCoach.Models;
using System.Windows;

namespace MathCoach
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {

        public SummaryWindow(Result UserResult)
        {
            InitializeComponent();
            ShowSummaryResult(UserResult);
        }

        private void ShowSummaryResult(Result UserResult)
        {
            string SummaryResults = "";
            string GeneralResults = "Wynik OK : " + UserResult.OK + " \n" + "Wynik NOK : " + UserResult.NOK + " \n\n";
            GatherResults(UserResult,ref SummaryResults);
            ShowAllResults(GeneralResults, SummaryResults);
        }


        private void GatherResults(Result userResult, ref string SummaryResult)
        {
            foreach (var result in userResult.DrawList)
            {
                if (result.IsUserResultOK == true)
                {
                    SummaryResult = SummaryResult + result.FirstNumber + " " + result.Action + " " + result.SecondNumber + " = " + result.Result + " OK" + "\n";
                }
                else
                {
                    SummaryResult = SummaryResult + result.FirstNumber + " " + result.Action + " " + result.SecondNumber + " = " + result.Result + " NOK --> Twoj wynik : " + result.UserResult + "\n";
                }         
            }
        }

        private void ShowAllResults(string generalResults, string summaryResults)
        {
            TxtToShow.Text = generalResults + summaryResults;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();

        }
    }
}

