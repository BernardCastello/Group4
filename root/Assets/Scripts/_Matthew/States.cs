public enum PlayerState
{
    init,
    idle,
    walk,
    run,
    dead,
}

public enum TurretState
{
    idle,
    patrol,
    shoot,
    destroyed,
}

public enum GoalState
{
    alive,
    destroyed,
}

public enum EnemyState
{
    Idle,
    Goal,
    Chase,
    Dead,
}

public enum LevelState
{
    intro,
    combat,
    exit,
}

public enum GameStates
{
    init,
    mainMenu, 
    gamePlay,
    pause,
    gameOver,
    close,
}
