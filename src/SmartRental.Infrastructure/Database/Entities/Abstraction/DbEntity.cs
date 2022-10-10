namespace SmartRental.Infrastructure.Database.Entities.Abstraction
{
    public abstract class DbEntity<TKey> : IEquatable<DbEntity<TKey>?> where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        public TKey Id { get; set; }

        // More common properties e.g. timestamps, concurency tokens, etc.

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as DbEntity<TKey>);
        }

        /// <inheritdoc/>
        public bool Equals(DbEntity<TKey>? other)
        {
            return other is not null &&
                   EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        /// <inheritdoc/>
        public static bool operator ==(DbEntity<TKey>? left, DbEntity<TKey>? right)
        {
            return EqualityComparer<DbEntity<TKey>>.Default.Equals(left, right);
        }

        /// <inheritdoc/>
        public static bool operator !=(DbEntity<TKey>? left, DbEntity<TKey>? right)
        {
            return !(left == right);
        }
    }
}
