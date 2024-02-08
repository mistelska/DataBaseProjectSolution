
using DataBaseProject.Services;
namespace DataBaseProject.MainMenu;
internal class MainMenuSubject
{
    private readonly SubjectService _subjectService;
    public MainMenuSubject(SubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    public void AddNewSubject()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Subject--");

            Console.Write("Subject: ");
            var subject = Console.ReadLine()!;

            var newSubject = _subjectService.CreateSubject(subject);
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
    public void ShowAllSubjects()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Subjects in our System");

            var subjects = _subjectService.GetAllSubjects();
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
    public void ShowOneSubjectById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Subject");
            Console.Write("Type in the Subject ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var subject = _subjectService.GetSubjectById(id);
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

    public void UpdateSubject()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Subject");
            Console.Write("Type Subject Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var subject = _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                Console.WriteLine($"{subject.SubjectName}");

                Console.Write("New Subject: ");
                subject.SubjectName = Console.ReadLine()!;

                var updatedSubject = _subjectService.UpdateSubject(subject);
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
    public void DeleteSubjectById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Subject");
            Console.Write("Subject ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var subject = _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                Console.WriteLine($"You are now deleting {subject.SubjectName}.");
                _subjectService.DeleteSubject(id);
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
