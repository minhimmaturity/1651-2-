namespace ASM
{
    public class Program
    {
        public static Person currentUser;
        public static ParkingLot currentParkingLot = new ParkingLot();
        public static readonly Dictionary<string, double> price = new Dictionary<string, double>
        {
            { "car", 5.99 },
            { "motorbike", 1.99 },
            { "electricCar", 7.5 }
        };
        public static void Main(string[] args)
        {
            Person.persons.Add(new Manager("khanh", new DateTime(2003, 12, 02), "khanh", "1234"));
            Person.persons.Add(new SecurityGuard("long", new DateTime(2003, 12, 02), "long", "1234"));
            Person.persons.Add(new SecurityGuard("tung", new DateTime(2003, 12, 02), "tung", "1234"));

            String? userName;
            String? passWord;
            int choice;
            String? Plate;

            Console.WriteLine(Program.price.ElementAt(2).Value);

        Start:
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


                    switch (choice)
                    {
                        case 1:

                        Start2:
                            Console.WriteLine("Please enter car plate: ");
                            Plate = Console.ReadLine();

                            if (Plate != null && currentParkingLot.CheckAvailableCarPlate(Plate) == true)
                            {
                                Console.WriteLine("Please choose vehicle type: ");
                                Console.WriteLine(" 1. " + price.ElementAt(0).Key);
                                Console.WriteLine(" 2. " + price.ElementAt(1).Key);
                                Console.WriteLine(" 3. " + price.ElementAt(2).Key);

                                choice = Convert.ToInt32(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        if (Plate != null)
                                        {
                                            ((Manager)currentUser).Park(price.ElementAt(0).Key, Plate);
                                        }
                                        break;
                                    case 2:
                                        if (Plate != null)
                                        {
                                            ((Manager)currentUser).Park(price.ElementAt(1).Key, Plate);

                                        }
                                        break;
                                    case 3:
                                        if (Plate != null)
                                        {
                                            ((Manager)currentUser).Park(price.ElementAt(2).Key, Plate);

                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid car plate!");
                                goto Start2;
                            }
                            break;

                        // case 2:
                        //     if (currentParkingLot.GetNumberOfAvailableSlot() == 0)
                        //     {
                        //         Console.WriteLine("No available parking slot!");
                        //     }
                        //     else
                        //     {
                        //         Console.WriteLine("Number of available parking slot are: " + currentParkingLot.GetNumberOfAvailableSlot());
                        //         currentParkingLot.FindAvailableSlot();
                        //     }
                        //     break;

                        case 3:
                            ((Manager)currentUser).GetAllTicket();
                            break;

                        case 4:
                        Start3:
                            Console.WriteLine("Please enter car plate: ");
                            Plate = Console.ReadLine();
                            if (currentParkingLot.CheckAvailableCarPlate(Plate) == true)
                            {
                                if (Plate != null)
                                {
                                    Console.WriteLine("Parking fee is: " + ((Manager)currentUser).UnPark(Plate) + "$");
                                }
                                Console.WriteLine("Thank you for using our service!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid car plate!");
                                goto Start3;
                            }
                            break;

                        case 5:
                            ((Manager)currentUser).GetSecurityGuards();
                            break;

                        case 6:
                            Console.WriteLine("Enter name: ");
                            String? name = Console.ReadLine();
                            Console.WriteLine("Enter birth date: ");
                            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter username: ");
                            userName = Console.ReadLine();
                            Console.WriteLine("Enter password: ");
                            passWord = Console.ReadLine();
                            if (name != null && userName != null && passWord != null)
                            {
                                SecurityGuard securityGuard = new SecurityGuard(name, birthDate, userName, passWord);
                                ((Manager)currentUser).AddSecurityGuard(securityGuard);
                            }
                            break;

                        case 7:
                            Console.WriteLine("Enter user that you want to delete: ");
                            int securityID = Convert.ToInt32(Console.ReadLine());
                            if (securityID != null)
                            {
                                if (((Manager)currentUser).RemoveSecurityGuard(securityID))
                                {
                                    Console.WriteLine("Remove success!");
                                }
                                else
                                {
                                    Console.WriteLine("Remove failed!");
                                }
                            }
                            break;

                        case 0:
                            if (Person.Logout())
                            {
                                Console.WriteLine("Logout success!");
                            }
                            else
                            {
                                Console.WriteLine("Logout failed!");
                            }

                            goto Start;
                        default:
                            break;
                    }

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


                    switch (choice)
                    {
                        case 1:

                        Start2:
                            Console.WriteLine("Please enter car plate: ");
                            Plate = Console.ReadLine();

                            if (Plate != null)
                            {
                                Console.WriteLine("Please choose vehicle type: ");
                                Console.WriteLine(" 1. " + price.ElementAt(0).Key);
                                Console.WriteLine(" 2. " + price.ElementAt(1).Key);
                                Console.WriteLine(" 3. " + price.ElementAt(2).Key);

                                choice = Convert.ToInt32(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        if (Plate != null)
                                        {
                                            ((SecurityGuard)currentUser).Park(price.ElementAt(0).Key, Plate);
                                        }
                                        break;
                                    case 2:
                                        if (Plate != null)
                                        {
                                            ((SecurityGuard)currentUser).Park(price.ElementAt(1).Key, Plate);

                                        }
                                        break;
                                    case 3:
                                        if (Plate != null)
                                        {
                                            ((SecurityGuard)currentUser).Park(price.ElementAt(2).Key, Plate);

                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid car plate!");
                                goto Start2;
                            }

                            break;

                        case 2:
                            if (currentParkingLot != null)
                            {
                                if (currentParkingLot.GetNumberOfAvailableSlot() == 0)
                                {
                                    Console.WriteLine("No available parking slot!");
                                }
                                else
                                {
                                    Console.WriteLine("Number of available parking slot are: " + currentParkingLot.GetNumberOfAvailableSlot());
                                    currentParkingLot.FindAvailableSlot();
                                }
                            }
                            break;

                        case 3:
                            ((SecurityGuard)currentUser).GetAllTicket();
                            break;

                        case 4:
                        Console.WriteLine(currentParkingLot.PrintNotAvailableSlot());
                        Start3:
                            Console.WriteLine("Please enter car plate: ");
                            Plate = Console.ReadLine();
                            if (currentParkingLot.CheckAvailableCarPlate(Plate) == true)
                            {
                                if (Plate != null)
                                {
                                    Console.WriteLine("Parking fee is: " + ((SecurityGuard)currentUser).UnPark(Plate) + "$");
                                }
                                Console.WriteLine("Thank you for using our service!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid car plate!");
                                goto Start3;
                            }
                            break;
                        case 0:
                            if (Person.Logout())
                            {
                                Console.WriteLine("Logout success!");
                            }
                            else
                            {
                                Console.WriteLine("Logout failed!");
                            }

                            goto Start;

                    }
                } while (choice != 0);

            }


        }
    }

}
