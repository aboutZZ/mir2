using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class LocalizedNameAttribute : Attribute
{
    public string LanguageCode { get; }
    public string Name { get; }

    public LocalizedNameAttribute(string languageCode, string name)
    {
        LanguageCode = languageCode;
        Name = name;
    }
}

public static class EnumLocalizationExtensions
{

    private static readonly ConcurrentDictionary<(Type, string), string> _cache =
        new ConcurrentDictionary<(Type, string), string>();

    public static string LocaleName(this Enum value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        var key = (value.GetType(), value.ToString());
        return _cache.GetOrAdd(key, k =>
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attribute = fieldInfo.GetCustomAttributes<LocalizedNameAttribute>().FirstOrDefault();

            if (attribute != null)
                return attribute.Name;

            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null)
                return descriptionAttribute.Description;

            return value.ToString();
        });
    }
}