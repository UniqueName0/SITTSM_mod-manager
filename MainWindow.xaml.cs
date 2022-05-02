using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SITTSM_mod_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public string get_repo()
        {
            string repoText = File.ReadAllText(@"./repo.txt");
            return repoText;
        }

        public MainWindow()
        {
            InitializeComponent();
            using (var client = new WebClient())
            {
                string modsData = client.DownloadString(get_repo());
                //string modsData = "mod1name|mod1url\nmod2name|mod2url\nmod3name|mod3url\nmod4name|mod4url\nmod5name|mod5url\nmod6name|mod6url\nmod7name|mod7url\nmod8name|mod8url";
                foreach (string line in modsData.Split("\n"))
                {
                    string[] lineSplit = line.Split("|");
                    string Modurl = lineSplit[1];
                    CheckBox modcheck = new CheckBox
                    {
                        Content = lineSplit[0],
                        DataContext = Modurl //stores url for mod in DataContext
                    };
                    mods.Children.Add(modcheck);
                }
            }
        }

        private void ActivateMods(object sender, RoutedEventArgs e)
        {
            try
            {
                    string gamePath = exeText.Text.Substring(0, exeText.Text.LastIndexOf('\\'));
                if (Directory.Exists(gamePath + "\\bepinex"))
                {
                    status.Text = "bepinex already installed"; //bepinex already installed
                }
                else
                {
                    status.Text = "bepinex not installed - installing bepinex"; //bepinex not installed
                    using (var client = new WebClient())
                    {
                        client.DownloadFile("https://uniquename.pythonanywhere.com/static/stick-man-files/sittsm-bepinex.zip", gamePath + "\\sittsm-bepinex.zip");
                    }
                    status.Text = "bepinex.zip downloaded - starting extraction";
               
                    ZipFile.ExtractToDirectory(gamePath + "\\sittsm-bepinex.zip", gamePath, true);
                
                    status.Text = "extraction complete";
                }

                foreach (CheckBox mod in mods.Children)
                {
                        string modPath = gamePath + "\\BepInEx\\plugins\\" + mod.Content.ToString().Trim() + ".dll";
                    if ((bool)mod.IsChecked)
                        {
                            status.Text = "downloading "+mod.Content.ToString();
                            using (var client = new WebClient())
                            {
                                client.DownloadFile(mod.DataContext.ToString(), modPath);
                            }
                            status.Text = "activated " + mod.Content.ToString();
                    }
                    else if (File.Exists(modPath))
                    {
                        status.Text = "deactivating mod: " + mod.Content.ToString();
                        File.Delete(modPath);
                        status.Text = "mod deactivated: " + mod.Content.ToString();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                status.Text = "please select the game's exe";
            }
        }
        
        private void StartGame(object sender, RoutedEventArgs e)
        {
            status.Text = "starting game";
            try
            {
                Process.Start(exeText.Text);
            }
            catch (System.ComponentModel.Win32Exception) {
                status.Text = "error: exe not selected";
            }
        }

        private void browseExe(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".exe";
            dlg.Filter = "exe Files (*.exe)|*.exe"; 


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                exeText.Text = filename;
            }
        }
    }
}