using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public string enemyType;
    public string weakness;
    public double weaknessMultiplier;

    public float maxSpeed;
    private float speed;

    private Collider[] hitColliders;
    private RaycastHit hit;

    public float sightLimit;
    public float detectionLimit;

    public Rigidbody rigidBody;
    public GameObject target;

    private bool seesTarget;

    private float Cooldown = 1;
    private bool CooldownActive = false;

    public Transform bulletStartPos;
    public GameObject bulletPrefabObj;
    public float bulletSpeed = 20;

    private Dictionary<string, Color> enemyColor = new Dictionary<string, Color>();

    void Start()
    {

        enemyColor.Add("Fire", Color.red);
        enemyColor.Add("Water", Color.blue);
        enemyColor.Add("Nature", Color.green);
        enemyColor.Add("Psychic", Color.rebeccaPurple);

        speed = maxSpeed;
        print(speed);

        if (enemyType == "Fire")
        {
            weakness = "Water";
        }
        else if (enemyType == "Water")
        {
            weakness = "Nature";
        }
        else if (enemyType == "Nature")
        {
            weakness = "Fire";
        }

        gameObject.GetComponent<Renderer>().material.color = enemyColor[enemyType];
    }
    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        CooldownActive = false;
    }

    void Update()
    {
        if (!seesTarget)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionLimit);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    target = hitCollider.gameObject;
                    seesTarget = true;
                }
            }
        }
        else 
        {
            print("is this working? target: " + target);
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, sightLimit)) 
            {
                print("testestest? has tag: " + hit.collider.CompareTag("Player"));
                if (hit.collider.CompareTag("Player"))
                {
                    print("nono see target");
                    seesTarget = false;
                }
                else
                {
                    print("see target");
                    var heading = target.transform.position - transform.position;
                    var distance = heading.magnitude;
                    var direction = heading / distance;

                    Vector3 move = new Vector3(direction.x * speed, 0, direction.z * speed);
                    rigidBody.linearVelocity = move;
                    transform.forward = move;

                    if (!CooldownActive) 
                    {
                        CooldownActive = true;

                        var magicBullet = Instantiate(bulletPrefabObj, bulletStartPos.position + transform.forward, bulletStartPos.rotation);
                        magicBullet.GetComponent<Rigidbody>().linearVelocity = bulletStartPos.forward * bulletSpeed;
                        magicBullet.GetComponent<Renderer>().material.SetColor("_BaseColor", enemyColor[enemyType]);
                        magicBullet.GetComponent<NewMonoBehaviourScript>().isPlayerOwned = false;
                        magicBullet.name = enemyType;

                        StartCoroutine(StartCooldown());
                    }
                }
            }
        }
    }
}
