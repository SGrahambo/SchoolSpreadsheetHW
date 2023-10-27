using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    class AdditionNode : OperatorNode
    {
        public AdditionNode()
            : base("+")
        {
            this.Precidence = 1;
        }

        public override double Evaluate()
        {
            return Expression.Evaluate(this.Left) + Expression.Evaluate(this.Right);
        }
    }
}
