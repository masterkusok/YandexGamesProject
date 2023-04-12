using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;
    private void Update()
    {
        if (Mathf.Abs(transform.position.z) > 200)
            Destroy(gameObject);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
