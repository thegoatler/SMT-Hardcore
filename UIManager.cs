using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using StarterAssets;

public class UIManager : MonoBehaviour
{
    static Slider healthSlider;
    public static PlayerHealth playerHealth;
    public static void SpawnHealthUI()
    {
        //HealthMod.Logger.LogInfo("SpawnHealthUI started");

        //Damntry: Pretty sure player object does not exist.
        //  You can use the class FirstPersonController to get access to most player functions.
        //  But in the end what matters to you is FirstPersonController.Instance to get the object without
        //  having to do this GameObject find stuff
        if(FirstPersonController.Instance == null ) HealthMod.Logger.LogInfo("FirstPersonController instance returned null");
        var player = FirstPersonController.Instance.gameObject;
        if(player == null ) HealthMod.Logger.LogInfo("Player game object returned null");

        if (player.GetComponent<PlayerHealth>() == null)
            player.AddComponent<PlayerHealth>();

        playerHealth = player.GetComponent<PlayerHealth>();
        //HealthMod.Logger.LogInfo("Playerhealth set to playerhealth");
        
        //most of this is ChatGPT after this line
        var canvasGO = new GameObject("HealthCanvas");
        var canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        var scaler = canvasGO.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f;

        canvasGO.AddComponent<GraphicRaycaster>();

        // Parent canvas to main GameCanvas
        canvasGO.transform.SetParent(GameCanvas.Instance.transform, false);

        // Create slider
        var sliderGO = new GameObject("HealthSlider", typeof(RectTransform), typeof(CanvasRenderer), typeof(Slider));
        sliderGO.transform.SetParent(canvasGO.transform, false);

        var rt = sliderGO.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(200, 20);
        rt.anchorMin = new Vector2(0.5f, 1f);  // Top center
        rt.anchorMax = new Vector2(0.5f, 1f);
        rt.pivot = new Vector2(0.5f, 1f);      // Pivot from top center
        rt.anchoredPosition = new Vector2(0, -40); // 40 units from top

        // Configure slider
        healthSlider = sliderGO.GetComponent<Slider>();
        healthSlider.minValue = 0;
        healthSlider.maxValue = 100f;
        healthSlider.value = 100f;

        // Add background
        var bgGO = new GameObject("Background", typeof(Image));
        bgGO.transform.SetParent(sliderGO.transform, false);
        var bgImg = bgGO.GetComponent<Image>();
        bgImg.color = Color.gray;
        var bgRT = bgGO.GetComponent<RectTransform>();
        bgRT.anchorMin = Vector2.zero;
        bgRT.anchorMax = Vector2.one;
        bgRT.offsetMin = Vector2.zero;
        bgRT.offsetMax = Vector2.zero;

        // Fill Area
        var fillAreaGO = new GameObject("Fill Area", typeof(RectTransform));
        fillAreaGO.transform.SetParent(sliderGO.transform, false);
        var fillAreaRT = fillAreaGO.GetComponent<RectTransform>();
        fillAreaRT.anchorMin = new Vector2(0f, 0f);
        fillAreaRT.anchorMax = new Vector2(1f, 1f);
        fillAreaRT.offsetMin = new Vector2(5f, 5f);
        fillAreaRT.offsetMax = new Vector2(-5f, -5f);

        // Fill
        var fillGO = new GameObject("Fill", typeof(Image));
        fillGO.transform.SetParent(fillAreaGO.transform, false);
        var fillImage = fillGO.GetComponent<Image>();
        fillImage.color = Color.red;

        var fillRT = fillGO.GetComponent<RectTransform>();
        fillRT.anchorMin = Vector2.zero;
        fillRT.anchorMax = Vector2.one;
        fillRT.offsetMin = Vector2.zero;
        fillRT.offsetMax = Vector2.zero;

        healthSlider.fillRect = fillRT;

        //HealthMod.Logger.LogInfo("Health slider made");
        if (canvasGO.GetComponent<UIManager>() == null)
            canvasGO.AddComponent<UIManager>();
        /*OLD CODE, no clue why its still in here but its funny
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        var sliderGO = new GameObject("HealthSlider");
        sliderGO.transform.SetParent(canvasGO.transform);
        var rt = sliderGO.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(200, 20);
        rt.anchoredPosition = new Vector2(0, -20);
        rt.anchorMin = new Vector2(0.5f, 1);
        rt.anchorMax = new Vector2(0.5f, 1);
        rt.pivot = new Vector2(0.5f, 1);

        healthSlider = sliderGO.AddComponent<Slider>();
        healthSlider.minValue = 0;
        healthSlider.maxValue = 100f;
        healthSlider.value = 100f;
       
        GameObject fillGO = new GameObject("Fill");
        fillGO.transform.SetParent(sliderGO.transform);
        Image fillImage = fillGO.AddComponent<Image>();
        fillImage.color = Color.red;
        healthSlider.fillRect = fillImage.rectTransform;
        HealthMod.Logger.LogInfo("Health slider made");
        // Attach this script to a persistent GameObject to enable Update
        if (canvasGO.GetComponent<UIManager>() == null)
            canvasGO.AddComponent<UIManager>();

        //Damntry: This says to add UIManager to enable Update, but canvasGO is nothing
        //  and its not tied to anything, so it wont know when to load.
        //Instead, you need to hook it to the game own canvas so it will get loaded at its proper time.
        // There are 2 ways to attach something:
        //  1. Add the whole class as a component, like chatGPT is doing below
        //  2. Add a gameobject as a children. This would be done with: GameCanvas.Instance.transform.SetParent(canvasGO)
        //  The difference is more conceptual than functional. For small mechanics like this you would do it like 1, but lets just do
        //  it like the 2º case for now.
        //  TL;DR;: You now need to add canvasGO to the GameCanvas as a children gameobject.
        canvasGO.transform.SetParent(GameCanvas.Instance.transform, false);

        HealthMod.Logger.LogInfo("canvasgo applied to gamecanvas");
        */
    }

    void Update()
    {
        if (healthSlider != null && playerHealth != null)
        {
            healthSlider.value = playerHealth.currentHealth;
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth.Die(1f); // Press H to die
        }
       
    }
}
