public class ValidationResponse
{
    public bool IsValid { get; }
    public string Message { get; }

    public ValidationResponse(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }
}

/**
 * Validates a provided array of tokens on whether it is a valid equation with appropriate syntax.
 */
public static class Validator
{
    private static readonly string[] _operators = { "Number", "Add", "Subtract", "Multiply", "Divide" };
    /**
     * Validates the given array of tokens.
     * @param tokens The array of tokens to validate.
     * @return True if the tokens are a valid equation, false otherwise.
     */
    public static ValidationResponse Validate(Token[] tokens)
    {
        // An equation must have at least one token.
        if (tokens.Length == 0) return new ValidationResponse(false, "An equation must have at least one token.");

        for (int i = 1; i < tokens.Length; i += 2)
        {
            Token cToken = tokens[i];
            Token pToken = tokens[i - 1];
            Token? nToken = tokens[i + 1] ?? null;
            // An equation must have an operator between each number.
            if (Array.IndexOf(_operators, cToken.Type) == -1)
            {
                return new ValidationResponse(false, "An equation must have an operator between each number.");
            }
        }

        return new ValidationResponse(true, "The equation is valid.");
    }
}