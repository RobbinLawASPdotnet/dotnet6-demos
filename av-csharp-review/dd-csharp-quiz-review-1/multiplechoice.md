# InClass2 - Classes, Objects, and File I/O

## Multiple Choice

( **1 mark each** ) For each of the following questions, select the best answer that applies.

## PUT YOUR ANSWERS IN THE **feedback.md** FILE THAT IS IN THE **feedback** FOLDER

------------------------------------------------------------------------


```csharp
01    using System;
02    using System.Collections.Generic;
03    namespace src
04    {
05        class Program
06        {
07            static void Main(string[] args)
08            {
09                Program app = new Program();
10                app.Run();
11            }
12            private void Run()
13            {
14                try
15                {
16                    Student theStudent = new Student("Joe");
17                    StudentInfo theStudentInfo = new StudentInfo(theStudent);
18                    theStudentInfo.AddMark(new Mark("Math", 67.0, 80.0));
19                    Console.WriteLine(theStudentInfo.Student.ToString());
20                    foreach (Mark item in theStudentInfo.Marks)
21                        Console.WriteLine(item.ToString());
22                }
23                catch (Exception ex)
24                {
25                    Console.WriteLine($"Exception: {ex.Message}");
26                } 
27            }
28        }
29        public class Student
30        {
31            public readonly string StudentName;
32            public Student(string studentName)
33            {
34                StudentName = studentName;
35            }
36            public override string ToString()
37            {
38                return $"Student Name: {StudentName}";
39            }        
40        }
41        public class Mark
42        {
43            public readonly string CourseName;
44            public readonly double RawMark;
45            public readonly double PossibleMarks;
46            public double MarkInPercent {get {return (RawMark/PossibleMarks * 100);}}
47            public Mark(string courseName, double rawMark, double possibleMarks)
48            {
49                CourseName = courseName;
50                RawMark = rawMark;
51                PossibleMarks = possibleMarks;
52            }
53            public override string ToString()
54            {
55                return $"Course Name: {CourseName}, Mark in Percent: {MarkInPercent}";
56            }             
57        }
58        public class StudentInfo
59        {
60            public Student Student { get; private set; }
61            public List<Mark> Marks { get; set; } = new();
62            public StudentInfo(Student student)
63            {
64                Student = student;
65            }
66            public void AddMark(Mark mark)
67            {
68                if (mark == null)
69                    throw new ArgumentNullException("No mark supplied. Mark not added.");
70                Marks.Add(mark); 
71            } 
72        }
73    }
```


1)	Which term best describes the words `System.Collections.Generic` from line 02 of the code above?

```
a.	Class Name
b.	Method Name
c.	Object Name
d.	Namespace
```

2)	Which term best describes the word `”Joe”` from line 16 of the code above?

```
a.	Data Type
b.	Variable
c.	Literal Value
d.	Expression
```

3)	Which term best describes the words `Student(“Joe”)` from line 16 of the code above?

```
a.	Instance Method Call
b.	Static Method Call
c.	Global Method Call
d.	Constructor Call
```

4)	Which term best describes the word `AddMark` from line 18 of the code above?

```
a.	Instance Method Call
b.	Class Method Call
c.	Global Method Call
d.	Constructor Call
```

5)	Which term best describes the word `”Math”` from line 18 of the code above?

```
a.	Parameter
b.	Return Type
c.	Argument
d.	Constructor
```

6)	Which term best describes the word `WriteLine` from line 19 of the code above?

```
a.	Instance Method Call
b.	Class Method Call
c.	Global Method Call
d.	Constructor Call
```

7)	Which term best describes line 31 of the code above?

```
a.	Auto-Implemented Property
b.	Fully-Implemented Property
c.	Field
d.	Constructor
e.	Method
```

8)	Which term best describes the word `string` from line 32 of the code above?

```
a.	Data Type
b.	Variable
c.	Literal Value
d.	Expression
```

9)	Which term best describes the words `string studentName` from line 32 of the code above?

```
a.	Argument
b.	Return Type
c.	Parameter
d.	Constructor
```

10)	Which term best describes the word `RawMark` from line 46 of the code above?

```
a.	Local Variable
b.	Field
c.	Property
d.	Method Name
```

11)	Which term best describes the word `MarkInPercent` from line 46 of the code above?

```
a.	Local Variable
b.	Field
c.	Property
d.	Method Name
e.	Class
```

12)	Which term best describes line 46 of the code above?

```
a.	Auto-Implemented Property
b.	Fully-Implemented Property
c.	Field
d.	Constructor
e.	Method
```

13)	Which term best describes the word `Mark` from line 47 of the code above?

```
a.	Local Variable
b.	Field
c.	Property
d.	Method Name
e.	Constructor
```

14)	Which term best describes the word `string` from line 53 of the code above?

```
a.	Argument
b.	Return Type
c.	Parameter
d.	Constructor
```

15)	Which term best describes line 53 of the code above?

```
a.	Auto-Implemented Property
b.	Fully-Implemented Property
c.	Field
d.	Constructor
e.	Method
```
16)	Which term best describes line 60 of the code above?

```
a.	Auto-Implemented Property
b.	Fully-Implemented Property
c.	Field
d.	Constructor
e.	Method
```

17)	Which term best describes line 62 of the code above?

```
a.	Auto-Implemented Property
b.	Fully-Implemented Property
c.	Field
d.	Constructor
e.	Method
```

18)	Which term best describes the word `AddMark` from line 66 of the code above?

```
a.	Local Variable
b.	Field
c.	Property
d.	Method Name
e.	Parameter
```

19)	Which term best describes the word `void` from line 66 of the code above?

```
a.	Argument
b.	Return Type
c.	Parameter
d.	Constructor
```

20)	Which term best describes line 66 of the code above?

```
a.	Auto-Implemented Property
b.	Fully-Implemented Property
c.	Field
d.	Constructor
e.	Method
```
