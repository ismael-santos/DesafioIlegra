﻿using System;
using System.ComponentModel;

namespace Utils
{
    public static class EnumExtensions
    {
        public static T GetEnumFromDescription<T>(string description)
        {
            var type = typeof(T);

            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                else
                    if (field.Name == description)
                        return (T)field.GetValue(null);
            }
            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
