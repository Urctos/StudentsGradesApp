using StudentsGradesApp;
using System.Runtime.CompilerServices;

Console.WriteLine("***********************************************************************");
Console.WriteLine("Program do wyliczania ocen studentów!");
Console.WriteLine("***********************************************************************");

Console.Write("Wprowadź imię studenta: ");
string studentFirstName = Console.ReadLine();

Console.Write("Wprowadź nazwisko studenta: ");
string studentLastName = Console.ReadLine();


var student = new StudentInMemory(studentFirstName, studentLastName);
//var student = new StudentInFile(studentFirstName, studentLastName);

student.GradeAdded += StudentGradeAdded;
bool running = true;


while (running)
{
    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine();
    Console.WriteLine("1. Wprowadź ocenę");
    Console.WriteLine("2. Pomoc");
    Console.WriteLine("3. Wyjście");

    string imput = Console.ReadLine();

    switch (imput)
    {
        case "1":
            Console.Clear();
            while (true)
            {
                Console.WriteLine("wprowadz ocenę: ");
                string gradeInput = Console.ReadLine();
                if (gradeInput == "q" || gradeInput == "Q")
                {
                    running = false;
                    break;
                }

                try
                {
                    student.AddGrade(gradeInput);
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Nieprawidłowa ocena!: {e.Message}");
                }
            }          
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("Menu Pomocy");
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("* Program pozwoli wyliczyć oceny Twoich studentów.");
            Console.WriteLine("* Możesz wprowadzić oceny w skali 2-5");
            Console.WriteLine("* Aby zakończyć dodawanie ocen wprowadz literę 'Q'");
            Console.WriteLine("* Program wyliczy średnią ocen studenta");
            Console.WriteLine("* Wskaże najniższe i najwyższe occeny");
            Console.WriteLine("* Sprawdzi czy student powinien zostać wyróżniony ");
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("Aby opóścić menu pomocy wciśnij dowolny klawisz!");
            Console.ReadLine();
            Console.Clear();
            break;
        case "3":
            running = false;
            break;

        default:
            Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2 lub 3.");
            break;
    }

    if (!running)
    {
        Console.Clear();
        var statistics = student.GetStatistics();
        Console.WriteLine("=======================================================================");
        Console.WriteLine($"Ocena studenta: {student.Name} {student.Surname} ");
        Console.WriteLine("=======================================================================");
        Console.WriteLine($"Wyróżnienie:     {statistics.AwardLetter}");
        Console.WriteLine($"Średnia z ocen:     {statistics.Average}");
        Console.WriteLine($"Ocena minimalna:  {statistics.Min}");
        Console.WriteLine($"Ocena maksymalna: {statistics.Max}");
        Console.WriteLine("=======================================================================");
    }
}
    void StudentGradeAdded(object sender, EventArgs args)
    {
        Console.WriteLine("Dodano nową ocenę! ");
    }
