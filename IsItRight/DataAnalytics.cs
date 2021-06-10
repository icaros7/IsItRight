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
            int row = so.Time == @"" ? 5 : 1;
            Debug.WriteLine(@"INFO: Set Row: " + (row - 1));
            
            double sum = 0;
            
            // TODO: 결과값 확인 요망 
            for (int i = 0; i < row; i++)
            {
                sum += Double.Parse(so.GetValue(value, i));
                Debug.WriteLine(@"sum: " + sum + @", i: " + i);
            }
            
            return sum / row;
        }
    }
}