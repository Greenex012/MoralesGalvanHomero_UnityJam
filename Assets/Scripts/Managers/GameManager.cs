using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int _money;

    public bool ItemSet1;

    public bool ItemSet2;

    public int NpcNumber;

    public int FailedNpcNumber;

    [SerializeField] private int _maxNpcs;
    public int MaxNpcs { get => _maxNpcs; set => _maxNpcs = value; }

    public int Money {
        
        get
        {

            return _money;

        }

        set
        {

            _money = value;

            if (_money < 0)
            {

                _money = 0;

            }

        }
    }

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);

        }

    }

    public void AddMoney(int money)
    {

        Money += money;

    }

    public void RemoveMoney(int money)
    {
        
        Money -= money;

    }

    public void LoadGainScene()
    {

        SceneManager.LoadScene(1);

    }

    public void LoadMainScene()
    {



    }

}
