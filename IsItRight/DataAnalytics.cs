using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IsItRight
{
    public class DataAnalytics
    {
        private readonly SeoulOpenData _so;
        
        public DataAnalytics(SeoulOpenData seoulOpenData)
        {
            Debug.WriteLine(@"INFO: New DataAnalytics initializing");
            _so = seoulOpenData;
        }

        /// <summary>
        /// 나이대 별 true 값 index를 List에 추가
        /// </summary>
        /// <param name="row">저장 할 List형</param>
        /// <param name="ageArray">성별 나이대 배열</param>
        private void SetRow(List<int> row, bool[] ageArray)
        {
            row.Add(0);
            for (int i = 0; i < ageArray.Length; i++)
            {
                if (!ageArray[i]) continue;
                row[0]++;
                row.Add(i);
            }
        }

        /// <summary>
        /// 특정 시간대 값들의 평균을 구합니다.
        /// </summary>
        /// <param name="_timeF">0-23, 시작 시간</param>
        /// <param name="_timeT">0-23, 종료 시간</param>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <returns></returns>
        public double GetArgThatTime(string _timeF, string _timeT, int sex)
        {
            Debug.WriteLine(@"INFO: Call GetArgThatTime");
            
            if (_so.IsTime(_timeF, _timeT) == false) return -1;
            double tmp = 0;

            string originTime = _so.Time;
            int timeF = Int32.Parse(_timeF);
            int timeT = Int32.Parse(_timeT);
            for (int i = 0; i < (timeT - timeF + 1); i++)
            {
                _so.Time = (timeF + i).ToString();
                tmp += GetSumAgeArg(sex);
            }

            _so.Time = (originTime == "") ? "-1" : originTime;
            return tmp / (timeT - timeF + 1);
        }
        
        /// <summary>
        /// 나이대 조건 별 값의 평균을 구합니다.
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        public double GetSumAgeArg(int sex)
        {
            Debug.WriteLine(@"INFO: Call GetSumAgeArg");
            
            List<int> ageRow = new List<int>();
            double sum = 0;
            int[] ageF = {0, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70};
            int[] ageT = {9, 14, 19, 24, 29, 34, 39, 44, 49, 54, 59, 64, 69, 74};
            int row = _so.Time == @"" ? 5 : 1;
            Debug.WriteLine(@"INFO: Set row: " + row);

            SetRow(ageRow, _so.GetAgeArray(sex)); // [0] row, [1] ... 성별 별 나이대 true 값 index 저장

            if (ageRow[0] == 0)
            {
                Debug.WriteLine(@"ERROR: No true age");
                return -1;
            }

            for (int i = 0; i < row; i++)
            {
                Debug.WriteLine(@"INFO: Row: " + i);
                for (int j = 0; j < ageRow.Count - 1; j++)
                {
                    sum += Double.Parse(_so.GetValue((sex == 0 ? @"" : @"FE") + @"MALE_F" + ageF[ageRow[j + 1]] + @"T" + ageT[ageRow[j + 1]] + @"_LVPOP_CO", i));
                }
            }
            
            return sum / (ageRow[0] * row);
        }

        /// <summary>
        /// 합의 평균을 구합니다.
        /// </summary>
        /// <param name="value">취합할 데이터 name</param>
        /// <param name="row">0-4, 취합할 데이터 row 수</param>
        public double GetSumArg(string value)
        {
            Debug.WriteLine(@"INFO: Call GetSumArg");
            int row = (_so.Time == "-1" ? 5 : 1);
            Debug.WriteLine(@"INFO: Set Row: " + (row - 1));
            
            double sum = 0;
            
            for (int i = 0; i < row; i++)
            {
                if (Double.TryParse(_so.GetValue(value, i), out double tmp))
                {
                    sum += tmp;
                }
                else
                {
                    return -1; // 잘못된 GetValue 매개변수로 인해 실패시, -1 반환
                }
            }
            
            return sum / row;
        }

        public double GetPercentOfAll(double value, string time)
        {
            Debug.WriteLine(@"INFO: Call GetPercentOfAll");
            
            if (_so.IsTime(time) == false) return -1;
            string originTime = _so.Time;
            _so.Time = time;
            double total = double.Parse(_so.GetValue("TOT_LVPOP_CO",0));

            _so.Time = (originTime == "") ? "-1" : originTime;
            return Math.Truncate((value / total) * 10000) / 100;
        }
    }
}