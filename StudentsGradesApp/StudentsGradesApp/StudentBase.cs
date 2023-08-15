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

        public void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                throw new Exception("Nie da się wczyatć oceny! - napis nie jest liczbą ");
            }
        }

        public void AddGrade(int grade)
        {
            float result = (float)grade;
            this.AddGrade(result);
        }

        public abstract Statistics GetStatistics();

    }
}
