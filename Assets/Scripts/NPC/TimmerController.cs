using UnityEngine;

public class TimmerController : MonoBehaviour
{

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {

        _anim.Play("TimmerAnim");

    }

    public void StopAnim()
    {

        _anim.Play("TimmerIdle");

    }

    public void ParenLeave()
    {

        GameManager.Instance.FailedNpcNumber++;

        transform.parent.GetComponent<NpcController>().Leave();

    }
}
