namespace CryoFall.ShowHealthBar.Bootstrappers
{
    using AtomicTorch.CBND.CoreMod.Bootstrappers;
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Game.WorldObjects.Character;
    using AtomicTorch.CBND.GameApi.Data.Characters;
    using AtomicTorch.CBND.GameApi.Scripting;

    public class BootstrapperClientShowHealthBar: BaseBootstrapper
    {
        public override void ClientInitialize()
        {
            BootstrapperClientGame.InitEndCallback += GameInitHandler;
        }

        private static void GameInitHandler(ICharacter currentCharacter)
        {
            var clientState = currentCharacter.GetClientState<PlayerCharacterClientState>();

            clientState.HealthbarControl = Client.UI.AttachControl(
                currentCharacter,
                new CharacterOverlayControl(currentCharacter),
                positionOffset: (0, currentCharacter.ProtoCharacter.CharacterWorldHeight),
                isFocusable: false);
        }
    }
}