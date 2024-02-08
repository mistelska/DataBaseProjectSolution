using DataBaseProject.Services;
namespace DataBaseProject.MainMenu;
internal class MainMenuStudent
{
    private readonly StudentService _studentService;
    public MainMenuStudent(StudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task AddNewStudent()
    {
        try
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
            phoneNumber = phoneNumber ?? string.Empty;
            Console.Write("Name of Course: ");
            var courseName = Console.ReadLine()!;
            Console.Write("Grade (F-A): ");
            var grade = Console.ReadLine()!;

            var newStudent = await _studentService.CreateStudent(firstName, lastName, email, phoneNumber, courseName, grade);
            if (newStudent != null)
            {
                Console.Clear();
                Console.WriteLine("The student is now added to the list.");
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
    public async Task ShowAllStudents()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Students in our System");

            var students = await _studentService.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"\n{student.FirstName} {student.LastName}, {student.Email} {student.PhoneNumber}");
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
    public async Task ShowOneStudentById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Student");
            Console.Write("Type in the students ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var student = await _studentService.GetStudentById(id);
            if (student != null)
            {
                Console.Clear();
                Console.WriteLine($"Student with the ID: {id}.");
                Console.WriteLine($"{student.FirstName} {student.LastName}, {student.Email} {student.PhoneNumber}");
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
    public async Task UpdateStudent()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Students information");
            Console.Write("Type Student Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var student = await _studentService.GetStudentById(id);
            if (student != null)
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

                var updatedStudent = await _studentService.UpdateStudent(student);
                Console.Clear();
                Console.WriteLine("Student updated!");
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
    public async Task DeleteStudentById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Student");
            Console.Write("Students ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var student = await _studentService.GetStudentById(id);
            if (student != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {student.FirstName} {student.LastName}.");
                await _studentService.DeleteStudent(id);
                Console.WriteLine("Student Deleted!");
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
