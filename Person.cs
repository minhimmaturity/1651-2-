

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
            foreach (Person p in persons)
            {
                if (p.UserName == username && p.Password == password)
                {
                    Program.currentUser = p;
                    return true;
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

        public Ticket Park(String type ,String Plate)
        {
            Slot newSlot = Program.currentParkingLot.ReleaseSlot(type, Plate);
            if(newSlot != null) {
                Ticket newTicket = new Ticket(newSlot);
                Ticket.tickets.Add(newTicket);
                return newTicket;
            } 
            Console.WriteLine("Out of slot");
            return null;
            // Ticket.tickets.Add(new Ticket(carPlate, new Slot(carPlate)));
        }

        public double? UnPark(String Plate)
        {
            bool flag = Program.currentParkingLot.ReturnSlot(Plate);
            if(flag) {
                foreach(Ticket t in Ticket.tickets) {
                    if(t.parkingSlot.Plate == Plate) {
                        t.stopParkingTime = DateTime.UtcNow.ToLocalTime();
                        TimeSpan duration = (TimeSpan)(t.stopParkingTime - t.startParkingTime);
                        double price = Program.price[t.parkingSlot.Type];
                        int totalHours = duration.Days * 24 + duration.Hours;
                        if(totalHours <6) {
                            return price;
                        } 
                        return totalHours * price;
                    } 
                }
            }
            return null;
        }

        public void GetAllTicket() {
            foreach(Ticket t in Ticket.tickets) {
                if(t.parkingSlot.Plate == this.Name) {
                    Console.WriteLine(t.Id + " " + t.parkingSlot.Plate + " " + t.startParkingTime + " " + t.stopParkingTime);
                }
            }
        }

    }
}