using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Other
{
    public class DelegatesPlayground
    {
        void Do(Func<int, int> f)
        {
            f(5);
        }

        private Func<int, int> a = x => x;

        delegate int F(int x);
        public void InvokeDelegate()
        {
            Do(a); // 1. Func delegate

            Do(x => x); // 2. lambda

            Do(C.F); // 3. static method group

            Do(new C().G); // 4. instance-level method group

            F f = x => x; // 5. strongly typed delegate and its instance
            Do(f.Invoke);

            Helper(); // 6.

            // 7. Static method by reflection
            // 8. Instance-level method by reflection
            // 9. Emit a class based on Do funtion's signature
        }

        void Helper()
        {
            int F (int x) => x;
            Do(F); // 6. Local function
        }
    }

    class C
    {
        public static int F(int x) => x;
        public int G(int x) => x;
    }
}
