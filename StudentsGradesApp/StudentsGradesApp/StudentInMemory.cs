namespace StudentsGradesApp
{
    public class StudentInMemory : StudentBase
    {
        private List<float> grade = new List<float>();

        public StudentInMemory(string name, string surname)
            : base(name, surname)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(float grade)
        {
            if (grade >= 2 && grade <= 5)
            {
                this.grade.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Błędna wartość oceny!!!");
            }
        }

        public override void AddGrade(string grade)
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

        public override void AddGrade(int grade)
        {
            float result = (float)grade;
            this.AddGrade(result);
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grade)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
