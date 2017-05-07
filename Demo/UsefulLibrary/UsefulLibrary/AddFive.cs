using System.Threading;

namespace UsefulLibrary
{
    public class AddFive
    {
        public static int ToInt(int addTo)
        {
            return addTo + 5;
        }
        public static string ToString(string addTo)
        {
            return addTo + "5";
        }
        public static string WithWait(string addTo)
        {
            Thread.Sleep(10 * 1000);
            return addTo + "5";
        }
    }
}
