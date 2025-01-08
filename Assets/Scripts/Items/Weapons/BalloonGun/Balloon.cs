using UnityEngine;

public class Balloon : MonoBehaviour
{
    private new Rigidbody rigidbody = null;
    private float lifetime = 5.0f;
    private IWeapon weapon = null;

    public void Initialize(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 10.0f, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                weapon?.OnShot(collision.collider);
            }

            Destroy(gameObject);
        }
    }
}
