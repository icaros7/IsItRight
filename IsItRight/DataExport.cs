using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace IsItRight
{
    public class DataExport
    {
        private static Application excelApp;
        private static Workbook wb;
        private static Worksheet ws;
        private static int row = 2;

        public DataExport()
        {
            Debug.WriteLine(@"INFO: New DataExport initializing");
            try
            {
                excelApp = new Application();
                excelApp.Visible = false;
                wb = excelApp.Workbooks.Add();
                ws = wb.Worksheets.get_Item(1) as Worksheet;

                // 1행 해더 추가
                ws.Cells[1, 1] = @"날짜";
                ws.Cells[1, 2] = @"행정동";
                ws.Cells[1, 3] = @"성별";
                ws.Cells[1, 4] = @"시간대";
                ws.Cells[1, 5] = @"연령층";
                ws.Cells[1, 6] = @"생활인구";
                ws.Cells[1, 7] = @"백분율";
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR: " + e);
                Release();
            }
        }

        /// <summary>
        ///     피벗 차트를 엑셀 우측에 추가합니다.
        /// </summary>
        private void ChartAdd()
        {
            Debug.WriteLine(@"INFO: Call ChartAdd");

            try
            {
                var last = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
                var range = ws.get_Range("A1", last);

                var pc = wb.PivotCaches().Create(XlPivotTableSourceType.xlDatabase, range);
                PivotTable pt = pc.CreatePivotTable(ws.Cells[4, 9], "요약");

                var chart = ws.Shapes.AddChart(XlChartType.xlLine,
                    300, 100, 500, 200);
                chart.Chart.SetSourceData(pt.TableRange1);

                var field = (PivotField) pt.PivotFields("날짜");
                field.Orientation = XlPivotFieldOrientation.xlRowField;

                field = (PivotField) pt.PivotFields("시간대");
                field.Orientation = XlPivotFieldOrientation.xlRowField;

                field = (PivotField) pt.PivotFields("생활인구");
                field.Orientation = XlPivotFieldOrientation.xlDataField;
                field.Function = XlConsolidationFunction.xlAverage;

                field = (PivotField) pt.PivotFields("성별");
                field.Orientation = XlPivotFieldOrientation.xlPageField;

                field = (PivotField) pt.PivotFields("연령층");
                field.Orientation = XlPivotFieldOrientation.xlColumnField;
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR: " + e);
                Environment.Exit(-1);
            }
        }

        /// <summary>
        ///     데이터를 셀에 추가합니다. 0: 날짜, 1: 행정동 코드, 2: 성별, 3: 시간대, 4: 연령층, 5: 생활인구, 6: 시간대 백분율
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void AddData(string[] data)
        {
            // TODO: 비동기 실행 대응
            try
            {
                for (var i = 0; i < data.Length; i++)
                    // 1행 해더에 알맞게 각 열에 데이터 입력
                    ws.Cells[row, i + 1] = data[i];
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR: " + e);
                Release();
            }

            row++;
        }

        /// <summary>
        ///     엑셀 데이터를 날짜 및 시간과 함께 디렉토리에 저장합니다.
        /// </summary>
        public void WriteData(bool addChart)
        {
            if (addChart) ChartAdd();

            var today = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            try
            {
                wb.SaveAs(Path.Combine(Environment.CurrentDirectory, @"IsItRight-" + today + @".xlsx"));
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR: " + e);
            }
            finally
            {
                Release();
            }
        }

        /// <summary>
        ///     엑셀 앱을 종료하여 파일을 반환합니다.
        /// </summary>
        private void Release()
        {
            ws = null;
            wb.Close(false);
            wb = null;
            excelApp.Quit();
            excelApp = null;

            GC.Collect();
            Debug.WriteLine("INFO: Released");
        }
    }
}