namespace minigame_library.Items
{
    public class DefenceItem : Item
    {
        public DefenceItem(int id, string name, int protection):
            base(id, name)
        {
            Protection = protection;
        }

        public int Protection { get; set; }
    }
}
