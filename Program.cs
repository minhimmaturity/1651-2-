namespace ASM
{
    public class Program
    {
        public static Person currentUser;
        public static void Main(string[] args)
        {
            Person.persons.Add(new Manager("khanh", new DateTime(2003, 12, 02), "khanh", "1234"));
            Person.persons.Add(new SecurityGuard("long", new DateTime(2003, 12, 02), "long", "1234"));
            Person.persons.Add(new SecurityGuard("tung", new DateTime(2003, 12, 02), "tung", "1234"));

            VehicleType carType = new VehicleType("CarType");
            VehicleType motorType = new VehicleType("MotorType");
            VehicleType electricCarType = new VehicleType("ElectricCarType");

            Slot slot1 = Slot.getInstance(carType);
            Slot slot2 = Slot.getInstance(motorType);
            Slot slot3 = Slot.getInstance(electricCarType);

            for(int i = 0; i < Slot.instance.Length; i++) {
                Console.WriteLine(Slot.instance[i].Type.Type);
            }

            String userName;
            String passWord;
            int choice;

            do
            {
                Console.WriteLine("Enter username: ");
                userName = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                passWord = Console.ReadLine();
            } while (!Person.login(userName, passWord));

            if (currentUser is Manager) // Manager
            {
                do
                {
                    Console.WriteLine(" 1. CREATE NEW TICKET");
                    Console.WriteLine(" 2. VIEW AVAILABLE PARKING SLOT");
                    Console.WriteLine(" 3. VIEW ALL TICKET");
                    Console.WriteLine(" 4. CALCULATE PARKING FEE");
                    Console.WriteLine(" 5. VIEW ALL SECURITY GUARD");
                    Console.WriteLine(" 6. ADD NEW SECURITY GUARD");
                    Console.WriteLine(" 7. DELETE SECURITY GUARD");
                    Console.WriteLine(" 0. LOGOUT");

                    Console.WriteLine("Please enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice != 0);

            }
            else // Guard
            {
                do
                {
                    Console.WriteLine(" 1. CREATE NEW TICKET");
                    Console.WriteLine(" 2. VIEW AVAILABLE PARKING SLOT");
                    Console.WriteLine(" 3. VIEW ALL TICKET");
                    Console.WriteLine(" 4. CALCULATE PARKING FEE");
                    Console.WriteLine(" 0. LOGOUT");

                    Console.WriteLine("Please enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice != 0);

            }

        }
    }

}
