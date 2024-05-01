using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarBook.Application.Utilities;

public static class MapperExtensions
{
    public static TSource MapWithSource<TSource, TDestination>(this TSource source, TDestination destination)
        where TSource : class, new()
        where TDestination : class, new()
    {
        var sourceProperties = typeof(TSource).GetProperties().ToList();
        typeof(TDestination).GetProperties().ToList().ForEach(property =>
        {
            var sourceFindedProperty = sourceProperties.FirstOrDefault(i => i.Name == property.Name);
            if (sourceFindedProperty != null)
            {
                sourceFindedProperty.SetValue(source, property.GetValue(destination));
            }
        });
        return source;
    }
}