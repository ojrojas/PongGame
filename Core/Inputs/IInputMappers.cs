namespace Pong.Core.Inputs;

public interface IInputMapper
{
    IEnumerable<IInputCommand> GetKeyboardState(SDL_Keycode @eventCommand);
    IEnumerable<IInputCommand> GetGamepadState(SDL_GamepadButton @eventCommand);
}