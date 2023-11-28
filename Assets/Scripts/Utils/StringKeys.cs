using UnityEngine;

namespace CodeSoldiers
{
	public class StringKeys : MonoBehaviour
	{
        public static class DataPrefs
        {
            public static string BLOBS_KEY = "Blobs";
            public static string TOTAL_SCORE_KEY = "TotalScore";
            public static string BEST_SCORE_KEY = "BestScore";

            public static string SOUND = "Sound";
            public static string NOTIFICATIONS = "Notifications";
            public static string ADS = "Ads";
        }

        public static class Analytics
        {
            // EVENTS
            // APP
            public const string GAMEOPENED_EVENT = "GameOpenedEvent";
            public const string GAMEPAUSED_EVENT = "GamePausedEvent";
            public const string GAMEUNPAUSED_EVENT = "GameUnPausedEvent";
            public const string GAMECLOSED_EVENT = "GameClosedEvent";

            // ARGS
            // GAME
            public const string GAMEOPENED_KEY = "GameOpened";
            public const string GAMEUNPAUSED_KEY = "GameUnPaused";
            public const string GAMEOPENED_FULLSTART_ARG = "FullStart";
            public const string GAMEOPENED_AFTERPAUSE_ARG = "AfterPause";

            public const string GAMECLOSEDREASON_KEY = "GameClosedReason";
            public const string GAMECLOSEDREASON_PAUSE_ARG = "Pause";
            public const string GAMECLOSEDREASON_QUIT_ARG = "Quit";

            public const string GAMEVERSION_KEY = "Game version: ";
            public static string GAMEVERSION_ARG = Application.version;

            // SESSION
            public const string GAMESESSION_START_KEY = "Session start: ";
            public const string GAMESESSION_END_KEY = "Session end: ";
            public const string GAMESESSION_PLAYTIME_KEY = "Current gameplay time: ";

            // ADS
            public const string GAMEADS_SHOWED_EVENT = "AdsShowed";
            public const string GAMEADS_CLOSE_EVENT = "AdsClosed";
            public const string GAMEADS_CLICK_EVENT = "AdsClicked";

            public const string GAMEADS_REWARD_KEY = "AdsRewardKey: ";
            public const string GAMEADS_RESULT_KEY = "AdsResultKey: ";

            // TILES

            // UI
            public const string GAMEUI_SHOW_EVENT = "UIPanelShow";
            public const string GAMEUI_CLOSE_EVENT = "UIPanelClose";
            public const string GAMEUI_SUPRISE_FOUND_KEY = "SupriseFound!";
            public const string GAMEUI_NAME_KEY = "UIPanelName: ";

            // IAPS
            public const string GAMEIAP_EVENT = "IAPEvent";
            public const string GAMEIAP_PURCHASED_KEY = "IAPPurchased: ";
            public const string GAMEIAP_FAILED_KEY = "IAPFailed: ";
            public const string GAMEIAP_FAILEDREASON_KEY = "IAPFailedReason: ";


            // SETTINGS
            public const string GAMESETTINGS_EVENT = "GameSettingsEvent";
            public const string GAMESETTINGS_SOUNDDISABLED_KEY = "GameSoundDisabled: ";

            // OTHER
            public const string GAMESHARING_EVENT = "GameSharing";
            public const string GAMESHARING_STATE_KEY = "GameShared: ";
            public const string SERVICES_EVENT = "GoogleServicesEvent";
            public const string SERVICES_KEY = "GoogleServices: ";
            public const string SERVICES_LEADERBOARD_ARG = "ServicesLedearboard";
            public const string SERVICES_ACHIEVS_ARG = "ServicesAchievements";

        }
	}
}