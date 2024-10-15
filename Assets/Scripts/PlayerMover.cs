using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(_rotateSpeed * rotation * Time.deltaTime * Vector3.up);
    }
    
    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = _moveSpeed * direction * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }
}
