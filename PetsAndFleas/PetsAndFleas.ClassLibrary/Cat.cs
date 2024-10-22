namespace PetsAndFleas.ClassLibrary;

public sealed class Cat : Pet
{
  #region METHODS
  public bool ClimbDown()
  {
    if (IsOnTree)
    {
      IsOnTree = false;
      return true;
    }
    else
      return false;
  }

  public bool ClimbOnTree()
  {
    if (!IsOnTree)
    {
      TreesClimbed++;
      IsOnTree = true;
      return true;
    }
    else
      return false;
  }
  #endregion

  #region CONSTRUCTOR
  public Cat() : base() { }
  #endregion 

  #region PROPERTIES
  public int TreesClimbed
  {
    get => _treesClimbed;
    private set => _treesClimbed = value;
  }
  public bool IsOnTree
  {
    get => _isOnTree;
    set => _isOnTree = value;
  }
  #endregion

  #region FIELDS
  bool _isOnTree = false;
  int _treesClimbed = 0;
  #endregion
}