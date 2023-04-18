namespace minigame_library.Logging
{
    internal class Debugger : TextWriterTraceListener
    {
        private readonly string _datetimeForamt = "dd/MM/yy HH:mm:ss:fff";

        public Debugger(TextWriter writer) : base(writer)
        {
        }

        public override void Write(string? message)
        {
            base.Write($"[{DateTime.Now.ToString(_datetimeForamt)}] {message}");
        }

        public override void WriteLine(string? message)
        {
            base.WriteLine(message);
        }
    }
}
