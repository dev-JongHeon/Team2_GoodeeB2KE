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

        public bool SetWorker(string produceID, int empID)
        {
            return new POPDAC().SetWorkerForPerformance(produceID, empID);
        }

        public string[] StartProduce(string produceID)
        {
            return new POPDAC().StartProduce(produceID);
        }

        public void Producing(string performanceID, int success, int bad)
        {
            new POPDAC().InProduction(performanceID, success, bad);
        }

        public void EndProduce(string performanceID)
        {
            new POPDAC().EndProduce(performanceID);
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
    }
}
