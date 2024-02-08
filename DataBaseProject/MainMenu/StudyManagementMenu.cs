namespace DataBaseProject.MainMenu;
internal class StudyManagementMenu
{
    private readonly MainMenuStudent _mainMenuStudent;
    private readonly MainMenuCourse _mainMenuCourse;
    private readonly MainMenuGrade _mainMenuGrade;
    private readonly MainMenuSubject _mainMenuSubject;
    private readonly MainMenuTeacher _mainMenuTeacher;
    public StudyManagementMenu(MainMenuStudent mainMenuStudent, MainMenuCourse mainMenuCourse, MainMenuGrade mainMenuGrade, MainMenuSubject mainMenuSubject, MainMenuTeacher mainMenuTeacher)
    {
        _mainMenuStudent = mainMenuStudent;
        _mainMenuCourse = mainMenuCourse;
        _mainMenuGrade = mainMenuGrade;
        _mainMenuSubject = mainMenuSubject;
        _mainMenuTeacher = mainMenuTeacher;
    }
    public async Task MainMenu()
    {
        bool goingMainMenu = true;
        while(goingMainMenu)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Study Management Application");
            Console.WriteLine("\n[1] Create New..");
            Console.WriteLine("[2] Show all..");
            Console.WriteLine("[3] Show one..");
            Console.WriteLine("[4] Update..");
            Console.WriteLine("[5] Delete..");
            Console.WriteLine("[6] Quit");
            int.TryParse(Console.ReadLine(), out var option);
            switch (option)
            {
                case 1:
                    bool goingCreateMenu = true;
                    while(goingCreateMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Create a new..");
                        Console.WriteLine("\n[1] Student");
                        Console.WriteLine("[2] Course");
                        Console.WriteLine("[3] Grade");
                        Console.WriteLine("[4] Teacher");
                        Console.WriteLine("[5] Subject");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionCreate);
                        switch (optionCreate)
                        {
                            case 1:
                                await _mainMenuStudent.AddNewStudent();
                                break;
                            case 2:
                                await _mainMenuCourse.AddNewCourse();
                                break;
                            case 3:
                                await _mainMenuGrade.AddNewGrade();
                                break;
                            case 4:
                                await _mainMenuTeacher.AddNewTeacher();
                                break;
                            case 5:
                                await _mainMenuSubject.AddNewSubject();
                                break;
                            case 6:
                                goingCreateMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 2:
                    bool goingShowAllMenu = true;
                    while (goingShowAllMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Show All..");
                        Console.WriteLine("\n[1] Students");
                        Console.WriteLine("[2] Courses");
                        Console.WriteLine("[3] Grades");
                        Console.WriteLine("[4] Teachers");
                        Console.WriteLine("[5] Subjects");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionShowAll);

                        switch (optionShowAll)
                        {
                            case 1:
                                await _mainMenuStudent.ShowAllStudents();
                                break;
                            case 2:
                                await _mainMenuCourse.ShowAllCourses();
                                break;
                            case 3:
                                await _mainMenuGrade.ShowAllGrades();
                                break;
                            case 4:
                                await _mainMenuTeacher.ShowAllTeachers();
                                break;
                            case 5:
                                await _mainMenuSubject.ShowAllSubjects();
                                break;
                            case 6:
                                goingShowAllMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 3:
                    bool goingShowOneMenu = true;
                    while (goingShowOneMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Show one of..");
                        Console.WriteLine("\n[1] Students");
                        Console.WriteLine("[2] Courses");
                        Console.WriteLine("[3] Grades");
                        Console.WriteLine("[4] Teachers");
                        Console.WriteLine("[5] Subjects");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionShowOne);

                        switch (optionShowOne)
                        {
                            case 1:
                                await _mainMenuStudent.ShowOneStudentById();
                                break;
                            case 2:
                                await _mainMenuCourse.ShowOneCourseById();
                                break;
                            case 3:
                                await _mainMenuGrade.ShowOneGradeById();
                                break;
                            case 4:
                                await _mainMenuTeacher.ShowOneTeacherById();
                                break;
                            case 5:
                                await _mainMenuSubject.ShowOneSubjectById();
                                break;
                            case 6:
                                goingShowOneMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 4:
                    bool goingUpdateMenu = true;
                    while (goingUpdateMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Update..");
                        Console.WriteLine("\n[1] Student");
                        Console.WriteLine("[2] Course");
                        Console.WriteLine("[3] Grade");
                        Console.WriteLine("[4] Teacher");
                        Console.WriteLine("[5] Subject");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionUpdate);

                        switch (optionUpdate)
                        {
                            case 1:
                                await _mainMenuStudent.UpdateStudent();
                                break;
                            case 2:
                                await _mainMenuCourse.UpdateCourse();
                                break;
                            case 3:
                                await _mainMenuGrade.UpdateGrade();
                                break;
                            case 4:
                                await _mainMenuTeacher.UpdateTeacher();
                                break;
                            case 5:
                                await _mainMenuSubject.UpdateSubject();
                                break;
                            case 6:
                                goingUpdateMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 5:
                    bool goingDeleteMenu = true;
                    while (goingDeleteMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Delete..");
                        Console.WriteLine("\n[1] Student");
                        Console.WriteLine("[2] Course");
                        Console.WriteLine("[3] Grade");
                        Console.WriteLine("[4] Teacher");
                        Console.WriteLine("[5] Subject");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionDelete);

                        switch (optionDelete)
                        {
                            case 1:
                                await _mainMenuStudent.DeleteStudentById();
                                break;
                            case 2:
                                await _mainMenuCourse.DeleteCourseById();
                                break;
                            case 3:
                                await _mainMenuGrade.DeleteGradeById();
                                break;
                            case 4:
                                await _mainMenuTeacher.DeleteTeacherById();
                                break;
                            case 5:
                                await _mainMenuSubject.DeleteSubjectById();
                                break;
                            case 6:
                                goingDeleteMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("You are now exiting this program.");
                    goingMainMenu = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input! Choose between 1-6, please.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
