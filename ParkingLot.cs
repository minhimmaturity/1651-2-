namespace ASM
{
    public class ParkingLot
    {
        private Slot[] slots = null;

        public ParkingLot()
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

        public Slot ReleaseSlot(string type, string plate)
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
                if (slot.Plate.Equals(plate) && slot != null)
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
                        if (slot != null && slot.Plate == null)
                        {
                            System.Console.WriteLine("Slot " + slot.Id + " " + slot.Type + " is available");
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
                    if (slot.Plate == Plate && slot != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int GetNumberOfAvailableSlot()
        {
            try
            {
                if (Program.currentParkingLot == null || slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    int count = 0;
                    foreach (Slot s in slots)
                    {
                        if (s != null && s.Plate == null)
                        {
                            count++;
                        }
                    }
                    return count;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Slot PrintNotAvailableSlot() {
            try
            {
                if (Program.currentParkingLot == null || slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    foreach (Slot s in slots)
                    {
                        if (s != null && s.Plate != null)
                        {
                            Console.WriteLine("Slot " + s.Id + " " + s.Type + " " + s.Plate + " is not available");
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return null;
        }
    }
}
