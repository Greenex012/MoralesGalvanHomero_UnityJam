using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{

    public ItemType Type;

    public Sprite sprite;

    public int Value = 0;

    public int Set = 0;

}
