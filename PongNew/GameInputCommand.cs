namespace Pong.PongNew;

public class GameInputCommand : IInputCommand
{
     public class Rack1MoveUp: IInputCommand { };
     public class Rack1MoveDown: IInputCommand { };
     public class Rack2MoveUp: IInputCommand { };
     public class Rack2MoveDown: IInputCommand { };
}