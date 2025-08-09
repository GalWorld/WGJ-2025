[System.Serializable]
public class CardEffect
{
    public enum EffectType { Life, Luck, Power }
    public EffectType type;
    public float value;
}

