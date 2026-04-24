using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class NpcController : MonoBehaviour
{

    private bool _leaving;

    [SerializeField] private float _speed;

    [SerializeField] private Vector3 _leavePos;

    [SerializeField] private Vector3 _attendPos;

    private Rigidbody2D _rb;

    [SerializeField] private ItemType _wanted;

    public ItemType Wanted { get => _wanted; set => _wanted = value; }

    [SerializeField] private TimmerController _timmer;

    [SerializeField] private GameObject _backCollider;

    private int mask;

    [SerializeField] private GameObject _though;

    [SerializeField] private Sprite _sword;

    [SerializeField] private Sprite _shield;

    [SerializeField] private Sprite _potion;

    private bool _last = false;

    public bool Last { get => _last; set => _last = value; }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        mask = ~LayerMask.GetMask("Npc");

        int i = Random.Range(1, 4);

        switch (i)
        {

            case 1:

                _wanted = ItemType.Sword;

                _though.GetComponent<SpriteRenderer>().sprite = _sword;

                break;

            case 2:

                _wanted = ItemType.Shield;

                _though.GetComponent<SpriteRenderer>().sprite = _shield;

                break;

            case 3:

                _wanted = ItemType.Potion;

                _though.GetComponent<SpriteRenderer>().sprite = _potion;

                break;
        }

        _though.SetActive(false);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameManager.Instance.NpcNumber++;

        transform.position = _leavePos;

        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, mask);


        if (!hit)
        {

            Move();

        }
        else
        { 

            _rb.linearVelocity = Vector2.zero;

        }

    }

    public void Move()
    {

        _rb.linearVelocity = _speed * Vector2.right;

    }

    public void Leave()
    {

        _leaving = true;

        _backCollider.SetActive(false);

        _though.SetActive(false);

        GetComponent<BoxCollider2D>().enabled = false;

        transform.DOMove(_leavePos, _speed).SetEase(Ease.Linear).OnComplete(Leaved);

    }

    public void Fail()
    {
        Leave();
    }

    public void InitTimmer()
    {

        _though.SetActive(true);

        _timmer.PlayAnim();

    }

    public void StopTimmer()
    {

        _timmer.StopAnim();

    }

    private void Leaved()
    {

        GameManager.Instance.NpcNumber -= 1;

        if (Last)
        {

            GameManager.Instance.LoadGainScene();

        }

        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + new Vector3(1f, 0, 0));

    }

}
