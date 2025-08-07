namespace Leisure.Libraries;

public class ClosedArray<T>
{
    public ClosedArray(int length)
    {
        _list = new List<T>(new T[length]);
        _length = length;
    }

    public T this[int i]
    {
        get => _list[i % _length];
        set => _list[i % _length] = value;
    }
    
    private readonly List<T> _list;
    private readonly int _length;
}