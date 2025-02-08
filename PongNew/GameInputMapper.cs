namespace Pong.PongNew;

public class GameInputMapper : InputMappers
{
    public override IEnumerable<IInputCommand> GetKeyboardState(SDL_Keycode eventCommand)
    {
        var commands = new List<IInputCommand>();

        if (eventCommand == SDL_Keycode.Up)
            commands.Add(new GameInputCommand.Rack1MoveUp());

        if (eventCommand == SDL_Keycode.Down)
            commands.Add(new GameInputCommand.Rack1MoveDown());

        if (eventCommand == SDL_Keycode.A)
            commands.Add(new GameInputCommand.Rack2MoveUp());

        if (eventCommand == SDL_Keycode.Z)
            commands.Add(new GameInputCommand.Rack2MoveDown());

        return commands;
    }

    public override IEnumerable<IInputCommand> GetGamepadState(SDL_GamepadButton eventCommand)
    {
        var commands = new List<IInputCommand>();

        if (eventCommand == SDL_GamepadButton.DpadUp)
            commands.Add(new GameInputCommand.Rack1MoveUp());

        if (eventCommand == SDL_GamepadButton.DpadDown)
            commands.Add(new GameInputCommand.Rack1MoveDown());

        if (eventCommand == SDL_GamepadButton.North)
            commands.Add(new GameInputCommand.Rack2MoveUp());

        if (eventCommand == SDL_GamepadButton.South)
            commands.Add(new GameInputCommand.Rack2MoveDown());

        return commands;
    }
}