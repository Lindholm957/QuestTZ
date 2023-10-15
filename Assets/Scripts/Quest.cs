namespace DefaultNamespace
{
    public enum Type
    {
        Single,
        Double
    }

    public enum State
    {
        Active,
        Disabled,
        TemporarilyDisabled,
        Completed
    }
    
    public class Quest
    {
        private Type _type;
        private State _state;
        private string _name;
        private string _preText;
        private string _text;

    }
}