using DG.Tweening;
using TMPro;
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

    [SerializeField] private TMP_Text _moneyDisplayValue;

    private AudioSource _audio;

    [SerializeField] private AudioClip _audioSellSucces;

    [SerializeField] private AudioClip _audioSellFail;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _buttons.SetActive(false);

        UpdateMoneyDisplay();

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

        PlaySuccesSound();

        UpdateMoneyDisplay();

    }

    public void SellMedium()
    {

        int _chance = Random.Range(0, 100);

        if (_chance < 75)
        {

            GameManager.Instance.AddMoney((int)Mathf.Floor(_player.ItemData.Value * 1.25f));

            Debug.Log("SI");

            PlaySuccesSound();

            UpdateMoneyDisplay();

        }
        else
        {

            Debug.Log("NO");

            PlayFailSound();

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

            PlaySuccesSound();

            UpdateMoneyDisplay();

        }
        else
        {

            Debug.Log("NO");

            PlayFailSound();

        }

        _currentClient.Leave();

        _player.LeaveItem();

        _buttons.SetActive(false);

    }

    private void PlaySuccesSound()
    {

        _audio.generator = _audioSellSucces;

        _audio.Play();

    }

    private void PlayFailSound()
    {

        _audio.generator = _audioSellFail;

        _audio.Play();

    }

    private void UpdateMoneyDisplay()
    {

        _moneyDisplayValue.text = GameManager.Instance.Money.ToString();

    }

}
