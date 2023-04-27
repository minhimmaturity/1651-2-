

namespace ASM
{
    // make var db and var collection become global variable
    public abstract class Person
    {
        public static List<Person> persons = new List<Person>();
        public int Id { get; private set; }
        private static int count = 1;

        public String Name { get; set; }

        public DateTime birthDate { get; set; }

        public String? Password { get; set; }

        public String? UserName { get; set; }

        public Boolean isLogin { get; set; }

        public Person(String Name, DateTime birthDate, String UserName, String Password)
        {
            this.Id = count;
            this.Name = Name;
            isLogin = false;

            this.birthDate = birthDate;
            this.Password = Password;
            this.UserName = UserName;
            count++;
        }


        public static Boolean login(String username, String password)
        {
            if (Person.persons != null && Person.persons.Count > 0)
            {
                foreach (Person p in persons)
                {
                    if (p.UserName == username && p.Password == password)
                    {
                        Program.currentUser = p;
                        return true;
                    }
                }
            }

            return false;
        }

        public static Boolean Logout()
        {
            if (Program.currentUser != null)
            {
                Program.currentUser = null;
                return true;
            }
            return false;
        }

        public Ticket Park(String type, String Plate)
        {
            Slot newSlot = Program.currentParkingLot.ReleaseSlot(type, Plate);
            if (newSlot != null)
            {
                Ticket newTicket = new Ticket(newSlot);
                Ticket.tickets.Add(newTicket);
                for (int i = 0; i < Ticket.tickets.Count; i++)
                {
                    Console.WriteLine(Ticket.tickets[i].Id);
                }
                return newTicket;
            }
            Console.WriteLine("Out of slot");
            return null;
            // Ticket.tickets.Add(new Ticket(carPlate, new Slot(carPlate)));
        }

        public double UnPark(string Plate)
        {

            foreach (Ticket t in Ticket.tickets)
            {
                    if (t.parkingSlot.Plate == Plate)
                    {
                        Console.WriteLine("Parking time: " + t.startParkingTime);
                        Console.WriteLine("Unparking time: " + DateTime.UtcNow.ToLocalTime());

                        t.stopParkingTime = DateTime.UtcNow.ToLocalTime();
                        TimeSpan duration = (TimeSpan)(t.stopParkingTime - t.startParkingTime);

                        Console.WriteLine("Duration: " + duration);

                        double price = 0.0;
                        int totalHours = duration.Days * 24 + duration.Hours;

                        Console.WriteLine("Total hours: " + totalHours);

                        if (Program.price.ElementAt(0).Key == t.parkingSlot.Type)
                        {
                            if (totalHours < 6)
                            {
                                price = Program.price.ElementAt(0).Value;
                                Program.currentParkingLot.ReturnSlot(Plate);
                                return price;
                            }
                            else
                            {
                                price = totalHours * Program.price.ElementAt(0).Value;
                                Program.currentParkingLot.ReturnSlot(Plate);
                                return price;
                            }
                        }
                        else if (Program.price.ElementAt(1).Key == t.parkingSlot.Type)
                        {
                            if (totalHours < 6)
                            {
                                price = Program.price.ElementAt(1).Value;
                                Program.currentParkingLot.ReturnSlot(Plate);
                                return price;
                            }
                            else
                            {
                                price = totalHours * Program.price.ElementAt(1).Value;
                                Program.currentParkingLot.ReturnSlot(Plate);
                                return price;
                            }
                        }
                        else
                        {
                            if (totalHours < 6)
                            {
                                price = Program.price.ElementAt(2).Value;
                                Program.currentParkingLot.ReturnSlot(Plate);
                                return price;
                            }
                            else
                            {
                                price = totalHours * Program.price.ElementAt(2).Value;
                                Program.currentParkingLot.ReturnSlot(Plate);
                                return price;
                            }
                        }
                    }
            }
            return -1;

        }


        public void GetAllTicket()
        {
            foreach (Ticket t in Ticket.tickets)
            {
                Console.WriteLine("ID: {0, -5} | Plate: {1, -10} | startParkingTime: {2, -15}", t.Id, t.parkingSlot.Plate, t.startParkingTime);
            }
        }

    }
}