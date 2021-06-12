using System;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

namespace IsItRight
{
    public class SeoulOpenData
    {
        private string _apiKey;
        private int _location;
        private DateTime _date;
        private int _time;
        private bool[] _male = new bool[14];
        private bool[] _female = new bool[14];

        // openAPI 인증키 설정 메서드
        // 발급: https://data.seoul.go.kr/together/mypage/actkeyMain.do
        public string ApiKey
        {
            get => _apiKey;
            set
            {
                _apiKey = value;
                Debug.WriteLine(@"INFO: Set openAPI Key: " + value);
            }
        }

        // 행자부 행정동 코드 기반 위치 설정 메서드
        // 행자부 행정동 코드: https://data.seoul.go.kr/dataVisual/seoul/seoulLivingPopulation.do
        public int Location
        {
            get => _location;
            set
            {
                _location = value;
                Debug.WriteLine(@"INFO: Set Location: " + value);
            }
        }
        
        // 날짜 설정 메서드
        // 정확성을 위해 2020년 2월 이후 설정 가능
        public int Date
        {
            get => Int32.Parse(_date.ToString("yyyyMMdd"));
            set
            {
                DateTime today = DateTime.Today;
                if (20200201 > value || value >= Int32.Parse(today.ToString(@"yyyyMMdd"))) return;

                _date = DateTime.ParseExact(value.ToString(), @"yyyyMMdd", null);
                Debug.WriteLine(@"INFO: Set Date: " + value);
            }
        }

        // 시간대 설정 메서드
        // 범위: 00 ~ 23
        public string Time => (_time == 0) ? "" : _time.ToString("D2");

        public int SetTime(string value)
        {
            if (0 > Int32.Parse(value) || Int32.Parse(value) > 23) return -1;
            _time = Int32.Parse(value);
            Debug.WriteLine(@"INFO: Set Time: " + value);

        public bool IsTime(string value)
        {
            return 0 <= Int32.Parse(value) && Int32.Parse(value) <= 23;
        }

        public bool IsTime(string value1, string value2)
        {
            return IsTime(value1) && IsTime(value2) && (Int32.Parse(value1) < Int32.Parse(value2));
        }
        
        /// <summary>
        /// 나이대 배열 설정 메서드
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <param name="age">0(0~9),1(10~14),2(15~19), ... ,14(64~69),15(70+@)</param>
        public void SetAge(int sex, int[] age)
        {
            if (sex == 0) { _male = new bool[14]; }
            else if (sex == 1) { _female = new bool[14]; }
            else { return; }
            
            Debug.Write(@"INFO: Set True in " + (sex == 0 ? "Male" : "Female") + @": ");
            foreach (int s in age)
            {
                if (sex == 0) { _male[s] = true; }
                else { _female[s] = true; }
                
                Debug.Write(s + @" ");
            }
            Debug.WriteLine(@"");
        }

        public SeoulOpenData(string apiKey)
        {
            Debug.WriteLine(@"INFO: New SeoulOpenData initializing");
            ApiKey = apiKey;
        }

        /// <summary>
        /// 각 성별 나이대 bool 배열 반환
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <returns></returns>
        public bool[] GetAgeArray(int sex)
        {
            Debug.WriteLine(@"INFO: Call GetAgeArray");
            
            if (sex == 0) return _male;
            return _female;
        }

        /// <summary>
        /// 성별의 나이대 bool 값 반환
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <param name="index">0~14,나이대</param>
        /// <returns></returns>
        public bool GetAgeAera(int sex, int index)
        {
            return (sex == 0) ? _male[index] : _female[index];
        }

        /// <summary>
        /// openAPI를 사용한 json 데이터 읽기 메서드, `행정동별 서울생활인구(내국인)` 참고
        /// </summary>
        /// <param name="value">가져올 json name</param>
        /// <param name="row">0-4, 데이터 row 번호</param>
        /// <returns></returns>
        public string GetValue(string value,int row)
        {
            Debug.WriteLine(@"INFO: Call GetValue");
            using (WebClient wc = new WebClient())
            {
                Debug.WriteLine(@"INFO: GetValue json data: " + value + @", " + row);
                string jsonData = new WebClient().DownloadString(@"http://openapi.seoul.go.kr:8088/" + ApiKey + @"/json/SPOP_LOCAL_RESD_DONG/1/5/" +
                                                                 Date + @"/" + Time + @"/" + Location);
                
                JObject json = JObject.Parse(jsonData);
                string e = (string) json.SelectToken(@"SPOP_LOCAL_RESD_DONG.RESULT.CODE");
                if (e != @"INFO-000")
                {
                    Debug.WriteLine(@"ERROR: " + e);
                    
                    return e;
                }
                
                return (string)json.SelectToken(@"SPOP_LOCAL_RESD_DONG.row[" + row + @"]." + value);
            }
        }
    }
}