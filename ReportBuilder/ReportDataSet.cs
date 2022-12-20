using ReportBuilder.MappingClasses;
using System;
using System.Reflection;

namespace ReportBuilder
{
    public abstract class ReportDataSet: IReportDataSet
    {
        internal DataSetIdentifier _dataSetName;

        public string Text01 { get; set; }
        public string Text02 { get; set; }
        public string Text03 { get; set; }
        public string Text04 { get; set; }
        public string Text05 { get; set; }
        public string Text06 { get; set; }
        public string Text07 { get; set; }
        public string Text08 { get; set; }
        public string Text09 { get; set; }
        public string Text10 { get; set; }
        public string Text11 { get; set; }
        public string Text12 { get; set; }
        public string Text13 { get; set; }
        public string Text14 { get; set; }
        public string Text15 { get; set; }


        public int Integer01 { get; set; }
        public int Integer02 { get; set; }
        public int Integer03 { get; set; }
        public int Integer04 { get; set; }
        public int Integer05 { get; set; }
        public int Integer06 { get; set; }
        public int Integer07 { get; set; }
        public int Integer08 { get; set; }
        public int Integer09 { get; set; }
        public int Integer10 { get; set; }
        public int Integer11 { get; set; }
        public int Integer12 { get; set; }
        public int Integer13 { get; set; }
        public int Integer14 { get; set; }
        public int Integer15 { get; set; }


        public double Double01 { get; set; }
        public double Double02 { get; set; }
        public double Double03 { get; set; }
        public double Double04 { get; set; }
        public double Double05 { get; set; }
        public double Double06 { get; set; }
        public double Double07 { get; set; }
        public double Double08 { get; set; }
        public double Double09 { get; set; }
        public double Double10 { get; set; }
        public double Double11 { get; set; }
        public double Double12 { get; set; }
        public double Double13 { get; set; }
        public double Double14 { get; set; }
        public double Double15 { get; set; }


        public DateTime DateTime01 { get; set; }
        public DateTime DateTime02 { get; set; }
        public DateTime DateTime03 { get; set; }
        public DateTime DateTime04 { get; set; }
        public DateTime DateTime05 { get; set; }


        public DataSetIdentifier DataSetName
        {
            get
            {
                return _dataSetName;
            }
        }

        public void SetValueByKey(string key, object value)
        {
            Type objType = typeof(ReportDataSet);
            PropertyInfo propertyInfo = objType.GetProperty(key);

            if (propertyInfo == null) throw new ArgumentException("No field with given key found!");

            try
            {
                if (propertyInfo.PropertyType == typeof(string))
                    propertyInfo.SetValue(this, StringMapper.Map(value));

                if (propertyInfo.PropertyType == typeof(int))
                    propertyInfo.SetValue(this, IntegerMapper.Map(value));

                if (propertyInfo.PropertyType == typeof(double))
                    propertyInfo.SetValue(this, DoubleMapper.Map(value));

                if (propertyInfo.PropertyType == typeof(DateTime))
                    propertyInfo.SetValue(this, DateTimeMapper.Map(value));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
