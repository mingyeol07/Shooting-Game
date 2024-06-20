using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPlayer : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int curHp;

    [SerializeField] private float shootDelayTime;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float unionTime;
    [SerializeField] private Animator engineAnim;
    private readonly int hashWeaponShot = Animator.StringToHash("Shot");
    private bool weaponShoting;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        curHp = maxHp;
        PlayerManager.Instance.SetUnionPlayer(gameObject);
        StartCoroutine(Co_StartUnionTime());
        StartCoroutine(ShotDelay());
    }

    protected virtual void FixedUpdate()
    {
        MoveInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("EnemyBeam"))
        {
            HpDown();
        }
    }

    private IEnumerator ShotDelay()
    {
        while (true)
        {
            ShotBullet();
            yield return new WaitForSeconds(shootDelayTime);
        }
    }

    private void ShotBullet()
    {
        if (!weaponShoting)
        {
            weaponShoting = true;
            engineAnim.SetTrigger(hashWeaponShot);
            StartCoroutine(AnimExit());
        }
    }

    private IEnumerator AnimExit()
    {
        yield return new WaitForSeconds(0.01f);
        float time = engineAnim.GetCurrentAnimatorClipInfo(0).Length / 10;
        yield return new WaitForSeconds(time);
        weaponShoting = false;
    }

    private void HpDown()
    {
        curHp--;
        if (curHp <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {

    }

    private void MoveInput()
    {
        float h = Input.GetAxisRaw("HorizontalMultiple");
        float v = Input.GetAxisRaw("VerticalMultiple");

        rigid.velocity = new Vector2(h, v).normalized * moveSpeed;
    }

    private IEnumerator Co_StartUnionTime()
    {
        yield return new WaitForSeconds(unionTime);
        PlayerManager.Instance.ExitUnion();
        Destroy(this.gameObject);
    }
}
