# VR Game UI and Interaction ⚙️

![VR UI](https://user-images.githubusercontent.com/62818241/210204905-1791e5da-d0ec-4245-94c5-aaed6fba5d09.PNG)

## 📌 Introduction
The **VR Game UI and Interaction** package provides a collection of Unity scripts designed to enhance the user interface and interactions in a VR game. This includes hand animations based on controller input, menu toggling, headset management, and customizable turn styles. Built for Unity and utilizing the XR Toolkit, these scripts offer smooth, immersive VR experiences with interactive UI elements and dynamic controls.

## 🔥 Features
- 🎮 **Hand Animation Control**: Animates hands based on pinch and grip input, adding realism to user interactions.
- 🖱️ **Menu Toggle**: Enables a VR menu to appear or disappear with the press of a button.
- 🏷️ **Headset Information**: Provides feedback on the active VR headset and displays appropriate messages.
- 🔄 **Turn Style Control**: Allows the player to switch between continuous and snap turning for customizable movement.

---

## 🏗️ How It Works
The VR game UI interacts with Unity's XR Toolkit and Input System to provide seamless, responsive behavior for VR users. The scripts manage different elements such as hand animations, the VR menu system, headset status, and movement styles.

### 📌 **AnimateHandOnInput Script**
This script uses Unity's Input System to animate the hand based on user input for pinch and grip actions. It links directly to the `Animator` to adjust animation values dynamically.

```csharp
public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    
    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
```

### 📌 **Game_Menu_Manager Script**
This script controls the VR menu. When the user presses the defined button, the menu will toggle between being visible or hidden.

```csharp
public class Game_Menu_Manager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty ShowButton;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if(ShowButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
```

### 📌 **HMD_Info_Manager Script**
Monitors and displays information about the VR headset. If no headset is connected, it alerts the user. If a mock device is in use, it gives a corresponding message.

```csharp
public class HMD_Info_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("No Headset Plugged");
        }
        else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockMDDisplay"))
        {
            Debug.Log("Using Mock HMD");
        }
        else
        {
            Debug.Log("We Have a headset " + XRSettings.loadedDeviceName);
        }
    }
}
```

### 📌 **Set_Turn_Type Script**
Allows users to toggle between continuous and snap turning. This is useful for adjusting comfort or style preferences when navigating the VR world.

```csharp
public class Set_Turn_Type : MonoBehaviour
{
    public ActionBasedContinuousTurnProvider continuousTurn;
    public ActionBasedSnapTurnProvider snapTurn;

    public void SetTypeFromIndex(int index)
    {
        if(index == 0)
        {
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
        else if(index == 1)
        {
            continuousTurn.enabled = false;
            snapTurn.enabled = true;
        }
    }
}
```

---

## 🎯 Conclusion
The **VR Game UI and Interaction** package provides essential scripts for enhancing VR gameplay and user interaction. It offers intuitive hand animation, dynamic menu control, headset status feedback, and customizable movement styles. These features create an immersive, interactive, and user-friendly experience for VR players, enhancing their overall gameplay experience. 🌟
