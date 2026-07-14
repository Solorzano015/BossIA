using UnityEngine;

using IA26Online.Decision.StateMachine;

public class CHealthBelow0 : Condition
{
    private BossController boss;
    public CHealthBelow0(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        if (boss.current_health <= 0f == true)
            return true;
        return false;
    }
}