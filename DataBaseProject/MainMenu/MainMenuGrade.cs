﻿using DataBaseProject.Services;

namespace DataBaseProject.MainMenu;
internal class MainMenuGrade
{
    private readonly GradeService _gradeService;

    public MainMenuGrade(GradeService gradeService)
    {
        _gradeService = gradeService;
    }

    public void AddNewGrade()
    {
        Console.Clear();
        Console.WriteLine("--Add New Grade--");

        Console.Write("Grade: ");
        var grade = Console.ReadLine()!;

        var newGrade = _gradeService.CreateGrade(grade);
        if (newGrade != null)
        {
            Console.Clear();
            Console.WriteLine("The Grade is now added to the list.");
            Console.ReadLine();
        }
    }
    public void ShowAllGrades()
    {
        Console.Clear();
        Console.WriteLine("All Grades in our System");

        var grades = _gradeService.GetAllGrades();
        foreach (var grade in grades)
        {
            Console.WriteLine($"\n{grade.Grade}");
        }
        Console.ReadLine();
    }
    public void ShowOneGradeById()
    {
        Console.Clear();
        Console.WriteLine("Show One Grade");
        Console.Write("Type in the Grade ID-number: ");
        var id = int.Parse(Console.ReadLine()!);

        var grade = _gradeService.GetGradeById(id);
        if (grade != null)
        {
            Console.WriteLine($"Grade with the ID: {id}");
            Console.WriteLine($"\n{grade.Grade}");
            Console.ReadKey();
        }
    }

    public void UpdateGrade()
    {
        Console.Clear();
        Console.WriteLine("Update Grade");
        Console.Write("Type Grade Id here: ");
        var id = int.Parse(Console.ReadLine()!);

        var grade = _gradeService.GetGradeById(id);
        if (grade != null)
        {
            Console.WriteLine($"{grade.Grade}");

            Console.Write("New Grade: ");
            grade.Grade = Console.ReadLine()!;

            var updatedGrade = _gradeService.UpdateGrade(grade);
            Console.Clear();
            Console.WriteLine("Grade updated!");
            Console.ReadKey();
        }
    }
    public void DeleteGradeById()
    {
        Console.Clear();
        Console.WriteLine("Delete a Grade");
        Console.Write("Grade ID-number: ");
        var id = int.Parse(Console.ReadLine()!);

        var grade = _gradeService.GetGradeById(id);
        if (grade != null)
        {
            Console.WriteLine($"You are now deleting {grade.Grade}.");
            _gradeService.DeleteGrade(id);
            Console.WriteLine("Grade Deleted!");
            Console.ReadKey();
        }
    }
}