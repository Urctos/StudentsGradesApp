namespace StudentsGradesApp
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "studentGrades.txt";

        public StudentInFile(string name, string surname)
            :base(name, surname)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(float grade)
        {
            if (grade >= 2 && grade <= 5)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("zła ocena!");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        statistics.AddGrade(number);
                        line = reader.ReadLine();

                    }
                }
            }
            return statistics;
        }
    }
}
