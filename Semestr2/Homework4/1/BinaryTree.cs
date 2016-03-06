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
                node = new Operator();
                node.Element = expression[curNumber + 1].ToString();
                curNumber += 2;
                var newNode = node.LeftChild;
                CreateChild(ref newNode, expression, ref curNumber);
                node.LeftChild = newNode;
                if (expression[curNumber] == ')')
                {
                    ++curNumber;
                }
                newNode = node.RightChild;
                CreateChild(ref newNode, expression, ref curNumber);
                node.RightChild = newNode;
            }
            else
            {
                node = new Operand();
                int newValue = 0;
                while (expression[curNumber] != ' ')
                {
                    if (expression[curNumber] == ')')
                        break;
                    newValue = newValue * 10 + (expression[curNumber] - '0');
                    ++curNumber;
                }
                node.Element = newValue.ToString();
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
