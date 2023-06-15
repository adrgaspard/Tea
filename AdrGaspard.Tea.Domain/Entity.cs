using System.ComponentModel.DataAnnotations;

namespace AdrGaspard.Tea.Domain
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>, IEquatable<IEntity<TKey>>
    {
        [Key]
        public TKey Id { get; private set; }

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        protected Entity() { }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.

        protected Entity(TKey id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"[Entity: {GetType().Name}] Id = {Id}";
        }

        public bool Equals(IEntity<TKey>? other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity<TKey>);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (left is null || right is null) { return false; }
            if (ReferenceEquals(left, right)) { return true; }
            Type leftType = left.GetType();
            Type rightType = right.GetType();
            return (leftType.IsAssignableFrom(rightType) || rightType.IsAssignableFrom(leftType))
&& left.Id is not null && right.Id is not null && !left.Id.Equals(default(TKey)) && !right.Id.Equals(default(TKey))
&& left.Id.Equals(right.Id);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}
