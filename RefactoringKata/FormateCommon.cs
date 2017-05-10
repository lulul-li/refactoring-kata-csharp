using System.Text;

namespace RefactoringKata
{
    public class FormateCommon
    {
        public void RemoveLastCharacter(StringBuilder sb, int ordersCount)
        {
            if (ordersCount > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }
        }
    }
}