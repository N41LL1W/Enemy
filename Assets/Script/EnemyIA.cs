using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { Parado, Patrulha, Seguir, Rodear, Lutar }

public class EnemyIA : MonoBehaviour
{
    public EnemyStates myStates = EnemyStates.Patrulha;

    Animator animator;
    NavMeshAgent agent;

    //alvo
    public Transform player;

    //vision
    public float anguloVision = 90;
    public float minDistVision = 10;
    public Transform olho;
    public float vTimer = 0;
    public float vtAmount = 0.1f;

    [Header("patrulha")]
    public Transform pathDad;
    public Transform[] paths;
    public float minDist = 2;
    int pathIndice = 0;
    bool isClose = false; 

    //animações
    float vertical;
    float horizontal;

    //seguir
    public float maxDist = 8;

    //rodear
    bool walkRight = false;
    public float minDistRodear = 3;
    public float rodearContador = 0;
    public float timeToChangeDir = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        paths = pathDad.GetComponentsInChildren<Transform>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        olho = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (myStates)
        {
            case EnemyStates.Parado:
            parado();
            break;

            case EnemyStates.Patrulha:
            patrulha();
            break;

            case EnemyStates.Seguir:
            seguir();
            break;

            case EnemyStates.Rodear:
            rodear();
            break;

            case EnemyStates.Lutar:
            lutar();
            break;
        }

        AnimUpdate();
        
    }

    void parado(){
        SetMove(true,false,0,0);

        VisionTimer();
    }

    void AnimUpdate(){
        animator.SetFloat("vertical",vertical);
        animator.SetFloat("horizontal",horizontal);
    }

    void SetMove(bool rm, bool ag, float v, float h){
        animator.applyRootMotion = rm;
        agent.enabled = ag;
        vertical = Mathf.Lerp(vertical, v, 2 * Time.deltaTime);
        horizontal = Mathf.Lerp(horizontal, h, 2 * Time.deltaTime);
    }

    void patrulha(){
        if(pathDad == null){
            myStates = EnemyStates.Parado;
            return;
        }

        VisionTimer();

        if(Ver()){
            return;
        }

        float dis = Vector3.Distance(paths[pathIndice].position,transform.position);

        if(dis <= minDist){
            pathIndice = Random.Range(0,paths.Length);
        }
        else{
            if(agent.enabled)
                agent.destination = paths[pathIndice].position;
        }

        SetMove(false, true, 1,0);

    }

    void seguir(){
        
        SetMove(false,true,2,0);
        agent.destination = player.position;
        
        float dist = Vector3.Distance(player.position,transform.position);

        if(dist <= minDist){
            myStates = EnemyStates.Rodear;
        }
    }

    void rodear(){
        float dist = Vector3.Distance(player.position,transform.position);
        if(dist >= maxDist){
            myStates = EnemyStates.Seguir;
        }

        Vector3 playerDir = new Vector3(player.position.x,0,player.position.z);
        transform.LookAt(playerDir);

        if(dist < minDistRodear){
            SetMove(true,false,-1,0);
        }
        else{
            if(walkRight){
                SetMove(true,false,0,1);
                rodearContador += Time.deltaTime;
                if(ItsTime(rodearContador,timeToChangeDir)){
                    walkRight = !walkRight;
                    rodearContador = 0;
                }
            }
            else{
                SetMove(true,false,0,-1);
                rodearContador += Time.deltaTime;
                if(ItsTime(rodearContador,timeToChangeDir)){
                    walkRight = !walkRight;
                    rodearContador = 0;
                }
            }
        }

    }

    void lutar(){
        float dist = Vector3.Distance(player.position,transform.position);
        if(dist >= maxDist){
            myStates = EnemyStates.Seguir;
        }
    }

    void VisionTimer(){
        if(Ver()){
            vTimer += vtAmount;
            SetMove(true,false,0,0);
        }
        else{
            vTimer -= vtAmount;
        }

        vTimer = Mathf.Clamp(vTimer,0,1);

        if(vTimer >= 1){
            myStates = EnemyStates.Seguir;
        }

        if(vTimer <= 0 && myStates == EnemyStates.Seguir){
            if(pathDad == null){
                myStates = EnemyStates.Parado;
            }
            else{
                myStates = EnemyStates.Patrulha;
            }
            
        }
    }

    bool Ver(){
        Vector3 dir = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, dir);
        float dist = Vector3.Distance(player.position,transform.position);
        RaycastHit hit;

        if(angle < anguloVision && dist <= minDistVision){
            if(Physics.Linecast(olho.position, player.position,out hit)){
                if(hit.transform.tag == "Player"){
                    return true;
                }
                else{ return false; }
            }
            else{ return false; }
        }
        else{
            return false;
        }
    }

    bool ItsTime(float cValue,float maxValue){
        
        if(cValue >= maxValue){
            return true;
        }
        else{
            return false;
        }
    }

}