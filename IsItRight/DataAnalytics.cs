using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace IsItRight
{
    public class DataAnalytics
    {
        private static JObject _json;
        private readonly SeoulOpenData _so;
        private DataExport _de;
        private readonly int[] _lastInfo = {-1, -1, -1};
        private readonly int[] ageF = {0, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70};
        private readonly int[] ageT = {9, 14, 19, 24, 29, 34, 39, 44, 49, 54, 59, 64, 69, 74};

        public DataAnalytics(string api, int location)
        {
            if (api.Equals(@"PUT_YOUR_API_KEY"))
            {
                Debug.WriteLine(@"ERROR: No API Key");
                Environment.Exit(-1);
            }
            Debug.WriteLine(@"INFO: New DataAnalytics initializing");
            _so = new SeoulOpenData(api, location);
            _lastInfo[2] = location;
        }

        /// <summary>
        ///     엑셀 데이터 저장 유무를 선택 합니다.
        /// </summary>
        public bool AddChart { get; set; }

        /// <summary>
        ///     나이대 배열을 받아 해당 나이대를 조건에 추가합니다.
        /// </summary>
        /// <param name="sex">0 or 1, 남성 or 여성</param>
        /// <param name="age">0-15, 0: 0~9, 1: 10~14, 2:15~19, ... , 12:64~69, 13: 70+@</param>
        public void SetAge(int sex, int[] age)
        {
            _so.SetAge(sex, age);
        }
        
        public void SetAge(int[] age)
        {
            _so.SetAge(age);
        }

        /// <summary>
        ///     지정된 데이터 범위 내에서 평균값을 산출 합니다.
        /// </summary>
        /// <param name="dateF">yyyyMMdd, 시작 날짜</param>
        /// <param name="dateT">yyyymmdd, 종료 날짜</param>
        /// <param name="timeF">d, 시작 시간</param>
        /// <param name="timeT">d, 종료 시간</param>
        /// <param name="sex">none or 0-1, 0: 남성, 1: 여성, 매개변수 안쓸 경우 모두</param>
        /// <returns></returns>
        public double[] GetSomeAvg(int dateF, int dateT, int timeF, int timeT, int sex)
        {
            Debug.WriteLine(@"INFO: Call GetSomeAvg");

            _de = new DataExport();
            var ageRow = new List<int>();
            SetRow(ageRow, _so.GetAgeArray(sex));
            SetSettings(false, dateF, timeF);
            var sum = new double[ageRow[0]];

            if (ageRow[0] == 0)
            {
                Debug.WriteLine(@"ERROR: No true age");
                return null;
            }

            try
            {
                for (var i = 0; i < dateT - dateF + 1; i++)
                for (var j = 0; j < timeT - timeF + 1; j++)
                {
                    SetSettings(true, dateF + i, timeF + j);
                    for (var k = 0; k < ageRow[0]; k++)
                    {
                        double.TryParse(GetSomeValue((sex == 0 ? @"" : @"FE") + @"MALE_F" + ageF[ageRow[k + 1]] +
                                                     @"T" + ageT[ageRow[k + 1]] + @"_LVPOP_CO"), out var value);
                        sum[k] += value;
                        _de.AddData(new[]
                        {
                            _lastInfo[0].ToString(), _so.Location.ToString(), sex == 0 ? "남성" : "여성",
                            _lastInfo[1].ToString(), ageF[ageRow[k + 1]] + "~" + ageT[ageRow[k + 1]] + "세",
                            value.ToString(), GetPercent(value) + "%"
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR: GetSomeAvg - " + e);
                return null;
            }

            for (var i = 0; i < sum.Length; i++) sum[i] = sum[i] / ((dateT - dateF + 1) * (timeT - timeF + 1));

            return sum;
        }

        // TODO: 두 성별 모두 검색시 알고리즘 개선 필요
        public double[][] GetSomeAvg(int dateF, int dateT, int timeF, int timeT)
        {
            Debug.WriteLine(@"INFO: Call GetSomeAvg");
            
            _de = new DataExport();
            var ageRow = new List<List<int>>();
            SetRow(ageRow, _so.GetAgeArray(0), _so.GetAgeArray(1));
            SetSettings(false, dateF, timeF);
            double[][] sum = {new double[ageRow[0][0]], new double[ageRow[1][0]]};

            if (ageRow[0][0] == 0 || ageRow[1][0] == 0)
            {
                Debug.WriteLine(@"ERROR: No true age - " + (ageRow[0][0] == 0 ? 0 : 1));
                return null;
            }

            try
            {
                for (var i = 0; i < dateT - dateF + 1; i++)
                for (var j = 0; j < timeT - timeF + 1; j++)
                {
                    SetSettings(true, dateF + i, timeF + j);
                    for (var k = 0; k < Math.Max(ageRow[0][0], ageRow[1][0]); k++)
                    {
                        if (ageRow[0][0] > k)
                        {
                            double.TryParse(GetSomeValue(@"MALE_F" + ageF[ageRow[0][k + 1]] +
                                                         @"T" + ageT[ageRow[0][k + 1]] + @"_LVPOP_CO"), out var value0);
                            sum[0][k] += value0;
                            _de.AddData(new []
                            {
                                _lastInfo[0].ToString(), _so.Location.ToString(), "남성",
                                _lastInfo[1].ToString(), ageF[ageRow[0][k + 1]] + "~" + ageT[ageRow[0][k + 1]] + "세",
                                value0.ToString(), GetPercent(value0) + "%"
                            });
                        }
                        if (ageRow[1][0] > k)
                        {
                            double.TryParse(GetSomeValue(@"FEMALE_F" + ageF[ageRow[1][k + 1]] +
                                                         @"T" + ageT[ageRow[1][k + 1]] + @"_LVPOP_CO"), out var value1);
                            sum[1][k] += value1;
                            _de.AddData(new[]
                            {
                                _lastInfo[0].ToString(), _so.Location.ToString(), "여성",
                                _lastInfo[1].ToString(),
                                ageF[ageRow[1][k + 1]] + "~" + ageT[ageRow[1][k + 1]] + "세",
                                value1.ToString(), GetPercent(value1) + "%"
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR: GetSomeAvg - " + e);
                return null;
            }

            for (var i = 0; i < sum[0].Length; i++) sum[0][i] = sum[0][i] / ((dateT - dateF + 1) * (timeT - timeF + 1));
            for (var i = 0; i < sum[1].Length; i++) sum[1][i] = sum[1][i] / ((dateT - dateF + 1) * (timeT - timeF + 1));

            return sum;
        }

        /// <summary>
        ///     수집된 데이터를 엑셀 데이터로 내보내기 합니다.
        /// </summary>
        public void Export()
        {
            _de.WriteData(AddChart);
        }

        /// <summary>
        ///     json 데이터로부터 값을 추출 합니다.
        /// </summary>
        /// <param name="value">원하는 데이터 name</param>
        /// <param name="row">0-4, row 값, 기본 값: 0</param>
        /// <returns></returns>
        private string GetSomeValue(string value)
        {
            if (_json == null)
            {
                try
                {
                    _json = JObject.Parse(_so.GetJson());
                }
                catch (Exception)
                {
                    Debug.WriteLine(@"ERROR: Wrong API Key or data.seoul.go.kr is down");
                    _de.Release();
                    Environment.Exit(-1);
                }
            }
            var status = (string) _json.SelectToken(@"SPOP_LOCAL_RESD_DONG.RESULT.CODE");
            if (status != @"INFO-000")
            {
                Debug.WriteLine(@"ERROR: GetSomeValue - " + status);
                Environment.Exit(-1);
            }

            return (string) _json.SelectToken(@"SPOP_LOCAL_RESD_DONG.row[0]." + value);
        }

        /// <summary>
        ///     전체 생활인구로부터 백분율을 구합니다.
        /// </summary>
        /// <param name="value">비교 값</param>
        /// <param name="row">0-4, row 값, 기본 값: 0</param>
        /// <returns></returns>
        private double GetPercent(double value)
        {
            var total = double.Parse(GetSomeValue(@"TOT_LVPOP_CO"));
            return Math.Truncate(value / total * 10000) / 100;
        }


        /// <summary>
        ///     SeoulOpenData 객체에 새로운 setter를 보냅니다.
        /// </summary>
        /// <param name="date">yyyyMMdd</param>
        /// <param name="time">00-23</param>
        private void SetSettings(bool newOne, int date, int time)
        {
            var isChanged = false;
            if (date != _lastInfo[0])
            {
                isChanged = true;
                _so.Date = date;
                _lastInfo[0] = date;
            }

            if (time != _lastInfo[1])
            {
                isChanged = true;
                _so.Time = time.ToString();
                _lastInfo[1] = time;
            }

            if (isChanged && newOne) _json = JObject.Parse(_so.GetJson());
        }

        /// <summary>
        ///     나이대 index List에 추가 합니다.
        /// </summary>
        /// <param name="row">저장 할 List형</param>
        /// <param name="ageArray">성별 나이대 배열</param>
        private void SetRow(List<int> row, bool[] ageArray)
        {
            row.Add(0);
            for (var i = 0; i < ageArray.Length; i++)
            {
                if (!ageArray[i]) continue;
                row[0]++;
                row.Add(i);
            }
        }

        private void SetRow(List<List<int>> row, bool[] ageArray0, bool[] ageArray1)
        {
            for (var i = 0; i < 2; i++)
            {
                row.Add(new List<int>());
                row[i].Add(0);
                for (var j = 0; j < (i == 0 ? ageArray0.Length : ageArray1.Length); j++)
                {
                    if (!( i == 0 ? ageArray0[j] : ageArray1[j])) continue;
                    row[i][0]++;
                    row[i].Add(j);
                }
            }
        }
    }
}
