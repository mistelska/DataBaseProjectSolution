using DataBaseProject.Services;

namespace DataBaseProject.MainMenu;
internal class MainMenuTeacher
{
    private readonly TeacherService _teacherService;

    public MainMenuTeacher(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    public void AddNewTeacher()
    {
        Console.Clear();
        Console.WriteLine("--Add New Teacher--");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;
        Console.Write("Subject: ");
        var subject = Console.ReadLine()!;

        var newTeacher = _teacherService.CreateTeacher(firstName,lastName,subject);
        if (newTeacher != null)
        {
            Console.Clear();
            Console.WriteLine("The Teacher is now added to the list.");
            Console.ReadLine();
        }
    }
    public void ShowAllTeachers()
    {
        Console.Clear();
        Console.WriteLine("All Teachers in our System");

        var teachers = _teacherService.GetAllTeachers();
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"\n{teacher.FirstName} {teacher.LastName}");
        }
        Console.ReadLine();
    }
    public void ShowOneTeacherById()
    {
        Console.Clear();
        Console.WriteLine("Show One Teacher");
        Console.Write("Type in the Teacher ID-number: ");
        var id = int.Parse(Console.ReadLine()!);

        var teacher = _teacherService.GetTeacherById(id);
        if (teacher != null)
        {
            Console.WriteLine($"Teacher with the ID: {id}");
            Console.WriteLine($"\n{teacher.FirstName} {teacher.LastName}");
            Console.ReadKey();
        }
    }

    public void UpdateTeacher()
    {
        Console.Clear();
        Console.WriteLine("Update Teacher");
        Console.Write("Type Teacher Id here: ");
        var id = int.Parse(Console.ReadLine()!);

        var teacher = _teacherService.GetTeacherById(id);
        if (teacher != null)
        {
            Console.WriteLine($"{teacher.FirstName} {teacher.LastName}");

            Console.Write("New First Name: ");
            teacher.FirstName = Console.ReadLine()!;
            Console.Write("New Last Name: ");
            teacher.LastName = Console.ReadLine()!;

            var updatedTeacher = _teacherService.UpdateTeacher(teacher);
            Console.Clear();
            Console.WriteLine("Teacher updated!");
            Console.ReadKey();
        }
    }
    public void DeleteTeacherById()
    {
        Console.Clear();
        Console.WriteLine("Delete a Teacher");
        Console.Write("Teacher ID-number: ");
        var id = int.Parse(Console.ReadLine()!);

        var teacher = _teacherService.GetTeacherById(id);
        if (teacher != null)
        {
            Console.WriteLine($"You are now deleting {teacher.FirstName} {teacher.LastName}.");
            _teacherService.DeleteTeacher(id);
            Console.WriteLine("Teacher Deleted!");
            Console.ReadKey();
        }
    }
}
