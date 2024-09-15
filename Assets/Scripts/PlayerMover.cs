using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotateSpeed;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");

        transform.Rotate(_rotateSpeed * rotation * Time.deltaTime * Vector3.up);
    }
    
    private void Move()
    {
        float direction = Input.GetAxis("Vertical");
        float distance = _moveSpeed * direction * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }
}
