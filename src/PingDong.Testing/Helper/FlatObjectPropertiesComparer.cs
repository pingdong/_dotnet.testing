using System;
using System.Collections.Generic;
using System.Reflection;

namespace PingDong.Testing
{
    /// <summary>
    /// Compare two flat objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FlatObjectPropertiesComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T expected, T actual)
        {
            // Null Null
            if (EqualityComparer<T>.Default.Equals(expected, default) &&
                EqualityComparer<T>.Default.Equals(actual, default))
                return true;

            // Null Object
            if (EqualityComparer<T>.Default.Equals(expected, default))
                return false;

            // Object Null
            if (EqualityComparer<T>.Default.Equals(actual, default))
                return false;

            if (ReferenceEquals(expected, actual))
                return true;

            var props = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var expectedValue = prop.GetValue(expected, null);
                var actualValue = prop.GetValue(actual, null);

                if (!Equals(expectedValue, actualValue))
                    return false;
            }

            return true;
        }
        
        public int GetHashCode(T parameterValue)
        {
            return Tuple.Create(parameterValue).GetHashCode();
        }
    }
}
