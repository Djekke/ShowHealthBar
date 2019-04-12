namespace CryoFall.CNEI.Bootstrappers
{
    using AtomicTorch.CBND.CoreMod.Bootstrappers;
    using AtomicTorch.CBND.CoreMod.Characters;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Game.WorldObjects.Bars;
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
            var publicState = currentCharacter.GetPublicState<PlayerCharacterPublicState>();

            clientState.HealthbarControl = Client.UI.AttachControl(
                currentCharacter,
                new CharacterHealthBarControl()
                    { CharacterCurrentStats = publicState.CurrentStats },
                positionOffset: (
                    0,
                    currentCharacter.ProtoCharacter
                        .CharacterWorldHeight),
                isFocusable: false);
        }
    }
}