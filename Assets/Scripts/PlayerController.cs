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
        var horizontalAxis = Input.GetAxisRaw(_horizontalAxis);
        var verticallAxis = Input.GetAxisRaw(_verticallAxis);


        var isWalk = horizontalAxis != 0 || verticallAxis != 0;

        _animator.SetBool(AnimatorKeys.IsWalk, isWalk);

        Vector3 _inputVector = new Vector3(horizontalAxis, verticallAxis, 0);

        _rb.MovePosition(transform.position + _inputVector * Time.deltaTime * _speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(AnimatorKeys.Death);
        }
    }


}
