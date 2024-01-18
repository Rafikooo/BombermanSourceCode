using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Gameplay
{
    public class CountdownTimer : MonoBehaviourPunCallbacks
    {
        public delegate void CountdownTimerHasExpired();

        bool isTimerRunning;

        int startTime;

        public int endTime;

        public static event CountdownTimerHasExpired OnCountdownTimerHasExpired;

        const string CountdownStartTimeKey = "StartTime";

        public void StartCountdown()
        {
            var props = new Hashtable
            {
                {CountdownStartTimeKey, PhotonNetwork.ServerTimestamp}
            };

            PhotonNetwork.CurrentRoom.SetCustomProperties(props);

            isTimerRunning = true;
            InitializeTimer();
        }

        void InitializeTimer()
        {
            endTime = PhotonNetwork.ServerTimestamp + GameParameters.GameTimeInSeconds * 1000;
        }

        public void Update()
        {
            if (!isTimerRunning) return;

            var timeRemaining = TimeRemaining();

            if (timeRemaining > 0) return;

            OnTimerEnds();
        }

        void OnTimerEnds()
        {
            isTimerRunning = false;
            enabled = false;

            OnCountdownTimerHasExpired?.Invoke();
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
        }

        int TimeRemaining()
        {
            var timeRemaining = endTime - PhotonNetwork.ServerTimestamp;

            return timeRemaining;
        }
    }
}
