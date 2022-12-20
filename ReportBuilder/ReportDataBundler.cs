using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder
{
    public class ReportDataBundler: IEnumerable
    {
        private Dictionary<string, List<IReportDataSet>> DataSources { get; set; } =
            new Dictionary<string, List<IReportDataSet>>();


        public void AddReportData(IReportDataSet reportData)
        {
            string datasetName = reportData.DataSetName.ToString();

            if (DataSources.ContainsKey(datasetName))
            {
                DataSources[datasetName].Add(reportData);
            }
            else
            {
                DataSources.Add(datasetName, new List<IReportDataSet> { reportData });
            }
        }


        public void ReplaceDataSet(IReportDataSet reportData)
        {
            string datasetName = reportData.DataSetName.ToString();

            if (DataSources.ContainsKey(datasetName))
            {
                DataSources[datasetName] = new List<IReportDataSet> { reportData };
            }
            else
            {
                DataSources.Add(datasetName, new List<IReportDataSet> { reportData });
            }
        }


        public void VerifyDataSetStructure()
        {
            foreach (DataSetIdentifier dataSetIdentifier in Enum.GetValues(typeof(DataSetIdentifier)))
            {
                string datasetName = dataSetIdentifier.ToString();
                
                if (!DataSources.ContainsKey(datasetName))
                {
                    DataSources[datasetName] = new List<IReportDataSet> { GetDataSetInstance(dataSetIdentifier) };
                }
            }
        }


        private IReportDataSet GetDataSetInstance(DataSetIdentifier dataSetIdentifier)
        {
            switch (dataSetIdentifier)
            {
                case DataSetIdentifier.DataSet1:
                    return new ReportDataSet01();
                    break;
                case DataSetIdentifier.DataSet2:
                    return new ReportDataSet02();
                    break;
                case DataSetIdentifier.DataSet3:
                    return new ReportDataSet03();
                    break;
                case DataSetIdentifier.DataSet4:
                    return new ReportDataSet04();
                    break;
                default:
                    return null;
                    break;
            }
        }


        public IEnumerator<ReportDataSource> GetEnumerator()
        {
            foreach (string key in DataSources.Keys)
            {
                ReportDataSource reportDataSource = new ReportDataSource(key, DataSources[key]);
                yield return reportDataSource;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
