using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchViewBot
{
    public partial class Form1 : Form
    {
        private static Process torProcess;
        private static List<ChromeDriver> drivers = new List<ChromeDriver>();
        private static int viewerCount = 2; // Default viewer count
        private static string channelName = "default"; // Default channel
        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private bool keepRefreshing = false;
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadSettings();
            Text = "Twitch Viewer Bot v1.0";

        }

        private void LoadSettings()
        {
            userNameBox.Text = config.AppSettings.Settings["ChannelName"]?.Value ?? "default";
            numViewersTxt.Text = config.AppSettings.Settings["ViewerCount"]?.Value ?? "2";
            refreshInterval.Value = int.TryParse(config.AppSettings.Settings["RefreshInterval"]?.Value, out int interval) ? interval : 10;
        }

        private void InitializeCustomComponents()
        {
            startBtn.Click += StartBtn_Click;
            stopBtn.Click += StopBtn_Click;
            this.FormClosing += Form1_FormClosing;
        }

        private void SaveSettings()
        {
            config.AppSettings.Settings.Remove("ChannelName");
            config.AppSettings.Settings.Add("ChannelName", userNameBox.Text);
            config.AppSettings.Settings.Remove("ViewerCount");
            config.AppSettings.Settings.Add("ViewerCount", numViewersTxt.Text);
            config.AppSettings.Settings.Remove("RefreshInterval");
            config.AppSettings.Settings.Add("RefreshInterval", refreshInterval.Value.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }



        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private async void StartBtn_Click(object sender, EventArgs e)
        {
            startBtn.Enabled = false;
            if (!int.TryParse(numViewersTxt.Text, out viewerCount) || viewerCount < 1)
            {
                Log("Error: Please enter a valid number of viewers (1 or more).");
                startBtn.Enabled = true;
                return;
            }
            channelName = userNameBox.Text.Trim();
            if (string.IsNullOrEmpty(channelName))
            {
                Log("Error: Please enter a channel name.");
                startBtn.Enabled = true;
                return;
            }

            SaveSettings();
            Log("Starting Twitch Viewer Bot...");
            try
            {
                keepRefreshing = true;
                await LaunchSequentialViewers();
                await Task.Run(() => RefreshViewers()); // Start refresh loop
                Log("All viewers launched.");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
            }
            startBtn.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Log("Stopping viewers...");
            keepRefreshing = false;
            Cleanup();
            Log("All processes terminated.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            keepRefreshing = false;
            Cleanup();
            Application.Exit();

        }

        private void StartTor()
        {
            string torPath = @"C:\Users\Luck\Desktop\Tor Browser\Browser\TorBrowser\Tor\tor.exe"; // Adjust path to your path
            torProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = torPath,
                    Arguments = "--SocksPort 9050",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            torProcess.Start();
            Log("Starting Tor...");
            Task.Delay(8000).Wait(); // Wait for Tor to bootstrap
            Log("Tor initialized.");
        }

        private async Task LaunchSequentialViewers()
        {
            for (int i = 0; i < viewerCount; i++)
            {
                if (torProcess != null && !torProcess.HasExited)
                {
                    torProcess.Kill();
                    Log("Cycling Tor circuit...");
                }
                StartTor();
                await Task.Run(() => LaunchViewer(i));
                UpdateViewerCount(); // Update after each viewer
            }
        }

        private void LaunchViewer(int viewerId)
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless"); // Uncomment after testing
                options.AddArgument("--proxy-server=socks5://127.0.0.1:9050");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--autoplay-policy=no-user-gesture-required");
                options.AddArgument("--enable-unsafe-swiftshader");
                options.AddArgument("--disable-gpu-sandbox");
                options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36");

                var service = ChromeDriverService.CreateDefaultService();
                service.SuppressInitialDiagnosticInformation = true;
                service.HideCommandPromptWindow = true;

                var driver = new ChromeDriver(service, options);
                lock (drivers) { drivers.Add(driver); }

                Log($"Viewer {viewerId + 1}: Connecting to {channelName}");
                driver.Navigate().GoToUrl($"https://www.twitch.tv/{channelName}");
                Task.Delay(30000).Wait(); // Wait for page load

                var videoExists = driver.ExecuteScript("return !!document.querySelector('video');");
                Log($"Viewer {viewerId + 1}: Video element exists: {videoExists}");
                if (Convert.ToBoolean(videoExists))
                {

                    ClickVideo(driver, viewerId).Wait();

                }
                else
                {
                    var errorText = driver.FindElement(By.XPath("//*[@id=\'root\']/div/div[1]/div/main/div[1]/div[3]/div/div/div[2]/div/div[2]/div/div[3]/div/div/div[7]/div/div[3]/button")).Enabled;
                    if (errorText)
                    {
                        Log($"Viewer {viewerId + 1}: Error #2000 detected. Refreshing...");
                        driver.Navigate().Refresh();
                        Task.Delay(15000).Wait();
                    }
                    else
                    {
                        Log($"Viewer {viewerId + 1}: No video found, no Error #2000 detected.");
                    }
                }

                Log($"Viewer {viewerId + 1}: Page loaded. Title: {driver.Title}");
            }
            catch (Exception ex)
            {
                Log($"Viewer {viewerId + 1} failed: {ex.Message}");
                lock (drivers) { drivers.RemoveAll(d => d == null || d.SessionId == null); } // Clean up failed drivers
                UpdateViewerCount();
            }
        }



        private async Task ClickVideo(ChromeDriver driver, int viewerId)
        {
            try
            {
                driver.ExecuteScript("document.querySelector('video')?.play();");
                Log($"Viewer {viewerId + 1}: Video play attempted.");

                driver.ExecuteScript("document.querySelector('video')?.play();");
                Log($"Viewer {viewerId + 1}: Video play attempted.");

                // Set lowest quality (160p)
                driver.ExecuteScript(@"
                var player = document.querySelector('.video-player');
                if (player) {
                    var settingsButton = document.querySelector('button[data-a-target=""player-settings-button""]');
                    if (settingsButton) {
                        settingsButton.click(); // Open settings
                        setTimeout(function() {
                            var qualityMenu = document.querySelector('button[data-a-target=""player-settings-menu-item-quality""]');
                            if (qualityMenu) {
                                qualityMenu.click(); // Open quality options
                                setTimeout(function() {
                                    var qualityOptions = document.querySelectorAll('input[data-a-target=""tw-radio""]');
                                    if (qualityOptions.length > 0) {
                                        var lowestQuality = qualityOptions[qualityOptions.length - 1]; // Last option is lowest (160p)
                                        lowestQuality.click();
                                    }
                                }, 1000);
                            }
                        }, 1000);
                    }
                }
            ");
                Task.Delay(100).Wait(); // Wait for quality change to apply
                Log($"Viewer {viewerId + 1}: Set to lowest quality (160p).");
            }
            catch (Exception ex)
            {
                Log($"Viewer {viewerId + 1} failed: {ex.Message}");
                lock (drivers) { drivers.RemoveAll(d => d == null || d.SessionId == null); } // Clean up failed drivers
                UpdateViewerCount();
            }

        }
        private async Task RefreshViewers()
        {
            while (keepRefreshing)
            {
                int minutes = (int)refreshInterval.Value;
                if (minutes > 0)
                {
                    await Task.Delay(minutes * 60 * 1000); // Convert to milliseconds
                    lock (drivers)
                    {
                        foreach (var driver in drivers)
                        {
                            try
                            {


                                driver.Navigate().Refresh();
                                Log($"Refreshed viewer: {driver.Url}");
                            }
                            catch (Exception ex)
                            {
                                Log($"Refresh failed: {ex.Message}");
                                drivers.Remove(driver); // Remove dead driver
                                UpdateViewerCount();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    await Task.Delay(1000); // Avoid tight loop if 0
                }
            }
        }

        private void UpdateViewerCount()
        {
            //this is completely wrong wtf
            int count = drivers.Count;
            if (liveViewerLabel.InvokeRequired)
                liveViewerLabel.Invoke(new Action(() => liveViewerLabel.Text = $"{count}"));
            else
                liveViewerLabel.Text = $"{count}";
        }

        private void KillAllProcesses()
        {
            string[] processNames = { }; // Empty array?
            foreach (var processName in processNames) { /* ... */ }

            var allProcesses = Process.GetProcesses();
            foreach (var process in allProcesses)
            {
                try
                {
                    if (!process.HasExited && !string.IsNullOrEmpty(process.MainWindowTitle) &&
                        process.MainWindowTitle.Contains(userNameBox.Text)) ;
                    {
                        process.Kill();
                        process.WaitForExit(1000);
                        Log($"Terminated process with 'chromedriver.exe' in title (PID: {process.Id}, Name: {process.ProcessName})");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Failed to kill process with 'chromedriver.exe' in title (PID: {process.Id}): {ex.Message}");
                }
                finally
                {
                    process.Dispose();
                }
            }
        }



        private void Cleanup()
        {
            lock (drivers) // Add thread safety
            {
                foreach (var driver in drivers.ToList()) // Use ToList() to avoid collection modification issues
                {
                    try
                    {
                        if (driver != null)
                        {
                            driver.Close();  // Close the browser window
                            driver.Quit();   // Terminate the driver process
                            Log($"Closed ChromeDriver instance.");
                            GC.Collect();
                        }
                    }
                    catch (Exception ex)
                    {
                        Log($"Error closing driver: {ex.Message}");
                    }
                }
                drivers.Clear(); // Clear the list after cleanup
            }

            if (torProcess != null && !torProcess.HasExited)
            {
                try
                {
                    torProcess.Kill();
                    torProcess.WaitForExit(2000); // Wait up to 2 seconds for clean exit
                    Log("Tor process terminated.");
                }
                catch (Exception ex)
                {
                    Log($"Error stopping Tor: {ex.Message}");
                }
                finally
                {
                    torProcess = null;
                }
            }

            UpdateViewerCount();
        }




        private void Log(string message)
        {
            if (LogTxtBx.InvokeRequired)
            {
                LogTxtBx.Invoke(new Action(() =>
                {
                    LogTxtBx.AppendText($"{DateTime.Now:HH:mm:ss} | {message}{Environment.NewLine}");
                    LogTxtBx.ScrollToCaret();
                }));
            }
            else
            {
                LogTxtBx.AppendText($"{DateTime.Now:HH:mm:ss} | {message}{Environment.NewLine}");
                LogTxtBx.ScrollToCaret();
            }
        }

        private void liveViewerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}