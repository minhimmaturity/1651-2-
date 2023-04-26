

namespace ASM
{
    public class SecurityGuard : Person
    {


        public SecurityGuard(String Name, DateTime BirthDate, String UserName, String Password) : base(Name, BirthDate, UserName, Password)
        {

        }

        public int GetNumberOfAvailableSlot()
        {
            try
            {
                if (Program.currentParkingLot == null || Program.currentParkingLot.slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    int count = 0;
                    foreach (Slot s in Program.currentParkingLot.slots)
                    {
                        if (s.Id != 0)
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
    }
}