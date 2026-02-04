using SlimeColorShop.Data;
using SlimeColorShop.Decor;
using UnityEngine;

namespace SlimeColorShop.MainMenu
{
    public class MainMenuSceneManager : BaseSceneManager
    {
        [SerializeField] private DecorationHandler decorationHandler;
        [SerializeField] private GameButton playButton;
        [SerializeField] private GameButton shopButton;
        [SerializeField] private GameButton decorButton;
        [SerializeField] private ShowTextEffect showTextEffectObject;
        [SerializeField] private SlimeDatabase slimeDatabase;
        [SerializeField] private PatrollingSlime patrollingSlime;

        void Start()
        {
            decorationHandler.Init();
            playButton.Init(
                delegate
                {
                    if (InventoryManager.Instance.IsEnergyEmpty())
                    {
                        RectTransform rectTransform = playButton.GetComponent<RectTransform>();
                        ShowTextEffect instance = Instantiate(showTextEffectObject, rectTransform);
                        instance.Init(Vector2.zero, "Not enough energy!", Color.red);
                        return;
                    }
                    LoadScene(SceneNameEnum.GAMEPLAY);
                }
            );
            shopButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.SHOP);
                }
            );
            decorButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.DECOR);
                }
            );

            InitPatrollingSlime();
        }

        private void InitPatrollingSlime()
        {
            int bodyId = UnityEngine.Random.Range(0, slimeDatabase.BodyEntryCount);
            int normalExpressionId = UnityEngine.Random.Range(0, slimeDatabase.NormalExpressionEntryCount);
            int happyExpressionId = UnityEngine.Random.Range(0, slimeDatabase.HappyExpressionEntryCount);
            int sadExpressionId = UnityEngine.Random.Range(0, slimeDatabase.SadExpressionEntryCount);

            Sprite bodySprite = slimeDatabase.GetBodyEntry(bodyId);
            Sprite normalExpressionSprite = slimeDatabase.GetNormalExpressionEntry(normalExpressionId);
            Sprite happyExpressionSprite = slimeDatabase.GetHappyExpressionEntry(happyExpressionId);
            Sprite sadExpressionSprite = slimeDatabase.GetSadExpressionEntry(sadExpressionId);

            patrollingSlime.Init(
                bodySprite,
                normalExpressionSprite,
                happyExpressionSprite,
                sadExpressionSprite
            );
        }
    }
}
