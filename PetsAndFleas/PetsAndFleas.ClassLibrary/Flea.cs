namespace PetsAndFleas.ClassLibrary;

public class Flea
{
  #region METHODS
  public void JumpOnPet(Pet petToJumpOn)
  {
    try
    {
      CheckForPet(petToJumpOn);
    }
    catch (InvalidOperationException  )
    {
      petToJumpOn = null;
      throw new ArgumentNullException();
    }
    finally
    {
      _actualPet = petToJumpOn;
    }
  }
  public int BitePet(int amount)
  {
    int possibleBites;

    try
    {
      CheckForPet(ActualPet);
      CheckAmount(amount);
    }
    catch (InvalidOperationException noPetExec)
    {
      possibleBites = 0;
      throw noPetExec;
    }
    catch (ArgumentException invalidBiteAmountExec)
    {
      possibleBites = 0;
      throw invalidBiteAmountExec;
    }
    finally
    {
      possibleBites = (ActualPet == null) ? 0 : ActualPet!.GetBiten(amount);
      _amountBites += possibleBites;
    }
    return possibleBites;
  }

  private bool CheckAmount(int amount, Exception? invalidBiteAmountExec = null)
    => (amount <= 0) ?
        throw new ArgumentException("! BiteAmount can't be 0 or negative !", invalidBiteAmountExec)
        : true;

  private bool CheckForPet(Pet? petToCheck, Exception? noPetExec = null)
    => (petToCheck == null) ?
        throw new InvalidOperationException($"! There is no Pet - {nameof(petToCheck)} !",noPetExec)
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