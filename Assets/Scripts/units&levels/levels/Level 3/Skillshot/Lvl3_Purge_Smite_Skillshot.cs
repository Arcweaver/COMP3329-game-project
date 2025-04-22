using UnityEngine;

public class Lvl3_Purge_Smite_Skillshot : Lvl3_Smite_Skillshot
{
    void Update()
    {
        //update timer
        hitTimer -= Time.deltaTime;

        //collision check and destroy skillshot
        //might need sprite change for "shooting" the skill?
        if (hitTimer < 0f)
        {
            GenerateHammers(transform.position, unit);
            Destroy(gameObject);
        }
    }




    protected void GenerateHammers(Vector3 position, UnitTemplate userUnit)
    {
        //generate multiple skillshot in random directions
        int numberOfDirections = 3;
        GameObject skillshotPrefab = Resources.Load<GameObject>("Prefabs/lvl3PurgeHammer");

        for (int i = 0; i < numberOfDirections; i++)
        {
            float angle = (i * (360f / numberOfDirections) + 90f) * Mathf.Deg2Rad;
            Vector3 _dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

            GameObject skillshot = Object.Instantiate(skillshotPrefab, position, Quaternion.identity);
            Skillshot skillshotComponent = skillshot.GetComponent<Skillshot>();
            if (skillshotComponent != null)
            {
                skillshotComponent.Initialize(_dir, 0, sourceSkill, userUnit);
            }
        }
    }
}