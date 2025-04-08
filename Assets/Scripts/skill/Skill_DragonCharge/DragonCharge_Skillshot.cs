using UnityEngine;

// template skillshot class
public class DragonChargeSkillshot : Skillshot
{

    private void Start()
    {
        //skill speed
        speed = 0f;
        //uncomment this if it is enemy skill
        //opponentTag = "Player" 

        // Destory after 2 seconds
        Destroy(gameObject, 2f);
    }

     void Update()
    {
        // Get player object
        GameObject _dummy = GameObject.FindGameObjectWithTag("Player");
        PlayerController player = _dummy.GetComponent<PlayerController>();

        UnitStat playerStats = player.GetModifiedStats();
        playerStats.moveSpeed *= 2;

        // Increase player speed
        Vector2 movement = direction.normalized * playerStats.moveSpeed; // Calculate movement vector
        player.rb.linearVelocity = movement; // Use Rigidbody2D to move the player

        //player.transform.position += 2 * Time.deltaTime * unit.moveSpeed * direction;

        // Make the skillshot stick to player
        transform.position = player.transform.position;

        // Calculate the angle based on the mouse direction
        direction = player.GetComponent<PlayerController>().GetDirectionToMouse();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        //get the unit stats to do crit modification/damage amp magic  :)
        //UnitStat sourceStat = unit.GetModifiedStats();
        //sourceStat.criticalModifier = 3f; //for example
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), 70);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        // Get player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");

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

                // Apply modifier
                PlayerController unit = player.GetComponent<PlayerController>();
                unit.AddModifier(new DragonChargeModifier());
            }
            //apply stat modifier if applicable
        }
    }

}
