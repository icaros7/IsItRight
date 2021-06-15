using System;
using System.Diagnostics;
using System.Net;

namespace IsItRight
{
    public class SeoulOpenData
    {
        private string _apiKey;
        private DateTime _date;
        private bool[] _female = new bool[14];
        private int _location;
        private bool[] _male = new bool[14];
        private int _time = -1;

        protected internal SeoulOpenData(string apiKey, int location)
        {
            Debug.WriteLine(@"INFO: New SeoulOpenData initializing");
            ApiKey = apiKey;
            Location = location;
        }

        // openAPI 인증키 설정 메서드
        private string ApiKey
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
        protected internal int Location
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
        protected internal int Date
        {
            get => int.Parse(_date.ToString("yyyyMMdd"));
            set
            {
                var today = DateTime.Today;
                if (20200201 > value || value >= int.Parse(today.ToString(@"yyyyMMdd")))
                {
                    Debug.WriteLine(@"ERROR: Not valid date: " + value);
                    return;
                }

                _date = DateTime.ParseExact(value.ToString(), @"yyyyMMdd", null);
                Debug.WriteLine(@"INFO: Set Date: " + value);
            }
        }

        // 시간대 설정 메서드
        // 범위: 00 ~ 23
        protected internal string Time
        {
            get => _time.ToString("D2");
            set
            {
                if (IsTime(value))
                {
                    _time = int.Parse(value);
                    Debug.WriteLine(@"INFO: Set Time: " + value);
                    return;
                }

                Debug.WriteLine(@"ERROR: " + value + @" is not correct time format. Set to -1 (Default value)");
                _time = -1;
            }
        }

        private bool IsTime(string value)
        {
            return 0 <= int.Parse(value) && int.Parse(value) <= 23;
        }

        private bool IsTime(string value1, string value2)
        {
            return IsTime(value1) && IsTime(value2) && int.Parse(value1) < int.Parse(value2);
        }

        /// <summary>
        ///     나이대 배열 설정 메서드
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <param name="age">0(0~9),1(10~14),2(15~19), ... ,12(64~69),13(70+@)</param>
        protected internal void SetAge(int sex, int[] age)
        {
            if (sex == 0)
                _male = new bool[14];
            else if (sex == 1)
                _female = new bool[14];
            else
                return;

            Debug.Write(@"INFO: Set True in " + (sex == 0 ? "Male" : "Female") + @": ");
            foreach (var s in age)
            {
                if (sex == 0)
                    _male[s] = true;
                else
                    _female[s] = true;

                Debug.Write(s + @" ");
            }

            Debug.WriteLine(@"");
        }

        protected internal void SetAge(int[] age)
        {
            SetAge(0, age);
            SetAge(1, age);
        }

        /// <summary>
        ///     각 성별 나이대 bool 배열 반환
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <returns></returns>
        protected internal bool[] GetAgeArray(int sex)
        {
            if (sex == 0) return _male;
            return _female;
        }

        /// <summary>
        ///     성별의 나이대 bool 값 반환
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <param name="index">0~14,나이대</param>
        /// <returns></returns>
        protected internal bool GetAgeAera(int sex, int index)
        {
            return sex == 0 ? _male[index] : _female[index];
        }

        protected internal string GetJson()
        {
            using (var wc = new WebClient())
            {
                if (_time == -1) return "-1";
                var jsonData = new WebClient().DownloadString(@"http://openapi.seoul.go.kr:8088/" + ApiKey +
                                                              @"/json/SPOP_LOCAL_RESD_DONG/1/5/" +
                                                              Date + @"/" + Time + @"/" + Location);
                Debug.WriteLine(@"INFO: GetJSON Date: {0}, Location: {1}, Time: {2}", Date, Location, Time);

                return jsonData;
            }
        }
    }
}