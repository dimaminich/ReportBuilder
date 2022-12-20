using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder
{
    public class ReportParameterBundler
    {
        private List<ReportParameter> Parameters { get; set; } =
            new List<ReportParameter>();

        public int Count
        {
            get
            {
                return Parameters.Count;
            }
        }


        public void AddDataParameter(string paramName, string paramValue)
        {
            Parameters.Add(new ReportParameter(paramName, paramValue));
        }

        public List<ReportParameter> GetParameters()
        {
            return Parameters;
        }
    }
}
