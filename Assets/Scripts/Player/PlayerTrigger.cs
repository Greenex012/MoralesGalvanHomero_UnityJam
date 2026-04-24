using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    private ItemData _itemData;
    public ItemData ItemData { get => _itemData; set => _itemData = value; }

    private bool _inLadder;
    public bool InLadder { get => _inLadder; set => _inLadder = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {

            _itemData = collision.GetComponent<ItemController>().Data;

        }

        if (collision.CompareTag("Ladder"))
        {

            _inLadder = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {

            _itemData = null;

        }

        if (collision.CompareTag("Ladder"))
        {

            _inLadder = false;

        }
    }
}
