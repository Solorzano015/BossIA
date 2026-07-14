using IA26Online.Decision.BehaviorTree.Actions;
using IA26Online.Decision.StateMachine;
using IA26Online.Decision.StateMachine.Actions;

public static class BossSMBuilder
{
    public static HierarchicalSM Build(BossController boss)
    {
        State root = new State();

        //----------------------- FASES -----------------------
        State phase1 = new State();
        phase1.root_state = root;

        State phase2 = new State();
        phase2.root_state = root;

        State explode = new State();
        explode.root_state = root;

        //----------------------- SUBESTADOS -----------------------
        //SUBESTADOS FASE 1
        State boss_wander = new State();
        boss_wander.root_state = phase1;

        State attack_phase1 = new State();
        attack_phase1.root_state = phase1;

        //SUBESTADOS ATAQUE FASE 1
        State guard_phase1 = new State();
        guard_phase1.root_state = attack_phase1;

        State melee_attack1_phase1 = new State();
        melee_attack1_phase1.root_state = attack_phase1;

        State melee_attack2_phase1 = new State();
        melee_attack2_phase1.root_state = attack_phase1;

        State range_attack_phase1 = new State();
        range_attack_phase1.root_state = attack_phase1;

        State boss_seek_phase1 = new State();
        boss_seek_phase1.root_state = attack_phase1;

        //SUBESTADOS FASE 2
        State special_attack = new State();
        special_attack.root_state = phase2;

        State boss_flee = new State();
        boss_flee.root_state = phase2;

        State attack_phase2 = new State();
        attack_phase2.root_state = phase2;

        //SUBESTADOS ATAQUE FASE 2
        State guard_phase2 = new State();
        guard_phase2.root_state = attack_phase2;

        State melee_attack1_phase2 = new State();
        melee_attack1_phase2.root_state = attack_phase2;

        State melee_attack2_phase2 = new State();
        melee_attack2_phase2.root_state = attack_phase2;

        State range_attack_phase2 = new State();
        range_attack_phase2.root_state = attack_phase2;

        State boss_seek_phase2 = new State();
        boss_seek_phase2.root_state = attack_phase2;

        //----------------------- ACCIONES -----------------------

        //ACCIONES DE ESTADO
        boss_wander.actions_state = new Action[]
        {
            new AWander(boss) };

        guard_phase1.actions_state = new Action[]
        {
            new AGuard(boss) };

        melee_attack1_phase1.actions_state = new Action[]
        {
            new AMeleeAttackPhase1_1(boss) };

        melee_attack2_phase1.actions_state = new Action[]
        {
            new AMeleeAttackPhase1_2(boss) };

        range_attack_phase1.actions_state = new Action[]
        {
            new ARangeAttackPhase1(boss) };

        boss_seek_phase1.actions_state = new Action[]
        {
            new APursue(boss) };

        special_attack.actions_state = new Action[]
        {
            new ASpecialAttack(boss) };

        boss_flee.actions_state = new Action[]
        {
            new AFlee(boss) };

        guard_phase2.actions_state = new Action[]
        {
            new AGuard(boss) };

        melee_attack1_phase2.actions_state = new Action[]
        {
            new AMeleeAttackPhase2_1(boss) };

        melee_attack2_phase2.actions_state = new Action[]
        {
            new AMeleeAttackPhase2_2(boss) };

        range_attack_phase2.actions_state = new Action[]
        {
            new ARangeAttackPhase2(boss) };

        boss_seek_phase2.actions_state = new Action[]
        {
            new APursue(boss) };

        // ACCIONES DE ENTRADA-SALIDA
        phase2.actions_entry = new Action[]
        {
            new AIncreaseSpeed(boss)};

        explode.actions_entry = new Action[]
        {
            new AExplode(boss) };

        //----------------------- TRANSICIONES -----------------------
        //TRANSICIONES RAÍZ
        Transitions root_explode = new Transitions();
        root_explode.condition= new CHealthBelow0(boss);
        root_explode.objective_state = explode;
        root.transitions = new Transitions[] { root_explode };

        //TRANSICIONES ENTRE FASES
        Transitions phase1_to_phase2 = new Transitions();
        phase1_to_phase2.condition = new CHealthBelow50(boss);
        phase1_to_phase2.objective_state = special_attack;
        phase1.transitions = new Transitions[] { phase1_to_phase2 };

        //TRANSICIONES FASE 1
        Transitions wander_attack_phase1 = new Transitions();
        wander_attack_phase1.condition = new CPlayerInRadius(boss);
        wander_attack_phase1.objective_state = guard_phase1;
        boss_wander.transitions = new Transitions[] { wander_attack_phase1 };

        Transitions attack_wander_phase1 = new Transitions();
        attack_wander_phase1.condition = new CPlayerOutRadius(boss);
        attack_wander_phase1.objective_state = guard_phase1;
        attack_phase1.transitions = new Transitions[] { attack_wander_phase1 };

        //TRANSICIONES DENTRO DE ATAQUE FASE 1
        Transitions guard_attack1_phase1 = new Transitions();
        guard_attack1_phase1.condition = new CDistLessThanX(boss);
        guard_attack1_phase1.objective_state = melee_attack1_phase1;

        Transitions guard_rangeAttack_phase1 = new Transitions();
        guard_rangeAttack_phase1.condition = new CDistBetweenXY(boss);
        guard_rangeAttack_phase1.objective_state = range_attack_phase1;

        Transitions guard_seek_phase1 = new Transitions();
        guard_seek_phase1.condition = new CDistMoreThanY(boss);
        guard_seek_phase1.objective_state = boss_seek_phase1;

        guard_phase1.transitions = new Transitions[]
        {
            guard_attack1_phase1,
            guard_rangeAttack_phase1,
            guard_seek_phase1 };

        Transitions attack1_guard_phase1 = new Transitions();
        attack1_guard_phase1.condition = new CPlayerDoesntAttack(boss);
        attack1_guard_phase1.objective_state = guard_phase1;

        Transitions attack1_attack2_phase1 = new Transitions();
        attack1_attack2_phase1.condition = new CPlayerAttacks(boss);
        attack1_attack2_phase1.objective_state = melee_attack2_phase1;

        melee_attack1_phase1.transitions = new Transitions[]
        {
            attack1_guard_phase1,
            attack1_attack2_phase1 };

        Transitions attack2_guard_phase1 = new Transitions();
        attack2_guard_phase1.condition = new CPlayerDoesntAttack(boss);
        attack2_guard_phase1.objective_state = guard_phase1;

        melee_attack2_phase1.transitions = new Transitions[]
        {
            attack2_guard_phase1 };

        Transitions range_guard_phase1 = new Transitions();
        range_guard_phase1.condition = new CDistLessThanX(boss);
        range_guard_phase1.objective_state = guard_phase1;

        range_attack_phase1.transitions = new Transitions[]
        {
            range_guard_phase1 };

        Transitions seek_guard_phase1 = new Transitions();
        seek_guard_phase1.condition = new CDistLessThanX(boss);
        seek_guard_phase1.objective_state = guard_phase1;

        boss_seek_phase1.transitions = new Transitions[]
        {
            seek_guard_phase1 };

        //TRANSICIONES FASE 2
        Transitions phase2_flee = new Transitions();
        phase2_flee.condition = new CHealthBelow10(boss);
        phase2_flee.objective_state = boss_flee;
        phase2.transitions = new Transitions[] { phase2_flee };

        Transitions specialAttack_attack_phase2 = new Transitions();
        specialAttack_attack_phase2.condition = new CPlayerInRadius(boss);
        specialAttack_attack_phase2.objective_state = guard_phase2;

        special_attack.transitions = new Transitions[]
        {
            specialAttack_attack_phase2 };

        Transitions attack_specialAttack_phase2 = new Transitions();
        attack_specialAttack_phase2.condition = new CPlayerOutRadius(boss);
        attack_specialAttack_phase2.objective_state = special_attack;

        attack_phase2.transitions = new Transitions[]
        {
            attack_specialAttack_phase2 };

        //TRANSICIONES DENTRO DE ATAQUE FASE 2
        Transitions guard_attack1_phase2 = new Transitions();
        guard_attack1_phase2.condition = new CDistLessThanX(boss);
        guard_attack1_phase2.objective_state = melee_attack1_phase2;

        Transitions guard_range_phase2 = new Transitions();
        guard_range_phase2.condition = new CDistBetweenXY(boss);
        guard_range_phase2.objective_state = range_attack_phase2;

        Transitions guard_seek_phase2 = new Transitions();
        guard_seek_phase2.condition = new CDistMoreThanY(boss);
        guard_seek_phase2.objective_state = boss_seek_phase2;

        guard_phase2.transitions = new Transitions[]
        {
            guard_attack1_phase2,
            guard_range_phase2,
            guard_seek_phase2 };

        Transitions attack1_guard_phase2 = new Transitions();
        attack1_guard_phase2.condition = new CPlayerDoesntAttack(boss);
        attack1_guard_phase2.objective_state = guard_phase2;

        Transitions attack1_attack2_phase2 = new Transitions();
        attack1_attack2_phase2.condition = new CPlayerAttacks(boss);
        attack1_attack2_phase2.objective_state = melee_attack2_phase2;

        melee_attack1_phase2.transitions = new Transitions[]
        {
            attack1_guard_phase2,
            attack1_attack2_phase2 };

        Transitions attack2_guard_phase2 = new Transitions();
        attack2_guard_phase2.condition = new CPlayerDoesntAttack(boss);
        attack2_guard_phase2.objective_state = guard_phase2;

        melee_attack2_phase2.transitions = new Transitions[]
        {
            attack2_guard_phase2 };

        Transitions range_guard_phase2 = new Transitions();
        range_guard_phase2.condition = new CDistLessThanX(boss);
        range_guard_phase2.objective_state = guard_phase2;

        range_attack_phase2.transitions = new Transitions[]
        {
            range_guard_phase2 };

        Transitions seek_guard_phase2 = new Transitions();
        seek_guard_phase2.condition = new CDistLessThanX(boss);
        seek_guard_phase2.objective_state = guard_phase2;

        boss_seek_phase2.transitions = new Transitions[]
        {
            seek_guard_phase2 };

        //----------------------- EST.INICIAL -----------------------
        return new HierarchicalSM(boss_wander);
    }
}
