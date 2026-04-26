using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.UIElements.ToolbarMenu;

public class GainManager : MonoBehaviour
{

    [SerializeField] private GameObject _tier1HUD;

    [SerializeField] private Button _tier1Btn;

    [SerializeField] private int _tier1Price;

    [SerializeField] private GameObject _tier2HUD;

    [SerializeField] private Button _tier2Btn;

    [SerializeField] private int _tier2Price;

    [SerializeField] private TMP_Text _gainValue;

    [SerializeField] private TMP_Text _roundValue;

    private void Awake()
    {
        
        if (GameManager.Instance.ItemSet1)
        {

            _tier1HUD.SetActive(false);

        }
        else if (GameManager.Instance.Money < _tier1Price)
        {

            _tier1Btn.interactable = false;

        }

        if (GameManager.Instance.ItemSet2)
        {

            _tier2HUD.SetActive(false);

        }
        else if (GameManager.Instance.Money < _tier2Price)
        {

            _tier2Btn.interactable = false;

        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _gainValue.text = GameManager.Instance.Money.ToString();

        _roundValue.text = GameManager.Instance.TotalRoundNumber.ToString();

    }

    public void BuyTier1()
    {

        GameManager.Instance.ItemSet1 = true;

        _tier1HUD.SetActive(false);

    }

    public void BuyTier2()
    {

        GameManager.Instance.ItemSet2 = true;

        _tier2HUD.SetActive(false);

    }

    public void Continue()
    {

        SceneManager.LoadScene(0);

    }

}
