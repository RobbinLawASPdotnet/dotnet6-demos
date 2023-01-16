/*
Purpose: Programming Fundamentals: Assignment 4 Part 4

Inputs: - Length of the room using InputLength method.
        - Width of the room using InputWidth method.
        - Cost per square foot using the InputCost method.

Outputs: - Inputted values of length and width. Area value calculated using the CalculateArea method.  
         - Total cost of the carpet calculated by the TotalCost method.

Algorithm: - Main method
                1. Create a new object of the RoomDimension class using the InputLength and InputWidth methods.
                    - User input the value of length into the InputLength method.
                    - User input the value of width into the InputWidth method.
                    - Both values are stored in the object 'room' for further use in the RoomDimensions class.
                
                2. Create a new object of the RoomCarpet class using the RoomDimension object 'room' and the InputCost method.
                    - User input the value of cost into the InputCost method.
                    - Both the object 'room' and the value of cost are stored in the object 'carpet' for further use in the RoomCarpet class.

                3. Console display the output of the RoomDimensions method ToString.
                    - The value of 'length' is stored in the data member 'length' and 'width' is stored in 'width'.
                    - The method CalculateArea uses the values of length and width to calculate an area value.
                    - ToString displays the user inputted values length and width, along with the value returned by the method CalculateArea.

                4. Console display the output of the RoomCarpet method ToString.
                    - The object 'room' is stored in the data member 'size' and 'cost' is stored in 'carpetCost'.
                    - The method TotalCost gets the value returned by CalculateArea using the object stored in size, and the value of carpetCost to calculate the value of TotalCost.
                    - ToString displays the value returned by the method TotalCost.
                
Test Plan:

Test Case       Test Data                       Expected Results
----------------------------------------------------------------------------------------------------------------------------------------
    
    1           length = 10                     Enter the room length in feet: 10
                width = 12                      Enter the room width in feet: 12
                cost = 3.99                     Enter the carpet cost per square feet: 3.99
                                                Length = 10, Width = 12, Area = 120
                                                The total cost of the carpet is $478.80
                
----------------------------------------------------------------------------------------------------------------------------------------

    2           length = 25                     Enter the room length in feet: 25
                width = 16                      Enter the room width in feet: 16
                cost = 9.99                     Enter the carpet cost per square feet: 9.99
                                                Length = 25, Width = 16, Area = 400
                                                The total cost of the carpet is $3996.00

----------------------------------------------------------------------------------------------------------------------------------------

    3           length = 0                      Enter the room length in feet: 0
                                                Error! Room length must be greater than 0.

----------------------------------------------------------------------------------------------------------------------------------------

    4           length = 1                      Enter the room length in feet: 1
                width = 0                       Enter the room width in feet: 0
                                                Error! Room width must be greater than 0.
                
----------------------------------------------------------------------------------------------------------------------------------------

    5           length = 1                      Enter the room length in feet: 1
                width = 1                       Enter the room width in feet: 1
                cost = 0                        Enter the carpet cost per square feet: 0
                                                Error! Carpet cost per square foot must be greater than 0.

----------------------------------------------------------------------------------------------------------------------------------------

    6           length = 'c'                    Enter the room length in feet: c
                                                Error! Input string was not in a correct format.
                
----------------------------------------------------------------------------------------------------------------------------------------

    7           length = 1                      Enter the room length in feet: 1
                width = 'c'                     Enter the room width in feet: c
                                                Error! Input string was not in a correct format.
                                   
----------------------------------------------------------------------------------------------------------------------------------------

    8           length = 1                      Enter the room length in feet: 1
                width = 1                       Enter the room width in feet: 1
                cost = 'c'                      Enter the carpet cost per square feet: c
                                                Error! Input string was not in a correct format.

----------------------------------------------------------------------------------------------------------------------------------------

Written by: Cody Tompkins

Written for: Harsimranjot Aulakh

Section No:	A06

Last modified: 2022-12-07
*/

using System;
class RoomDimension

// Declaring RoomDimension class for holding the room dimension values, calculating area of the room and displaying those values back to the user.
{
    double length;
    double width;

    // Declaring data members for the RoomDimension class.

    public double Length
    {
        get { return length; }
        set { length = value; }
    }
    // Setting properties for the length data member. Simple fully-implemented get/set.
    public double Width
    {
        get { return width; }
        set { width = value; }
    }
    // Setting properties for the width data member. Simple fully-implemented get/set.
    public RoomDimension(double len, double wid)
    {
        Length = len;
        Width = wid;
    }
    // Declaring constructor for the RoomDimension class.
    public double CalculateArea()
    {
        return Length * width;
    }
    // Declaring the CalculateArea method for the RoomDimension class. This method will return the area of the room when it is called.
    public override string ToString()
    {
        return $"Length = {Length}, Width = {Width}, Area = {CalculateArea()}";
    }
    // Declaring ToString method for the RoomDimension class. This method will display the dimension values to the user.
}
class RoomCarpet

// Declaring RoomCarpet class for holding the room size and carpet cost values, calculating total cost of the carpet and displaying the total cost back to the user.
{
    RoomDimension size;
    double carpetCost;

    // Declaring data members for the RoomCarpet class.

    public RoomDimension Size
    {
        get { return size; }
        set { size = value; }
    }
    // Setting properties for the size data member. Simple fully-implemented get/set.
    public double CarpetCost
    {
        get { return carpetCost; }
        set { carpetCost = value; }
    }
    // Setting properties for the carpetCost data member. Simple fully-implemented get/set.
    public RoomCarpet(RoomDimension dimen, double cost)
    {
        Size = dimen;
        carpetCost = cost;
    }
    // Declaring constructor for the RoomCarpet class.
    public double TotalCost()
    {
        return Size.CalculateArea() * CarpetCost;
    }
    // Declaring the TotalCost method for the RoomCarpet class. This method will return the total cost of the carpet when it is called.
    public override string ToString()
    {
        return "The total cost of the carpet is $" + TotalCost().ToString("0.00");
    }
    // Declaring ToString method for the RoomCarpet class. This method will display the total carpet cost value to the user.
}
class Program
{
    public static double InputLength()

    // Declaring method InputLength which recieves the value of length from the user and validates that it is greater than 0.
    {
        double length = 0;
        bool inputLengthError = false; ;

        // Declaring variables for the InputLength method.

        do

        // Beginning of do while loop.
        {
            try

            // try to perform the actions below without error.
            {
                Console.Write("Enter the room length in feet: ");
                length = double.Parse(Console.ReadLine());

                // Console prompt user to input the value of length. User enter the value of length.

                if (length <= 0)
                {
                    throw new Exception("Room length must be greater than 0.");
                }
                // if the value of length is less than or equal to 0, throw an exception telling that to the user.
            }
            catch (Exception e)

            // if the above actions cannot be run without error, catch them here with Exception.
            {
                Console.WriteLine("Error! " + e.Message);

                // Console display error message.

                inputLengthError = true;

                // Set the value of inputLengthError to true.
            }
        } while (inputLengthError == true);

        // Perform the actions above at least once. If there is an error, perform them again.

        return length;

        // return the value of length to the method that called this method.
    }
    public static double InputWidth()

    // Declaring method InputWidth which recieves the value of width from the user and validates that it is greater than 0.
    {
        double width = 0;
        bool inputWidthError = false;

        // Declaring variables for the InputWidth method.

        do

        // Beginning of do while loop.
        {
            try

            // try to perform the actions below without error.
            {
                Console.Write("Enter the room width in feet: ");
                width = double.Parse(Console.ReadLine());

                // Console prompt user to input the value of width. User enter the value of width.

                if (width <= 0)
                {
                    throw new Exception("Room width must be greater than 0.");
                }

                // if the value of width is less than or equal to 0, throw an exception telling that to the user.
            }
            catch (Exception e)

            // if the above actions cannot be run without error, catch them here with Exception.
            {
                Console.WriteLine("Error! " + e.Message);

                // Console display error message.

                inputWidthError = true;

                // Set the value of inputWidthError to true.
            }
        } while (inputWidthError == true);

        // Perform the actions above at least once. If there is an error, perform them again.

        return width;

        // return the value of width to the method that called this method.
    }
    public static double InputCost()

    // Declaring method InputCost which recieves the value of cost from the user and validates that it is greater than 0.
    {
        double cost = 0;
        bool inputCostError = false;

        // Declaring variables for the InputCost method.

        do

        // Beginning of do while loop.
        {
            try

            // try to perform the actions below without error.
            {
                Console.Write("Enter the carpet cost per square feet: ");
                cost = double.Parse(Console.ReadLine());

                // Console prompt user to input the value of cost. User enter the value of cost.

                if (cost <= 0)
                {
                    throw new Exception("Carpet cost per square foot must be greater than 0.");
                }
                // if the value of cost is less than or equal to 0, throw an exception telling that to the user.
            }
            catch (Exception e)

            // if the above actions cannot be run without error, catch them here with Exception.
            {
                Console.WriteLine("Error! " + e.Message);

                // Console display error message.

                inputCostError = true;

                // Set the value of inputCostError to true.
            }
        } while (inputCostError == true);

        // Perform the actions above at least once. If there is an error, perform them again.

        return cost;

        // return the value of cost to the method that called this method.
    }
    public static void Main(string[] args)
    {
        RoomDimension room = new RoomDimension(InputLength(), InputWidth());

        // Creating object of the RoomDimension class using the values returned by InputLength and InputWidth methods.

        RoomCarpet carpet = new RoomCarpet(room, InputCost());

        // Creating object of the RoomCarpet class using the RoomDimension object 'room' and the value returned by the InputCost method.

        Console.WriteLine(room.ToString());

        // Use the RoomDimension method ToString to display the values of length, width, and the value returned by the CalculateArea method.

        Console.WriteLine(carpet.ToString());

        // Use the RoomCarpet method ToString to display the value returned by the TotalCost method.
    }
}