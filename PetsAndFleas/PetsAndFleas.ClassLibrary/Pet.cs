namespace PetsAndFleas.ClassLibrary;

public abstract class Pet
{
  #region METHODS
  // {
  //   int returnValue = amount;
  //
  //   if (returnValue < 0)
  //   {
  //     returnValue = 0;
  //     throw new ArgumentException("Biteamount can't be nagative!" , nameof(amount));
  //   }
  //   else if (returnValue == 0)
  //   {
  //     returnValue = 0;
  //   }
  //   else if (amount > RemainingBites)
  //   {
  //     returnValue = RemainingBites;
  //   }
  //   else
  //   { returnValue = amount; }
  //   return returnValue;
  // 
  // }
  public int GetBiten(int amount)
  {
    // CheckAmount(amount);
    int actualBites;
    Exception negativeAmountException = new();

    try
    {
      if (amount <= 0)
      {
        actualBites = 0;
        throw new ArgumentException("Can't be negative!" , negativeAmountException);
      }
      else if (amount > RemainingBites)
      {
        actualBites = RemainingBites;
      }
      else
        actualBites = amount;
    }
    catch (ArgumentException n)
    {
      actualBites = 0;
    }
    RemainingBites = RemainingBites - actualBites;

    return actualBites;
    /* amount < 0 ?  :
      // amount == 0 ? 0 :
      // amount > RemainingBites ? RemainingBites :
      // amount;
      */
  }

  private bool CheckAmount(int amount)
  {
    try
    {
      if (amount > 0)
        return true;
    }
    catch
    {
      throw new ArgumentException("Can't be negative!");
    }
    return false;
  }
  #endregion



  #region CONSTRUCTOR
  public Pet()
  {
    _petID = LastPetID;
  }
  #endregion

  #region PROPERTIES
  public int PetID { get => _petID; }
  public int RemainingBites 
  { 
    get => _remainingBites; 
    private set => _remainingBites = value; 
  }

  public static int LastPetID { get => _lastPetID++; }
  #endregion

  #region FIELDS
  private int
    _petID,
    _remainingBites = 100;

  private static int _lastPetID = 0;
  #endregion
}