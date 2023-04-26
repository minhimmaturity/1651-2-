namespace ASM
{
    public class ParkingLot
    {
        public Slot[] slots = null;

        public ParkingLot()
        {
            if (slots == null)
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

                for (int i = 21; i < 25; i++)
                {
                    slots[i] = new Slot("electricCar");
                }
            }
        }

        public Slot ReleaseSlot(string type, string plate)
        {
            if (slots != null)
            {
                foreach (Slot slot in slots)
                {
                    if (slot.Type == type && slot.Plate == null)
                    {
                        slot.Plate = plate;
                        return slot;
                    }
                }
            }
            return null;
        }

        public bool ReturnSlot(string plate)
        {
            foreach (Slot slot in slots)
            {
                if (slot.Plate == plate)
                {
                    slot.Plate = null;
                    return true;
                }
            }
            return false;
        }

        

        public void FindAvailableSlot()
        {
            try
            {
                if (slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    foreach (Slot slot in slots)
                    {
                        if (slot.Plate == null)
                        {
                            System.Console.WriteLine("Slot " + slot.Id + slot.Type + " is available");
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool? CheckAvailableCarPlate(String Plate)
        {
            if (slots != null)
            {
                foreach (Slot slot in slots)
                {
                    if (slot.Plate == Plate && slot.Plate != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
