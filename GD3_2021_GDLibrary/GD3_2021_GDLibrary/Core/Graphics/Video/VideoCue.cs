using Microsoft.Xna.Framework.Media;
using System;

namespace GDLibrary
{
    /// <summary>
    /// Encapsulates the properties of a playable video
    /// </summary>
    public class VideoCue
    {
        #region Fields

        /// <summary>
        /// A unique name for the video
        /// </summary>
        private string name;

        /// <summary>
        /// Unique auto generated id
        /// </summary>
        private string id;

        /// <summary>
        /// A user defined video file in supported format
        /// </summary>
        private Video video;

        /// <summary>
        /// Video volume [0-1]
        /// </summary>
        private float volume;

        /// <summary>
        /// Get/set looping
        /// </summary>
        private bool isLooped;

        /// <summary>
        /// Get/set is muted
        /// </summary>
        private bool isMuted;

        /// <summary>
        /// Time between each frame update in MS
        /// </summary>
        private int frameUpdateRateMS;


        /// <summary>
        /// Time from which to begin playing the video
        /// </summary>
        private TimeSpan playPosition;

        #endregion Fields

        #region Properties

        public string Name { get => name; set => name = value.Length != 0 ? value.Trim() : "Default_Name"; }
        public string Id { get => id; }
        public Video Video { get => video; set => video = value; }
        public bool IsLooped { get => isLooped; set => isLooped = value; }
        public bool IsMuted { get => isMuted; set => isMuted = value; }
        public TimeSpan PlayPosition { get => playPosition; set => playPosition = value; }
        public float Volume { get => volume; set => volume = value >= 0 && value <= 1 ? value : 0.5f; }

        public int FrameUpdateRateMS
        {
            get
            {
                return frameUpdateRateMS;
            }
        }
        #endregion Properties

        public VideoCue(Video video)
           : this(video, 1, false, false)
        {
        }
        public VideoCue(Video video, float volume = 1, bool isLooped = false, bool isMuted = false)
        {
            id = $"VC-" + Guid.NewGuid();
            this.video = video;
            frameUpdateRateMS = (int)Math.Ceiling(1000.0f / video.FramesPerSecond);
            Volume = volume;
            this.isLooped = isLooped;
            this.isMuted = isMuted;
        }

        //TODO - Clone, Equals, GetHashCode
    }
}