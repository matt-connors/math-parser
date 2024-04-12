string equation = "2+2";
Token[] tokens = Tokenizer.Tokenize(equation);

foreach (Token token in tokens) {
    Console.WriteLine(token.Type + ": " + token.Value);
}