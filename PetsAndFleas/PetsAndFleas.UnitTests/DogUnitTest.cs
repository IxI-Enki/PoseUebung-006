namespace PetsAndFleas.UnitTests;

/// <summary>
///This is a test class for DogTest and is intended
///to contain all DogTest Unit Tests
///</summary>
[TestClass()]
public class DogUnitTest
{
  [TestMethod]
  public void ItShouldReturnTrueAndIncrementHuntedAnimals_GivenFirstHunt()
  {
    // Arrange
    Dog d1 = new Dog();

    // Act
    bool actual = d1.HuntAnimal();

    // Assert
    Assert.AreEqual(1 , d1.HuntedAnimals , "Es sollte 1 in HuntedAnimals stehen!");
    Assert.AreEqual(true , actual , "Es sollte true zurückgegeben werden!");
  }

  [TestMethod]
  public void ItShouldReturnTrueAndIncrementHuntedAnimals_GivenHuntAfterSufficientPause()
  {
    // Arrange
    Dog d1 = new Dog();
    d1.HuntAnimal(); // Erste Jagd
    Thread.Sleep(1001); // Pause

    // Act
    bool actual = d1.HuntAnimal(); // Zweite Jagd nach ausreichender Pause

    // Assert
    Assert.AreEqual(2 , d1.HuntedAnimals , "Es sollte nun 2 in HuntedAnimals stehen! (Pause eingehalten)");
    Assert.AreEqual(true , actual , "Es sollte true zurückgegeben werden!");
  }

  [TestMethod]
  public void ItShouldReturnFalseAndNotIncrementHuntedAnimals_GivenSecondHuntWithinShortPause()
  {
    // Arrange
    Dog d1 = new Dog();
    d1.HuntAnimal(); // Erste Jagd

    // Act
    bool actual = d1.HuntAnimal(); // Zweite Jagd direkt danach

    // Assert
    Assert.AreEqual(1 , d1.HuntedAnimals , "Es sollte immer noch 1 in HuntedAnimals stehen! (Pause zu kurz)");
    Assert.AreEqual(false , actual , "Es sollte false zurückgegeben werden!");
  }
}
