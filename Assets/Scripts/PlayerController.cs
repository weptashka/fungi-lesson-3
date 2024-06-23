using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private class AnimatorKeys
    {
        public static int IsWalk = Animator.StringToHash("IsWalk");
        public static int Death = Animator.StringToHash("Death");
    }

    [Header("Animator")]
    [SerializeField] private Animator _animator;
    [Header("Movement Control")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    private string _horizontalAxis = "Horizontal";
    private string _verticallAxis = "Vertical";

    private void Update()
    {
        var axis = GetAxis();

        Move(axis);
        Animate(axis);
    }

    private Vector3 GetAxis()
    {
        var horizontalAxis = Input.GetAxisRaw(_horizontalAxis);
        var verticalAxis = Input.GetAxisRaw(_verticallAxis);

        return new Vector3(horizontalAxis, verticalAxis);
    }

    private void Move(Vector3 axis) 
    {
        _rb.MovePosition(transform.position + axis * (Time.deltaTime * _speed));
    }

    
    private void Animate(Vector3 axis) 
    {
        _animator.SetBool(AnimatorKeys.IsWalk, !axis.Equals(Vector3.zero));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(AnimatorKeys.Death);
        }
    }

    private void Test()
    {
        Debug.Log("DEATH EVENT");
    }
}
