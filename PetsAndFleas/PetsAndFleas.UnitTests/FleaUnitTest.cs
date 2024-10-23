namespace PetsAndFleas.UnitTests;

/// <summary>
///This is a test class for FleaTest and is intended
///to contain all FleaTest Unit Tests
///</summary>
[TestClass()]
public class FleaUnitTest
{
  #region FIELDS
  private static Flea? f1, f2, f3;
  private static Pet? p1, p2, p3, p4;
  #endregion

  #region INIT-TESTS
  [ClassInitialize]
  public static void Initialize(TestContext context)
  {
    f1 = new();
    f2 = new();
    f3 = new();
    p1 = new Cat();
    p2 = new Cat();
    p3 = new Dog();
    p4 = new Cat();
  }
  #endregion

  #region TESTCASES
  [TestMethod]
  public void ItShouldAssignPetCorrectly_GivenJumpOnValidPet()
  {
    // Arrange
    int startID = Pet.LastPetID;
    Pet c1 = new Cat();
    Pet d2 = new Dog();
 
    // Act
    f1.JumpOnPet(c1);
    f2.JumpOnPet(d2);
    f3.JumpOnPet(c1);

    // Assert
    Assert.AreEqual(startID + 1 , f1.ActualPet!.PetID , "Floh 1 sollte auf Pet ID {0} sitzen!" , startID + 1);
    Assert.AreEqual(startID + 2 , f2.ActualPet!.PetID , "Floh 2 sollte auf Pet ID {0} sitzen!" , startID + 2);
    Assert.AreEqual(startID + 1 , f3.ActualPet!.PetID , "Floh 3 sollte auf Pet ID {0} sitzen!" , startID + 1);

    // Act: Floh 3 springt auf Pet 2
    f3.JumpOnPet(d2);

    // Assert
    Assert.AreEqual(startID + 2 , f3.ActualPet.PetID , "Floh 3 sollte nach Übersprung auf Pet ID {0} sitzen!" , startID + 2);

    // Act: Floh 3 springt ab (kein Haustier mehr)
    f3.JumpOnPet(null);

    // Assert
    Assert.IsNull(f3.ActualPet , "Floh 3 sollte nach Absprung auf keinem Tier sitzen.");
  }
  [TestMethod]
  public void ItShouldReducePetRemainingBites_GivenValidBiteAmount()
  {
    Flea f = new();
    // Arrange
    f.JumpOnPet(p4!);

    // Act
    f.BitePet(40);
    int result = p4!.RemainingBites;

    // Assert
    Assert.AreEqual(60 , p4.RemainingBites , "Nach 40 Bissen sollten 60 übrig sein!");

    Assert.AreEqual(40 , f.AmountBites , "Floh 1 sollte 40 Bisse vollzogen haben!");
    Assert.AreEqual(60 , result , "Es sollten 60 verbleibende Bisse zurückgegeben werden.");
  }
  [TestMethod]
  public void ItShouldReturnRemainingBites_GivenBiteAmountExceedingRemainingBites()
  {
    // Arrange
    f1.JumpOnPet(p1);

    f1.BitePet(40); // 60 Bisse übrig

    // Act
    int result = f1.BitePet(70); // Versuche 70 Bisse

    // Assert
    Assert.AreEqual(60 , result , "Es sind nur noch 60 Bisse übrig, daher sollte 60 zurückgegeben werden.");
    Assert.AreEqual(100 , f1.AmountBites , "Floh 1 sollte 100 Bisse vollzogen haben.");
    Assert.AreEqual(0 , p1.RemainingBites , "Alle Bisse des Haustiers sollten aufgebraucht sein.");
  }
  [TestMethod]
  public void ItShouldReturnMaxBites_GivenAnotherPetWithFullBiteCapacity()
  {
    f1.JumpOnPet(p2);

    // Act
    int result = f1.BitePet(150); // Mehr Bisse als möglich

    // Assert
    Assert.AreEqual(100 , result , "Es sind nur 100 Bisse möglich, daher sollte 100 zurückgegeben werden.");
    Assert.AreEqual(200 , f1.AmountBites , "Floh sollte insgesamt 200 Bisse vollzogen haben.");
  }
  #endregion

  #region EXCEPTION TESTS

  /// <summary>
  /// Thrown Exceptions
  /// </summary>
  [TestMethod]
  public void ItShouldThrowArgumentException_GivenNegativeBiteAmount()
  {
    f2.JumpOnPet(p3);

    // Act & Assert
    Assert.ThrowsException<ArgumentException>(() => f2.BitePet(-100) , "Negative Bissanzahl sollte eine ArgumentException auslösen!");
  }
  [TestMethod]                                                                      ///   FAILS STILL !!
  public void ItShouldThrowInvalidOperationException_GivenFleaNotOnAnyPetAndAttemptToBite()
  {
    // Act & Assert
    Assert.ThrowsException<InvalidOperationException>(() => f1.BitePet(100) , "Floh sollte eine InvalidOperationException auslösen, wenn versucht wird zu beißen, ohne auf einem Haustier zu sein.");
  }
  [TestMethod]                                         
  public void ItShouldThrowArgumentNullException_GivenJumpOnNullPet()
  {
    // Act & Assert
    Assert.ThrowsException<ArgumentNullException>(() => f1.JumpOnPet(null) , "Das Springen auf null sollte eine ArgumentNullException auslösen.");
  }

  /// <summary>
  /// Error-corrected returns
  /// </summary>
  [TestMethod]                                                                      ///   FAILS STILL !!
  public void ItShouldReturnZero_GivenNegativeBiteAmount()
  {
    // Arrange
    f2.JumpOnPet(p3);

    // Act
    int result = f2.BitePet(-100); // Negative Anzahl an Bissen

    // Assert
    Assert.AreEqual(0 , result , "Negative Bissanzahl nicht möglich! 0 als Rückgabewert erwartet.");
    Assert.AreEqual(0 , f2.AmountBites , "Es sollten keine Bisse gezählt werden.");
  }
  [TestMethod]                                                                      ///   FAILS STILL !!
  public void ItShouldReturnZero_GivenFleaNotOnAnyPet()
  {
    // Act
    f1.JumpOnPet(null); // Floh auf keinem Haustier
    int result1 = f1.BitePet(100);
    int result2 = f3.BitePet(100); // Floh 3 ebenfalls auf keinem Haustier

    // Assert
    Assert.AreEqual(0 , result1 , "Floh sitzt auf keinem Tier, daher sollte 0 zurückgeliefert werden.");
    Assert.AreEqual(0 , result2 , "Floh sitzt auf keinem Tier, daher sollte 0 zurückgeliefert werden.");
  }
  #endregion
}