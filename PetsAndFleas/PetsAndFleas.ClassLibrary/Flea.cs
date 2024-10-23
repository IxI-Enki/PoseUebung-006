namespace PetsAndFleas.ClassLibrary;

public class Flea
{
  #region METHODS
  public void JumpOnPet(Pet petToJumpOn)
  {

    _actualPet = petToJumpOn;

  }
  public int BitePet(int amount)
  {
    int possibleBites = 0;

    try
    {
      CheckForMountedPet();

      CheckAmount(amount);
    }
    catch (InvalidOperationException)
    {
      possibleBites = 0;
    }
    catch (ArgumentException)
    {
      possibleBites = 0;
    }
    finally
    {
      if (ActualPet != null)
        possibleBites = ActualPet!.GetBiten(amount);
      else
        possibleBites = 0;
      _amountBites += possibleBites;
    }
    return possibleBites;
  }

  private bool CheckAmount(int amount)
    => (amount <= 0) ?
        throw new ArgumentException("! BiteAmount can't be 0 or negative !")
        : true;
  private bool CheckForMountedPet()
    => (ActualPet == null) ? 
        throw new InvalidOperationException("! There is no Pet to bite !") 
        : true;
  #endregion



  #region PROPERTIES
  public Pet? ActualPet { get => _actualPet; }
  public int AmountBites { get => _amountBites; }
  #endregion

  #region FIELDS
  private Pet? _actualPet = null;  ///    -  
  private int _amountBites = 0;    ///    -  
  #endregion
}