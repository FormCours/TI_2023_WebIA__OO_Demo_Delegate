namespace Demo_Delegue.Models
{
    public class Person
    {
        #region Props
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Email { get; set; }
        public string Fullname { get { return Firstname + " " + Lastname; } }
        #endregion

        #region Ctor
        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Birthdate = null;
            Email = null;
        }
        public Person(string firstname, string lastname, string? email)
            : this(firstname, lastname)
        {
            Email = email;
        }
        public Person(string firstname, string lastname, DateTime? birthdate)
            : this(firstname, lastname)
        {
            Birthdate = birthdate;
        }
        public Person(string firstname, string lastname, DateTime? birthdate, string? email)
            : this(firstname, lastname, birthdate)
        {
            Email = email;
        }
        #endregion

        #region Methods
        public void SayHello()
        {
            Console.WriteLine($"{Fullname} dit bonjour !");
        }

        public void SayHello(Person person)
        {
            Console.WriteLine($"{Fullname} dit bonjour à {person.Fullname}.");
        }
        #endregion


    }
}
