namespace PetsAndFleas.UnitTests;

/// <summary>
///This is a test class for PetTest and is intended
///to contain all PetTest Unit Tests
///</summary>
[TestClass()]
public class PetUnitTest
{
  [TestMethod]
  public void ItShouldInitializeWith100RemainingBites_GivenNewPet()
  {
    // Arrange
    Pet p1 = new Cat();
    Pet p2 = new Cat();
    Pet p3 = new Dog();

    // Assert
    Assert.AreEqual(100 , p1.RemainingBites , "Remaining Bites von p1 falsch initialisiert!");
    Assert.AreEqual(100 , p2.RemainingBites , "Remaining Bites von p2 falsch initialisiert!");
    Assert.AreEqual(100 , p3.RemainingBites , "Remaining Bites von p3 falsch initialisiert!");
  }


  [TestMethod]
  public void ItShouldReduceRemainingBites_GivenBiteAmount()
  {
    // Arrange
    Pet p1 = new Cat();

    // Act
    int result = p1.GetBiten(40);

    // Assert
    Assert.AreEqual(60 , p1.RemainingBites , "Nach 40 Bissen sollten 60 übrig sein!");
  }


  [TestMethod]
  public void ItShouldReturnRemainingBites_GivenBiteAmountExceedingRemainingBites()
  {
    // Arrange
    Pet p1 = new Cat();
    p1.GetBiten(40); // 60 Bisse übrig

    // Act
    int result = p1.GetBiten(70);

    // Assert
    Assert.AreEqual(60 , result , "Es sind nur 60 Bisse übrig, daher sollte 60 zurückgegeben werden.");
    Assert.AreEqual(0 , p1.RemainingBites , "Alle Bisse von p1 sollten aufgebraucht sein.");
  }


  [TestMethod]
  public void ItShouldReturnMaxRemainingBites_GivenBiteAmountExceedingCapacity()
  {
    // Arrange
    Pet p2 = new Cat();

    // Act
    int result = p2.GetBiten(200); // Versuche mehr als möglich

    // Assert
    Assert.AreEqual(100 , result , "Es sind nur 100 Bisse möglich, daher sollte 100 zurückgegeben werden.");
    Assert.AreEqual(0 , p2.RemainingBites , "Alle Bisse von p2 sollten aufgebraucht sein.");
  }

  [TestMethod]
  public void ItShouldReturnZero_GivenNegativeBiteAmount()
  {
    // Arrange
    Pet p3 = new Dog();

    // Act
    int result = p3.GetBiten(-100); // Negative Anzahl an Bissen

    // Assert
    Assert.AreEqual(0 , result , "Negative Bissanzahl nicht möglich! 0 als Rückgabewert erwartet.");
    Assert.AreEqual(100 , p3.RemainingBites , "Es sollten immer noch 100 Bisse übrig sein.");
  }

  [TestMethod]
  public void ItShouldReturnZero_GivenZeroBiteAmount()
  {
    // Arrange
    Pet p3 = new Dog();

    // Act
    int result = p3.GetBiten(0); // 0 Bisse

    // Assert
    Assert.AreEqual(0 , result , "Eine Bissanzahl von 0 sollte keinen Effekt haben und 0 zurückgeben.");
    Assert.AreEqual(100 , p3.RemainingBites , "Es sollten immer noch 100 Bisse übrig sein.");
  }

  [TestMethod]
  public void ItShouldThrowArgumentException_GivenNegativeBiteAmount()
  {
    // Arrange
    Pet p3 = new Dog();

    // Act & Assert
    Assert.ThrowsException<ArgumentException>(() => p3.GetBiten(-100) , "Eine negative Bissanzahl sollte eine ArgumentException auslösen.");
  }

  [TestMethod]
  public void ItShouldThrowArgumentException_GivenZeroBiteAmount()
  {
    // Arrange
    Pet p3 = new Dog();

    // Act & Assert
    Assert.ThrowsException<ArgumentException>(() => p3.GetBiten(0) , "Eine Bissanzahl von 0 sollte eine ArgumentException auslösen.");
  }
}
