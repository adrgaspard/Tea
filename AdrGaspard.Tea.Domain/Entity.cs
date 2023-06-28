using System.ComponentModel.DataAnnotations;

namespace AdrGaspard.Tea.Domain
{
    [Serializable]
    public abstract class Entity : IEntity, IEquatable<IEntity>
    {
        protected Entity()
        { }

        public override string ToString()
        {
            return $"[Entity: {GetType().Name}]";
        }

        public bool Equals(IEntity? other)
        {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            Type type = GetType();
            Type otherType = other.GetType();
            if (!type.IsAssignableFrom(otherType) && !otherType.IsAssignableFrom(type)) { return false; }
            object[] key = GetKey();
            object[] otherKey = other.GetKey();
            if (key.Length != otherKey.Length || key.Length == 0) { return false; }
            for (int i = 0; i < key.Length; i++)
            {
                if (!key[i].Equals(otherKey[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as IEntity);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return left is not null && left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return GetKey().GetHashCode();
        }

        public abstract object[] GetKey();
    }

    [Serializable]
    public abstract class Entity<TKey> : Entity, IEntity<TKey>, IEquatable<IEntity<TKey>> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; private set; }

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.

        protected Entity()
        { }

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
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            Type type = GetType();
            Type otherType = other.GetType();
            return (type.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(type)) && other.Id is not null && !Id.Equals(default) && !other.Id.Equals(default) && Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as IEntity<TKey>);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return left is not null && left.Equals(right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }

        public override object[] GetKey()
        {
            return new object[1] { Id };
        }
    }
}