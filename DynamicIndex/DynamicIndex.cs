using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DynamicIndex
{
    public class DynamicIndex(object? value)
    {
        public static readonly DynamicIndex Null = new(null);

        private readonly object? _value = value;

        public DynamicIndex this[int index] 
        {
            get
            {
                if (_value is IEnumerable enumerable)
                {
                    int counter = 0;

                    var enumerator = enumerable.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (counter++ == index)
                        {
                            return new DynamicIndex(enumerator.Current);
                        }
                    }
                }

                return Null;
            }
        }

        public DynamicIndex this[string key]
        {
            get
            {
                if (_value is null) return Null;

                var type = _value.GetType();

                // TODO handle dicts here

                var property = type.GetProperty(key);
                if (property is not null && property.CanRead)
                {
                    return new DynamicIndex(property.GetValue(_value));
                }

                return Null;
            }
        }

        public bool Get([MaybeNullWhen(false)]out object value)
        {
            if (_value is not null)
            {
                value = _value;
                return true;
            }

            value = null;
            return false;
        }

        public bool Get<T>([MaybeNullWhen(false)]out T value)
        {
            if (_value is T t)
            {
                value = t;
                return true;
            }

            value = default;
            return false;
        }
    }
}
