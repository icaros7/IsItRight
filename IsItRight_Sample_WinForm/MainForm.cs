/*
 * Is It Right Sample WinForm Application
 * 
 * hominlab@gmail.com
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using IsItRight;

namespace IsItRight_Sample_WinForm
{
    public partial class MainForm : Form
    {
        private DataAnalytics _da = null;
        private List<int> ageList = new List<int>();
        private int sex = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 옵션 기본 설정 값
            dateF.Value = DateTime.Today.AddDays(-7);
            dateT.Value = DateTime.Today.AddDays(-5);
            timeT.SelectedIndex = 20;
            timeF.SelectedIndex = 15;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form Closing 이벤트 시 DataAnalytics Release를 위해 FormClosing 이벤트 제어
            exitBtn.PerformClick();
        }

        private void openProcess(string value)
        {
            var process = new ProcessStartInfo(value)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(process);
        }

        /// <summary>
        /// DataAnalytisc 및 SeoulOpenData를 초기화 합니다.
        /// </summary>
        private void initSOD()
        {
            _da = new DataAnalytics(apiTextBox.Text, Int32.Parse(locationTextBox.Text));
        }

        private void checkList(CheckBox cb)
        {
            string tmp_name = cb.Name;
            if (cb.Checked) ageListAdd(Int32.Parse(tmp_name.Replace("age","")));
            else ageListRemove(Int32.Parse(tmp_name.Replace("age", "")));
        }

        /// <summary>
        /// ageList List에 값을 추가 합니다.
        /// </summary>
        /// <param name="index">-13, 추가할 나이대</param>
        private void ageListAdd(int index)
        {
            ageList.Add(index);
            ageList.Sort();
            ageList.Distinct().ToList();
        }

        /// <summary>
        /// ageList List에서 값을 제거 합니다.
        /// </summary>
        /// <param name="index">0-13, 제거할 나이대</param>
        private void ageListRemove(int index)
        {
            ageList.Remove(index);
            ageList.Sort();
        }

        /// <summary>
        /// 선택한 날짜의 데이터를 검사합니다.
        /// </summary>
        /// <param name="date">DateTimePicker 형식</param>
        /// <param name="isItF">bool, Is It From?</param>
        private void checkDate(DateTimePicker date, bool isItF = false)
        {
            DateTime min = new DateTime(2020,02,01);
            if (isItF)
            {
                if (date.Value >= min && date.Value <= DateTime.Today.AddDays(-2) && date.Value <= dateT.Value) return;
                else
                {
                    MessageBox.Show("날짜 범위는 2020년 2월 이후부터 2일전까지만 가능 합니다.\r또한, 시작 날짜가 종료 날짜보다 같거나 앞이어야 합니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    date.Value = dateT.Value;
                    return;
                }
            }
            else
            {
                if (date.Value >= min && date.Value <= DateTime.Today.AddDays(-2) && date.Value >= dateF.Value) return;
                else
                {
                    MessageBox.Show("날짜 범위는 2020년 2월 이후부터 2일전까지만 가능 합니다.\r또한, 종료 날짜가 시작 날짜보다 같거나 앞이어야 합니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    date.Value = dateF.Value;
                    return;
                }
            }
        }

        private void authBtn_Click(object sender, EventArgs e)
        {
            // OpenAPI키 미입력시 중단
            if (apiTextBox.Text == "")
            {
                MessageBox.Show("오픈API키를 입력하여 주십시오.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string url = @"http://openapi.seoul.go.kr:8088/" + apiTextBox.Text + @"/xml/SPOP_LOCAL_RESD_DONG/1/5/20210601/00/11140550";
            XDocument xDocument = XDocument.Load(url);

            try
            {
                var returnValue = xDocument.Element("RESULT");
                var code = returnValue.Descendants("CODE").First().Value;
            }
            catch (NullReferenceException) // 정상적으로 SPOP_LOCAL_RESD_DONG 로 반환된 경우
            {
                MessageBox.Show("정상 확인 되었습니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (locationTextBox.Text == "") locationTextBox.Text = "11140550";
                initSOD();
                apiTextBox.Enabled = false;
                authBtn.Enabled = false;
                locationTextBox.Enabled = false;
                dataExportBtn.Enabled = true;
                pivotChart.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                return;
            }
            catch (System.Net.Http.HttpRequestException) // 데이터 불러오기에 실패한 경우
            {
                MessageBox.Show("서울 열린데이터 광장이 응답하지 않습니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SPOP_LOCAL_RESD_DONG를 포함하여 반환되지 않은 경우
            MessageBox.Show(apiTextBox.Text + "는 올바른 키가 아닙니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void locationTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPress 이벤트 제어를 통해 숫자만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("서울 열린데이터 광장 오픈API키 신청 화면으로 이동하시겠습니까?", "Is It Right", MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK) openProcess("https://data.seoul.go.kr/together/mypage/actkeyMain.do");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("서울 열린데이터 광장으로부터 행정동 코드표 (엑셀)을 다운로드 하시겠습니까?", "Is It Right", MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK) openProcess("https://data.seoul.go.kr/together/statbook/fileDownload.do?cotCd=999&filename=%ED%96%89%EC%A0%95%EB%8F%99%EC%BD%94%EB%93%9C_%EB%A7%A4%ED%95%91%EC%A0%95%EB%B3%B4_20200325.xlsx&mnuSrl=1&mnuNm=%ED%85%8C%EC%8A%A4%ED%8A%B81&mnuFg=C&upMnuSrl=1");
        }

        private void timeF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timeF.SelectedIndex <= timeT.SelectedIndex) return;
            MessageBox.Show("시작 시간은 종료 시간과 같거나 더 앞이어야 합니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            timeF.SelectedIndex = timeT.SelectedIndex;
        }

        private void timeT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timeT.SelectedIndex >= timeF.SelectedIndex) return;
            MessageBox.Show("종료 시간은 시작 시간과 같거나 더 뒤이어야 합니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            timeT.SelectedIndex = timeF.SelectedIndex;
        }

        private void dataExportBtn_Click(object sender, EventArgs e)
        {
            if (ageList.Count == 0)
            {
                MessageBox.Show("나이대를 선택해주세요!", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                if (sex == 3) _da.SetAge(ageList.ToArray());
                else _da.SetAge(sex, ageList.ToArray());

                dataExportBtn.Enabled = false;
                dataExportBtn.Text = "잠시만 기다려주십시오";
                _da.AddChart = pivotChart.Checked;

                if (sex == 3)
                {
                    if (_da.GetSomeAvg(Int32.Parse(dateF.Value.ToString("yyyyMMdd")), Int32.Parse(dateT.Value.ToString("yyyyMMdd")), timeF.SelectedIndex, timeT.SelectedIndex) == null)
                    {
                        _da.Release();
                        MessageBox.Show("해당 날짜에 데이터가 없습니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    if (_da.GetSomeAvg(Int32.Parse(dateF.Value.ToString("yyyyMMdd")), Int32.Parse(dateT.Value.ToString("yyyyMMdd")), timeF.SelectedIndex, timeT.SelectedIndex, sex) == null)
                    {
                        _da.Release();
                        MessageBox.Show("해당 날짜에 데이터가 없습니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (_da.Export() == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("데이터 내보내기가 완료되었습니다.\r저장위치: " + Environment.CurrentDirectory + "\r\r저장된 폴더를 여시겠습니까?", "Is It Right", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult.Equals(DialogResult.Yes)) openProcess(Environment.CurrentDirectory);
                }
                else
                {
                    MessageBox.Show("데이터 파일 쓰기에 실패하였습니다.", "Is Right", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataExportBtn.Text = "데이터 추출";
                dataExportBtn.Enabled = true;
            }
            catch (Exception _e)
            {
                MessageBox.Show("문제가 생겻습니다.", "Is It Right", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(_e.ToString());
            }
        }

        private void maleRadio_CheckedChanged(object sender, EventArgs e)
        {
            sex = 0;
        }

        private void femaleRadio_CheckedChanged(object sender, EventArgs e)
        {
            sex = 1;
        }

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            sex = 3;
        }

        private void dateF_ValueChanged(object sender, EventArgs e)
        {
            checkDate(dateF, true);
        }

        private void dateT_ValueChanged(object sender, EventArgs e)
        {
            checkDate(dateT);
        }

        private void age0_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age0);
        }

        private void age1_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age1);
        }

        private void age2_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age2);
        }

        private void age3_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age3);
        }

        private void age4_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age4);
        }

        private void age5_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age5);
        }

        private void age6_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age6);
        }

        private void age7_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age7);
        }

        private void age8_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age8);
        }

        private void age9_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age9);
        }

        private void age10_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age10);
        }

        private void age11_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age11);
        }

        private void age12_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age12);
        }

        private void age13_CheckedChanged(object sender, EventArgs e)
        {
            checkList(age13);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (_da != null) _da.Release();
            Environment.Exit(0);
        }
    }
}
