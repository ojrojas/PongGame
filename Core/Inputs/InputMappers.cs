
namespace Pong.Core.Inputs;

public class InputMappers : IInputMapper
{
    public virtual IEnumerable<IInputCommand> GetGamepadState(SDL_GamepadButton eventCommand)=> [];
    public virtual IEnumerable<IInputCommand> GetKeyboardState(SDL_Keycode eventCommand)=> [];
}