using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum State // 문자를 상수로 바꿔줌
{
    Move, // 0
    Attack, // 1
    Die, // 2

    None
}
[RequireComponent(typeof(HPBar))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] Animator animator;
    [SerializeField] Vector3 originDirection;
    [SerializeField] GameObject target;

    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 targetDirection;
    [SerializeField] float speed = 5.0f;

    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;

    [SerializeField] HPBar healthBar;
    [SerializeField] Sound sound = new Sound();
    private void Awake()
    {
        target = GameObject.Find("Player");
        healthBar = GetComponent<HPBar>();
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        state = State.Move;
        originDirection = transform.position;
    }

    public void OnHit(float damage)
    {
        if (health <= 0) return;
        
        health -= damage;

        if(health <=0)
        {
            state = State.Die;
        }

        healthBar.UpdateHP(health, maxHealth);
    }

    public virtual void Release()
    {
        // Destroy(gameObject);
        ObjectPool.instance.InsertObject(gameObject);
    }


    public void Update()
    {
        
        switch (state)
        {
            case State.Move: Move();
                break;
            case State.Attack: Attack();
                break;
            case State.Die: Die();
                break;


        }
    }
    public virtual void Move()
    {
        animator.SetBool("Attack", false);
        // 1. Target의 백터 -자신의 위치 백터  ->가고자 하는 방향

        direction = target.transform.position - transform.position;
        targetDirection = target.transform.position;
        // 2. y축을 0으로 설정
        direction.y = 0;
        targetDirection.y = 0;
        // 3. 백터의 정규화
        direction.Normalize();

        // 4. 특정한 대상을 바라본다.
        transform.LookAt(targetDirection);

        // 5. 방향 백터를 구한 값을 가지고 이동을 한다.
        transform.position += direction * speed * Time.deltaTime;
    }

    public virtual void Attack()
    {
   
        animator.SetBool("Attack", true);
    }

    public void AttackSound()
    {
        SoundManager.instance.Sound(sound.audioClips[0]);
    }
    public virtual void Die()
    {
        
        
            SoundManager.instance.Sound(sound.audioClips[1]);

        
        animator.Play("Die");
        state = State.None;
    }
    // OnTriggerEnter() : Trigger 충돌이 되었을 때 이벤트를 호출하는 함수
    private void OnTriggerEnter(Collider other)
    {

        state = State.Attack;
    }

    // OnTriggerStay() : Trigger 충돌중 일 때 이벤트를 호출하는 함수
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger와 충돌이 끝났을 때 이벤트를 호출하는 함수
    private void OnTriggerExit(Collider other)
    {

        state = State.Move;
    }

    private void OnDisable()
    {
        transform.position = originDirection;
        health = maxHealth;
    }
}
