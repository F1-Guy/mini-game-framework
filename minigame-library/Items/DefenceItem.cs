namespace minigame_library.Items
{
    // It's spelled wrong because I cant spell. I might fix it later
    public class DefenceItem : Item
    {
        public DefenceItem(int id, string name, int protection, string? description = null) :
            base(id, name, description)
        {
            Protection = protection;
        }

        /// <summary>
        /// Gets the amount of protection the item provides
        /// </summary>
        public int Protection { get; }

        public override string ToString()
        {
            return $"Name: {Name}, Protection: {Protection}, Description {Description ?? string.Empty}";
        }
    }
}
