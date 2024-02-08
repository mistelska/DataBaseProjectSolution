using DataBaseProject.Services;

namespace DataBaseProject.MainMenu;
internal class MainMenuGrade
{
    private readonly GradeService _gradeService;

    public MainMenuGrade(GradeService gradeService)
    {
        _gradeService = gradeService;
    }

    public async Task AddNewGrade()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Grade--");

            Console.Write("Grade: ");
            var grade = Console.ReadLine()!;

            var newGrade = await _gradeService.CreateGrade(grade);
            if (newGrade != null)
            {
                Console.Clear();
                Console.WriteLine("The Grade is now added to the list.");
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task ShowAllGrades()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Grades in our System");

            var grades = await _gradeService.GetAllGrades();
            foreach (var grade in grades)
            {
                Console.WriteLine($"\n{grade.Grade}");
            }
            Console.ReadLine();
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task ShowOneGradeById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Grade");
            Console.Write("Type in the Grade ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var grade = await _gradeService.GetGradeById(id);
            if (grade != null)
            {
                Console.Clear();
                Console.WriteLine($"Grade with the ID: {id}");
                Console.WriteLine($"\n{grade.Grade}");
                Console.ReadKey();
            }
        }
        catch( Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }

    public async Task UpdateGrade()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Grade");
            Console.Write("Type Grade Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var grade = await _gradeService.GetGradeById(id);
            if (grade != null)
            {
                Console.WriteLine($"{grade.Grade}");

                Console.Write("New Grade: ");
                grade.Grade = Console.ReadLine()!;

                var updatedGrade = await _gradeService.UpdateGrade(grade);
                Console.Clear();
                Console.WriteLine("Grade updated!");
                Console.ReadKey();
            }
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task DeleteGradeById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Grade");
            Console.Write("Grade ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var grade = await _gradeService.GetGradeById(id);
            if (grade != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {grade.Grade}.");
                await _gradeService.DeleteGrade(id);
                Console.WriteLine("Grade Deleted!");
                Console.ReadKey();
            }
        }
        catch( Exception ex )
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
