/**
  * Tokenizer.cs
  * 
  * This file contains the Token and Tokenizer classes.
  * The Token class represents a token in the equation.
  * The Tokenizer class is responsible for converting an equation string into an array of tokens.
  */

/**
  * Represents a token in the equation.
  */
public class Token
{
    public string Type { get; }
    public string Value { get; }

    public Token(string type, char value)
    {
        Type = type;
        Value = value.ToString();
    }
}

/**
  * Converts an equation string into an array of tokens.
  */
public static class Tokenizer
{
    /**
      * Tokenizes the given equation string.
      * @param equation The equation string to tokenize.
      * @return An array of tokens representing the equation.
      */
    public static Token[] Tokenize(string equation)
    {
        Token[] tokens = new Token[equation.Length];
        for (int i = 0; i < equation.Length; i++)
        {
            char character = equation[i];
            tokens[i] = GetToken(character);
        }
        return tokens;
    }

    /**
      * Gets the token for the given character.
      * @param character The character to get the token for.
      * @return The token for the character.
      */
    private static Token GetToken(char character)
    {
        switch (character)
        {
            case '+': return new Token("Add", '+');
            case '-': return new Token("Subtract", '-');
            case '*': return new Token("Multiply", '*');
            case '/': return new Token("Divide", '/');
            default:
                return char.IsDigit(character)
                    ? new Token("Number", character)
                    : new Token("Unknown", character);
        }
    }
}
