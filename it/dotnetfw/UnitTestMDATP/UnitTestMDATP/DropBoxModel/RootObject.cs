using System.Collections.Generic;

namespace UnitTestMDATP.DropBoxModel
{
    internal class RootObject
    {
        public List<Entry> Entry { get; set; }
        public string Cursor { get; set; }
        public bool HasMore { get; set; }
    }
}