using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class OperatorNodeFactory
    {
        public static OperatorNode CreateOperatorNode(char op)
        {
            switch (op)
            {
                case '+':
                    AdditionNode add = new AdditionNode();
                    return add;
                case '-':
                    SubractionNode sub = new SubractionNode();
                    return sub;
                case '*':
                    MultiplicationNode mul = new MultiplicationNode();
                    return mul;
                case '/':
                    DivisionNode div = new DivisionNode();
                    return div;
                case '^':
                    ExponentNode exp = new ExponentNode();
                    return exp;
                case '(':
                    ParenthesisNode par = new ParenthesisNode();
                    return par;
            }

            throw new Exception("Operater not supported");
        }
    }
}
