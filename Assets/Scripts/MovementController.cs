using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private int _speed;

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float horisontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("MoveForward", true);
            transform.Translate(new Vector3(horisontalMovement, 0, verticalMovement) * _speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetBool("MoveForward", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("MoveBack", true);
            transform.Translate(new Vector3(horisontalMovement, 0, verticalMovement) * _speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("MoveBack", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int sortOfKick = GetAleaNumber();
            switch (sortOfKick)
            {
                case 0: _animator.SetBool("Kick", true); break;
                case 1: _animator.SetBool("Strike", true); break;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("Kick", false);
            _animator.SetBool("Strike", false);
        }
    }
    private int GetAleaNumber() => Random.Range(0, 2);

}
