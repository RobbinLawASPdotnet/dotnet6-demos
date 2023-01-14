using System;
using System.Collections.Generic;
namespace src
{
	class Program
	{
		static void Main(string[] args)
		{
			Program app = new Program();
			app.Run();
		}
		private void Run()
		{
			try
			{
				Student theStudent = new Student("Joe");
				StudentInfo theStudentInfo = new StudentInfo(theStudent);
				theStudentInfo.AddMark(new Mark("Math", 67.0, 80.0));
				Console.WriteLine(theStudentInfo.Student.ToString());
				foreach (Mark item in theStudentInfo.Marks)
					Console.WriteLine(item.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
			} 
		}
	}
	public class Student
	{
		public readonly string StudentName;
		public Student(string studentName)
		{
			StudentName = studentName;
		}
		public override string ToString()
		{
			return $"Student Name: {StudentName}";
		}        
	}
	public class Mark
	{
		public readonly string CourseName;
		public readonly double RawMark;
		public readonly double PossibleMarks;
		public double MarkInPercent {get {return (RawMark/PossibleMarks * 100);}}
		public Mark(string courseName, double rawMark, double possibleMarks)
		{
			CourseName = courseName;
			RawMark = rawMark;
			PossibleMarks = possibleMarks;
		}
		public override string ToString()
		{
			return $"Course Name: {CourseName}, Mark in Percent: {MarkInPercent}";
		}             
	}
	public class StudentInfo
	{
		public Student Student { get; private set; }
		public List<Mark> Marks { get; set; } = new();
		public StudentInfo(Student student)
		{
			Student = student;
		}
		public void AddMark(Mark mark)
		{
			if (mark == null)
				throw new ArgumentNullException("No mark supplied. Mark not added.");
			Marks.Add(mark); 
		} 
	}
}
