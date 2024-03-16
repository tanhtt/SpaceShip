using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);
        return newEnemy;
    }

    public virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl enemy = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.hpBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetShootableObjCtrl(enemy);
        hpBar.gameObject.SetActive(true);
        hpBar.SetFollowTarget(newEnemy);
    }
}
