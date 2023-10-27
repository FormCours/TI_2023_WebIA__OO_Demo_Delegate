using Demo_Delegue.Delegates;
using Demo_Delegue.Models;

List<Person> people = new List<Person>
{
    new Person("Della", "Duck", "d.duck@example.be"),
    new Person("Zaza", "Vanderquack", new DateTime(2013, 1, 6)),
    new Person("Balthazar", "Picsou", new DateTime(1967, 5, 6), "b.picsou@money.org"),
    new Person("Gontran", "Bonheur", new DateTime(1988, 5, 9)),
    new Person("Archibald", "Gripsou", new DateTime(1966, 11, 3), "a.gripsou@money.org"),
    new Person("Riri", "Duck", new DateTime(2012, 6, 9)),
    new Person("Fifi", "Duck", new DateTime(2012, 6, 9)),
    new Person("Hortence", "Picsou"),
    new Person("Daisy", "Duck", "daisy.duck@tf.be"),
    new Person("Donald", "Duck", "donald.duck@tf.be")
};

void PrintPersonList(List<Person> people, string message)
{
    Console.WriteLine(message + " : ");
    foreach (Person person in people)
    {
        Console.WriteLine($" - {person.Fullname}");
    }
    Console.WriteLine();
}

List<Person> GetAllDuck(List<Person> people)
{
    List<Person> result = new List<Person>();

    foreach (Person person in people)
    {
        if (person.Lastname.Equals("duck", StringComparison.OrdinalIgnoreCase))
        {
            result.Add(person);
        }
    }

    return result;
}

List<Person> GetPersonWithLetterO(List<Person> people)
{
    List<Person> result = new List<Person>();

    foreach (Person person in people)
    {
        if(person.Firstname.Contains("o", StringComparison.OrdinalIgnoreCase))
        {
            result.Add(person);
        }
    }

    return result;
}

List<Person> GetPersonWithShortFirstname(List<Person> people)
{
    List<Person> result = new List<Person>();

    foreach (Person person in people)
    {
        if(person.Firstname.Length <= 5)
        {
            result.Add(person);
        }
    }

    return result;
}

List<Person> GetPersonWithDelegate(List<Person> people, ConditionnalDelegate filter)
{
    List<Person> result = new List<Person>();

    foreach (Person person in people)
    {
        if (filter(person))
        {
            result.Add(person);
        }
    }

    return result;
}



PrintPersonList(people, "Toutes les données");

List<Person> r1 = GetAllDuck(people);
PrintPersonList(r1, "Liste des ducks");

List<Person> r2 = GetPersonWithLetterO(people);
PrintPersonList(r2, "Liste des personnages avec un \"o\" dans leur prénom");

List<Person> r3 = GetPersonWithShortFirstname(people);
PrintPersonList(r3, "Liste des personnages avec un prénom avec moins de 5 lettres");



bool FilterLongLastname(Person person)
{
    return person.Lastname.Length > 6;
}
List<Person> r4 = GetPersonWithDelegate(people, FilterLongLastname);
PrintPersonList(r4, "Liste des personnages avec un nom avec plus de 6 lettres");

List<Person> r5 = GetPersonWithDelegate(people, delegate (Person p)
{
    return p.Firstname.Contains("a", StringComparison.OrdinalIgnoreCase);
});
PrintPersonList(r5, "Liste des personnages avec un \"a\" dans leur prénom");

List<Person> r6 = GetPersonWithDelegate(people, p => { return p.Lastname == "Picsou"; }); // Fonction Fleché
PrintPersonList(r6, "Liste des Picsou");

List<Person> r7 = GetPersonWithDelegate(people, p => p.Firstname.Length == 4);  // Expression Lambda
PrintPersonList(r7, "Liste des personnages avec un nom de 4 lettres");
