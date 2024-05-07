string equation = "1+2-3*4";
Token[] tokens = Tokenizer.Tokenize(equation);
ValidationResponse validationResponse = Validator.Validate(tokens);
Treenode tree = Parser.ParseEX(tokens);

if (validationResponse.IsValid == false)
{
    Console.WriteLine("Invalid equation: " + validationResponse.Message);
    return;
}

foreach (Token token in tokens) {
    Console.WriteLine(token.Type + ": " + token.Value);
}