/*
 * Is It Right Sample Console Application
 *
 * hominlab@gmail.com
 */

using System;
using IsItRight;

namespace IsItRight_Sample_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // API키와 행자부 행정동 코드를 통한 초기 객체 생성
            // API키 발급: https://data.seoul.go.kr/together/mypage/actkeyMain.do
            // 행정동 코드: https://data.seoul.go.kr/dataVisual/seoul/seoulLivingPopulation.do 중 "행정구역 코드정보" 참조
            DataAnalytics da = new DataAnalytics("PUT_YOUR_API_KEY", 11140550); // 11140550: 서울특별시 중구 명동
            
            da.SetAge(0, new[] {3, 4, 5, 6}); // 남성 나이대 20~39세로 설정
            
            da.AddChart = true; // 피벗 차트 표출 활성
            
            // 2021년 5월 3일부터 2021년 5월 9일까지 7시부터 20시 까지 남성 데이터 수집
            if (da.GetSomeAvg(20210503, 20210509, 7, 20,0) == null) return;
            da.Export(); // 수집된 데이터 내보내기
            
            da.SetAge(new[] {3, 4, 5}); // 모든 성별 나이대 20~29세로 설정
            
            // 2021년 6월 1일부터 2021년 6월 3일까지 7시부터 20시 까지 데이터 수집
            if (da.GetSomeAvg(20210601, 20210603, 7, 20) == null) return;
            da.Export(); // 수집된 데이터 내보내기
        }
    }
}