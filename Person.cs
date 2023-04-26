

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

        // public static Boolean logout(String username)
        // {

        // }

    }
}