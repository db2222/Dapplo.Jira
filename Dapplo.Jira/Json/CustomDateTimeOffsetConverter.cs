﻿using System;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Dapplo.Jira.Json
{
    /// <summary>
    /// A JsonConverter especially for the Jira datetime format
    /// </summary>
    public class CustomDateTimeOffsetConverter : DateTimeConverterBase
    {
        private const string Iso8601Format = @"yyyy-MM-dd\THH:mm:ss.FFFF";

        /// <summary>
        /// Default constructor with the Iso8601 format
        /// </summary>
        public CustomDateTimeOffsetConverter() : this(Iso8601Format)
        {
        }

        /// <summary>
        /// Constructor which supports a custom format
        /// </summary>
        /// <param name="format"></param>
        public CustomDateTimeOffsetConverter(string format)
        {
            
        }
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dateTime = (DateTimeOffset)value;
            string sign = dateTime.Offset < TimeSpan.Zero ? " - " : "+";
            var output = $"{dateTime.ToString(Iso8601Format, CultureInfo.InvariantCulture)}{sign}{Math.Abs(dateTime.Offset.Hours):00}{Math.Abs(dateTime.Offset.Minutes):00}";
            writer.WriteValue(output);
            writer.Flush();
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string dateTimeOffsetString = (string)reader.Value;

            if (reader.TokenType != JsonToken.String)
            {
                throw new Exception($"Unexpected token parsing date. Expected string, got {reader.TokenType}.");
            }
            if (Regex.IsMatch(dateTimeOffsetString, @"\d{4}$"))
            {
                dateTimeOffsetString = dateTimeOffsetString.Insert(dateTimeOffsetString.Length - 2, ":");

            }
            return DateTimeOffset.Parse(dateTimeOffsetString, CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }
    }
}
