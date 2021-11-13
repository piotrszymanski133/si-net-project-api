using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace si_net_project_api.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable<object>).IsAssignableFrom(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var type = context.ObjectType.GetGenericArguments().Length > 0 ? context.ObjectType.GetGenericArguments()[0]
                : context.ObjectType.GetElementType();
            var builder = new StringBuilder();
            builder.AppendLine(string.Join(",", type.GetProperties().Select(property => property.Name)));
            foreach (var item in (IEnumerable<object>) context.Object)
            {
                var properties = item.GetType().GetProperties().Select(
                    property => new
                    {
                        Value = property.GetValue(item, null)
                    });
                var formattedProperties = new List<string>();
                foreach (var property in properties)
                {
                    formattedProperties.Add(property.Value.ToString());
                }

                builder.AppendLine(string.Join(",", formattedProperties));
            }

            return context.HttpContext.Response.WriteAsync(builder.ToString(), selectedEncoding);
        }
    }
}