
using DataBaseProject.Services;
namespace DataBaseProject.MainMenu;
internal class MainMenuSubject
{
    private readonly SubjectService _subjectService;
    public MainMenuSubject(SubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    public async Task AddNewSubject()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Subject--");

            Console.Write("Subject: ");
            var subject = Console.ReadLine()!;

            var newSubject = await _subjectService.CreateSubject(subject);
            if (newSubject != null)
            {
                Console.Clear();
                Console.WriteLine("The Subject is now added to the list.");
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
    public async Task ShowAllSubjects()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Subjects in our System");

            var subjects = await _subjectService.GetAllSubjects();
            foreach (var subject in subjects)
            {
                Console.WriteLine($"\n{subject.SubjectName}");
            }
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task ShowOneSubjectById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Subject");
            Console.Write("Type in the Subject ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var subject = await _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                Console.WriteLine($"Subject with the ID: {id}");
                Console.WriteLine($"\n{subject.SubjectName}");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }

    public async Task UpdateSubject()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Subject");
            Console.Write("Type Subject Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var subject = await _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                Console.WriteLine($"{subject.SubjectName}");

                Console.Write("New Subject: ");
                subject.SubjectName = Console.ReadLine()!;

                var updatedSubject = await _subjectService.UpdateSubject(subject);
                Console.Clear();
                Console.WriteLine("Subject updated!");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task DeleteSubjectById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Subject");
            Console.Write("Subject ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var subject = await _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                Console.WriteLine($"You are now deleting {subject.SubjectName}.");
                await _subjectService.DeleteSubject(id);
                Console.WriteLine("Subject Deleted!");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
