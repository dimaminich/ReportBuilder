using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder.MappingClasses
{
    internal static class StringMapper
    {
        private static string _mappedValue;

        public static string Map(object value)
        {
            _mappedValue = String.Empty;

            if (value.GetType() == typeof(bool))        MapFromBoolean(value);
            if (value.GetType() == typeof(Int16))       MapFromInt16(value);
            if (value.GetType() == typeof(Int32))       MapFromInt32(value);
            if (value.GetType() == typeof(Int64))       MapFromInt64(value);
            if (value.GetType() == typeof(Double))      MapFromDouble(value);
            if (value.GetType() == typeof(Decimal))     MapFromDecimal(value);
            if (value.GetType() == typeof(String))      MapFromString(value);
            if (value.GetType() == typeof(DateTime))    MapFromDateTime(value);
            if (value.GetType() == typeof(Single))      MapFromSingle(value);
            if (value.GetType() == typeof(Guid))        MapFromGuid(value);
            if (value.GetType() == typeof(object))      MapFromObject(value);
            if (value.GetType() == typeof(Byte[]))      MapFromByteArray(value);

            return _mappedValue;
        }

        private static void MapFromBoolean(object value)
        {
            _mappedValue = ((bool)value).ToString();
        }

        private static void MapFromInt16(object value)
        {
            _mappedValue = ((Int16)value).ToString();
        }

        private static void MapFromInt32(object value)
        {
            _mappedValue = ((Int32)value).ToString();
        }

        private static void MapFromInt64(object value)
        {
            _mappedValue = ((Int64)value).ToString();
        }

        private static void MapFromDouble(object value)
        {
            _mappedValue = ((Double)value).ToString();
        }

        private static void MapFromDecimal(object value)
        {
            _mappedValue = ((Decimal)value).ToString();
        }

        private static void MapFromString(object value)
        {
            _mappedValue = ((string)value).ToString().Trim();
        }

        private static void MapFromDateTime(object value)
        {
            _mappedValue = ((DateTime)value).ToString();
        }
        
        private static void MapFromSingle(object value)
        {
            _mappedValue = ((Single)value).ToString();
        }

        private static void MapFromGuid(object value)
        {
            _mappedValue = ((Guid)value).ToString();
        }

        private static void MapFromObject(object value)
        {
            _mappedValue = value.ToString();
        }

        private static void MapFromByteArray(object value)
        {
            string[] strings = ((Byte[])value).ToList().Select(i => i.ToString()).ToArray();
            _mappedValue = String.Join(",", strings);
        }
    }
}
