namespace minigame_library.Items
{
    public class DefenceItem : Item
    {
        public DefenceItem(int id, string name, int protection, string? description = null) :
            base(id, name, description)
        {
            Protection = protection;
            IsActive = false;
        }

        /// <summary>
        /// Gets the amount of protection the item provides
        /// </summary>
        public int Protection { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the item will be used to protect the entity
        /// </summary>
        public bool IsActive { get; set; }
    }
}
