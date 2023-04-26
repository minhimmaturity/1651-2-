namespace ASM
{

    public class Slot
    {
        // public static final Dictionary<string, int> myHashMap = new Dictionary<string, int>();
        public static readonly Dictionary<string, double> myHashMap = new Dictionary<string, double>
        {
            { "car", 5.0 },
            { "motorbike", 3.0 },
            { "electricCar", 2.0 }
        };
        public int Id { get; private set; }
        private static int count = 1;
        public VehicleType Type { get; private set; }

        public String? Plate { get; private set; }

        public static Slot[] instances = null;

        private Slot(VehicleType type)
        {
            instances = new Slot[25];

                for (int i = 1; i <= 10; i++)
                {
                    instances[i] = new Slot(
                }

            this.Id = count;
            this.Type = type;
            this.Plate = null;
            count++;
        }

        public static Slot getInstance(VehicleType type)
        {
            if (instance == null)
            {
                instance = new Slot[25];
                for (int i = 0; i < instance.Length; i++)
                {
                    instance[i] = new Slot(type);
                }
            }
            return null;
        }


    }
}

