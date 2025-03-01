using UnityEngine;

// template skillshot class
public class Skillshot : MonoBehaviour
{
    public float speed = 100f;
    public Vector3 direction;
    public int affix = 0;

    

    public void Initialize(Vector3 dir, int affixValue)
    {
        direction = dir.normalized;
        direction.y = 1;
        affix = affixValue;
        Destroy(gameObject, 5f); // Destroy skillshot after 5 seconds if it doesn't hit anything
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    protected virtual void skillEffect()
    {

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        GameObject collidedObject = obj.gameObject;
        // Example of how you might use the affix during collision
        if (collidedObject.CompareTag("Enemy"))
        {
            EnemyTemplate enemy = collidedObject.GetComponent<EnemyTemplate>();
            // collision/damange logic
            if (enemy != null)
            {
                Destroy(gameObject);
                enemy.TakeDamage(1);
                Debug.Log("Enemy damaged");
            }
            //apply stat modifier if applicable
        }
    }

    void OnBecameInvisible() { Destroy(gameObject); }
}
