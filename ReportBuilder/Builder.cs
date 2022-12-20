using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ReportBuilder
{
    /// <summary>
    /// Class <c>ReportBuilder</c> builds and saves a RDLC-Report.
    /// </summary>
    public class Builder
    {
        private ReportViewer viewer;
        private string DeviceInfo { get; } = "<DeviceInfo>" +
                                                  "   <EmbedFonts>None</EmbedFonts>" +
                                                  "</DeviceInfo>";
        public string[] StreamIds { get; private set; }
        public Warning[] Warnings { get; private set; }
        public string MimeType { get; private set; } = string.Empty;
        public string Encoding { get; private set; } = string.Empty;
        public string Extension { get; private set; } = string.Empty;
        private string fullFileName { get; set; } = string.Empty;


        public Builder()
        {
            viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
        }


        public byte[] CreateReportBytes(string reportname, ReportDataBundler reportDataBundler, ReportParameterBundler reportParameterBundler)
        {
            if (reportParameterBundler.Count > 0) viewer.LocalReport.SetParameters(reportParameterBundler.GetParameters());

            reportDataBundler.VerifyDataSetStructure();

            foreach (var reportData in reportDataBundler)
            {
                viewer.LocalReport.DataSources.Add(reportData);
            }

            string[] streamIds;
            Warning[] warnings;

            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            viewer.LocalReport.ReportPath = reportname + ".rdlc";

            byte[] bytes = viewer.LocalReport.Render(
                "PDF",
                DeviceInfo,
                out mimeType,
                out encoding,
                out extension,
                out streamIds,
                out warnings
            );

            this.StreamIds = streamIds;
            this.Warnings = warnings;
            this.MimeType = mimeType;
            this.Encoding = encoding;
            this.Extension = extension;

            return bytes;
        }


        public string BuildPdfReport(string reportname, string fullFilePathWithoutExtension, ReportDataBundler reportDataBundler, ReportParameterBundler reportParameterBundler)
        {
            try
            {
                var bytes = CreateReportBytes(reportname, reportDataBundler, reportParameterBundler);

                fullFileName = $"{fullFilePathWithoutExtension}.pdf";
                File.WriteAllBytes(fullFileName, bytes);

                return fullFileName;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] BuildReportBytes(string reportname, ReportDataBundler reportDataBundler, ReportParameterBundler reportParameterBundler)
        {
            try
            {
                var bytes = CreateReportBytes(reportname, reportDataBundler, reportParameterBundler);
                return bytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
