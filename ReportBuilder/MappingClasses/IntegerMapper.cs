﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder.MappingClasses
{
    internal static class IntegerMapper
    {
        private static int _mappedValue;

        public static int Map(object value)
        {
            _mappedValue = int.MinValue;

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
            _mappedValue = Convert.ToInt32((bool)value);
        }

        private static void MapFromInt16(object value)
        {
            _mappedValue = (int)value;
        }

        private static void MapFromInt32(object value)
        {
            _mappedValue = (int)value;
        }

        private static void MapFromInt64(object value)
        {
            _mappedValue = (int)value;
        }

        private static void MapFromDouble(object value)
        {
            _mappedValue = Convert.ToInt32((Double)value);
        }

        private static void MapFromDecimal(object value)
        {
            _mappedValue = Convert.ToInt32((Decimal)value);
        }

        private static void MapFromString(object value)
        {
            _mappedValue = Int32.Parse((string)value);
        }

        private static void MapFromDateTime(object value)
        {
            throw new ArgumentNullException("DateTime is not parseable to Integer");
        }
        
        private static void MapFromSingle(object value)
        {
            throw new ArgumentNullException("Single is not parseable to Integer");
        }

        private static void MapFromGuid(object value)
        {
            throw new ArgumentNullException("Guid is not parseable to Integer");
        }

        private static void MapFromObject(object value)
        {
            throw new ArgumentNullException("Object is not parseable to Integer");
        }

        private static void MapFromByteArray(object value)
        {
            throw new ArgumentNullException("Byte[] is not parseable to Integer");
        }
    }
}
