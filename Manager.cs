namespace ASM
{
    public class Manager : Person
    {
        public Manager(String Name, DateTime birthDate, String UserName, String Password) : base(Name, birthDate, UserName, Password)
        {
            
        }

        public SecurityGuard? AddSecurityGuard(SecurityGuard securityGuard)
        {
            foreach(Person p in persons) {
                if(p is SecurityGuard && p.UserName == securityGuard.UserName) {
                    return null;
                }
            }
            persons.Add(securityGuard);
            return securityGuard;
        }

        public bool RemoveSecurityGuard(int? id)
        {
            foreach(Person p in persons)
            {
                if(p.Id == id && p is SecurityGuard)
                {
                    persons.Remove(p);
                    return true;
                }
            }
            return false;
        }

        public void GetSecurityGuards()
        {
            foreach(Person p in persons)
            {
                if(p is SecurityGuard)
                {
                    System.Console.WriteLine("ID: {0, -5} | Name: {1, -5} | birthDate: {2, -10} | username: {3, -15} | age: {4, -10}", p.Id, p.Name, p.BirthDay , p.UserName, p.age);
                }
            }
        }
   
    }
}