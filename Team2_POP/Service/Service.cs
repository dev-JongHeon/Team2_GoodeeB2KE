﻿using System;
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
        public List<ComboItemVO> GetFactoryList()
        {
            return new POPDAC().GetFactory();
        }

        public List<ComboItemVO> GetLineList(int factoryID)
        {
            return new POPDAC().GetLine(factoryID);
        }

        public List<Work> GetWorks(string date, int lineID)
        {
            return new POPDAC().GetWorks(date, lineID);
        }

        public List<Produce> GetProduce(string workID)
        {
            if (!string.IsNullOrEmpty(workID))
                return new POPDAC().GetProduces(workID);
            else
                return null;
        }

        public List<Performance> GetPerformance(string produceID)
        {
            return new POPDAC().GetPerformance(produceID);
        }

        public List<ComboItemVO> GetWorker(int factoryDivision)
        {
            return new POPDAC().GetWorker(factoryDivision);
        }

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

        public void Producing(string performanceID, int success, int bad)
        {
            new POPDAC().InProduction(performanceID, success, bad);
        }

        public void EndProduce(string performanceID, string produceID)
        {
            new POPDAC().EndProduce(performanceID, produceID);
        }

        public DataTable GetDefectiveCode()
        {
            return new POPDAC().GetDefectiveCode();
        }

        public List<string> GetDefective(string performanceID)
        {
            return new POPDAC().GetDefective(performanceID);
        }

        public bool SetDefective(string defectiveID, string handleCode, string defecCode)
        {
            return new POPDAC().SetDefective(defectiveID, handleCode, defecCode);

        }

        public List<ComboItemVO> GetDowntimeCode()
        {
            return new POPDAC().GetDowntimeCode();
        }

        public void SetDowntime(int lineID, string downtimeCode)
        {
            new POPDAC().SetDowntime(lineID, downtimeCode);
        }
    }
}
