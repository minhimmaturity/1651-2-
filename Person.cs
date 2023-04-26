

namespace ASM
{
    // make var db and var collection become global variable
    public abstract class Person
    {
        public static List<Person> persons = new List<Person>();
        public int Id { get; private set; }
        private static int count = 1;

        public String Name { get; set; }

        public DateTime birthDate {get; set;}

        /**
         * 0: Manager
         * 1: SecurityGuard
        */

        // private Byte role;
        // public Byte Role
        // {
        //     get { return role; }
        //     set { role = value; }
        // }

        public String? Password { get; set; }

        public String? UserName { get; set; }

        /**
         * 0: Logout
         * 1: Login
        */
        public Boolean isLogin { get; set; }

        public Person(String Name, DateTime birthDate, String UserName, String Password)
        {
            this.Id = count;
            this.Name = Name;
            isLogin = false;
            // this.Role = Role;
            this.birthDate = birthDate;
            this.Password = Password;
            this.UserName = UserName;
            count++;
        }


        public static Boolean login(String username, String password)
        {
           foreach(Person p in persons) {
                if (p.UserName == username && p.Password == password) {
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