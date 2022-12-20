using System.Data.Metadata.Edm;
using System.Runtime.Serialization;

namespace ReportBuilder
{
    public enum DataSetIdentifier
    {
        [EnumMember(Value = "DataSet1")]
        DataSet1,
        [EnumMember(Value = "DataSet2")]
        DataSet2,
        [EnumMember(Value = "DataSet3")]
        DataSet3,
        [EnumMember(Value = "DataSet4")]
        DataSet4
    }
}
