using DataBaseProject.Services;

namespace DataBaseProject;

internal class StudyManagementProgram
{
    private readonly StudentService _studentService;

    public StudyManagementProgram(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void AddNewStudent()
    {
        Console.Clear();
        Console.WriteLine("--Add New Student--");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;
        Console.Write("Email: ");
        var email = Console.ReadLine()!;
        Console.Write("Phone Number: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Name of Course: ");
        var courseName = Console.ReadLine()!;
        Console.Write("Grade (F-A): ");
        var grade = Console.ReadLine()!;

        var newStudent = _studentService.CreateStudent(firstName,lastName,email,phoneNumber,courseName,grade);
        if(newStudent != null)
        {
            Console.Clear();
            Console.WriteLine("The student is now added to the list.");
            Console.ReadLine();
        }
    }

    public void ShowAllStudents()
    {
        Console.Clear();
        Console.WriteLine("All Students in our System");

        var students = _studentService.GetAllStudents();
        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, {student.Email} {student.PhoneNumber}");
        }
        Console.ReadLine();
    }

    public void ShowOneStudentByEmail()
    {
        Console.Clear();
        Console.WriteLine("Show One Student");
        Console.Write("Type in the students email: ");
        var email = Console.ReadLine();

    }

    public void UpdateStudent()
    {
        Console.Clear();
        Console.WriteLine("Update Students information");
        Console.Write("Type Student Id here: ");
        var id = int.Parse(Console.ReadLine()!);

        var student = _studentService.GetStudentByEmail(id);
        if(student != null)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, {student.Email} {student.PhoneNumber}");

            Console.Write("New First Name: ");
            student.FirstName = Console.ReadLine()!;
            Console.Write("New Last Name: ");
            student.LastName = Console.ReadLine()!;
            Console.Write("New Email: ");
            student.Email = Console.ReadLine()!;
            Console.Write("New Phone Number: ");
            student.PhoneNumber = Console.ReadLine();

            var updatedStudent = _studentService.UpdateStudent(student);
            Console.WriteLine("Student updated!");
        }
    }
}
