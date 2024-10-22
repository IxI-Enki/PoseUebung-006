namespace PetsAndFleas.ClassLibrary;

public sealed class Dog : Pet
{
  #region METHODS
  public bool HuntAnimal()
    => LastHuntIsAtLeastOneSecondInThePast && CanHunt();

  /*    PRIVATE HelperMethods:    */
  private bool LastHuntIsAtLeastOneSecondInThePast
    => DateTime.Now - _lastHuntedTime > TimeSpan.FromSeconds(1);
  private bool CanHunt()
  {
    _huntedAnimals++;
    _lastHuntedTime = DateTime.Now;
    return true;
  }
  #endregion

  #region CONSTRUCTOR
  public Dog() : base() { }
  #endregion

  #region PROPERTIES
  public int HuntedAnimals { get => _huntedAnimals; }
  #endregion

  #region FIELDS
  private int _huntedAnimals = 0;
  private DateTime _lastHuntedTime = DateTime.MinValue;
  #endregion
}