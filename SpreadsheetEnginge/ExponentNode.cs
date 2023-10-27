using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    class ExponentNode : OperatorNode
    {
        public ExponentNode()
        {
            this.Precidence = 3;
        }
        public override double Evaluate()
        {
            return System.Math.Pow(Expression.Evaluate(this.Left), Expression.Evaluate(this.Right));
        }
    }
}
