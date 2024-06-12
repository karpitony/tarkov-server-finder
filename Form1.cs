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
        private string logsFolderPath;
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
                    logsFolderPath = JsonConvert.DeserializeObject<string>(File.ReadAllText(settingsFilePath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"설정 파일을 불러오는 중 오류 발생: {ex.Message}", "오류");
                }
            }
            else
            {
                // 기본 Logs 경로 설정
                logsFolderPath = @"C:\Battlestate Games\Escape from Tarkov\Logs";
            }

            // 텍스트 상자에 기본 설정값 표시
            textBoxFolderPath.Text = logsFolderPath;
        }

        private void SaveSettings()
        {
            try
            {
                File.WriteAllText(settingsFilePath, JsonConvert.SerializeObject(logsFolderPath));
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
                InitialDirectory = logsFolderPath,
                IsFolderPicker = true
            };

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                logsFolderPath = dlg.FileName;
                textBoxFolderPath.Text = logsFolderPath; // 텍스트 상자 업데이트
                SaveSettings();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(logsFolderPath))
            {
                MessageBox.Show("먼저 폴더 경로를 설정하세요.", "경로 설정 필요");
                return;
            }

            try
            {
                if (Directory.Exists(logsFolderPath))
                {
                    // 가장 최근 파일 찾기
                    var latestFile = new DirectoryInfo(logsFolderPath)
                        .GetFiles("*-network-connection.log", SearchOption.AllDirectories)
                        .OrderByDescending(f => f.LastWriteTime)
                        .FirstOrDefault();

                    if (latestFile != null)
                    {
                        // 파일에서 가장 최근 IP 주소 추출
                        string lastIpAddress = GetFirstIpAddress(latestFile.FullName);
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
                    MessageBox.Show($"디렉토리가 존재하지 않습니다: {logsFolderPath}", "오류");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류");
            }
        }

        static string GetFirstIpAddress(string logFilePath)
        {
            try
            {
                string firstIpAddress = null;

                // FileStream을 사용하여 파일을 읽기 전용으로 엽니다.
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Match match = Regex.Match(line, @"(?<=Try add connection )(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})");

                            if (match.Success)
                            {
                                firstIpAddress = match.Value;
                                break; // 첫 번째 IP 주소를 찾았으므로 루프를 종료합니다.
                            }
                        }
                    }
                }

                return firstIpAddress;
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
                    labelCountryName.Text = $"국가 : {geoInfo["country"]}";
                    labelRegionName.Text = $"지역 : {geoInfo["regionName"]}";
                    labelCityName.Text = $"도시 : {geoInfo["city"]}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");

                // 오류 발생 시 라벨에 오류 메시지 표시
                labelCountryName.Text = "국가 : 오류";
                labelRegionName.Text = "지역 : 오류";
                labelCityName.Text = "도시 : 오류";
            }

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
}
