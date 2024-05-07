public class Treenode
{
    public string Type { get; }
    public string Value { get; }
    public Treenode? Left { get; set; }
    public Treenode? Right { get; set; }

    public Treenode(Token token)
    {
        Type = token.Type;
        Value = token.Value;
    }
}


public static class Parser
{

    private static readonly string[] _operators = ["Add", "Subtract", "Multiply", "Divide"];
    public static Treenode ParseEX(Token[] tokens) {
        if (tokens.Length <= 2) {
            return new Treenode(tokens[0]);
        }
        if (Array.IndexOf(_operators, tokens[1].Type) != -1) {
            Treenode node = new(tokens[1])
            {
                Left = new Treenode(tokens[0]),
                Right = ParseEX(tokens[2..])
            };
            return node;
        }
        return new Treenode(tokens[0]);
    }
}