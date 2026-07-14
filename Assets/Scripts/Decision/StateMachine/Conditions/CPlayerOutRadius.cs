using UnityEngine;
using IA26Online.Decision.StateMachine;
public class CPlayerOutRadius : Condition
{
    private BossController boss;

    public CPlayerOutRadius(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        float distance = Vector2.Distance(boss.transform.position, boss.playerTransform.position);
        if (distance > boss.radius_dist == true)
            return true;
        return false;
    }
}
