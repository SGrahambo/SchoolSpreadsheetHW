using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    class ParenthesisNode : OperatorNode
    {
        public ParenthesisNode()
        {
            this.IsParenthesis = true;
        }

        public override double Evaluate()
        {
            return 0;
        }
    }
}
