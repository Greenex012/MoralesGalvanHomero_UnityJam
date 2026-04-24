using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rayLenght;

    LayerMask mask;

    private bool _onGround;

    [SerializeField] private PlayerStateEnum _currentState;

    private Rigidbody2D _rb;

    private GatherInput _input;

    [SerializeField] private float _speed;

    [SerializeField] private float _jumpForce;

    private ItemData _itemData;
    public ItemData ItemData { get => _itemData; set => _itemData = value; }

    private PlayerTrigger _trigger;

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private GameObject _itemRenderer;

    private void Awake()
    {
        mask = LayerMask.GetMask("Ground");

        _rb = GetComponent<Rigidbody2D>();

        _input = GetComponent<GatherInput>();

        _trigger = GetComponentInChildren<PlayerTrigger>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentState = PlayerStateEnum.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        if (_rb.linearVelocityX < 0)
        {

            _renderer.flipX = false;

        }
        else if (_rb.linearVelocityX > 0)
        {

            _renderer.flipX = true;

        }

        switch(_currentState)
        {

            case PlayerStateEnum.Idle:

                if(_input.MoveX != 0f)
                {

                    ChangeState(PlayerStateEnum.Move);

                }

                Jump();

                GrabItem();

                GrabLadder();

                break;

            case PlayerStateEnum.Move:

                if (_input.MoveX == 0f)
                {

                    ChangeState(PlayerStateEnum.Idle);

                }

                Jump();

                GrabItem();

                GrabLadder();

                break;

            case PlayerStateEnum.Jump:

                if (!_input.Jump)
                {

                    ChangeState(PlayerStateEnum.Fall);

                }

                GrabItem();

                GrabLadder();

                break;

            case PlayerStateEnum.Fall:

                GrabItem();

                GrabLadder();

                break;

            case PlayerStateEnum.ClimbIdle:

                if (_input.MoveY != 0f)
                {

                    ChangeState(PlayerStateEnum.ClimMove);

                }

                if (_input.MoveX != 0f)
                {

                    ChangeState(PlayerStateEnum.Move);

                }

                Jump();

                break;

            case PlayerStateEnum.ClimMove:

                if (_input.MoveY == 0f)
                {

                    ChangeState(PlayerStateEnum.ClimbIdle);

                }

                if (_input.MoveX != 0f)
                {

                    ChangeState(PlayerStateEnum.Move);

                }

                Jump();

                break;

        }
    }

    private void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayLenght, mask);

        if (hit)
        {

            _onGround = true;

        }
        else
        {

            _onGround = false;

        }

        switch (_currentState)
        {

            case PlayerStateEnum.Idle:

                _rb.linearVelocityX = 0f;

                if (!_onGround)
                {

                    ChangeState(PlayerStateEnum.Fall);

                }

                break;

            case PlayerStateEnum.Move:

                _rb.linearVelocityX = _speed * _input.MoveX;

                if (!_onGround)
                {

                    ChangeState(PlayerStateEnum.Fall);

                }

                break;

            case PlayerStateEnum.Jump:

                _rb.linearVelocityX = _speed * _input.MoveX;

                if (_rb.linearVelocityY < 0)
                {

                    ChangeState(PlayerStateEnum.Fall);

                }

                break;

            case PlayerStateEnum.Fall:

                _rb.linearVelocityX = _speed * _input.MoveX;

                if (_onGround)
                {

                    if (_rb.linearVelocityX != 0)
                    {

                        ChangeState(PlayerStateEnum.Move);

                    }
                    else
                    {

                        ChangeState(PlayerStateEnum.Idle);

                    }

                }

                break;

            case PlayerStateEnum.ClimbIdle:

                _rb.linearVelocity = Vector2.zero;

                break;

            case PlayerStateEnum.ClimMove:

                _rb.linearVelocityX = 0;

                _rb.linearVelocityY = _speed * _input.MoveY;

                break;

        }

    }

    private void ChangeState(PlayerStateEnum state)
    {

        StateEnd();

        _currentState = state;

        StateStart();

    }

    private void StateStart()
    {
        switch (_currentState)
        {

            case PlayerStateEnum.Idle:

                _rb.linearVelocityX = 0f;

                break;

            case PlayerStateEnum.Move:

                break;

            case PlayerStateEnum.Jump:

                _rb.linearVelocityY += _jumpForce;

                break;

            case PlayerStateEnum.Fall:

                _rb.linearVelocityY /= 4;

                break;

            case PlayerStateEnum.ClimbIdle:

                _rb.gravityScale = 0f;

                break;

            case PlayerStateEnum.ClimMove:

                _rb.gravityScale = 0f;

                break;

        }
    }

    private void StateEnd()
    {
        switch (_currentState)
        {

            case PlayerStateEnum.Idle:

                break;

            case PlayerStateEnum.Move:

                break;

            case PlayerStateEnum.Jump:

                break;

            case PlayerStateEnum.Fall:

                break;

            case PlayerStateEnum.ClimbIdle:

                _rb.gravityScale = 3f;

                break;

            case PlayerStateEnum.ClimMove:

                _rb.gravityScale = 3f;

                break;

        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -_rayLenght, 0));

    }

    private void GrabItem()
    {

        if (_input.GrabItem)
        {

            ItemData = _trigger.ItemData;

            if (ItemData != null)
            {

                _itemRenderer.GetComponent<SpriteRenderer>().sprite = ItemData.sprite;

            }

        }

    }

    public void LeaveItem()
    {

        if (ItemData != null)
        {
            ItemData = null;

            _itemRenderer.GetComponent<SpriteRenderer>().sprite = null;

        }

    }

    private void GrabLadder()
    {

        if (_input.GrabLader && _trigger.InLadder)
        {

            ChangeState(PlayerStateEnum.ClimbIdle);

        }

    }

    private void Jump()
    {

        if (_input.Jump)
        {

            ChangeState(PlayerStateEnum.Jump);

        }

    }
}
