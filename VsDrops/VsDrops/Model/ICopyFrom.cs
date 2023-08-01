namespace VsDrops.Model;

public interface ICopyFrom<T>
{
    void CopyFrom(T other);
}
