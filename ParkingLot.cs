using ASM;

namespace _1651_2_
{
    internal class ParkingLot
    {
        public static readonly Dictionary<string, double> price = new Dictionary<string, double>
        {
            { "car", 5.99 },
            { "motorbike", 1.99 },
            { "electricCar", 7.5 }
        };

        private Slot[] slots;

        public ParkingLot()
        {
            slots = new Slot[25];

            for (int i = 1; i <= 10; i++)
            {
                slots[i] = new Slot("car");
            }

            for (int i = 11; i <= 20; i++)
            {
                slots[i] = new Slot("motorbike");
            }

            for (int i = 21; i <= 25; i++)
            {
                slots[i] = new Slot("electricCar");
            }
        }

        public Slot? ReleaseSlot(string type, string plate)
        {
            foreach (var slot in slots)
            {
                if (slot.Type == type && slot.Plate == null)
                {
                    slot.Plate = plate;
                    return slot;
                }
            }

            return null;
        }

        public bool ReturnSlot(string plate)
        {
            foreach (var slot in slots)
            {
                if (slot.Plate == plate)
                {
                    slot.Plate = null;
                    return true;
                }
            }
            return false;
        }
    }
}
