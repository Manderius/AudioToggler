namespace AudioToggler
{
    enum AudioLevel { HIGH, LOW };

    internal class AudioManipulation
    {
        const string ConfigPath = @"C:\Program Files\EqualizerAPO\config\config.txt";
        const string TEXT_LOW = "-20";
        const string TEXT_HIGH = "10";

        public static AudioLevel GetAudioLevel() {
            string[] lines = File.ReadAllLines(ConfigPath);
            return lines[0].Contains(TEXT_LOW) ? AudioLevel.LOW : AudioLevel.HIGH;
        }

        public static AudioLevel ToggleAudio()
        {
            string[] lines = File.ReadAllLines(ConfigPath);
            AudioLevel newLevel;
            if (lines[0].Contains(TEXT_LOW))
            {
                lines[0] = lines[0].Replace(TEXT_LOW, TEXT_HIGH);
                newLevel = AudioLevel.HIGH;
            }
            else
            {
                lines[0] = lines[0].Replace(TEXT_HIGH, TEXT_LOW);
                newLevel = AudioLevel.LOW;
            }
            File.WriteAllLines(ConfigPath, lines);
            return newLevel;
        }
    }
}
