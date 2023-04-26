namespace ASM {
    public class Ticket {
        
        public static List<Ticket> tickets = new List<Ticket>();
        public int Id { get; private set; }
        private static int count = 1;
        public Slot parkingSlot { get; set; }
        public DateTime startParkingTime { get; set; }
        public DateTime? stopParkingTime { get; set; }

        public Ticket(Slot slot) {
            this.Id = count;
            this.parkingSlot = slot;
            this.startParkingTime = DateTime.UtcNow.ToLocalTime();
            this.stopParkingTime = null;
            count++;
        }
    }
}