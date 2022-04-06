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
            // If null or only one or two nodes, do nothing.
            if (head == null || head.next == null || head.next.next == null)
                return head;

            // First I will count how many nodes are there - I will need that to find the middle node
            var p1 = head;
            var nodesCount = 0;
            while (p1 != null)
            {
                p1 = p1.next;
                nodesCount++;
            }

            // Define what is the middle element
            var middle = nodesCount / 2 + nodesCount % 2;

            // Now I'll reverse the whole list
            int count = 1;
            p1 = head;
            var p2 = head.next;
            LinkedList p3=null;
            LinkedList pMiddleNext = null;
            LinkedList pMiddleAnt = null;
            LinkedList pMiddle = null;
            while ( p2 != null ) 
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
                count++;
                //  Save last before middle
                if (count == middle-1)
                    pMiddleAnt = p1;
                // When middle element is reached, save it
                if ( count == middle )
                    pMiddle = p1;
                // When middle element +1 is reached, save it
                if ( count== middle+1)
                    pMiddleNext = p1;
            }

            // Adjust pointers. Check if lenght is even or Odd
            if ( nodesCount%2 == 0)
            {
                // Even nodes
                // 0->1->2->3->4-5
                // 2->1->0 -> 5->4->3

                //  pMiddle->Next->Next = null
                pMiddleNext.next = null;
                //  oldHead->next = last element
                head.next = p1;

                return pMiddle;

            }
            else
            {
                // 0->1->2->3->4
                // 4->3 ->2-> 1->0

                // 1->0 -> 2 -> 4->3
                // Old head points to middle
                head.next = pMiddle;
                // Middle points to last element
                pMiddle.next = p1;
                // Middle next points null
                pMiddleNext.next = null;

                return pMiddleAnt;
            }
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

            /*
             *   0->1->2->3->4->5
             *   0<-1<-2<-3<-4<-5
             *   <-3<-4<-5<-0<-1<-2
             */
            var head2 = InvertedBisection(head);
            while (head2 != null)
            {
                Console.Write(head2.value + "->");
                head2 = head2.next;
            }
            Console.WriteLine("");

            // 0-1
            head = new LinkedList(0);
            head.next = new LinkedList(1);

            head2 = InvertedBisection(head);
            while (head2 != null)
            {
                Console.Write(head2.value + "->");
                head2 = head2.next;
            }
            Console.WriteLine("");

            // 0->1->2
            head = new LinkedList(0);
            head.next = new LinkedList(1);
            head.next.next = new LinkedList(2);

            head2 = InvertedBisection(head);
            while (head2 != null)
            {
                Console.Write(head2.value + "->");
                head2 = head2.next;
            }
            Console.WriteLine("");

            // 0->1->2->3->4
            // 1->0 -> 2 -> 4->3
            head = new LinkedList(0);
            head.next = new LinkedList(1);
            head.next.next = new LinkedList(2);
            head.next.next.next = new LinkedList(3);
            head.next.next.next.next = new LinkedList(4);

            head2 = InvertedBisection(head);
            while (head2 != null)
            {
                Console.Write(head2.value + "->");
                head2 = head2.next;
            }
            Console.WriteLine("");


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
