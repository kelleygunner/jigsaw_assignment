using System;

namespace Infrastructure.UI
{
    public struct ScreenId : IEquatable<ScreenId>
    {
        public string Id;

        public ScreenId(string id)
        {
            Id = id;
        }

        public bool Equals(ScreenId other)=> Id == other.Id;
        public override int GetHashCode() => Id.GetHashCode();
        public override string ToString() => Id;
        public static bool operator ==(ScreenId left, ScreenId right) => left.Equals(right);
        public static bool operator !=(ScreenId left, ScreenId right) => !(left == right);
        public override bool Equals(object obj)
        {
            return obj is ScreenId other && Equals(other);
        }
        
        public static ScreenId HomeScreen => new ScreenId("HomeScreen");
        public static ScreenId StartLevelScreen => new ScreenId("StartLevelScreen");
    }
}