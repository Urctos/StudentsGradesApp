namespace StudentsGradesApp
{
    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }

        Statistics GetStatistics();
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);
    }
}
