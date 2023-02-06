using RenoSystem;

namespace RenoUnitTestsEx2
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        //Parse good csv string
        [DataRow("Brd1,367,244,White,Window,100,120,12")]
        [DataRow("Brd1,367,244,White,Door,100,120,0")]
        public void CreateWall_Good_Parse(string text)
        {
            try
            {
                Wall theWall = null;
                theWall = Wall.Parse(text);
                //Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        //TryParse good csv string
        [DataRow("Brd1,367, 244, White, Window, 100, 120, 12")]
        [DataRow("Brd1,367, 244, White, Door, 0, 0, 0")]
        public void CreateWall_Good_TryParse(string text)
        {
            try
            {
                Wall theWall = null;
                bool parsed = Wall.TryParse(text, out theWall);
                Assert.IsTrue(parsed == true, $"Exception boolean result {parsed} should be true.");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        //Parse bad csv string
        //insufficient parameter values, missing color
        [DataRow("Brd1,367,244,Window,100,120,12")]
        //Bad numerics
        [DataRow("Brd1,bob, 244, White, Window, 100, 120, 12")]
        [DataRow("Brd1,367, bob, White, Window, 100, 120, 12")]
        [DataRow("Brd1,367, 244, White, Window, bob, 120, 12")]
        [DataRow("Brd1,367, 244, White, Window, 100, bob, 12")]
        [DataRow("Brd1,367, 244, White, Window, 100, 120, bob")]
        //bad enum
        [DataRow("Brd1,367, 244, White, Widow, 100, 120, 12")]
        public void CreateWall_Bad_Parse(string text)
        {
            try
            {
                Wall theWall = null;
                theWall = Wall.Parse(text);
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");

            }
            catch (FormatException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        //TryParse bad csv string
        //missing/empty string

        // ArgumentNullException was thrown by null check, Caught by the TryParse ArgumentException, thrown again as an ArgumentException, and caught in this method as an ArgumentException
        [DataRow(" ")] // argument Exception
        [DataRow("")] // argument Exception
        [DataRow(null)] // argument Exception

        //insufficient parameter values
        [DataRow("Brd1,367, 244, Window, 100, 120")] // FormatException(missing/extra value)

        //Bad numerics
        [DataRow("Brd1,bob, 244, White, Window, 100, 120,12")] // FormatException (Input string was not in a correct format)
        [DataRow("Brd1,367, bob, White, Window, 100, 120,12")]
        [DataRow("Brd1,367, 244, White, Window, bob, 120,12")]
        [DataRow("Brd1,367, 244, White, Window, 100, bob,12")]
        [DataRow("Brd1,367, 244, White, Window, 100, 120,bob")]
        //bad enum
        [DataRow("Brd1,367, 244, White, Widow, 100, 120,12")]
        public void CreateWall_Bad_TryParse(string text)
        {
            try
            {
                Wall theWall = null;
                Wall.TryParse(text, out theWall);
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");

            }
            catch (FormatException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        public void Wall_Delete_WallOpening()
        {
            try
            {
                //Arrange
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 10);
                Wall theWall = new Wall("Brd1", 367, 244, "White", theOpening);
                //Act
                theWall.DeleteOpening();
                //Assess
                Assert.IsTrue(theWall.ToString().Equals("Brd1,367,244,White"),
                    $"Delete Wall Opening not as expected.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        public void Wall_ReplaceSuppliedOpening_WallOpening()
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 10);
                Opening newOpening = new Opening(OpeningType.Door, 120, 180, 10);

                Wall theWall = new Wall("Brd1", 367, 244, "White", theOpening);
                theWall.ReplaceOpening(newOpening);
                Assert.IsTrue(theWall.WallOpening.ToString().Equals("Door,120,180,10"),
                    $"Remove wall {theWall.WallOpening.ToString()} not as expected.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        public void Wall_ReplaceOpeningMissing_WallOpening()
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 10);

                Wall theWall = new Wall("Brd1", 367, 244, "White", theOpening);
                theWall.ReplaceOpening(null);
                Assert.Fail("Exception was expected and failed to be thrown.");
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
        public void Wall_ReplaceOpening_BadSize_WallOpening()
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 10);

                Wall theWall = new Wall("Brd1", 105, 125, "White", theOpening);
                theWall.ReplaceOpening(theOpening);
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("missing") ||
                                ex.Message.Contains("required"), "Exception message should indicate the parameter is missing/required");

            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Opening limit exceeded"));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
    }
}