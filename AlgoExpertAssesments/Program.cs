using System;
using System.Text.RegularExpressions;

namespace AlgoExpertAssesments
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInvertedBiSection();
        }
        // Bugged with odd numbers of elements, or only 2
        public static LinkedList InvertedBisection(LinkedList head)
        {
            // If null or only one node, do nothing.
            if (head == null || head.next == null)
                return head;

            // First I will count how many nodes are there - I will need that to find the middle node
            var p1 = head;
            var nodesCount = 0;
            while (p1 != null)
            {
                p1 = p1.next;
                nodesCount++;
            }

            // Now I'll reverse the first half
            int count = 1;
            p1 = head;
            var p2 = head.next;
            LinkedList p3=null;
            while ( p2 != null && count < nodesCount/2) 
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
                count++;
            }
  
            // Now p1 points to the last element of the first half - new head
            LinkedList pNewHead = p1;
            // p3 points to the firt element of second half - this will be the tail - will need to set next to null
            LinkedList pnewTail = p3;

            // Now lets reverse second half
            while (p2 != null)
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
                count++;
            }

            // Adjust pointers
            pnewTail.next = null;
            head.next = p1;


            return pNewHead;
        }

        public class LinkedList
        {
            public int value;
            public LinkedList next = null;

            public LinkedList(int value)
            {
                this.value = value;
            }
        }
        public static void TestInvertedBiSection()
        {
            var head = new LinkedList(0);
            head.next = new LinkedList(1);
            head.next.next = new LinkedList(2);
            head.next.next.next = new LinkedList(3);
            head.next.next.next.next = new LinkedList(4);
            head.next.next.next.next.next = new LinkedList(5);

            var head2 = InvertedBisection(head);
            while (head2 != null)
            {
                Console.Write(head2.value + "->");
                head2 = head2.next;
            }

            head = new LinkedList(0);
            head.next = new LinkedList(1);

            head2 = InvertedBisection(head);
            while (head2 != null)
            {
                Console.Write(head2.value + "->");
                head2 = head2.next;
            }

        }
        public static void TestGlobMatching()
        {
            string filename;
            string pattenr;

            filename = "abcdef.net";
            pattenr = "abcde?";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: false");

            filename = "abcdefg";
            pattenr = "a*e?g";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: true");

            filename = "abcdefg";
            pattenr = "*";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: true");

            filename = "abcdef";
            pattenr = "abcde?";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: true");


            filename = "asfde";
            pattenr = "a?f?g";

            Console.WriteLine(GlobMatching(filename, pattenr));
            Console.WriteLine("Expected: false");


        }
        /*
         *   Return True or False - if filename matches pattner
         *   * - match any char, any lenght
         *   ? - matches any char, exact 1 position
         */
        public static bool GlobMatching(string fileName, string pattern)
        {

            // Convert global patter no Regex
            var regPatter = '^' + pattern.Replace("?", "\\S").Replace("*", "[a-zA-Z1-9]*") + '$';

            // Check if regex
            return Regex.IsMatch(fileName, regPatter);
        }
    }
}
