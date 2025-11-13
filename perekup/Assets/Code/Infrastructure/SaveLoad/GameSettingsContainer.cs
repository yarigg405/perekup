using Yrr.Audio;


namespace Assets.Code.Infrastructure.SaveLoad
{
    internal sealed class GameSettingsContainer
    {
        public float SoundVolume;
        public float MusicVolume;

        public void UpdateVolumeSettings()
        {
            AudioManager.Instance.SetSoundsVolume(SoundVolume);
            AudioManager.Instance.SetMusicVolume(MusicVolume);
        }
    }
}
