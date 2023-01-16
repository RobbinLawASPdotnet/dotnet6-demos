using System;

class RoomDimension
{
    private double _roomLength;
    private double _roomWidth;

    public RoomDimension(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double Length
    {
        get { return _roomLength; }
        set { _roomLength = value; }
    }

    public double Width
    {
        get { return _roomWidth; }
        set { _roomWidth = value; }
    }

    public double Area()
    {
        return Length * Width;
    }

    public override string ToString()
    {
        return $"Length = {Length}, Width = {Width}";
    }

}

class RoomCarpet
{
    private double _carpetCost;
    private RoomDimension _size;

    public RoomCarpet(double cost, RoomDimension dimen)
    {
        CarpetCost = cost;
        Size = dimen;
    }

    public double CarpetCost
    {
        get { return _carpetCost; }
        set { _carpetCost = value; }
    }

    public RoomDimension Size
    {
        get { return _size; }
        set { _size = value; }
    }

    public double TotalCost()
    {
        return Size * CarpetCost;
    }
   
    public override string ToString()
    {
        return $"Area = {Size}";
    }
    

}

class Program
{
    public static void Main(string[] args)
    {
        double roomLength;
        double roomWidth;
        double carpetCost;

        Console.WriteLine("*********************");
        Console.WriteLine("* Carpet Calculator *");
        Console.WriteLine("*********************");

        Console.WriteLine("Enter the room length in feet: ");
        roomLength = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the room width in feet: ");
        roomWidth = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the carpet cost per square feet: ");
        carpetCost = double.Parse(Console.ReadLine());

        RoomDimension rd = new RoomDimension(roomLength, roomWidth);
        RoomCarpet rc = new RoomCarpet(carpetCost, rd);  
    }
}