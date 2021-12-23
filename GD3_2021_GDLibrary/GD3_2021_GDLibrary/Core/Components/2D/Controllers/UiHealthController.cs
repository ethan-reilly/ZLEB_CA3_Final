using GDLibrary.Core;
using System;

namespace GDLibrary.Components.UI
{
    public class UiHealthController : UIController
    {
        #region Fields

        private int currentValue;
        private int maxValue;
        private int startValue;
        private UITextureObject parentUITextureObject;
        private float timeSinceLastUpdate;

        #endregion Fields

        #region Properties

        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = ((value >= 0) && (value <= maxValue)) ? value : 0;
            }
        }

        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = (value >= 0) ? value : 0;
            }
        }

        public int StartValue
        {
            get
            {
                return startValue;
            }
            set
            {
                startValue = (value >= 0) ? value : 0;
            }
        }

        #endregion Properties

        public UiHealthController(int startValue, int maxValue)
        {
            StartValue = startValue;
            MaxValue = maxValue;
            CurrentValue = startValue;

            //listen for UI events to change the SourceRectangle
           // EventDispatcher.Subscribe(EventCategoryType.UI, HandleEvents);
        }

        #region Event Handling
        /*
        private void HandleEvents(EventData eventData)
        {
            if (eventData.EventActionType == EventActionType.OnHealthDelta)
            {
                //get the name of the ui object targeted by this event
                var targetUIObjectName = eventData.Parameters[0] as string;

                //is it for me?
                if (targetUIObjectName != null
                    && uiObject.Name.Equals(targetUIObjectName))
                    CurrentValue = currentValue + (int)eventData.Parameters[1];
            }
        }
        */
        public override void Update()
        {
            //TODO - wasteful, called each update - refactor
            //update draw source rectangle based on current value
            timeSinceLastUpdate += Time.Instance.DeltaTimeMs;
            if(timeSinceLastUpdate >= 2000)
            {
                timeSinceLastUpdate -= 2000;
                currentValue--;
            }
            if(currentValue <=0)
            {
                //raise an event that ends the game 
                EventDispatcher.Raise(new EventData(EventCategoryType.GameObject, EventActionType.OnLose));
                
                
            }
            UpdateSourceRectangle();
        }

        protected void UpdateSourceRectangle()
        {
            //try to cast the parent that this component is attached to
            parentUITextureObject = uiObject as UITextureObject;

            if (parentUITextureObject == null)
                return;

            //how much of a percentage of the width of the image does the current value represent?
            var widthMultiplier = (float)currentValue / maxValue;

            //now set the amount of visible rectangle using the current value
            parentUITextureObject.SourceRectangleWidth = (int)Math.Round(widthMultiplier * parentUITextureObject.OriginalSourceRectangle.Width);
        }

        #endregion Event Handling

        #region Actions - Input

        protected override void HandleInputs()
        {
            throw new System.NotImplementedException();
        }

        protected override void HandleKeyboardInput()
        {
            throw new System.NotImplementedException();
        }

        protected override void HandleMouseInput()
        {
            throw new System.NotImplementedException();
        }

        protected override void HandleGamepadInput()
        {
            throw new System.NotImplementedException();
        }

        #endregion Actions - Input

        //to do...Equals, GetHashCode, Clone
    }
}