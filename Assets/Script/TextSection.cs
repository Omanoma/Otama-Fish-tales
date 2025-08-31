[System.Serializable]
public struct TextSection
{
    public Character character;
    public string speech;

    public override string ToString()
    {
        return character.ToString() + " (" + speech + ")";
    }
}

public enum Character
{
    Narrator = 0,
    Kial = 1,
    OP = 2,
    Action = 3,

}

