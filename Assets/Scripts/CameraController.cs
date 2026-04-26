using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    [SerializeField] private Vector3 _camPos1;

    [SerializeField] private Vector3 _camPos2;

    [SerializeField] private float _doTime;

    [SerializeField] private NpcController _currentClient;

    private PlayerMovement _player;

    [SerializeField] private GameObject _buttons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            _camera.transform.DOMove(_camPos2, _doTime);

            _player = collision.GetComponent<PlayerMovement>();

            if (collision.GetComponent<PlayerMovement>().ItemData != null && _currentClient != null)
            {

                if (_player.ItemData.Type == _currentClient.Wanted)
                {

                    _currentClient.StopTimmer();

                    _buttons.SetActive(true);

                }

            }

        }

        if (collision.CompareTag("Npc"))
        {

            _currentClient = collision.GetComponent<NpcController>();

            _currentClient.InitTimmer();

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            _camera.transform.DOMove(_camPos1, _doTime);

            if (_currentClient != null)
            {

                _currentClient.InitTimmer();

                _buttons.SetActive(false);

            }
        }

        if (collision.CompareTag("Npc"))
        {

            _currentClient = null;

        }

    }

    public void SellEasy()
    {

        GameManager.Instance.AddMoney(_player.ItemData.Value);

        _currentClient.Leave();

        _player.LeaveItem();

        _buttons.SetActive(false);

    }

    public void SellMedium()
    {

        int _chance = Random.Range(0, 100);

        if (_chance < 75)
        {

            GameManager.Instance.AddMoney((int)Mathf.Floor(_player.ItemData.Value * 1.25f));

            Debug.Log("SI");

        }
        else
        {

            Debug.Log("NO");

        }

        _currentClient.Leave();

        _player.LeaveItem();

        _buttons.SetActive(false);

    }

    public void SellRisky()
    {

        int _chance = Random.Range(0, 100);

        if (_chance < 50)
        {

            GameManager.Instance.AddMoney((int)Mathf.Floor(_player.ItemData.Value * 1.5f));

            Debug.Log("SI");

        }
        else
        {

            Debug.Log("NO");

        }

        _currentClient.Leave();

        _player.LeaveItem();

        _buttons.SetActive(false);

    }
}
