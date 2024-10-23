namespace PetsAndFleas.ClassLibrary;

public abstract class Pet
{
  #region METHODS
  public int GetBiten(int numberOfBites)
  {
    int actualBites;

    try
    {
      CheckBiteNumber(numberOfBites);
    }
    catch (ArgumentException)
    {
      return 0;
    }
    finally
    {
      if (numberOfBites > RemainingBites)
        actualBites = RemainingBites;
      else if (numberOfBites <= 0)
        actualBites = 0;
      else
        actualBites = numberOfBites;

      _remainingBites -= actualBites;
    }
    return actualBites;
  }

  private bool CheckBiteNumber(int numberOfBites)
    => (numberOfBites <= 0) ?
        throw new ArgumentException("Number of Bites can't be 0 or negative!")
        : true;
  #endregion

  #region CONSTRUCTOR
  public Pet()
  {
    PetID = LastPetID + 1;
    LastPetID++;
  }
  #endregion

  #region PROPERTIES
  public int PetID { get => _petID; private set => _petID = value; }
  public int RemainingBites => Math.Max(_remainingBites , 0);

  public static int LastPetID { get => _lastPetID; private set => _lastPetID = value; }


  #endregion

  #region FIELDS
  private int
    _petID,
    _remainingBites = 100;

  private static int _lastPetID = 0;
  #endregion
}