using System.Collections;
using UnityEngine;

public class NpcFactory : MonoBehaviour
{

    [SerializeField] private float _interval;

    [SerializeField] private int _targetCuantity;

    [SerializeField] private GameObject _npc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine("CreateNPC");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateNPC()
    {

        GameObject NewNpc;

        while (true)
        {

            for (int i = _targetCuantity + (GameManager.Instance.TotalRoundNumber * 2); i != 0; i--)
            {

                if (GameManager.Instance.NpcNumber < GameManager.Instance.MaxNpcs)
                {

                    NewNpc = Instantiate(_npc);

                    if (i == 1)
                    {

                        NewNpc.GetComponent<NpcController>().Last = true;

                    }

                    yield return new WaitForSeconds(_interval);

                }
                else
                {

                    i++;

                    yield return new WaitForSeconds(_interval);

                }

            }

            yield break;

        }

    }
}
