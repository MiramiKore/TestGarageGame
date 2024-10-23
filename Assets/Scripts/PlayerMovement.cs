using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10; // Скорость движения
    
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Перемещение игрока
    private void Move()
    {
        var xMoveAxis  = Input.GetAxis("Horizontal");
        var zMoveAxis = Input.GetAxis("Vertical");
        
        var moveDirection = new Vector3(xMoveAxis, 0, zMoveAxis).normalized;

        _rb.velocity = moveDirection * moveSpeed;
    }
}