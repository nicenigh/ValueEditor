namespace System.Windows.Forms
{
    public class LinesChangedEventArgs : EventArgs
    {
        public LinesChangedType ChangedType { get; set; }
        public int StartLine { get; set; }
        public int ChangedCount { get; set; }
    }
    public enum LinesChangedType : ushort
    {
        Add, Remove
    }
}

