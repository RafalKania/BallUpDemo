using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CodeSoldiers
{

    public enum PlayerState
    {
        Normal,
        Blue,
        Pink,
        Red,
        Green
    }

    public enum PlayerLiveState
    {
        Neutral,
        Live,
        Dead
    }

    public class Player : MonoBehaviour
    {
        //Singleton
        public static Player Instance;

        [SerializeField]
        new Rigidbody2D rigidbody2D = null;
        public Rigidbody2D _Rigidbody2D
        {
            get
            {
                return rigidbody2D;
            }
        }

        [SerializeField]
        new Collider2D collider = null;

        [SerializeField]
        ParticleSystem particles = null;
        [SerializeField]
        ParticleSystem getCrystalParticles = null;

        [SerializeField]
        Transform startPosition = null;

        [SerializeField]
        Transform currentPlayerTransform = null;

        [SerializeField]
        List<Transform> playerTransforms = new List<Transform>();
        [SerializeField]
        List<ParticleSystem> playerParticles = new List<ParticleSystem>();

        [SerializeField]
        new AudioSource audio = null;

        [SerializeField]
        List<AudioClip> audioClips = new List<AudioClip>();

        [SerializeField]
        PlayerState currentPlayerState;

        [SerializeField]
        PlayerLiveState currentPlayerLiveState;

        [SerializeField]
        float jumpForce = 0;

        [SerializeField]
        bool isJumping = false;
        public bool _IsJumping
        {
            get
            {
                return isJumping;
            }
        }

        [SerializeField]
        Touch touch;
		
		void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
            //rigidbody2D = GetComponent<Rigidbody2D>();
            //collider = GetComponent<Collider2D>();
            //startPosition = PlayerSpawnPoint.Instance.transform;
        }

        void Update()
        {
            if (GameManager.Instance.currentGameState == GameState.GamePlay)
            {
                if (currentPlayerLiveState == PlayerLiveState.Neutral)
                {
#if UNITY_EDITOR
                    if (Input.GetMouseButtonDown(0))
                    {
                        SetPlayerLiveState(PlayerLiveState.Live);
                    }
#endif

#if UNITY_ANDROID
                    if (Input.touchCount == 1)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                        {
                            SetPlayerLiveState(PlayerLiveState.Live);
                        }
                    }
#endif
                }

                if (currentPlayerLiveState == PlayerLiveState.Live)
                {
#if UNITY_EDITOR
                    if (Input.GetMouseButtonDown(0))
                    {
                        isJumping = true;
                        rigidbody2D.velocity = Vector2.zero;
                        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        audio.PlayOneShot(audioClips[0]);
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        isJumping = false;
                    }
#endif

#if UNITY_ANDROID
                    if (Input.touchCount == 1)
                    {
                        isJumping = true;

                        //if (Input.GetTouch(0).phase == TouchPhase.Stationary && isJumping == true)
                        //{
                        //    // fix : add stop touching
                        //    rigidbody2D.velocity = Vector2.zero;
                        //    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        //    StartCoroutine(TouchTimer());
                        //}
                        touch = Input.GetTouch(0);

                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                rigidbody2D.velocity = Vector2.zero;
                                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                                audio.PlayOneShot(audioClips[0]);
                                StartCoroutine(TouchTimer());
                                break;

                            case TouchPhase.Ended:
#if UNITY_ANDROID
                                isJumping = false;
#endif
                                break;
                        }
                    }
#endif
                }

                #region Set states
                if (Input.GetKeyDown(KeyCode.Alpha0))
                    SetPlayerState(PlayerState.Normal);

                if (Input.GetKeyDown(KeyCode.Alpha1))
                    SetPlayerState(PlayerState.Blue);

                if (Input.GetKeyDown(KeyCode.Alpha2))
                    SetPlayerState(PlayerState.Green);

                if (Input.GetKeyDown(KeyCode.Alpha3))
                    SetPlayerState(PlayerState.Pink);

                if (Input.GetKeyDown(KeyCode.Alpha4))
                    SetPlayerState(PlayerState.Red);
                #endregion
            }
        }

        private void FixedUpdate()
        {
            
        }

        private void OnEnable()
        {
            //transform.localPosition = startPosition.position;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void SetPlayerState(PlayerState _playerState)
        {
            currentPlayerState = _playerState;

            switch (currentPlayerState)
            {
                case PlayerState.Normal:
                    currentPlayerTransform = playerTransforms[0];
                    particles = playerParticles[0];
                    break;
                case PlayerState.Blue:
                    currentPlayerTransform = playerTransforms[1];
                    particles = playerParticles[1];
                    break;
                case PlayerState.Green:
                    currentPlayerTransform = playerTransforms[2];
                    particles = playerParticles[2];
                    break;
                case PlayerState.Pink:
                    currentPlayerTransform = playerTransforms[3];
                    particles = playerParticles[3];
                    break;
                case PlayerState.Red:
                    currentPlayerTransform = playerTransforms[4];
                    particles = playerParticles[4];
                    break;
            }

            currentPlayerTransform.gameObject.SetActive(true);

            foreach(Transform t in playerTransforms)
            {
                if (t != currentPlayerTransform)
                    t.gameObject.SetActive(false);
            }
        }

        public void UpdatePlayerState()
        {
            switch (currentPlayerState)
            {
                case PlayerState.Normal:
                    break;
                case PlayerState.Blue:
                    break;
                case PlayerState.Green:
                    break;
                case PlayerState.Pink:
                    break;
                case PlayerState.Red:
                    break;
            }
        }

        public void SetPlayerLiveState(PlayerLiveState _playerLiveState)
        {
            currentPlayerLiveState = _playerLiveState;

            switch(currentPlayerLiveState)
            {

                case PlayerLiveState.Neutral:
                    UIManager.Instance._GameplayView.startGameText.gameObject.SetActive(true);

                    gameObject.SetActive(true);

                    if (DeadPlatform.Instance.gameObject != null)
                        DeadPlatform.Instance.gameObject.SetActive(true);

                    rigidbody2D.gravityScale = 0;
                    rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    break;
                case PlayerLiveState.Live:
                    UIManager.Instance._GameplayView.startGameText.gameObject.SetActive(false);

                    SetPlayerState(PlayerState.Normal);
                    gameObject.SetActive(true);

                    if (DeadPlatform.Instance.gameObject != null)
                        DeadPlatform.Instance.gameObject.SetActive(true);

                    rigidbody2D.gravityScale = 1;
                    rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    collider.enabled = true;
                    break;
                case PlayerLiveState.Dead:
                    currentPlayerTransform.gameObject.SetActive(false);

                    if (DeadPlatform.Instance.gameObject != null)
                        DeadPlatform.Instance.gameObject.SetActive(false);

                    rigidbody2D.gravityScale = 0;
                    rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    collider.enabled = false;
                    StartCoroutine(DisablePlayer());
                    break;
            }
        }

        public void InitPlayer()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            startPosition = PlayerSpawnPoint.Instance.transform;
            transform.position = PlayerSpawnPoint.Instance.transform.position;

            SoundManager.Instance._GameAudioSources.Add(audio);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Obstacle"))
            {
                if (GameManager.Instance.currentGameState == GameState.GamePlay)
                {
                    SetPlayerLiveState(PlayerLiveState.Dead);
                    CameraController.Instance.ShakeCamera();
                    particles.Play();
                    audio.PlayOneShot(audioClips[1]);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Diamond"))
            {
                if (GameManager.Instance.currentGameState == GameState.GamePlay)
                {
                    audio.PlayOneShot(audioClips[2]);

                    if (collision.GetComponent<Diamond>()._Parent.isSpecial == true)
                    {
                        // +2
                        PlayerManager.Instance._PlayerDiamonds += 2;
                        collision.gameObject.SetActive(false);
                    } 
                    else
                    {
                        // +1
                        PlayerManager.Instance._PlayerDiamonds += 1;
                        collision.gameObject.SetActive(false);
                    }

                    getCrystalParticles.Play();
                }
            }

            if (collision.gameObject.tag.Equals("ColorChanger"))
            {
                if (GameManager.Instance.currentGameState == GameState.GamePlay)
                {
                    if (collision.GetComponent<ColorChanger>()._Parent._ObstacleColorType == ObstacleColorType.Quad)
                    {
                        collision.gameObject.SetActive(false);
                        SetPlayerState(collision.GetComponent<ColorChanger>()._Parent.GetComponent<ObstacleColor>()._RandomedPlayerState);
                    }
                    else if (collision.GetComponent<ColorChanger>()._Parent._ObstacleColorType == ObstacleColorType.OneHalf)
                    {
                        collision.gameObject.SetActive(false);
                        SetPlayerState(collision.GetComponent<ColorChanger>()._Parent.GetComponent<ObstacleHalfRing>()._RandomedPlayerState);
                    }
                }
            }

            if (collision.gameObject.tag.Equals("PositionChanger"))
            {
                var colorType = collision.GetComponent<ChanePositionTrigger>()._Parent._CurrentObstacle._ObstacleType._ObstacleColorType;

                if (GameManager.Instance.currentGameState == GameState.GamePlay)
                {
                    PlayerManager.Instance._PlayerScore += 1;
                    collision.GetComponent<ChanePositionTrigger>().MoveParentUp();

                    if (currentPlayerState != PlayerState.Normal)
                        SetPlayerState(PlayerState.Normal);
                }
            }
        }

        public void ResetPlayer()
        {
            transform.localPosition = startPosition.position;
            currentPlayerTransform.gameObject.SetActive(false);

            if (DeadPlatform.Instance.gameObject != null)
                DeadPlatform.Instance.InitDeadPlatform(transform);
        }

        public void PausePlayer()
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }

        public void UnpausePlayer()
        {
            StartCoroutine(PlayerAfterPause());
        }

        private IEnumerator DisablePlayer()
        {
            yield return new WaitForSeconds(0.6f);
            GameManager.Instance.SetGameState(GameState.EndGame);
        }

        private IEnumerator StartPlayer()
        {
            yield return new WaitForSeconds(3f);
            //SetPlayerLiveState(PlayerLiveState.Live);
        }

        private IEnumerator TouchTimer()
        {
            yield return new WaitForSeconds(0.1f);
#if UNITY_EDITOR
            isJumping = false;
#endif
            //jumpForce = 0;
            touch.phase = TouchPhase.Ended;
        }

        private IEnumerator PlayerAfterPause()
        {
            yield return new WaitForSeconds(0.5f);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
