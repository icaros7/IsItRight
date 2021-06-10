using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IsItRight
{
    public class DataAnalytics
    {
        private SeoulOpenData so;
        
        public DataAnalytics(SeoulOpenData seoulOpenData)
        {
            Debug.WriteLine(@"INFO: New DataAnalytics initializing");
            so = seoulOpenData;
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
        /// 나이대 조건 별 값의 평균을 구합니다.
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        public double GetSumAgeArg(int sex)
        {
            Debug.WriteLine(@"INFO: Call GetSumAgeArg");
            
            List<int> row = new List<int>(); // [0] row, [1] ... 성별 별 나이대 true 값 index 저장
            double sum = 0;
            int ageF = 0, ageT = 9; // GetValue를 위한 From, To 나이대 값

            SetRow(row, so.GetAgeArray(sex));

            if (row[0] == 0)
            {
                Debug.WriteLine(@"ERROR: No true age");
                return -1;
            }
            
            Debug.WriteLine(@"INFO: Set row: " + (row.Count - 1));
            for (int i = 0; i < row.Count - 2; i++)
            {
                sum += Double.Parse(so.GetValue((sex == 0 ? @"" : @"FE") + @"MALE_F" + ageF + @"T" + ageT + @"_LVPOP_CO", i));
                
                // TODO: row 리스트를 활용하여 특정 나이대 가져오기 구현
                ageF += (i == 0) ? 10 : 5;
                ageT += 5;
            }

            return sum / row[0];
        }

        /// <summary>
        /// 합의 평균을 구합니다.
        /// </summary>
        /// <param name="value">취합할 데이터 name</param>
        /// <param name="row">0-4, 취합할 데이터 row 수</param>
        public double GetSumArg(string value)
        {
            Debug.WriteLine(@"INFO: Call GetSumArg");
            int row = so.Time == @"" ? 5 : 1;
            Debug.WriteLine(@"INFO: Set Row: " + (row - 1));
            
            double sum = 0;
            
            for (int i = 0; i < row; i++)
            {
                if (Double.TryParse(so.GetValue(value, i), out double tmp))
                {
                    sum += tmp;
                    Debug.WriteLine(@"sum: " + sum + @", i: " + i);
                }
                else
                {
                    return -1; // 잘못된 GetValue 매개변수로 인해 실패시, -1 반환
                }
            }
            
            return sum / row;
        }
    }
}