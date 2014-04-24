using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Alpha
{
    public class InputManager
    {
        private List<InputEvent> _EVENT;
        public InputEvent this[string eventName]
        {
            get
            {
                return _EVENT.Find((InputEvent a) => { return a._Name == eventName; });
            }
        }

        public InputManager()
        {
            _EVENT = new List<InputEvent>();
            AddInput();
           
        }

        public void AddEvent(string eventName)
        {
            _EVENT.Add(new InputEvent(this, eventName));
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            foreach (InputEvent a in _EVENT)
                a.Update(kbState);
        }

        private void AddInput()
        {
            AddEvent("Escape"); this["Escape"].Add(Keys.Escape);
            AddEvent("Enter"); this["Enter"].Add(Keys.Enter);
            AddEvent("Full"); this["Full"].Add(Keys.F);
            AddEvent("Pause"); this["Pause"].Add(Keys.P);
            AddEvent("Left");  this["Left"].Add(Keys.Left);
            AddEvent("Right"); this["Right"].Add(Keys.Right);
            AddEvent("Up");  this["Up"].Add(Keys.Up);
            AddEvent("Down");this["Down"].Add(Keys.Down);
            AddEvent("W"); this["W"].Add(Keys.W);
            AddEvent("A"); this["A"].Add(Keys.A);
            AddEvent("S"); this["S"].Add(Keys.S);
            AddEvent("D"); this["D"].Add(Keys.D);
        }
    }

    public class InputEvent
    {
        public string _Name;

        List<Keys> _KEYBOARD = new List<Keys>();
        InputManager _Im = null;
        bool _HeldPressed = false;
        bool _TapPressed = false;

        public bool IsDown { get { return _HeldPressed; } }
        public bool IsTapped { get { return (_HeldPressed) && (!_TapPressed); } }

        public InputEvent(InputManager im, string name)
        {
            _Im = im;
            _Name = name;
        }

        public void Add(Keys key)
        {
            if (!_KEYBOARD.Contains(key))
                _KEYBOARD.Add(key);
        }

        internal void Update(KeyboardState kbState)
        {
            _TapPressed = _HeldPressed;
            _HeldPressed = false;

            foreach (Keys k in _KEYBOARD)
                if (kbState.IsKeyDown(k))
                    _HeldPressed = true;
        }
    }
}
