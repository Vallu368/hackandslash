using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiBlast : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public GameObject blastVFXPrefab;
    public float projectileSpeed = 10;
    public int energyDrain = 5;

    private PlayerStats stats;
    private AimBehaviourBasic aim;
    void Start()
    {
        stats = this.gameObject.GetComponent<PlayerStats>();
        aim = this.gameObject.GetComponent<AimBehaviourBasic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aim.aim)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (stats.currentEnergy >= energyDrain)
                {
                    stats.currentEnergy = stats.currentEnergy - energyDrain;
                    Debug.Log("fired projectile");
                    //Instantiate(blastVFXPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                    var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                    projectile.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * projectileSpeed;
                }
                else
                {
                    Debug.Log("not enough energy");
                }
                
            }
        }
    }
}
