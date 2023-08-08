namespace StudentsGradesApp
{
    public abstract class StudentBase : IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;

        public StudentBase(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name  {get; private set;}
        public string Surname { get; private set; }


        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);

        public abstract void AddGrade(int grade);

        public abstract Statistics GetStatistics();

    }
}
