namespace minigame_library.Items
{
    public abstract class Item
    {
        private readonly Logger _logger = Logger.GetInstance();

        public Item(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
            _logger.Log(TraceEventType.Information, $"Item was created with ID: {id} Name: {name}");
        }

        /// <summary>
        /// Gets or sets the ID of the item. ID is NOT unique
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item
        /// </summary>
        public string? Description { get; set; }
    }
}
