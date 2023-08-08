namespace StudentsGradesApp
{
    public abstract class Person
    {
        public Person()
            : this("no name")
        {
            
        }

        public Person(string name)
            : this (name, " no surname")
        {
            this.Name = name;       
        }

        public Person(string name, string surname)
            : this (name, surname, 'X')
        {
            this.Name = name;
            this.Surname = surname;
            
        }

        public Person(string name, string surname, char sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;

        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public char Sex { get; private set;}
    }
}
