# Train System - Ex01b - Classes, Objects, and Composition

> This is the second of a set of exercises that follow the evolution of a console program to manage trains.

## Overview

Your task is to generate a set of simple data types to represent the primary objects for managing trains.

Use the demos presented in class as a guide to implementing this exercise.

For this exercise, place all the required data types in the namespace `TrainSystem` and ensure that they are `public`. 

### General Validation Rules

All validation is to be performed by throwing exceptions. Here are some general requirements.

- Exceptions must have meaningful error messages.
- Error messages must include details about the limits for acceptable values.
- Weights must always be positive and non-zero whole numbers. Weights are to be in 100 pound increments (all weights are in pounds).
- All string information must contain text. Null, empty, and plain white-space text is not allowed. Sanitize your strings by trimming the leading and trailing whitespace.

### The  `RollingStock (RailCar)`

Railcars carry various kinds of goods. Each railcar is stenciled with certain information:

- **Reporting Mark** (e.g.: "C&S 18172") - Uniquely identifies a specific car; may include characters in the number.
- **Light Weight** (in lbs) - The weight of the railcar when empty.
- **Load Limit** (in lbs) - Absolute maximum Net Weight allowed for safety purposes. This does not include the Light Weight. Exceeding this weight makes the railcar unsafe.
- **Capacity** (in lbs) - Standard maximum Net Weight. This is the "ballpark" figure used when loading a railcar. The actual scale weight may be slightly higher or lower for what is considered a "full" load.

![RollingStock](./img/Hopper.jpg)

Railcars can be loaded with freight. When loaded, each car is weighed at a scale that gives the weight to the nearest 100 pounds. The **Gross Weight** is the weight of the freight and the railcar. The **Net Weight** is the weight of the freight only. NOTE, that we will NOT be writing code to simulate weighing a loaded car at a scale, but in the constructor you are to set the **Gross Weight** to the **Light Weight**, meaning that when the railcar is created it will be empty.

Create a file called "RollingStock.cs" in the TrainSystem directory and then in the file a class called "RollingStock" that has the following fields, properties, and constructor. You must complete the constructor.

Override the **`ToString()`** method to return the RailCar's data, as shown below.

```csharp
using System;
namespace TrainSystem
{
    public class RollingStock
    {
        public readonly string ReportingMark;
        public readonly string Owner;
        public readonly int LightWeight;
        public readonly int LoadLimit;
        public readonly int Capacity;
        public readonly RailCarType Type;
        public readonly int YearBuilt;
        public readonly bool InService;
        public readonly string Notes;
        public int GrossWeight { get; private set; }
        public int NetWeight { get { return GrossWeight - LightWeight; } }

        private const string SPECIALCHARACTERS =@",:;\/!?@#$%^&*~`";

        public RollingStock(string reportingMark, string owner, int lightWeight, 
            int loadLimit, int capacity,  RailCarType type, int yearBuilt, bool inService, string notes) {}

        public override string ToString()
       {
           return $"{ReportingMark},{Owner},{LightWeight},{LoadLimit},{Capacity},{Type},{YearBuilt},{InService},{Notes}";
       }
    }
}
```
Note the following:
- In the `RollingStock` constructor ensure that the supplied reporting number does not contain any of the following characters: `,:;\/!?@#$%^&*~` and the backtick (`) character.
- Load Limit and Capacity are in terms of the freight itself. This is the net weight of the railcar, and does not include the Light Weight.
- Capacity must always be less than the Load Limit.

> [Source: Boulder Creek Engineering](https://www.bouldercreekengineering.com/scale_ops3.php)

### The `RailCarType`

Railcars come in various types. Initially, we will consider only three types of railcars: box cars, coal cars, and covered hoppers. 

Create a file called "RailCarType.cs" in the TrainSystem directory and then in the file an enum as follows.

```csharp
namespace TrainSystem
{
    public enum RailCarType
    {
        BOX_CAR,
        COAL_CAR,
        COVERED_HOPPER
    }
}
```

### The `Train`

A train is a set of railcars pulled by an engine. At present, a train must have a single engine. Railcars are added to the train one-by-one. All `set` properties must be `private`, while all `get` properties are `public`; some properties only have a `get`, because they calculate their values based on the state of the train.

- **Gross Weight** - This is the total weight of the train, including the engine in lbs.
- **Maximum Gross Weight** - This measure is also in lbs. This is based upon the capacity of the engine. The "rule-of-thumb" that we will be following is that 1 HP can pull 1 Ton (a Ton is 2000 pounds). Thus, a 4400 HP engine can pull about 4400 Tons.

In the file called "Train.cs" in the TrainSystem directory add to the class called "Train" the following properties, and other methods. You added the Engine property in the previous exercise. You created the constructor also in the previous exercise. You must complete the other methods *AddRailCar(RollingStock car)* and *CalculateGrossWeightOfCars()*.

```csharp
using System;
using System.Collections.Generic;

namespace TrainSystem
{
    public class Train
    {
        public Engine Engine { get; private set; }
        public int GrossWeight { get { return Engine.Weight + CalculateGrossWeightOfCars(); } }
        public int MaxGrossWeight { get { return Engine.HorsePower * 2000; } }
        public List<RollingStock> RailCars { get; set; } = new();
        //TotalCars does not include the engine.
        public int TotalCars { get { return RailCars.Count; } }

        public Train(Engine engine) {}

        public void AddRailCar(RollingStock car) {}

        private int CalculateGrossWeightOfCars() {}
    }
}
```
With regard to the `AddRailCar(RollingStock car)` method, ensure the following:

- Ensure the supplied object is not `null`. If it is, throw an `ArgumentNullException(string.Empty,"No car supplied. Car not added.")`.
- When adding railcars to the train, do not allow the gross weight to exceed the maximum gross weight allowed for the train. If this happens throw an `ArgumentException` with a message of `"This new car will overload engine. Car not added."`.
- Ensure there are no duplicate reporting marks in the train. If the supplied car's reporting mark already exists, throw an `ArgumentException` with a message of `"The railcar {car.ReportingMark} is already attached to the train"`.
- When adding railcars to the train, do not allow the gross weight to exceed the maximum gross weight allowed for the train.

### The `Program`

Add to the contents of Program.cs the following.
  
```csharp
using System;
using System.Collections.Generic;
using System.IO;

namespace TrainSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Ex01a();
            app.Ex01b();
        }

        private void Ex01b()
        {
            try
            {
                Console.WriteLine("Ex01b Program started");
                //build a simple train.
                Engine theEngine = new Engine("CP 8002","123658",147700,4400);
                Train theTrain = new Train(theEngine);
                theTrain.AddRailCar(new RollingStock("GATX 220455","Alberta Gov",
                    38800,130200,110000,RailCarType.BOX_CAR,1980,true,"none"));
                theTrain.AddRailCar(new RollingStock("TXLX 152635","Alberta Gov",
                    39200,125200,105000,RailCarType.COVERED_HOPPER,1980,true,"none"));
                //print out the train components to the console.
                Console.WriteLine(theTrain.Engine.ToString());
                foreach (var item in theTrain.RailCars)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("Ex01b Program ended");
                Console.WriteLine("");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Exception in Ex01b: {ex.Message}");
            }
            
        }
    }
}
```