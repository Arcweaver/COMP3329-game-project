using UnityEngine;

// template skillshot class
public class Skillshot : MonoBehaviour
{
    public float speed = 100f;
    public Vector3 direction;
    public int affix = 0;
    public UnitTemplate unit;
    public string opponentTag = "Enemy";

    

    public virtual void Initialize(Vector3 dir, int affixValue, UnitTemplate userUnit)
    {
        unit = userUnit;
        direction = dir.normalized;
        affix = affixValue;
        Destroy(gameObject, 5f); // Destroy skillshot after 5 seconds if it doesn't hit anything
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        // Calculate the angle based on the movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected virtual void SkillEffect(UnitTemplate enemy)
    {
        enemy.TakeDamage(1);
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), 1);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        GameObject collidedObject = obj.gameObject;
        // Example of how you might use the affix during collision
        if (collidedObject.CompareTag(opponentTag))
        {
            UnitTemplate enemy = collidedObject.GetComponent<UnitTemplate>();
            // collision/damange logic
            if (enemy != null)
            {
                Destroy(gameObject);
                SkillEffect(enemy);
                Debug.Log("Enemy damaged");
            }
            //apply stat modifier if applicable
        }
    }

    void OnBecameInvisible() { Destroy(gameObject); }
}
