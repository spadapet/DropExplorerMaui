using System;
using System.Diagnostics;

namespace VsDrops.Model;

[DebuggerDisplay("{Name,nq} ({Id})")]
public sealed class AdoBuild: IComparable, IComparable<AdoBuild>, IEquatable<AdoBuild>
{
    public int Id { get; set; }
    public int Revision { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }
    public string Url { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? FinishTime { get; set; }

    public override string ToString()
    {
        return this.Name;
    }

    public override bool Equals(object obj)
    {
        return obj is AdoBuild other && this.Equals(other);
    }

    public bool Equals(AdoBuild other)
    {
        return string.Equals(this.Id, other.Id);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public int CompareTo(AdoBuild other)
    {
        return other.Id.CompareTo(this.Id);
    }

    public int CompareTo(object obj)
    {
        if (obj is not AdoBuild other)
        {
            throw new InvalidOperationException();
        }

        return this.CompareTo(other);
    }
}
