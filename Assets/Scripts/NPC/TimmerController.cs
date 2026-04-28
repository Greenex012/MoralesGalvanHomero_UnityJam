using UnityEngine;
using UnityEngine.UIElements;

public class TimmerController : MonoBehaviour
{

    private Animator _anim;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _anim = GetComponent<Animator>();

        _renderer = GetComponent<SpriteRenderer>();
    }

    public void PlayAnim()
    {

        _renderer.enabled = true;

        _anim.Play("TimmerAnim");

    }

    public void StopAnim()
    {

        _renderer.enabled = false;

        _anim.Play("TimmerIdle");

    }

    public void ParenLeave()
    {

        GameManager.Instance.AddFail();

        _renderer.enabled = false;

        transform.parent.GetComponent<NpcController>().Fail();

    }
}
