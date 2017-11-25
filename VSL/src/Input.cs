using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VSL.Input
{
    class InputModule
    {
        public InputModule()
        {
            m_Keyboard = new KeyboardState();
            m_Mouse = new MouseState();
        }

        /// <summary>
        /// Pull next Input Event.
        /// </summary>
        public void Pull_Events()
        {
            m_Keyboard = Keyboard.GetState();
            m_Mouse = Mouse.GetState();
        }

        /// <summary>
        ///     <para>
        ///         Check whether or not a specific Key is being pressed.
        ///     </para>
        /// </summary>
        /// <param name="key">Monogame Key index</param>
        /// <returns>Current state of Key</returns>
        public bool KeyState(Keys key)
        {
            return m_Keyboard.IsKeyDown(key) ? true : false;
        }

        /// <summary>
        ///     <para>
        ///         Fetch current Mouse position.
        ///     </para>
        ///     - Mouse position relative to monitor
        /// </summary>
        /// <returns>Current state of Mouse</returns>
        public Point MousePos()
        {
            return m_Mouse.Position;
        }

        KeyboardState m_Keyboard;
        MouseState m_Mouse;
    }
}
