namespace PetsAndFleas.UnitTests;

[TestClass()]
public class CatTests
{
  [TestMethod]
  public void ItShouldReturnTrueAndIncrementTreesClimbed_GivenFirstClimb()
  {
    // Arrange
    Cat c1 = new Cat();

    // Act
    bool result = c1.ClimbOnTree();

    // Assert
    Assert.AreEqual(1 , c1.TreesClimbed , "Katze sollte auf 1 Baum geklettert sein!");
    Assert.AreEqual(true , result , "Katze sollte auf 1 Baum geklettert sein (Rückgabewert true erwartet)!");
  }

  [TestMethod]
  public void ItShouldReturnFalseAndNotIncrementTreesClimbed_GivenClimbWhileOnTree()
  {
    // Arrange
    Cat c1 = new Cat();
    c1.ClimbOnTree(); // Katze klettert auf den ersten Baum

    // Act
    bool result = c1.ClimbOnTree(); // Zweiter Versuch, während sie auf dem Baum ist

    // Assert
    Assert.AreEqual(1 , c1.TreesClimbed , "Katze ist gerade auf einen Baum! Muss vorher runter....");
    Assert.AreEqual(false , result , "Katze ist gerade auf einen Baum! Rückgabewert false erwartet.");
  }

  [TestMethod]
  public void ItShouldReturnTrueAndIncrementTreesClimbed_GivenClimbAfterClimbingDown()
  {
    // Arrange
    Cat c1 = new Cat();
    c1.ClimbOnTree(); // Katze klettert auf den ersten Baum
    c1.ClimbDown(); // Katze klettert wieder herunter

    // Act
    bool result = c1.ClimbOnTree(); // Klettert auf den zweiten Baum

    // Assert
    Assert.AreEqual(2 , c1.TreesClimbed , "Katze sollte auf 2 Bäume geklettert sein!");
    Assert.AreEqual(true , result , "Katze sollte auf den zweiten Baum geklettert sein (Rückgabewert true erwartet)!");
  }
}