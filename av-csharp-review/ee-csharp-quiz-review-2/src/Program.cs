// To use this program enter the names of students
// as args when you run.

using System;
using	System.Collections.Generic;
namespace CSharp.Language.Quiz
{
	public class Program
	{	
	  private static Random rnd = new Random();
		
	  public static void Main(string[] args)
    {
      Console.WriteLine("BEGIN Main");	
      Program app = new Program(args);
      
      app.AssignMarks(30, 80);
      
      foreach (Student person in app.Students)
      {
        System.Console.WriteLine("Name: " + person.Name);
        foreach (EarnedMark item in person.Marks)
          System.Console.WriteLine("\t" + item);
      }
    }	
		
	  private List<Student> _students = new List<Student>();
		
    public List<Student> Students
    {	
      get { return _students; }
      set { _students = value; }
    }	
		
    public Program(string[] studentNames)
    {	
      WeightedMark[] CourseMarks = new WeightedMark[4];
      CourseMarks[0] = new WeightedMark("Quiz 1", 20);
      CourseMarks[1] = new WeightedMark("Quiz 2", 20);
      CourseMarks[2] = new WeightedMark("Exercises", 25);
      CourseMarks[3] = new WeightedMark("Lab", 35);
      int[] possibleMarks = new int[4] { 25, 50, 12, 35 };
      
      foreach (string name in studentNames)
      {
        EarnedMark[] marks = new EarnedMark[4];
        for (int i = 0; i < possibleMarks.Length; i++)
          marks[i] = new EarnedMark(CourseMarks[i], possibleMarks[i], 0);
        Students.Add(new Student(name, marks));
      }
    }	
		
    public void AssignMarks(int min, int max)
    {
      Console.WriteLine("BEGIN AssignMarks");	
      foreach (Student person in Students)
        foreach (EarnedMark item in person.Marks)
          item.Earned = (rnd.Next(min, max) / 100.0) * item.Possible;
    }	
  }		
		
	public class Student
	{	
    public string Name { get; private set; }
    public EarnedMark[] Marks { get; private set; }
      
    public Student(string name, EarnedMark[] marks)
    {
    Name = name;
    Marks = marks;
    }
	}
	
	public class WeightedMark
	{
    public int Weight { get; private set; }
    public string Name { get; private set; }
    
    public WeightedMark(string name, int weight)
    {
      if (weight <= 0 || weight > 100)
        throw new Exception("Invalid weight: must be greater than zero and at most 100");
      if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name.Trim()))
        throw new Exception("Name cannot be empty for weighted item");
      Weight = weight;
      Name = name;
    }
	}
	
	public class EarnedMark : WeightedMark
	{
    public int Possible { get; private set; }
    private double _Earned;
    public double Earned
    {
      get { return _Earned; }
      set
      {
        if (value < 0 || value > Possible)
          throw new Exception("Invalid earned mark assigned");
        _Earned = value;
      }
	  }
	
    public double Percent
    { get { return (Earned / Possible) * 100; } }
	
    public double WeightedPercent
    { get { return Percent * Weight / 100; } }
	
    public EarnedMark(WeightedMark markableItem, int possible, double earned)
    : this(markableItem.Name, markableItem.Weight, possible, earned)
    {
    }
	
    public EarnedMark(string name, int weight, int possible, double earned)
    : base(name, weight)
    {
      if (possible <= 0)
        throw new Exception("Invalid possible marks");
      Possible = possible;
      Earned = earned;
    }
	
    public override string ToString()
    {
      return String.Format("{0} ({1})\t - {2}% ({3}/{4}) \t- Weighted Mark {5}%",
      Name,
      Weight,
      Percent,
      Earned,
      Possible,
      WeightedPercent);
    }
  }
}