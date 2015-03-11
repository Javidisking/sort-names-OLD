namespace ContactHelper
{
    public class Contact
    {
        public Contact(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1}", FirstName, LastName);
        }
    }
}
