using NAudio.Wave;
using NAudio.Flac;
using System.IO;

public static class AudioDecoderFactory
{
    public static WaveStream CreateAudioReader(string filePath)
    {
        var ext = Path.GetExtension(filePath).ToLowerInvariant();
        return ext switch
        {
            ".mp3" => new Mp3FileReader(filePath),
            ".aac" => new MediaFoundationReader(filePath), // 使用MediaFoundation解码
            ".wav" => new WaveFileReader(filePath),
            ".flac" => new FlacReader(filePath), // 确保引用了 NAudio.Flac  
            ".ogg" => new VorbisWaveReader(filePath), // 自定义类，封装 NVorbis  
            _ => throw new NotSupportedException($"不支持的音频格式: {ext}")
        };
    }
}
