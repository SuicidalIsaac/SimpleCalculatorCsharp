using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SimpleCalculatorCsharp.Src.Infrastructure.Parsers
{
    public class ShuntingYardParser : IExpressionParser
    {
        private readonly ILogger<ShuntingYardParser> _logger;
        private readonly Dictionary<string, (int precedence, bool isRightAssociative)> operators =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["+"] = (1, false),
                ["-"] = (1, false),
                ["*"] = (2, false),
                ["/"] = (2, false)
            };

        public ShuntingYardParser(ILogger<ShuntingYardParser> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> Parse(string expression)
        {
            expression = expression.Replace(" ", "");
            _logger.LogInformation($"Parsing expression: '{expression}'");

            var output = new Queue<string>();
            var stack = new Stack<string>();

            var tokens = Tokenize(expression).ToList();
            _logger.LogInformation($"Tokenized: [{string.Join(", ", tokens)}]");

            foreach (var token in tokens)
            {
                if (decimal.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    output.Enqueue(token);
                }
                else if (operators.ContainsKey(token))
                {
                    while (stack.Count > 0 && stack.Peek() != "(" &&
                           operators.TryGetValue(stack.Peek(), out var op2) &&
                           (operators[token].precedence < op2.precedence ||
                           (operators[token].precedence == op2.precedence && !operators[token].isRightAssociative)))
                    {
                        output.Enqueue(stack.Pop());
                    }
                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Enqueue(stack.Pop());
                    }

                    if (stack.Count == 0)
                    {
                        throw new ArgumentException("Mismatched parentheses");
                    }

                    stack.Pop();
                }
                else
                {
                    throw new ArgumentException($"Invalid token: {token}");
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                {
                    throw new ArgumentException("Mismatched parentheses");
                }
                output.Enqueue(stack.Pop());
            }

            var result = output.ToList();
            _logger.LogInformation($"RPN tokens: [{string.Join(", ", result)}]");
            return result;
        }

        private IEnumerable<string> Tokenize(string expression)
        {
            var pattern = @"(\d+\.?\d*|\.\d+)|([\+\*\/\(\)])|(-)";
            var matches = Regex.Matches(expression, pattern);

            var tokens = new List<string>();
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    tokens.Add(match.Value);
                }
            }

            var result = new List<string>();
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "-")
                {
                    if (i == 0 || result.Last() == "(" ||
                        "+-*/".Contains(result.Last()))
                    {
                        if (i + 1 < tokens.Count)
                        {
                            result.Add(tokens[i] + tokens[i + 1]);
                            i++;
                        }
                        else
                        {
                            result.Add(tokens[i]);
                        }
                    }
                    else
                    {
                        result.Add(tokens[i]);
                    }
                }
                else
                {
                    result.Add(tokens[i]);
                }
            }

            return result;
        }
    }
}