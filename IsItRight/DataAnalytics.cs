using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        /// 합의 평균을 구합니다.
        /// </summary>
        /// <param name="value">취합할 데이터 name</param>
        /// <param name="row">0-4, 취합할 데이터 row 수</param>
        public double GetSumArg(string value)
        {
            Debug.WriteLine(@"INFO: Call GetSumArg");
            int row = (so.Time == @"") ? 0 : (23 - Int32.Parse(so.Time) > 4) ? Int32.Parse(so.Time) : 4;
            Debug.WriteLine(@"INFO: Set Row: " + row);
            
            double sum = 0;
            
            // TODO: 결과값 확인 요망 
            for (int i = 0; i <= row; i++)
            {
                if (Double.TryParse(so.GetValue(value, i), out double temp))
                {
                    Debug.WriteLine(temp);
                    sum += temp;
                    Debug.WriteLine(sum);
                }
                else
                {
                    Debug.WriteLine(@"Is Here?");
                    return sum / row;
                }
            }
            
            return sum / row;
        }
    }
}