namespace ASM
{
    public class ParkingLotPool
    {
        public static Slot[] slots = null;

        public ParkingLotPool()
        {
            if (slots == null)
            {
                slots = new Slot[25];

                for (int i = 0; i < 10; i++)
                {
                    slots[i] = new Slot("car");
                }

                for (int i = 10; i < 20; i++)
                {
                    slots[i] = new Slot("motorbike");
                }

                for (int i = 20; i < 25; i++)
                {
                    slots[i] = new Slot("electricCar");
                }
            }
        }

        public Slot RequestSlot(string type, string plate)
        {
            if (slots != null)
            {
                foreach (Slot slot in slots)
                {
                    if (slot != null && slot.Type == type && slot.Plate == null)
                    {
                        slot.Plate = plate;
                        return slot;
                    }
                }
            }
            return null;
        }

        public bool ReturnSlot(String plate)
        {
            foreach (Slot slot in slots)
            {
                if (slot.Plate.Equals(plate))
                {
                    slot.Plate = null;
                    return true;
                }
            }
            return false;
        }
    }
}
