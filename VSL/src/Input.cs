using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VSL.Input
{
    /// <summary>
    /// Defines a accessible mouse button.
    /// </summary>
    enum MouseButton
    {
        Left,
        Right,
        Middle,

     // Special Keys

        X1,
        X2
    }

    class InputModule
    {
        /// <summary>
        /// Module Initialization.
        /// </summary>
        public InputModule()
        {
            m_Keyboard = new KeyboardState();
            m_Mouse = new MouseState();
            m_MouseButton = new ButtonState[3];
        }

        /// <summary>
        ///     Pull next Input Event.
        ///     <para>
        ///         -keyboard, mouse position, mouse buttons
        ///     </para>
        /// </summary>
        public void Pull_Events()
        {
            m_Keyboard = Keyboard.GetState();
            m_Mouse = Mouse.GetState();

            m_MouseButton[(int)MouseButton.Left] = m_Mouse.LeftButton;
            m_MouseButton[(int)MouseButton.Right] = m_Mouse.RightButton;
            m_MouseButton[(int)MouseButton.Middle] = m_Mouse.MiddleButton;

            m_MouseButton[(int)MouseButton.X1] = m_Mouse.XButton1;
            m_MouseButton[(int)MouseButton.X2] = m_Mouse.XButton2;
        }

        /// <summary>
        ///     Check whether or not a specific keyboard Key is being pressed.
        /// </summary>
        /// <param name="key">Monogame Key index</param>
        /// <returns>Current state of Key</returns>
        public bool KeyState(Keys key)
        {
            return m_Keyboard.IsKeyDown(key) ? true : false;
        }

        /// <summary>
        ///     Fetch current Mouse position.
        ///     <para>
        ///         -Mouse position relative to monitor
        ///     </para>
        /// </summary>
        /// <returns>Current state of Mouse pos</returns>
        public Point MousePos()
        {
            return m_Mouse.Position;
        }

        /// <summary>
        ///     Fetch whether or not a specific mouse Key is being pressed.
        /// </summary>
        /// <param name="button">VSL Mouse button index</param>
        /// <returns>Current state of Key</returns>
        public bool MouseButtonState(MouseButton button)
        {
            return m_MouseButton[(int)button] == ButtonState.Pressed ? true : false;     
        }



        ButtonState[] m_MouseButton;
        KeyboardState m_Keyboard;
        MouseState m_Mouse;
    }

}
