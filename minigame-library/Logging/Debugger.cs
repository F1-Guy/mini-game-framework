namespace minigame_library.Logging
{
    internal class Debugger : TextWriterTraceListener
    {
        public Debugger(TextWriter writer) : base(writer)
        {
        }

        public override void Write(string? message)
        {
            base.Write($"[{DateTime.Now.ToString(Config.DatetimeFormat)}] {message}");
        }

        public override void WriteLine(string? message)
        {
            base.WriteLine(message);
        }
    }
}
