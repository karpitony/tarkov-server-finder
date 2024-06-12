using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace tarkov_server_finder
{
    public partial class Form1 : Form
    {
        private string baseFolderPath;
        private const string settingsFilePath = "settings.json";

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                try
                {
                    var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsFilePath));
                    baseFolderPath = settings.BaseFolderPath;
                    textBoxFolderPath.Text = baseFolderPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"설정 파일을 불러오는 중 오류 발생: {ex.Message}", "오류");
                }
            }
            else
            {
                // 기본 경로 설정
                baseFolderPath = @"C:\Battlestate Games";
                textBoxFolderPath.Text = baseFolderPath;
            }
        }

        private void SaveSettings()
        {
            try
            {
                var settings = new Settings
                {
                    BaseFolderPath = baseFolderPath
                };
                File.WriteAllText(settingsFilePath, JsonConvert.SerializeObject(settings));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파일을 저장하는 중 오류 발생: {ex.Message}", "오류");
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog
            {
                InitialDirectory = @"C:\",
                IsFolderPicker = true
            };

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string selectedPath = dlg.FileName;
                string targetDirectory = Path.Combine(selectedPath, @"Escape from Tarkov\Logs");

                if (Directory.Exists(targetDirectory))
                {
                    textBoxFolderPath.Text = selectedPath;
                    baseFolderPath = selectedPath;
                    SaveSettings();
                }
                else
                {
                    MessageBox.Show($"선택한 폴더에 'Escape from Tarkov\\Logs' 디렉토리가 없습니다: {targetDirectory}", "오류");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(baseFolderPath))
            {
                MessageBox.Show("먼저 폴더 경로를 설정하세요.", "경로 설정 필요");
                return;
            }

            string searchDirectory = Path.Combine(baseFolderPath, @"Escape from Tarkov\Logs");

            try
            {
                if (Directory.Exists(searchDirectory))
                {
                    // 가장 최근 폴더 찾기
                    var latestDirectory = new DirectoryInfo(searchDirectory)
                        .GetDirectories()
                        .OrderByDescending(d => d.LastWriteTime)
                        .FirstOrDefault();

                    if (latestDirectory != null)
                    {
                        // 가장 최근 파일 찾기
                        var latestFile = latestDirectory.GetFiles("*-network-connection.log")
                            .OrderByDescending(f => f.LastWriteTime)
                            .FirstOrDefault();

                        if (latestFile != null)
                        {
                            // 파일에서 가장 최근 IP 주소 추출
                            string lastIpAddress = GetLastIpAddress(latestFile.FullName);
                            if (!string.IsNullOrEmpty(lastIpAddress))
                            {
                                labelIpAddress.Text = $"IP 주소 : {lastIpAddress}";
                                SetGeoLocationLabels(lastIpAddress);
                            }
                            else
                            {
                                MessageBox.Show("로그 파일에서 IP 주소를 찾을 수 없습니다.", "IP 주소 없음");
                            }
                        }
                        else
                        {
                            MessageBox.Show("해당 폴더에 '-network-connection.log'로 끝나는 파일이 없습니다.", "파일 없음");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Logs 디렉토리에 폴더가 없습니다.", "폴더 없음");
                    }
                }
                else
                {
                    MessageBox.Show($"디렉토리가 존재하지 않습니다: {searchDirectory}", "오류");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류");
            }
        }

        // log 파일에서 가장 최근 ip 주소 가져오기
        static string GetLastIpAddress(string logFilePath)
        {
            try
            {
                string lastIpAddress = null;
                using (StreamReader reader = new StreamReader(logFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // 'address: ' 뒤에 오는 IP 주소와 포트를 찾는 정규 표현식
                        Match match = Regex.Match(line, @"(?<=address: )(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})");
                        if (match.Success)
                        {
                            lastIpAddress = match.Groups[1].Value;
                        }
                    }
                }
                return lastIpAddress;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
                return null;
            }
        }


        // IP 주소를 받아서 지리적 위치 정보를 가져와 라벨에 표시하는 메서드
        private void SetGeoLocationLabels(string ipAddress)
        {
            try
            {
                string apiUrl = $"http://ip-api.com/json/{ipAddress}";
                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(apiUrl);
                    dynamic geoInfo = JsonConvert.DeserializeObject(response);

                    // 국가, 도시 정보를 라벨에 표시
                    labelCountryName.Text = $"국가: {geoInfo["country"]}";
                    labelRegionName.Text = $"지역: {geoInfo["regionName"]}";
                    labelCityName.Text = $"도시: {geoInfo["city"]}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");

                // 오류 발생 시 라벨에 오류 메시지 표시
                labelCountryName.Text = "국가: 오류";
                labelRegionName.Text = "지역: 오류";
                labelCityName.Text = "도시: 오류";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelCountryName_Click(object sender, EventArgs e)
        {

        }

        private void labelRegionName_Click(object sender, EventArgs e)
        {

        }

        private void labelCityName_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFolderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/karpitony/tarkov-server-finder/blob/main/README.md");
        }

        private void linkLabelBugReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/karpitony/tarkov-server-finder/issues");
        }
    }

    public class Settings
    {
        public string BaseFolderPath { get; set; }
    }
}
