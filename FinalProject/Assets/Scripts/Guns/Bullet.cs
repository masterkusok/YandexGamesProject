using UnityEngine;

class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    private void Update()
    {
        if (transform.position.z > 200)
            Destroy(gameObject);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
