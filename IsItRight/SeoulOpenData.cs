﻿using System;
using System.Diagnostics;

namespace IsItRight
{
    public class SeoulOpenData
    {
        private string _apiKey;
        private int _location;
        private DateTime _date;
        private int _time;
        private bool[] _male;
        private bool[] _female;

        // openAPI 인증키 설정 메서드
        // 발급: https://data.seoul.go.kr/together/mypage/actkeyMain.do
        public string ApiKey
        {
            get => _apiKey;
            set
            {
                _apiKey = value;
                Debug.WriteLine(@">> Set openAPI Key: " + value);
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
                Debug.WriteLine(@">> Set Location: " + value);
            }
        }
        
        // 날짜 설정 메서드
        // 정확성을 위해 2020년 2월 이후 설정 가능
        public int Date
        {
            get => Int32.Parse(_date.ToString("yyyymmdd"));
            set
            {
                DateTime today = DateTime.Today;
                if (20200201 > value || value >= Int32.Parse(today.ToString(@"yyyymmdd"))) return;

                _date = DateTime.Parse(value.ToString());
                Debug.WriteLine(@">> Set Date: " + value);
            }
        }

        // 시간대 설정 메서드
        // 범위: 00 ~ 23
        public string Time
        {
            get => _time.ToString("D2");
            set
            {
                if (0 > Int32.Parse(value) || Int32.Parse(value) > 23) return;
                _time = Int32.Parse(value);
                Debug.WriteLine(@">> Set Time: " + value);
            }
        }
        
        /*
         * 성별 별 나이대 설정 메서드
         *
         * sex = 0, 남성
         * sex = 1, 여성
         *
         * age[0] = 0~9세
         * age[1] = 10~14세
         * age[2] = 15~19세
         * ...
         * age[11] = 60~64세
         * age[12] = 65~69세
         * age[13] = 70세 이상
         */
        public void SetAge(int sex, int[] age)
        {
            if (sex == 0) { _male = new bool[14]; }
            else if (sex == 1) { _female = new bool[14]; }
            else { return; }
            
            Debug.Write(@">> Set True in " + (sex == 0 ? "Male" : "Female") + @": ");
            foreach (int s in age)
            {
                if (sex == 0) { _male[s] = true; }
                else { _female[s] = true; }
                
                Debug.Write(s + @" ");
            }
            Debug.WriteLine(@"");
        }

        public SeoulOpenData(string name,string apiKey)
        {
            Debug.WriteLine(@"> New SeoulOpenData initializing: " + name);
            ApiKey = apiKey;
        }
    }
}