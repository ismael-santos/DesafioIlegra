namespace Utils
{
    public static class DirectoryPath
    {
        public const string IN = @"C:\HOMEPATH\data\in\";
        public const string OUT = @"C:\HOMEPATH\data\out\";

        public const string IN_FILE = @"in.txt";
        public const string OUT_FILE = @"out.txt";

        public static string IN_AND_FILE => string.Format("{0}{1}", IN, IN_FILE);
        public static string OUT_AND_FILE => string.Format("{0}{1}", OUT, OUT_FILE);

        public static string IN_CUSTOM (string file) => string.Format("{0}{1}", IN, file);
    }
}
