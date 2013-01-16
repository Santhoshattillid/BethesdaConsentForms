using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SequenceInstaller
{
    public partial class BethesdEConsentsnstaller : RadForm
    {
        public BethesdEConsentsnstaller()
        {
            InitializeComponent();
        }

        private void BethesdEConsentsnstaller_Load(object sender, System.EventArgs e)
        {
            Application.DoEvents();

            string filePath = Path.Combine(Application.StartupPath, "BethesdaEConsentsSetup.msi");
            RunApp(filePath);

            Application.DoEvents();

            filePath = Path.Combine(Application.StartupPath, "BethesdaConsentFormWCFSvcSetup.msi");
            RunApp(filePath);

            Application.DoEvents();

            filePath = Path.Combine(Application.StartupPath, "Setup.msi");
            RunApp(filePath);

            Application.DoEvents();

            Application.Exit();
        }

        private void RunApp(string filePath)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = filePath,
                WindowStyle = ProcessWindowStyle.Normal
            };

            var process = Process.Start(startInfo);
            process.EnableRaisingEvents = true;
            process.WaitForExit();
        }
    }
}