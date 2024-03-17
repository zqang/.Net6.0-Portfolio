namespace PortfolioAPI.BuildingBlocks
{
    public static class CollectionExtensions
    {
        public static void ReplaceAll<T>(this ICollection<T> collection, IEnumerable<T> newItems)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (newItems == null)
            {
                throw new ArgumentNullException(nameof(newItems));
            }

            collection.Clear();
            foreach (var item in newItems)
            {
                collection.Add(item);
            }
        }
    }
}
