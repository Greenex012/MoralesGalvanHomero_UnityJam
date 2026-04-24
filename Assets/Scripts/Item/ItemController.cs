using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    [SerializeField] private ItemData _data;

    public ItemData Data { get => _data; set => _data = value; }

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _renderer.sprite = Data.sprite;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (_data.Set == 1 && !GameManager.Instance.ItemSet1)
        {

            gameObject.SetActive(false);

        }

        if (_data.Set == 2 && !GameManager.Instance.ItemSet2)
        {

            gameObject.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
