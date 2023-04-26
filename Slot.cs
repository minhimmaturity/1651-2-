namespace ASM
{

    public class Slot
    {
        public int Id { get; private set; }
        private static int count = 1;

        public String Type { get; private set; }
        public String? Plate { get; set; }

        public bool isAvailable { get; set; }

        public Slot(string type)
        {
            this.Id = count;
            this.Type = type;
            this.Plate = null;
            this.isAvailable = true;
            count++;
        }
    }
}

