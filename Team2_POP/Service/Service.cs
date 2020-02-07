using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;
using Team2_DAC;
using System.Data;

namespace Team2_POP
{
    public class Service
    {
        #region 조회

        // 공장 목록 조회
        public List<ComboItemVO> GetFactoryList()
        {
            return new POPDAC().GetFactory();
        }

        // 공정 목록 조회
        public List<ComboItemVO> GetLineList(int factoryID)
        {
            return new POPDAC().GetLine(factoryID);
        }

        // 작업 목록 조회
        public List<Work> GetWorks(string date, int lineID)
        {
            return new POPDAC().GetWorks(date, lineID);
        }

        // 생산 목록 조회
        public List<Produce> GetProduce(string workID, int lineID)
        {
            if (!string.IsNullOrEmpty(workID))
                return new POPDAC().GetProduces(workID, lineID);
            else
                return null;
        }

        // 생산 실적 조회
        public List<Performance> GetPerformance(string produceID)
        {
            return new POPDAC().GetPerformance(produceID);
        }

        //작업자 목록 조회
        public List<ComboItemVO> GetWorker(int factoryDivision)
        {
            return new POPDAC().GetWorker(factoryDivision);
        }
        
        //불량처리유형 조회
        public List<ComboItemVO> GetDefectiveCode()
        {
            return new POPDAC().GetDefectiveCode();
        }

        //불량 조회
        public List<string> GetDefective(string performanceID)
        {
            return new POPDAC().GetDefective(performanceID);
        }

        public bool GetDefectiveByProduce(string produceID)
        {
            return new POPDAC().GetDefectiveByProduce(produceID);
        }

        //비가동 종류 조회
        public List<ComboItemVO> GetDowntimeCode()
        {
            return new POPDAC().GetDowntimeCode();
        }

        #endregion

        // 작업할당 메서드
        public bool SetWorker(string produceID, int empID)
        {
            return new POPDAC().SetWorkerForPerformance(produceID, empID);
        }

        // 생산 시작 메서드
        public string[] StartProduce(string produceID)
        {
            return new POPDAC().StartProduce(produceID);
        }
     
        

        // 불량유형을 설정하는 코드
        public bool SetDefective(string defectiveID, string handleCode, string defecCode)
        {
            return new POPDAC().SetDefective(defectiveID, handleCode, defecCode);

        }

        // 비가동 설정
        public bool SetDowntime(int lineID, string downtimeCode, int employeeID)
        {
            return new POPDAC().SetDowntime(lineID, downtimeCode, employeeID);
        }

        // 비가동인지 아닌지
        public bool IsDowntime(int lineID)
        {
            return new POPDAC().IsDowntime(lineID);
        }

        
    }
}
