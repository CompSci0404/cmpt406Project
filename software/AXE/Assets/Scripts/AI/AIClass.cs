using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
///  AIClass, think of this piece of software as a toolbox.
///  We can use this class to build and construct any AI we wish using
///  pre-defiend functions already built to help construct and build our AI's 
///  Decision Tree.
///  
/// </summary>
public abstract class AIClass : MonoBehaviour
{
    public float speed;                     /*the speed at how fast a movement based AI can move.*/
    public float fov;                       /*The field of view a AI has, when making decisions its sight.*/
    public float range;                     /*Range before a Ranged AI can attack.*/
    public float health;                    /*the ammount of health a AI has.*/
    public int atkDamage = 1;               /*The ammount of damage a AI can deal.*/
    public float tooCloseRange;             /*only enforced when this unit is retreating*/
    public float velocityOfRangedAttack;    /*the speed of how fast a bullet can leave from a AI.*/
    public float rangedAttackCooldown;      /*the cool down before a Range AI can fire again.*/
    public GameObject[]  spawnPoints;
    public GameObject ParticleDamage;
    public Sprite helShield;

    protected DecisionTree rootOfTree;      /*this is the root of the tree. for the decision tree. All classes extended from this super class have access to this function call.*/

    private bool controlToPf = false;               /*Is Path finding needed? This will be set by code.*/
    private float saveSpeed;                /*The inital speed a AI originally had.*/
    private GameObject player;
    private List<GameObject> rangePrefabs;  /* all bullet prefabs for AI are stored in this list. */
    private float cooldown;                 /*actual timer inbetween range attacks.*/
    private string currentAct;              /*the current action the specific AI is taking. communicated to the animation script.*/
    private float teleportCoolDown = 0;     /*cool down before AI can teleport.*/
    private float teleportTimerSet = 3;     /*^*/
    private RaycastHit2D hit;               /*used in AI teleporation, a ray cast to determine if the AI is going to teleport out of a wall.*/
    private int rangePrefabIndex;           /*the index for range projetcile gameobject.*/
    private int enemySpawnIndex;            /*index of wanted enemy to spawn.*/
    private List<GameObject> AIPrefabs;
    
    /*Hel*/
    private GameObject oldLaserObject;
    private bool laserSpawned;
    private float laserSpeed = 60;
    private float spawnTimer = 10;
    private float spawnCoolDown = 0;
    private float halfedHP;
    private float totalHP;
    private bool setupShield = false;
    private bool phase2 = false;
    
 
    //---[[pre-setup calls (call these before building the decision tree in start.)]]---//

    /// <summary>
    /// <c>SetSaveSpeed</c>
    /// pre: Set the speed
    /// post: save the speed that was original given in the unity inspector.
    /// </summary>
    /// <returns>nothing</returns>
    public void SetSaveSpeed()
    {
        this.saveSpeed = speed; 
    }



    public void findHalfedHealth()
    {

        halfedHP = health / 2;
        totalHP = health; 
    }

    /// <summary>
    /// <c>FindPlayer()</c>: 
    /// pre: player within same scene
    /// post: Saves a reference to the gameobject titled player.
    /// return: nothing.
    /// </summary>
   /// <returns>nothing</returns>
    public void FindPlayer()
    {
        this.player = GameObject.FindWithTag("Player"); 
    }


    /// <summary>
    /// <c>SetCooldown</c>
    ///
    /// pre: called before decision tree.
    /// post: sets the cooldown time to 0
    /// </summary>
    /// <returns>nothing</returns>
    public void SetCooldown()
    {
        this.cooldown = 0; 
    }


    /// <summary>
    ///  <c>BuildRangePrefabs</c>
    ///  pre: ensure there is prefabs located in the /prefabs/rangeAttacks prefab folder.
    ///  post: builds a list containing references to each prefab located in rangeAttack folder.
    ///  
    /// </summary>
    /// <returns>nothing</returns>
    public void BuildRangePrefabs()
    {
        rangePrefabs = new List<GameObject>();
        AIPrefabs = new List<GameObject>();
        oldLaserObject = null; 

        object[] prefabs;
        int counter = 0; 

        prefabs = Resources.LoadAll("rangeAttacks", typeof(GameObject)); 

        while(counter < prefabs.Length)
        {
            GameObject newItem = (GameObject)prefabs[counter];

            rangePrefabs.Add(newItem);

            counter++; 
        }

        counter = 0;
        object[] AI;

        AI = Resources.LoadAll("AI", typeof(GameObject)); 

        while(counter < AI.Length)
        {
            GameObject enemy = (GameObject)AI[counter];


            AIPrefabs.Add(enemy); 
            counter++; 
        }

    }

    public void FindProj(string nameRngGameObject)
    {
        int counter = 0; 

        while(counter < rangePrefabs.Count)
        {

            if (rangePrefabs[counter].name.Equals(nameRngGameObject))
            {

                this.rangePrefabIndex = counter;
                return;
            } 

            counter++; 
        }


        Debug.LogError("You have not correctly setup this AI, ensure you entered the correct name" +
            " of the projectile. You entered: \n "+ nameRngGameObject);

    }

    public void FindAIPrefab(string aiName)
    {

        int counter = 0; 

        while(counter < AIPrefabs.Count)
        {

            if (AIPrefabs[counter].name.Equals(aiName))
            {

                this.enemySpawnIndex = counter;
                return;
            }

            counter++; 
        }

        Debug.LogError("You have not correctly setup this AI, ensure you entered the correct name" +
           " of the enemyAI . You entered: \n " + aiName);

    }

    /// <summary>
    /// <c>FindEnemyParticle</c>
    /// 
    /// pre: path to the gameobject we want to use as particles. 
    /// post: sets the particleDamage variable to a gameobject.
    /// 
    /// 
    /// </summary>
    /// <param name="effectName">path to the Particle effect we want to use.</param>
    public void FindEnemyParticle(string effectName)
    {
        if (this.ParticleDamage == null)
        {
            this.ParticleDamage = Resources.Load(effectName) as GameObject;
        }
    }

    // --- [[ Damage to AI: ]] ---//

    /// <summary>
    /// <c> Damage</c>
    /// pre: set AI health.
    /// post: takes away a certain amount of health from AI.
    /// </summary>
    /// <param name="damage">amount of damage to give to AI.</param>
    /// <returns>nothing</returns>

    public void Damage(float damage)
    {
        health -= damage;
        Instantiate(ParticleDamage, transform.position, Quaternion.identity);
        //sound Effect
        FindObjectOfType<AudioManager>().PlaySound("enemyHit");

        if (health <= 0) {
            if (phase2 == false)
            {
                this.gameObject.GetComponent<EnemyAnim>().Death();
            }
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject, 0.1f);
        SendMessageUpwards("EnemyDestroyed", gameObject, SendMessageOptions.RequireReceiver);
        


    }

    //---[[range attack actions]]---//

    /// <summary>
    /// <c>RangedAttack</c>
    /// 
    /// pre: ensure the AI is setup for range attack useage variable wise.
    /// post:creates a new projectile and fires it towards the player.
    /// 
    /// </summary>
    /// <returns>nothing</returns>
    public void RangedAttack()
    {
        if (cooldown != 0)
        {
            this.cooldown -= Time.deltaTime;

            if (this.cooldown <= 0)
            {
                this.cooldown = 0;
            }
        }
        else if (cooldown == 0)
        {
            this.currentAct = "attack";

            this.gameObject.GetComponent<EnemyAnim>().UpdateCurrentAct(currentAct);

            FindObjectOfType<AudioManager>().PlaySound("NanoShot");

            // direction that AI is currently facing is where we want to shoot our object!
            Vector2 direction = (player.transform.position - this.transform.position).normalized;

            GameObject newProjectile = Instantiate(rangePrefabs[this.rangePrefabIndex], this.transform.position, Quaternion.identity);

            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            newProjectile.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

            Physics2D.IgnoreCollision(newProjectile.GetComponent<PolygonCollider2D>(), this.gameObject.GetComponent<PolygonCollider2D>(), true);

            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * velocityOfRangedAttack);

            cooldown = this.rangedAttackCooldown;

            Destroy(newProjectile, 3.0f); 
        }
    }

    public void LaserBeamAttack()
    {

        if(cooldown != 0)
        {
            this.cooldown -= Time.deltaTime; 

            if(this.oldLaserObject != null)
            {
                oldLaserObject.transform.RotateAround(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.forward, laserSpeed * Time.deltaTime); ;
                    
            }

            if (this.cooldown <= 0)
            {

                this.cooldown = 0; 
            }
        }

        if(cooldown == 0)
        {

                this.gameObject.GetComponent<EnemyAnim>().HelLaser();

                this.cooldown = this.rangedAttackCooldown;

                Vector2 moveLaserDown = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 2);
                GameObject newProjectile = Instantiate(rangePrefabs[this.rangePrefabIndex], this.transform.position, Quaternion.identity);

                newProjectile.transform.position = moveLaserDown; 

                Physics2D.IgnoreCollision(newProjectile.GetComponent<PolygonCollider2D>(), this.gameObject.GetComponent<PolygonCollider2D>(), true);

                
                

                oldLaserObject = newProjectile;

                Destroy(newProjectile, 5.0f);

        }
        


    }

    //---[[Movement Decisions]]---//

        /// <summary>
        ///  <c>EnemySpotted</c>
        ///  pre: most decision trees usually start with this decision. so setup this first.
        ///  post: determines if the player is close or not.
        /// </summary>
        /// <returns>true if close, false if not.</returns>
    public bool EnemySpotted()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < this.fov)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// <c>TooClose</c>
    /// pre: hook up to a decision, which lead to action. 
    /// post: determines if a player is too close to the AI.
    /// </summary>
    /// <returns>True if too close, false if not.</returns>
    public bool TooClose()
    {
        if(Vector2.Distance(this.transform.position, player.transform.position) < tooCloseRange)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

    /// <summary>
    /// <c>CheckRange</c>
    /// pre: checks range before teleporting.
    /// post: if player is within range initate a teleport.
    /// 
    /// </summary>
    /// <returns>returns true if correct, or false if not.</returns>
    public bool CheckRange()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < this.range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool CanSpawn()
    {

        if (this.spawnCoolDown > 0)
        {

            this.spawnCoolDown = this.spawnCoolDown - Time.deltaTime;
            

            if(this.spawnCoolDown <= 0)
            {

                this.spawnCoolDown = 0; 
            }

            return false; 

        } 
        
        if(this.spawnCoolDown == 0)
        {
            
            this.spawnCoolDown = this.spawnTimer;

            return true; 

        }


        return false; 
     

    }


    public bool checkHPHalfed()
    {
        Debug.Log("checking health: health:" + health + " halfed:" + halfedHP);
        if(this.health >= this.halfedHP)
        {

            return true;

        } 
        else
        {

            return false; 

        }


    }


    //---[[Movement Actions!]]---//



    public void activatePhase2()
    {

        phase2 = true;
        this.health = totalHP;
        this.gameObject.GetComponent<HelAI>().PhaseCheck(); 
    }

    /// <summary>
    /// <c>MoveTowrdsPlayer</c>
    /// 
    /// pre: must have a decision hooked up to it.
    /// post: move ai towards the player.
    /// 
    /// </summary>
    public void MoveTowardsPlayer()
    {
        if (controlToPf == false)
        {
            speed = saveSpeed;
            this.currentAct = "move";
            this.gameObject.GetComponent<EnemyAnim>().UpdateCurrentAct(currentAct);
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        } 
        else
        {
            speed = saveSpeed;
            this.GetComponent<pathFinding>().walkAroundObject(this.speed, this.player, this.gameObject);
        }
    }


    public void shieldedAtkMove()
    {
        speed = saveSpeed;
        this.currentAct = "move";
        this.gameObject.GetComponent<EnemyAnim>().UpdateCurrentAct(currentAct);

        this.gameObject.tag = "rngBlock";

        if (setupShield == false)
        {  
            // not the best way to do this, but for now we out product > coding style.
            //Sprite shield = Resources.Load("AI/sprites/Hel", typeof(Sprite)) as Sprite;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = helShield;
            this.gameObject.GetComponent<EnemyAnim>().isHel = false;
            Destroy(this.gameObject.GetComponent<Animator>());  // just for now, our hels are different shadow V shield etc.
            Destroy(this.gameObject.GetComponent<PolygonCollider2D>());

            this.gameObject.AddComponent<PolygonCollider2D>(); // just re-adding a polygon collider, because the sprite changes.

            this.spawnTimer = 20;

            setupShield = true; 
        }
    
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);




    }
    
    /// <summary>
    /// <c>Teleport</c>
    /// pre: make sure to have a decision hooked up before this function call.
    /// post: teleports AI randomly near player.
    /// </summary>
    public void Teleport()
    {

        // teleport cooldown.
        if (teleportCoolDown != 0)
        {
            this.teleportCoolDown -= Time.deltaTime;

            if (this.teleportCoolDown <= 0)
            {
                this.teleportCoolDown = 0;
            }
        }
        else if (teleportCoolDown == 0)
        {
            speed = saveSpeed;
            this.currentAct = "move";
            this.gameObject.GetComponent<EnemyAnim>().UpdateCurrentAct(currentAct);
            teleportCoolDown = teleportTimerSet;

            StartCoroutine(PlayTeleportAnim());
        }
    }

    /// <summary>
    /// <c>PlayTeleportAnim</c>
    /// 
    /// Coroutine function, used to ensure the animation fully plays out.
    /// 
    /// </summary>
    /// <returns> return how much time until this function called again.</returns>
    private IEnumerator PlayTeleportAnim()
    {
        yield return new WaitForSeconds(2.0f);

        bool hitWall = false;
        float x = UnityEngine.Random.Range(this.transform.position.x, player.transform.position.x);
        float y = UnityEngine.Random.Range(this.transform.position.y, player.transform.position.y);

        Vector2 randomPosition = new Vector2(x,y);

        this.hit = Physics2D.Raycast(this.transform.position, randomPosition);
        //Debug.DrawLine(, hit.point,Color.green);

        // as long as it does not hit a wall, we are good to teleport to a new location. 
        if(hit.collider != null)
        {
            Vector2 posAwayFromWall = new Vector2(0.0f,0.0f); 

            while(hit.transform.gameObject.layer == LayerMask.NameToLayer("wall"))
            {
                // move closer to the player, but subtract a bit from it. (player cannot leave room.)
                hitWall = true;
                posAwayFromWall = new Vector2(player.transform.position.x -5, player.transform.position.y -5);

                this.hit = Physics2D.Raycast(this.transform.position, posAwayFromWall); 

            }

            if (hitWall)
            {
                hitWall = false;

                this.transform.position = posAwayFromWall;
            }
            else
            {

                this.transform.position = randomPosition;
            }
        }
    }

    public void SpawnUnits()
    {
        int counter = 0;

        int randomNumSpawns = UnityEngine.Random.Range(0, spawnPoints.Length);


        while (counter < randomNumSpawns)
        {
            int randomLocation = UnityEngine.Random.Range(0, spawnPoints.Length-1);

            GameObject newEnemy = Instantiate(this.AIPrefabs[this.enemySpawnIndex], spawnPoints[randomLocation].transform.position, Quaternion.identity);
         
            counter++;
        }
    }

    
    public void createIllusions()
    {
        int counter = 0;

        int randomNumSpawns = UnityEngine.Random.Range(0, spawnPoints.Length);

        // could be neat, but decided to axe this.
        //this.gameObject.transform.position = new Vector2(spawnPoints[randomNumSpawns].transform.position.x, spawnPoints[randomNumSpawns].transform.position.y);


        while (counter < randomNumSpawns)
        {
            int randomLocation = UnityEngine.Random.Range(0, spawnPoints.Length - 1);

            GameObject newEnemy = Instantiate(this.AIPrefabs[this.enemySpawnIndex], spawnPoints[randomLocation].transform.position, Quaternion.identity);

            counter++;
        }

    }



    /// <summary>
    /// <c>MoveAwayFromPlayer</c>
    /// pre: ensure decision is hooked up to this action.
    /// post: moves ai away from player.
    /// </summary>
    public void MoveAwayFromPlayer()
    {
        speed = saveSpeed;
        this.currentAct = "move";
        this.gameObject.GetComponent<EnemyAnim>().UpdateCurrentAct(currentAct);
        Vector2 direction = this.gameObject.transform.position - player.transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime); 
    }

    /// <summary>
    /// 
    /// <c>Idle</c>
    /// pre: decision hooked up
    /// post: makes AI idle in spot until other action called.
    /// 
    /// </summary>
    public void Idle()
    {
        this.currentAct = "idle";
        this.gameObject.GetComponent<EnemyAnim>().UpdateCurrentAct(currentAct);
        this.speed = 0f;
    }


    public bool returnPhase()
    {

        return phase2; 
    }

    /// <summary>
    /// pre: none
    /// post: returns the current action this AI is doing.
    /// </summary>
    /// <returns>string containing action.</returns>
    public string ReturnCurrentAct()
    {
        return this.currentAct;
    }


    public void giveControlToPF()
    {
        controlToPf = true; 

    }

    public void takeControlFromPF()
    {
        controlToPf = false; 

    }

}
