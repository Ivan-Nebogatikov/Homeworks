namespace Problem1
{
    /// <summary>
    /// Binary tree class
    /// </summary>
    public class BinaryTree
    {
        private AbstractTreeElement root;

        /// <summary>
        /// Binary tree constructor
        /// </summary>
        /// <param name="fileName"> Name of file to read </param>
        public BinaryTree(string expression)
        {
            int startValue = 0;
            CreateChild(ref root, expression, ref startValue);
        }

        private void CreateChild(ref AbstractTreeElement node, string expression, ref int curNumber)
        {
            if (curNumber >= expression.Length)
                return;
            while (expression[curNumber] == ' ' || expression[curNumber] == ')')
                ++curNumber;
            if (expression[curNumber] == '(')
            {
                Operator newOpertator = new Operator();
                newOpertator.Element = expression[curNumber + 1];
                curNumber += 2;
                var newNode = newOpertator.LeftChild;
                CreateChild(ref newNode, expression, ref curNumber);
                newOpertator.LeftChild = newNode;
                if (expression[curNumber] == ')')
                {
                    ++curNumber;
                }
                newNode = newOpertator.RightChild;
                CreateChild(ref newNode, expression, ref curNumber);
                newOpertator.RightChild = newNode;
                node = newOpertator;
            }
            else
            {
                Operand newOperand = new Operand();
                newOperand.Element = 0;
                while (expression[curNumber] != ' ')
                {
                    if (expression[curNumber] == ')')
                        break;
                    newOperand.Element = newOperand.Element * 10 + (expression[curNumber] - '0');
                    ++curNumber;
                }
                node = newOperand;
            }
        }

        /// <summary>
        /// Print all tree
        /// </summary>
        public void Print()
        {
            root.Print();
        }

        /// <summary>
        /// Calculate all tree
        /// </summary>
        /// <returns> Int value of calculating </returns>
        public int Calculate() => root.Calculate();
    }
}
