namespace minigame_library.Items
{
    public class DefenceItem : Item
    {
        public DefenceItem(int id, string name, int protection, string? description = null) :
            base(id, name, description)
        {
            Protection = protection;
        }

        public int Protection { get; set; }
    }
}
