namespace PetsAndFleas.ClassLibrary;

public class Flea
{
  #region METHODS
  public void JumpOnPet(Pet petToJumpOn) => _actualPet = petToJumpOn;
  public int BitePet(int amount)
  {

    int delta = 0;
    if (ActualPet != null)
    {
      delta = ActualPet.GetBiten(amount);

      _amountBites += delta;

    }
    return delta;
  }
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