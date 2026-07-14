using UnityEngine;
using IA26Online.Decision.StateMachine;
public class CPlayerDoesntAttack : Condition
{
    private BossController boss;
    public CPlayerDoesntAttack(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        if (boss.player_attacks == false)
            return true;
        return false;
    }
}
