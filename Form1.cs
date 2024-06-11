using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace tarkov_server_finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetDirectory = @"E:\Battlestate Games\Escape from Tarkov\Logs";

            try
            {
                if (Directory.Exists(targetDirectory))
                {
                    // 가장 최근 폴더 찾기
                    var latestDirectory = new DirectoryInfo(targetDirectory)
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
                    MessageBox.Show($"디렉토리가 존재하지 않습니다: {targetDirectory}", "오류");
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
                        if (line.Contains("address:"))
                        {
                            Match match = Regex.Match(line, @"address: (\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})");
                            if (match.Success)
                            {
                                // 첫 번째 그룹을 가져와서 IP 주소만을 추출합니다.
                                lastIpAddress = match.Groups[1].Value;
                            }
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
    }
}
