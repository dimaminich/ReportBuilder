using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder.MappingClasses
{
    internal static class DateTimeMapper
    {
        private static DateTime _mappedValue;

        public static DateTime Map(object value)
        {
            _mappedValue = DateTime.MinValue;

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
            throw new ArgumentNullException("Boolean is not parseable to DateTime");
        }

        private static void MapFromInt16(object value)
        {
            throw new ArgumentNullException("Int16 is not parseable to DateTime");
        }

        private static void MapFromInt32(object value)
        {
            throw new ArgumentNullException("Int32 is not parseable to DateTime");
        }

        private static void MapFromInt64(object value)
        {
            throw new ArgumentNullException("Int64 is not parseable to DateTime");
        }

        private static void MapFromDouble(object value)
        {
            throw new ArgumentNullException("Double is not parseable to DateTime");
        }

        private static void MapFromDecimal(object value)
        {
            throw new ArgumentNullException("Decimal is not parseable to DateTime");
        }

        private static void MapFromString(object value)
        {
            _mappedValue = DateTime.ParseExact((string)value, "MM'/'dd'/'yy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        private static void MapFromDateTime(object value)
        {
            _mappedValue = (DateTime)value;
        }
        
        private static void MapFromSingle(object value)
        {
            throw new ArgumentNullException("Single is not parseable to DateTime");
        }

        private static void MapFromGuid(object value)
        {
            throw new ArgumentNullException("Guid is not parseable to DateTime");
        }

        private static void MapFromObject(object value)
        {
            throw new ArgumentNullException("Object is not parseable to DateTime");
        }

        private static void MapFromByteArray(object value)
        {
            throw new ArgumentNullException("Byte[] is not parseable to DateTime");
        }
    }
}
