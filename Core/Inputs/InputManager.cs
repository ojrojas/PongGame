namespace Pong.Core.Inputs;

public class InputManager(IInputMapper mapper)
{
    private readonly IInputMapper _mapper = mapper;

    private int _joystickDeadZone = 13000;

    public void GetCommandInput(SDL_Event @event, Action<IInputCommand> commands)
    {
        if (@event.gaxis.value > _joystickDeadZone || @event.gaxis.value < -_joystickDeadZone)
        {
            var button = @event.gbutton.Button;
            foreach (var command in _mapper.GetGamepadState(button))
                commands(command);
        }

        var key = @event.key.key;
        foreach (var command in _mapper.GetKeyboardState(key))
            commands(command);
    }
}