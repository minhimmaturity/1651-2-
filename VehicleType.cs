namespace ASM
{
    public class VehicleType
    {
        private int Id { get; set; }
        private static int count = 1;
        public String Type { get; set; }
        public static double carPrice = 5;
        public static double motorPrice = 3;
        public static double electricCarPrice = 6;

        public VehicleType(String Type)
        {
            this.Id = count;
            this.Type = Type;
            count++;
        }

    }
}