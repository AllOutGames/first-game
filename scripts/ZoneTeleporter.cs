using AO;

public class ZoneTeleporter : Component
{
    [Serialized] public string ZoneName;
    [Serialized] public Entity SpawnPoint;

    public override void Start()
    {
        var interactable = Entity.GetComponent<Interactable>();
        interactable.OnInteract += OnInteract;
    }

    public override void Update()
    {
        if (Network.IsServer) return;
        var interactable = Entity.GetComponent<Interactable>();
        if (interactable == null) return;

        var localPlayer = (FatPlayer) Network.LocalPlayer;
        var owned = localPlayer.UnlockedZones.Contains(ZoneName);
        interactable.Text = owned ? "Teleport" : "Buy";

        if (interactable.IsWorldUIShowing()) 
        {
            UI.PushContext(UI.Context.WORLD);
            using var _ = AllOut.Defer(UI.PopContext);

            var worldRect = interactable.GetWorldRect();
            var rect = worldRect.TopCenterRect().Grow(0.2f, 0.3f, 0, 0.3f);
            UI.Image(rect, References.Instance.FrameDark, new AO.Vector4(0,0,0, 0.5f), References.Instance.FrameSlice);

            var textSettings = new UI.TextSettings()
            {
                color = Vector4.White,
                size = 0.175f,
                horizontalAlignment = UI.TextSettings.HorizontalAlignment.Center,
                verticalAlignment = UI.TextSettings.VerticalAlignment.Center,
                outline = true,
                outlineThickenss = 0.1f,
            };

            if (owned) 
            {
                UI.Text(rect, $"{ZoneName}", textSettings);
            }
            else
            {
                localPlayer.ZoneCosts.TryGetValue(ZoneName, out var cost);
                UI.Image(rect.LeftRect().Grow(0, 0.1f, 0, 0.1f), References.Instance.CoinIcon, Vector4.White, new UI.NineSlice());
                UI.Text(rect, $"{cost}", textSettings);
            }
        }
    }

    public void OnInteract(Player p)
    {
        var player = (FatPlayer) p;
        if (Network.IsServer) 
        {
            if (!player.UnlockedZones.Contains(ZoneName)) 
            {
                player.PurchaseZone(ZoneName);
            }
            else 
            {
                player.Teleport(SpawnPoint.Position);
            }
        }
    }
}