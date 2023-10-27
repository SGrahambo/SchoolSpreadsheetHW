// CptS 321: Expression Tree Code Demo of how NOT to code your assignements
// Problems and sollutions of this code will be discussed in class
// Note that if you sumbit this code you will not get ANY points for the assignments

namespace SpreadsheetEngine
{
    public abstract class OperatorNode : Node
    {

        public OperatorNode(char c)
        {
            this.IsOperand = false;
            this.IsParenthesis = false;
        }

        public OperatorNode(string c)
        {
            this.IsOperand = false;
            this.IsParenthesis = false;
        }

        public OperatorNode()
        {
            this.IsOperand = false;
            this.IsParenthesis = false;
        }

        public static bool ValidOperators(string c)
        {
            switch (c)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                case "(":
                case ")":
                    return true;
            }

            return false;
        }

        public static bool ValidOperators(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '(':
                case ')':
                    return true;
            }

            return false;
        }

        public string Operator { get; set; }

        public abstract double Evaluate();

    }
}