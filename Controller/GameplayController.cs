using System.Collections;
using Gameplay;
using Model;
using Photon.Pun;
using UnityEngine;
using View;

namespace Controller
{
	public class GameplayController : MonoBehaviourPunCallbacks
	{
		static GameplayController _instance;

		GUIView _guiView;

		CountdownTimer _countdownTimer;

		bool _isGameStarted;

		void Awake()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(gameObject);
				return;
			}

			_instance = this;
			DontDestroyOnLoad(gameObject);
		}

		void InitializeObjects()
		{
			_countdownTimer = gameObject.AddComponent<CountdownTimer>();
			_guiView = FindObjectOfType<GUIView>();
			if (!_guiView)
			{
				throw new MissingReferenceException(
					"GUIView component not found, please add it to the canvas on the scene");
			}
		}

		void Start()
		{
			InitializeObjects();
			CountdownTimer.OnCountdownTimerHasExpired += HandleGameOver;
			SetGameplayReady();
			StartCountdown();
			StartCoroutine(StartGame());
		}

		static void SetGameplayReady()
		{
			DisableAllPlayersMovement();
		}


		IEnumerator StartGame()
		{
			while (!_isGameStarted)
			{
				yield return new WaitForSecondsRealtime(1);
			}

			EnableAllPlayersMovement();
			_countdownTimer.StartCountdown();
		}

		static void EnableAllPlayersMovement()
		{
			var players = FindObjectsOfType<Player>();
			foreach (var player in players)
			{
				player.EnableMovement();
			}
		}

		static void DisableAllPlayersMovement()
		{
			var players = FindObjectsOfType<Player>();
			foreach (var player in players)
			{
				player.DisableMovement();
			}
		}

		void StartCountdown()
		{
			StartCoroutine(Countdown());
		}

		IEnumerator Countdown()
		{
			int countdownTime = 3;
			while (countdownTime > 0)
			{
				_guiView.UpdateCenterText(countdownTime + "!");
				yield return new WaitForSecondsRealtime(1);
				countdownTime--;
			}
			_guiView.UpdateCenterText("");
			_isGameStarted = true;
		}

		void HandleGameOver()
		{
			_isGameStarted = false;
			StartCoroutine(ShowGameOverView());
			DisableAllPlayersMovement();

		}

		IEnumerator ShowGameOverView()
		{
			_guiView.gameover.enabled = true;
			_guiView.UpdateCenterText(GameplayModel.GetGameResult());

			yield return new WaitForSecondsRealtime(6);

			PhotonNetwork.LoadLevel("Lobby");
		}
	}
}
