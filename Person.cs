namespace ASM
{
    public abstract class Person
    {
        public static List<Person> persons = new List<Person>();
        public int Id { get; private set; }
        private static int count = 1;

        public String Name { get; set; }

        private DateTime birthDay;
        public DateTime BirthDay
        {
            get { return birthDay; }
            set { 
                birthDay = value;
                this.age = calcuateAge(birthDay);
            }
        }

        public int age; //derived attribute

        public String? Password { get; set; }

        public String? UserName { get; set; }


        public Person(String Name, DateTime birthDay, String UserName, String Password)
        {
            this.Id = count;
            this.Name = Name;
            this.birthDay = birthDay;
            age = calcuateAge(birthDay);
            this.Password = Password;
            this.UserName = UserName;
            count++;
        }

        private int calcuateAge(DateTime birthDay)
        {
            int age = DateTime.Now.Year - birthDay.Year;
            if (age < 0) return -1;
            else if(age==0) return age;
            else
            {
                if (DateTime.Now.Month < birthDay.Month ||
                    (DateTime.Now.Month == birthDay.Month && DateTime.Now.Day < birthDay.Day))
                    age--;
                return age;
            }
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
            Slot newSlot = Program.currentParkingLot.RequestSlot(type, Plate);
            if (newSlot != null)
            {
                Ticket newTicket = new Ticket(newSlot);
                Ticket.tickets.Add(newTicket);
                for (int i = 0; i < Ticket.tickets.Count; i++)
                {
                    Console.WriteLine(Ticket.tickets[i].parkingSlot.Id + " " + Ticket.tickets[i].parkingSlot.Type + " " + Ticket.tickets[i].parkingSlot.Plate);
                }
                return newTicket;
            }
            Console.WriteLine("Out of slot");
            return null;
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
                                price = Program.price.ElementAt(0).Value +  (totalHours - 6) * Program.price.ElementAt(0).Value;
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
                                price = Program.price.ElementAt(1).Value +  (totalHours - 6) * Program.price.ElementAt(1).Value;
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
                                price = Program.price.ElementAt(2).Value +  (totalHours - 6) * Program.price.ElementAt(2).Value;
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
                Console.WriteLine("ID: {0, -5} | Plate: {1, -10} | startParkingTime: {2, -15} | type: {3, -5}", t.Id, t.parkingSlot.Plate, t.startParkingTime, t.parkingSlot.Type);
            }
        }

        public void FindAvailableSlot()
        {
            try
            {
                if (ParkingLotPool.slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    foreach (Slot slot in ParkingLotPool.slots)
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
            if (ParkingLotPool.slots != null)
            {
                foreach (Slot slot in ParkingLotPool.slots)
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
                if (Program.currentParkingLot == null || ParkingLotPool.slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    int count = 0;
                    foreach (Slot s in ParkingLotPool.slots)
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
                if (Program.currentParkingLot == null || ParkingLotPool.slots == null)
                {
                    throw new System.Exception("Parking lot is not created");
                }
                else
                {
                    foreach (Slot s in ParkingLotPool.slots)
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