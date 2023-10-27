using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    class MultiplicationNode : OperatorNode
    {
        public MultiplicationNode()
        {
            this.Precidence = 2;
        }

        public override double Evaluate()
        {
            return Expression.Evaluate(this.Left) * Expression.Evaluate(this.Right);
        }
    }
}
