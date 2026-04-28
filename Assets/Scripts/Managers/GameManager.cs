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

    public int TotalRoundNumber;

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

    public void AddFail()
    {

        FailedNpcNumber++;

        if (FailedNpcNumber > 2)
        {

            FailedNpcNumber = 0;

            LoadMainScene();

        }

    }

    public void LoadGainScene()
    {

        TotalRoundNumber++;

        NpcNumber = 0;

        SceneManager.LoadScene(2);

    }

    public void LoadMainScene()
    {

        TotalRoundNumber = 0;

        NpcNumber = 0;

        SceneManager.LoadScene(0);

    }

}
