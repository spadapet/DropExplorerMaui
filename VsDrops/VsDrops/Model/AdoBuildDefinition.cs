using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace VsDrops.Model;

[DebuggerDisplay("{Name,nq} ({Id})")]
public sealed class AdoBuildDefinition: IComparable, IComparable<AdoBuildDefinition>, IEquatable<AdoBuildDefinition>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }

    public ObservableCollection<AdoBuild> Builds { get; } = new();

    public override string ToString()
    {
        return this.Name;
    }

    public override bool Equals(object obj)
    {
        return obj is AdoBuildDefinition other && this.Equals(other);
    }

    public bool Equals(AdoBuildDefinition other)
    {
        return string.Equals(this.Id, other.Id);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public int CompareTo(AdoBuildDefinition other)
    {
        return this.Id.CompareTo(other.Id);
    }

    public int CompareTo(object obj)
    {
        if (obj is not AdoBuildDefinition other)
        {
            throw new InvalidOperationException();
        }

        return this.CompareTo(other);
    }
}
