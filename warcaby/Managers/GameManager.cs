using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using warcaby.AI;
using warcaby.AI.Rating;
using warcaby.Extensions;
using warcaby.Movements.Fight;

namespace Checkers
{
  public class GameManager
  {
    public BoardForm BoardForm { get; set; }

    public BoardGraphical BoardGraphical { get; set; }
    public PlayerGraphical Player1 { get; set; }
    public PlayerGraphical Player2 { get; set; }

    public PlayerGraphical ActualPlayer { get; set; }
    public MovementManager MovementManager { get; set; }
    public bool GameHasEnded { get; set; }

    public GameManager(BoardForm form, PlayerGraphical player1, PlayerGraphical player2)    // every time white pawns start game
    {
      BoardForm = form;
      Player1 = player1;
      Player2 = player2;
      BuildBoardForm();
      ActualPlayer = Player1.PawnsColor == PawnColor.Light ? Player1 : Player2;
    }

    public void SetUpGame()
    {
      GameHasEnded = false;
      BoardForm.RestrtTimer();
      Player1.RestartLeftTime();
      Player2.RestartLeftTime();
      ActualPlayer = Player1.PawnsColor == PawnColor.Light ? Player1 : Player2;
      BoardGraphical.ResetBoardState(Player1, Player2);
      BoardForm.StartCountingTime();
      UpdateGameState();
    }

    public void ChangeTurn()
    {
      ChangePlayer();
      UpdateGameState();
    }

    void UpdateGameState()
    {
      MovementManager.UpdatePlayerMoves();

      if (!GameHasEnded)
      {
        if (ActualPlayer.Ai)
        {
          MakeAiMove();
        }
      }
    }

    public void EndGame()
    {
      GameHasEnded = true;
      string endText = string.Format("Game over.\nPlayer {0} won!", GetOponent(ActualPlayer).Player.Nick);
      BoardForm.ShowMessage(endText);
      BoardForm.StopTimer();
    }

    void BuildBoardForm()
    {
      MovementManager = new MovementManager(this);
      BoardGraphical = new BoardGraphical(new Board(8), MovementManager);
      BoardForm.AddToForm(BoardGraphical);
      BoardGraphical.SetBoardWithPawns(Player1, Player2);
    }

    async void MakeAiMove()
    {
      Speculation spec = new Speculation(ActualPlayer.Player, GetOponent(ActualPlayer).Player,
          BoardGraphical.SourceBoard, 3);
      MoveAnalyze move = await spec.FindBestMove();

      Pawn selectedPawn = BoardGraphical.SourceBoard.GetControlInPosition(move.Move.PositionBeforeMove) as Pawn;
      Field selectedField = BoardGraphical.SourceBoard.GetControlInPosition(move.Move.PositionAfterMove) as Field;

      WaitForMove();
      MovementManager.SelectPawn(selectedPawn);

      if (move.Move is MultipleFightMove)
      {
        MultipleFightMove multipleFightMove = move.Move as MultipleFightMove;
        int childCount = multipleFightMove.FightMoves.Count;

        for (int i = 0; i < childCount; i++)
        {
          WaitForMove(false);
          IMakeBeat nextChild = multipleFightMove.GetNextMove();
          selectedField =
              BoardGraphical.SourceBoard.GetControlInPosition(nextChild.PositionAfterMove) as Field;
          MovementManager.SelectField(selectedField);
        }
      }
      else
      {
        WaitForMove(false);
        MovementManager.SelectField(selectedField);
      }
    }

    void WaitForMove(bool waitLong = true)
    {
      if (waitLong)
      {
        Random random = new Random();
        WaitNSeconds(random.Next(2, 4));
        return;
      }
      WaitNSeconds(0);
    }

    void WaitNSeconds(int sec)
    {
      if (sec < 1) return;
      DateTime _desired = DateTime.Now.AddSeconds(sec);
      while (DateTime.Now < _desired)
      {
        Application.DoEvents();
      }
    }

    PlayerGraphical GetOponent(PlayerGraphical playerGraphical)
    {
      if (playerGraphical == Player1)
        return Player2;
      return Player1;
    }

    void ChangePlayer()
    {
      ActualPlayer = GetOponent(ActualPlayer);
    }
  }
}
