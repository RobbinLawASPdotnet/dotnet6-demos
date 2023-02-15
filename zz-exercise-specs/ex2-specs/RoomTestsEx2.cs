using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenoSystem;

namespace RenoUnitTestsEx2
{
  [TestClass]
  public class RoomTests
  {
    [TestMethod]
    public void Room_AddWall_MissingParameter()
    {
      try
      {
        Room theRoom = new Room("Bedroom 1", "Oak Plate", null);
        theRoom.AddWall(null);
        Assert.Fail("Exception was expected and failed to be thrown.");
      }
      catch (ArgumentNullException ex)
      {
        Assert.IsTrue(ex.Message.Contains("missing") ||
                        ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");
      }
      catch (Exception ex)
      {
        Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
        Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message.");
      }
    }

    [TestMethod]
    public void Room_AddWall_GoodUniquePlanId()
    {
      try
      {
        //Arrange
        Room theRoom = new Room("Bedroom 1", "Oak Plate", null);
        Opening theWindow = new Opening(OpeningType.Window, 105, 120, 15);
        Wall wallA = new Wall("Brd1", 254, 243, "Ivory White", theWindow);
        theRoom.AddWall(wallA);
        Opening theDoor = new Opening(OpeningType.Door, 112, 244, 15);
        Wall wallB = new Wall("Brd2", 309, 243, "Ivory White", theDoor);
        //Act
        theRoom.AddWall(wallB);
        //Assess
        Assert.IsTrue(theRoom.TotalWalls == 2, "Wall Brd2 was not added. Wall was expected to be added.");
      }
      catch (ArgumentNullException ex)
      {
        Assert.IsTrue(ex.Message.Contains("missing") ||
                        ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");
      }
      catch (Exception ex)
      {
        Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
      }
    }

    [TestMethod]
    public void Room_AddWall_BadUniquePlanId_WallFound()
    {
      try
      {
        //Arrange
        Room theRoom = new Room("Bedroom 1", "Oak Plate", null);
        Opening theWindow = new Opening(OpeningType.Window, 105, 120, 15);
        Wall wallA = new Wall("Brd1", 254, 243, "Ivory White", theWindow);
        theRoom.AddWall(wallA);
        Opening theDoor = new Opening(OpeningType.Door, 112, 244, 15);
        Wall wallB = new Wall("Brd1", 309, 243, "Ivory White", theDoor);
        //Act
        theRoom.AddWall(wallB);
        //Assess
        Assert.Fail("Exception was expected and failed to be thrown.");
      }
      catch (ArgumentNullException ex)
      {
        Assert.IsTrue(ex.Message.Contains("missing") ||
                        ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");
      }
      catch (Exception ex)
      {
        Assert.IsTrue(ex.Message.Contains("Duplicate plan identifier")
            && ex.Message.Contains("Brd1"), "Exception message should indicate the planId with message Duplicate plan identifier");
      }
    }

    [TestMethod]

    public void Room_RemoveWall_MissingParameter()
    {
      try
      {
        Room theRoom = new Room("Bedroom 1", "Oak Plate", null);
        theRoom.RemoveWall(null);
        Assert.Fail("Exception was expected and failed to be thrown.");
      }
      catch (ArgumentNullException ex)
      {
        Assert.IsTrue(ex.Message.Contains("missing") ||
                        ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");
      }
      catch (Exception ex)
      {
        Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
        Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message.");
      }
    }

    [TestMethod]
    public void Room_RemoveWall_WallFound()
    {
      try
      {
        //Arrange
        Room theRoom = new Room("Bedroom 1", "Oak Plate", null);
        Opening theWindow = new Opening(OpeningType.Window, 105, 120, 15);
        Opening theDoor = new Opening(OpeningType.Door, 112, 244, 15);
        Opening theCloset = new Opening(OpeningType.Closet, 203, 182, 15);
        Opening theWall = new Opening(OpeningType.Closet, 105, 120, 15);
        Wall wallA = new Wall("Brd1", 309, 243, "Ivory White", theDoor);
        Wall wallB = new Wall("Brd2", 213, 243, "Ivory White", theCloset);
        Wall wallC = new Wall("Brd3", 254, 243, "Ivory White", theWindow);
        Wall wallD = new Wall("Brd4", 309, 243, "Ivory White", theWall);
        theRoom.AddWall(wallA);
        theRoom.AddWall(wallB);
        theRoom.AddWall(wallC);
        theRoom.AddWall(wallD);
        //Act
        theRoom.RemoveWall("Brd2");
        //Assess
        Assert.IsTrue(theRoom.TotalWalls == 3
                && theRoom.Walls[0].PlanId.Equals("Brd1")
                && theRoom.Walls[1].PlanId.Equals("Brd3")
                && theRoom.Walls[2].PlanId.Equals("Brd4"), "Wall Brd2 was not removed as expected.");
      }
      catch (ArgumentNullException ex)
      {
        Assert.IsTrue(ex.Message.Contains("missing") ||
                        ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");
      }
      catch (Exception ex)
      {
        Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
      }
    }

    [TestMethod]
    public void Room_RemoveWall_WallNotFound()
    {
      try
      {
        //Arrange
        Room theRoom = new Room("Bedroom 1", "Oak Plake", null);
        Opening theWindow = new Opening(OpeningType.Window, 105, 120, 15);
        Opening theDoor = new Opening(OpeningType.Door, 112, 244, 15);
        Opening theCloset = new Opening(OpeningType.Closet, 203, 182, 15);
        Opening theWall = new Opening(OpeningType.Closet, 105, 120, 15);
        Wall wallA = new Wall("Brd1", 309, 243, "Ivory White", theDoor);
        Wall wallB = new Wall("Brd2", 213, 243, "Ivory White", theCloset);
        Wall wallC = new Wall("Brd3", 254, 243, "Ivory White", theWindow);
        Wall wallD = new Wall("Brd4", 309, 243, "Ivory White", theWall);
        theRoom.AddWall(wallA);
        theRoom.AddWall(wallB);
        theRoom.AddWall(wallC);
        theRoom.AddWall(wallD);
        //Act
        theRoom.RemoveWall("Brd6");
        //Assess
        Assert.Fail("Exception was expected and failed to be thrown.");
      }
      catch (ArgumentNullException ex)
      {
        Assert.IsTrue(ex.Message.Contains("missing") ||
                        ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");
      }
      catch (ArgumentException ex)
      {
        Assert.IsTrue(ex.Message.Contains("Brd6"), "Exception message should indicate the parameter.");
      }
      catch (Exception ex)
      {
        Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
      }
    }
  }
}
