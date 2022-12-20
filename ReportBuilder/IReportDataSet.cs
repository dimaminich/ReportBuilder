using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder
{
    public interface IReportDataSet
    {
        DataSetIdentifier DataSetName { get; }
        void SetValueByKey(string key, object val);
    }
}
