using GDLibrary.Core;
using Microsoft.Xna.Framework.Media;
using System;

namespace GDLibrary.Components.UI
{
    public class UIVideoTextureBehaviour : UIBehaviour, IDisposable
    {
        #region Fields

        private VideoCue videoCue;

        #endregion Fields

        #region Fields

        /// <summary>
        /// A player to play, pause, stop, resume, loop a user-defined video file
        /// </summary>
        private VideoPlayer videoPlayer;

        /// <summary>
        /// Cached reference to the UITextureObject for this controller
        /// </summary>
        private UITextureObject uiTextureObject;

        #endregion Fields

        public UIVideoTextureBehaviour(VideoCue videoCue)
        {
            this.videoCue = videoCue;
            videoPlayer = new VideoPlayer();
            videoPlayer.IsLooped = videoCue.IsLooped;
            videoPlayer.IsMuted = videoCue.IsMuted;

            //subscribe to events that will affect the state of this behaviour
            SubscribeToEvents();
        }

        #region Handle Events

        /// <summary>
        /// Subscribe to any events that will affect any child class (e.g. menu pause in ObjectManager)
        /// </summary>
        protected virtual void SubscribeToEvents()
        {
            EventDispatcher.Subscribe(EventCategoryType.Video, HandleEvent);
        }

        protected virtual void HandleEvent(EventData eventData)
        {
            switch (eventData.EventActionType)
            {
                case EventActionType.OnPlay:
                    break;

                case EventActionType.OnPause:
                    break;

                case EventActionType.OnResume:
                    break;

                case EventActionType.OnStop:
                    break;

                case EventActionType.OnMute:
                    break;

                case EventActionType.OnUnMute:
                    break;

                case EventActionType.OnVolumeSet:
                    break;

                default:
                    break;
            }
        }

        #endregion Handle Events

        public override void Awake()
        {
            //access the texture so we can update it!
            uiTextureObject = uiObject as UITextureObject;
        }

        public override void Update()
        {
            //update texture
            if (videoPlayer.State == MediaState.Playing)
                uiTextureObject.DefaultTexture = videoPlayer.GetTexture();
        }

        protected override void OnDisabled()
        {
            videoPlayer?.Pause();
            base.OnDisabled();
        }

        public override void Dispose()
        {
            videoPlayer?.Dispose();
        }

        //TODO - Clone
    }
}