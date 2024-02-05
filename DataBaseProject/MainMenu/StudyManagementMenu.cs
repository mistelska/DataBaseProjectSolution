﻿namespace DataBaseProject.MainMenu;
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
    public void MainMenu()
    {
        bool goingMainMenu = true;
        while(goingMainMenu)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Study Management Application");
            Console.WriteLine("[1] Create New..");
            Console.WriteLine("[2] Show all..");
            Console.WriteLine("[3] Show one..");
            Console.WriteLine("[4] Update..");
            Console.WriteLine("[5] Delete..");
            Console.WriteLine("[6] Quit");

            var option = int.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    bool goingCreateMenu = true;
                    while(goingCreateMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Create a new..");
                        Console.WriteLine("[1] Student");
                        Console.WriteLine("[2] Course");
                        Console.WriteLine("[3] Grade");
                        Console.WriteLine("[4] Teacher");
                        Console.WriteLine("[5] Subject");
                        Console.WriteLine("[6] Back to Main Menu");
                        var optionCreate = int.Parse(Console.ReadLine()!);

                        switch (optionCreate)
                        {
                            case 1:
                                _mainMenuStudent.AddNewStudent();
                                break;
                            case 2:
                                _mainMenuCourse.AddNewCourse();
                                break;
                            case 3:
                                _mainMenuGrade.AddNewGrade();
                                break;
                            case 4:
                                _mainMenuTeacher.AddNewTeacher();
                                break;
                            case 5:
                                _mainMenuSubject.AddNewSubject();
                                break;
                            case 6:
                                goingCreateMenu = false;
                                break;
                            default:
                                Console.WriteLine("Choose between 1-6, please.");
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
                        Console.WriteLine("[1] Students");
                        Console.WriteLine("[2] Courses");
                        Console.WriteLine("[3] Grades");
                        Console.WriteLine("[4] Teachers");
                        Console.WriteLine("[5] Subjects");
                        Console.WriteLine("[6] Back to Main Menu");
                        var optionShowAll = int.Parse(Console.ReadLine()!);

                        switch (optionShowAll)
                        {
                            case 1:
                                _mainMenuStudent.ShowAllStudents();
                                break;
                            case 2:
                                _mainMenuCourse.ShowAllCourses();
                                break;
                            case 3:
                                _mainMenuGrade.ShowAllGrades();
                                break;
                            case 4:
                                _mainMenuTeacher.ShowAllTeachers();
                                break;
                            case 5:
                                _mainMenuSubject.ShowAllSubjects();
                                break;
                            case 6:
                                goingShowAllMenu = false;
                                break;
                            default:
                                Console.WriteLine("Choose between 1-6, please.");
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
                        Console.WriteLine("[1] Students");
                        Console.WriteLine("[2] Courses");
                        Console.WriteLine("[3] Grades");
                        Console.WriteLine("[4] Teachers");
                        Console.WriteLine("[5] Subjects");
                        Console.WriteLine("[6] Back to Main Menu");
                        var optionShowOne = int.Parse(Console.ReadLine()!);

                        switch (optionShowOne)
                        {
                            case 1:
                                _mainMenuStudent.ShowOneStudentById();
                                break;
                            case 2:
                                _mainMenuCourse.ShowOneCourseById();
                                break;
                            case 3:
                                _mainMenuGrade.ShowOneGradeById();
                                break;
                            case 4:
                                _mainMenuTeacher.ShowOneTeacherById();
                                break;
                            case 5:
                                _mainMenuSubject.ShowOneSubjectById();
                                break;
                            case 6:
                                goingShowOneMenu = false;
                                break;
                            default:
                                Console.WriteLine("Choose between 1-6, please.");
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
                        Console.WriteLine("[1] Student");
                        Console.WriteLine("[2] Course");
                        Console.WriteLine("[3] Grade");
                        Console.WriteLine("[4] Teacher");
                        Console.WriteLine("[5] Subject");
                        Console.WriteLine("[6] Back to Main Menu");
                        var optionUpdate = int.Parse(Console.ReadLine()!);

                        switch (optionUpdate)
                        {
                            case 1:
                                _mainMenuStudent.UpdateStudent();
                                break;
                            case 2:
                                _mainMenuCourse.UpdateCourse();
                                break;
                            case 3:
                                _mainMenuGrade.UpdateGrade();
                                break;
                            case 4:
                                _mainMenuTeacher.UpdateTeacher();
                                break;
                            case 5:
                                _mainMenuSubject.UpdateSubject();
                                break;
                            case 6:
                                goingUpdateMenu = false;
                                break;
                            default:
                                Console.WriteLine("Choose between 1-6, please.");
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
                        Console.WriteLine("[1] Student");
                        Console.WriteLine("[2] Course");
                        Console.WriteLine("[3] Grade");
                        Console.WriteLine("[4] Teacher");
                        Console.WriteLine("[5] Subject");
                        Console.WriteLine("[6] Back to Main Menu");
                        var optionDelete = int.Parse(Console.ReadLine()!);

                        switch (optionDelete)
                        {
                            case 1:
                                _mainMenuStudent.DeleteStudentById();
                                break;
                            case 2:
                                _mainMenuCourse.DeleteCourseById();
                                break;
                            case 3:
                                _mainMenuGrade.DeleteGradeById();
                                break;
                            case 4:
                                _mainMenuTeacher.DeleteTeacherById();
                                break;
                            case 5:
                                _mainMenuSubject.DeleteSubjectById();
                                break;
                            case 6:
                                goingDeleteMenu = false;
                                break;
                            default:
                                Console.WriteLine("Choose between 1-6, please.");
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
                    Console.WriteLine("Choose between 1-6, please.");
                    break;
            }
        }
    }
}