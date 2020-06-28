namespace UnitTestMDATP.DropBoxModel
{
    class SharingInfo
    {
        public bool ReadOnly { get; set; }
        public string ParentSharedFolderId { get; set; }
        public string ModifiedBy { get; set; }
        public bool? TraverseOnly { get; set; }
        public bool? NoAccess { get; set; }
    }
}
