//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BeforeStart : PlayerState
//{
//    public override void SetState(PlayerState state)
//    {

//    }

//    public override void TryStartGame(Game game)
//    {
//        game.startTime = Time.fixedTime;
//        game.timeText.enabled = true;
//        game.timeText.text = game.startTime - game.startTime + "";

//        game.player.playerState = PlayerState.InMaze;
//    }

//    public override void TryEndGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void HandleUI()
//    {
//        throw new System.NotImplementedException();
//    }
//}

//public class Start : PlayerState
//{
//    public override void SetState(PlayerState state)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryStartGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryEndGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void HandleUI()
//    {
//        throw new System.NotImplementedException();
//    }
//}

//public class InMaze : PlayerState
//{
//    public override void SetState(PlayerState state)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryStartGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryEndGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void HandleUI()
//    {
//        throw new System.NotImplementedException();
//    }
//}

//public class End : PlayerState
//{
//    public override void SetState(PlayerState state)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryStartGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryEndGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void HandleUI()
//    {
//        throw new System.NotImplementedException();
//    }
//}

//public class AfterEnd : PlayerState
//{
//    public override void SetState(PlayerState state)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryStartGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void TryEndGame(Game game)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void HandleUI()
//    {
//        throw new System.NotImplementedException();
//    }
//}

//public abstract class PlayerState
//{
//    public abstract void SetState(PlayerState state);

//    public abstract void TryStartGame(Game game);

//    public abstract void TryEndGame(Game game);

//    public abstract void HandleUI();
//}
//HandleUI