using AO;

public class References : Component
{
    [Serialized] public Texture CoinIcon;
    [Serialized] public Texture FoodIcon;
    [Serialized] public Texture MouthSizeIcon;
    [Serialized] public Texture ChewSpeedIcon;

    [Serialized] public Texture GreenButton;
    [Serialized] public Texture RedButton;
    [Serialized] public Texture BlueButton;
    [Serialized] public Texture OrangeButton;
    [Serialized] public Texture GreenFill;
    [Serialized] public Texture RedFill;
    [Serialized] public Texture BlueFill;
    [Serialized] public Texture OrangeFill;
    [Serialized] public Texture FrameDark;
    [Serialized] public Texture FrameWhite;

    public UI.NineSlice FrameSlice = new UI.NineSlice() { slice = new Vector4(12, 12, 48, 48), sliceScale = 1f };

    public Vector4 RedText    = new Vector4(255.0f/255.0f, 109.0f/255.0f, 119.0f/255.0f, 1.0f);
    public Vector4 GreenText  = new Vector4( 80.0f/255.0f, 205.0f/255.0f, 109.0f/255.0f, 1.0f);
    public Vector4 BlueText   = new Vector4( 72.0f/255.0f, 235.0f/255.0f, 251.0f/255.0f, 1.0f);
    public Vector4 YellowText = new Vector4(255.0f/255.0f, 230.0f/255.0f, 100.0f/255.0f, 1.0f);

    public Vector4 BlueBg = new Vector4(101.0f/255.0f, 241.0f/255.0f, 250.0f/255.0f, 1.0f);
    

    [Serialized] public Prefab PetPrefab;

    public static References Instance;

    public override void Start()
    {
        Instance = this;
    }
}