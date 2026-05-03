using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public Transform bullet;
 public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Destroy(collision.gameObject);
           Destroy(gameObject);
        }
    }
}
