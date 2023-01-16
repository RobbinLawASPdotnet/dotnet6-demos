using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fields_properties
{
  class Student
  //All classes inherit from System.Object which has a ToString() method
  //that we override.
  //class Student : Object
  {
    //Public field can be changed directly by other class objects.
    //Using public fields is NOT good OOP practice.
    public string Name;

    //Private field can only be set once in this class objects constructor, because of the readonly.
    private readonly int GradeField1;

    //Private field cannot be changed by any other class object, only this one.
    private int _GradeField2;

    public int getGradeField2()
    {
      Console.WriteLine("getGradeField2");
      return _GradeField2;
    }
    public void setGradeField2(int number)
    {
      Console.WriteLine("setGradeField2");
      if (number == 34)
        throw new Exception($"setGradeField2 Bad Input: {number}");
      _GradeField2 = number;
    }

    //Private field backing for PropFullImp property
    //notice that this field is private
    //encapsulation pillar of OOP
    private int _GradeField3;
    //Public fully implemented property. Use for validation if not in the constructor.
    //the get is run if the PropFullImp is on the right side of an equation.
    //ex. someVariable = PropFullImp;
    //the set is run if the PropFullImp is on the left side of an equation.
    //ex. PropFullImp = 10;
    //When the set is run a reserved word variable is created called "value" and
    //whatever was on the right side "10" is stored in "value".
    public int PropFullImp
    {
      get
      {
        Console.WriteLine("PropFullImp getter");
        return _GradeField3;
      }
      set
      {
        Console.WriteLine("PropFullImp setter");
        if (value == 45)
          throw new Exception($"PropFullImp setter Bad Input: {value}");
        _GradeField3 = value;
      }
    }

    //Public auto implemented property: No backing field required as it is
    //automatically set up. 
    //Use when validation is done in the constructor which is its job.
    public int PropAutoImp { get; set; }

    //Greedy constructor that insures that all fields and properties have values.
    //These constructors have the job of ensuring that only valid data gets to
    //the fields and properties.
    //In this case we allow some fields and the PropFullImp property to do the validation.
    public Student(string name, int gradeField1, int gradeField2, int propFullImp, int propAutoImp)
    {
      if (propAutoImp == 56)
        throw new Exception($"PropAutoImp Bad Input: {propAutoImp}");
      Name = name;
      GradeField1 = gradeField1;
      setGradeField2(gradeField2);
      PropFullImp = propFullImp;
      PropAutoImp = propAutoImp;
    }

    //Non greedy constructor that calls the greedy constructor via :this()
    //to populate the object fields and properties with good default data.
    //Example of constructor chaining.
    public Student() : this("john", 20, 30, 40, 55)
    {

    }

    public override string ToString()
    {
      return $"Name: {Name}, GradeField1: {GradeField1}, GradeField2: {getGradeField2()}, PropFullImp: {PropFullImp}, PropAutoImp: {PropAutoImp}";
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Student newStudent1 = new Student("Jim", 22, 33, 44, 55);
        Console.WriteLine(newStudent1.ToString());
        Student newStudent2 = new Student();
        Console.WriteLine(newStudent2.ToString());
        //newStudent1.Name = "robbin";
        //Console.WriteLine(newStudent1.ToString());
        //newStudent1._GradeField2 = 10;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Exception: {ex.Message}");
      }
    }
  }
}
