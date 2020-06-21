namespace SimpleLabeling
{
    class Data
    {
        public string File { get; set; }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public Data(string file, int x1, int y1, int x2, int y2)
        {
            File = file;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Data()
        {
            File = "";
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
        }
    }
}
