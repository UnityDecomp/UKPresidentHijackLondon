using System.Collections;
using System.Collections.Generic;

public abstract class GenericGenerator<T> : IEnumerable, IEnumerable<T>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public abstract IEnumerator<T> GetEnumerator();

    public override string ToString()
    {
        return $"generator({typeof(T)})";
    }
}