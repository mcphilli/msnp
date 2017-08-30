using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLOMcSharp7617
{
    //partition.cpp MCP 8-8-17
    public static class partition
    {
        //int get_partition_from_file_tp_format(string S, deque<deque<int> > & M, deque<double> & bss) 
        public static int get_partition_from_file_tp_format(string S, ref List<List<int>> M, ref LinkedList<double> bss)
        {
            bss = new LinkedList<double>(); //.clear();
            //M.clear();
            M = new List<List<int>>();
            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(S, ref b);
            b = S;
            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            string st;
            
            //while (getline(inb, st))
            while((st=inb.ReadLine())!=null)
            {

                LinkedList<string> vv = new LinkedList<string>();
                cast.separate_strings(ref st, ref vv);
                if (st.Count() > 0 && (vv.ElementAt(0) == "#module" || vv.ElementAt(0) == "#group")) {
                    string vv5 = vv.ElementAt(5);
                    if (cast.cast_string_to_double(ref vv5) < 1)
                    {
                        
                        //getline(inb, st);
                        double bs = cast.cast_string_to_double(ref vv5);
                        vv.Find(vv.ElementAt(5)).Value = vv5;

                        List<int> v = new List<int>(); //MCP 8-8 I changed this from deque<int>.
                        cast.cast_string_to_doubles(ref st, ref v);
                        //sort(v.begin(), v.end());
                        v.Sort();
                        //if (!v.empty())
                        if(v.Count()>0) //should check whether empty or not...
                        {
                            M.Add(v);
                            bss.AddLast(bs);
                        }
                    }
                }
            }
            return 0;
        }
        public static int get_partition_from_file_tp_format_with_homeless(string S, ref List<List<int>> M, ref LinkedList<double> bss)
        {

            //bss.clear();
            bss = new LinkedList<double>();
            //M.clear();
            M = new List<List<int>>();

            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(S, ref b);
            b = S;

            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            string st;
            //while (getline(inb, st))
            while((st = inb.ReadLine())!= null)
            {
                List<string> vv = new List<string>();
                cast.separate_strings(ref st, ref vv);
                if (st.Count() > 0 && (vv[0] == "#module" || vv[0] == "#group"))
                {

                    //getline(inb, st);
                    st = inb.ReadLine();
                    string vv5 = vv[5];
                    double bs = cast.cast_string_to_double(ref vv5);

                    List<int> v = new List<int>();
                    cast.cast_string_to_doubles(ref st, ref v);
                    //sort(v.begin(), v.end());
                    v.Sort();
                    //if (!v.empty())
                    if(v.Count()>0)
                    {
                        M.Add(v);
                        bss.AddLast(bs);
                    }
                }
            }
            return 0;
        }
        
        public static int get_partition_from_file_tp_format(string S, ref Dictionary<int, List<int>> M)
        {
            // M gives the name of the module and the corresponding deque (all the deques!!!)

            //M.clear();
            M = new Dictionary<int, List<int>>();

            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(S, ref b);
            b = S;

            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            string st;
            //while (getline(inb, st))
            while((st = inb.ReadLine())!=null)
            {
                List<string> vv = new List<string>();
                cast.separate_strings(ref st, ref vv);
                if (st.Count() > 0 && (vv[0] == "#module"))
                {
                    string vvSend = vv[1];
                    int name = cast.cast_int(cast.cast_string_to_double(ref vvSend));
                    vv[1] = vvSend;
                    //getline(inb, st);
                    st = inb.ReadLine();

                    List<int> v = new List<int>();
                    cast.cast_string_to_doubles(ref st, ref v);
                    //sort(v.begin(), v.end());
                    v.Sort();
                    //if (!v.empty())
                    if(v.Count()>0)
                        M.Add(name, v);
                }
            }
            return 0;
        }
        public static int get_partition_from_file_tp_format(string S, ref List<List<int>> M, ref List<int> homel)
        {
            M = new List<List<int>>();//.clear();
            homel = new List<int>();//.clear();

            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(S, ref b);
            b = S;

            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            string st;
            //while (getline(inb, st))
            while((st = inb.ReadLine())!=null)
            {

                List<string> vv = new List<string>();
                cast.separate_strings(ref st, ref vv);
                if (st.Count() > 0 && (vv[0] == "#module" || vv[0] == "#group"))
                {
                    string vv5 = vv[5];
                    if (cast.cast_string_to_double(ref vv5) < 1)
                    {
                        vv[5] = vv5;
                        //getline(inb, st);
                        st = inb.ReadLine();

                        List<int> v = new List<int>();
                        cast.cast_string_to_doubles(ref st, ref v);
                        //sort(v.begin(), v.end());
                        v.Sort();
                        //if (!v.empty())
                        if(v.Count()>0)
                            M.Add(v);
                    }
                    else
                    {
                        //getline(inb, st);
                        st = inb.ReadLine();
                        List<int> v = new List<int>();
                        cast.cast_string_to_doubles(ref st, ref v);
                        //if (!v.empty())
                        if(v.Count()>0)
                            homel.Add(v[0]);
                    }
                }
            }
            //sort(homel.begin(), homel.end());
            homel.Sort();
            return 0;
        }

        public static int get_partition_from_file_tp_format(string S, ref List<List<int>> M, bool anyway)
        {
            // if anyway = true il also takes the homeless
            //M.clear();
            M = new List<List<int>>();

            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(S, ref b);
            b = S;

            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            string st;
            //while (getline(inb, st))
            while((st = inb.ReadLine())!=null)
            {
                List<string> vv = new List<string>();
                cast.separate_strings(ref st, ref vv);
                if (st.Count() > 0 && (vv[0] == "#module" || vv[0] == "#group")) {
                    string vv5 = vv[5];
                    if (cast.cast_string_to_double(ref vv5) < 1 || anyway)
                    {
                        //getline(inb, st);
                        st = inb.ReadLine();
                        List<int> v = new List<int>();
                        cast.cast_string_to_doubles(ref st, ref v);
                        //sort(v.begin(), v.end());
                        v.Sort();
                        //if (!v.empty())
                        if(v.Count()>0)
                            M.Add(v);
                    }
                }
            }
            return 0;
        }

        public static int get_partition_from_file_tp_format(string S, ref List<List<int>> M)
        {
            return get_partition_from_file_tp_format(S, ref M, false);
        }


        public static int get_partition_from_file(string s, ref List<List<int>> M, int min)
        {
            //M.clear();
            M = new List<List<int>>();
            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(s, ref b);
            b = s;

            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            string st;
            //while (getline(inb, st))
            while((st = inb.ReadLine())!=null)
            {
                List<int> v = new List<int>();
                cast.cast_string_to_doubles(ref st, ref v);
                //sort(v.begin(), v.end());
                v.Sort();
                if ((v.Count()>0)&& (int)(v.Count()) > min)
                    M.Add(v);
            }
            return 0;
        }

        public static int get_partition_from_file(string s, ref List<List<int>> M)
        {
            return get_partition_from_file(s, ref M, 0);
        }

        public static int get_partition_from_file_list(string s, ref List<List<int>> ten)
        {
            //ten.clear();
            ten = new List<List<int>>();

            string b = string.Empty ;//new char[100];
            //cast.cast_string_to_char(s, ref b);
            b = s;

            //ifstream inb(b);
            System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

            //multimap<int, int> id_value;
            Dictionary<int, List<int>> id_value = new Dictionary<int, List<int>>();
            Dictionary<int, int> value_com = new Dictionary<int, int>();
            string st;
            //while (getline(inb, st))
            while((st = inb.ReadLine())!= null)
            {
                List<int> v = new List<int>(); ;
                cast.cast_string_to_doubles(ref st, ref v);
                for (int i = 1; i < (int)(v.Count()); i++)
                {
                    value_com.Add(v[i], value_com.Count());
                    //id_value.insert(make_pair(v[0], v[i]));
                    if (id_value.ContainsKey(v[i])) { 
                        id_value[v[0]].Add(v[i]);
                    }
                    else //takes care of adding an actual new element, where the key doesn't already exist.
                    {
                        List<int> vi = new List<int>(v[i]);
                        id_value.Add(v[0], vi);
                    }
                }

            }


            int com = 0;
            //for (map<int, int>::iterator it = value_com.begin(); it != value_com.end(); it++)
            foreach(KeyValuePair<int,int> it in value_com) { 
                value_com[it.Key] = com++;
            }
            List<int> first = new List<int>();
            for (int i = 0; i < (int)(value_com.Count()); i++)
                ten.Add(first);
            
            //for (multimap<int, int>::iterator itm = id_value.begin(); itm != id_value.end(); itm++)
            foreach(KeyValuePair<int, List<int>> itmo in id_value)
            {
                foreach(int itmi in itmo.Value)
                {
                    //ten[value_com[itm->second]].push_back(itm->first);
                    ten[value_com[itmi]].Add(itmo.Key);
                }
            }   
            return 0;
        }
    }
    public class oslom_module
    {


        public oslom_module(int a) { nc = 1; kout = a; ktot = a; }
        //~oslom_module() { };

        public int nc;
        public int kout;
        public int ktot;

    }
    //Incorporating the Standard Includes, I hope, 7-18-17.
    //Starts with Cast.h.
    public static class cast
    {
        public static bool cast_string_to_double(ref string b, ref double h)
        {

            // set h= the number written in b[]; 
            // return false if there is an error


            h = 0;
            int epresent = 0;

            for (int i = 0; i < (int)(b.Length); i++)
            {

                if (b[i] == 'e' || b[i] == 'E')
                    epresent++;
            }

            if (epresent > 1)
                return false;


            if (epresent == 1)
            {

                string sbefe = System.String.Empty;
                string safte = System.String.Empty;

                epresent = 0;

                for (int i = 0; i < (int)(b.Length); i++)
                {


                    if (epresent == 0 && (b[i] != 'e' && b[i] != 'E'))
                        sbefe += b[i];

                    if (epresent == 1 && (b[i] != 'e' && b[i] != 'E'))
                        safte += b[i];

                    if (b[i] == 'e' || b[i] == 'E')
                    {
                        epresent++;


                    }

                }

                double number_ = new double();
                bool bone = cast_string_to_double(ref sbefe, ref number_);

                double exp_ = new double();
                bool btwo = cast_string_to_double(ref safte, ref exp_);

                if (bone && btwo)
                {
                    h = number_ * Math.Pow(10, exp_);
                    return true;

                }
                else
                    return false;





            }


            if ((int)(b.Length) == 0)
                return false;

            int sign = 1;


            if (b[0] == '-')
            {

                //b[0] = '0';
                StringBuilder builder = new StringBuilder(b);
                builder[0] = '0';
                b = builder.ToString();
                sign = -1;

            }

            if (b[0] == '+')
            {
                StringBuilder builder = new StringBuilder(b);
                builder[0] = '0';
                b = builder.ToString();
            }






            int digits_before = 0;
            for (int i = 0; i < (int)(b.Length); i++)
                if (b[i] != '.')
                    digits_before++;
                else
                    break;
            int j = 0;
            while (j != digits_before)
            {
                int number = ((int)(b[j]) - 48);
                h += number * Math.Pow(10, digits_before - j - 1);
                if (number < 0 || number > 9)
                {
                    //cout<<"err "<<number<<endl;
                    return false;
                }
                j++;
            }


            j = digits_before + 1;

            while (j < (int)(b.Length))
            {

                int number = ((int)(b[j]) - 48);
                h += number * Math.Pow(10, digits_before - j);

                if (number < 0 || number > 9)
                    return false;

                j++;
            }


            h = sign * h;


            return true;

        }


        public static double cast_string_to_double(ref string b)
        {


            double h = new double();
            cast_string_to_double(ref b, ref h);

            return h;

        }

        public static int cast_int(double u)
        {

            return (int)(u + 0.5);

        }


        /*public static int cast_string_to_char(string file_name, ref string b) //MCP commented out 7-18-17, hoping I won't need CharPtrs. (Originally char*).
        {
            for (int i = 0; i < (int)(file_name.Count()); i++) {
                //b.ElementAt(i) = file_name[i];
                b[i] = file_name[i];
            }
            b[file_name.Count()] = '\0';
            return 0;

        }*/



        public static bool cast_string_to_doubles(ref string b, ref List<double> v)
        {


            v.Clear();
            string s1 = System.String.Empty;

            for (int i = 0; i < (int)(b.Length); i++)
                if ((int)(b.Length) > 0 && b[0] != '#')
                {


                    if (b[i] != '1' && b[i] != '2' && b[i] != '3' && b[i] != '4' && b[i] != '5' && b[i] != '6' && b[i] != '7' && b[i] != '8' && b[i] != '9' && b[i] != '0' && b[i] != '.' && b[i] != 'e' && b[i] != '+' && b[i] != '-' && b[i] != 'E')
                    {

                        double num = new double();
                        if (cast_string_to_double(ref s1, ref num))
                            v.Add(num);

                        s1.Remove(0);
                    }
                    else
                        s1 += b[i];


                    if (i == (int)(b.Length) - 1)
                    {

                        double num = new double();
                        if (cast_string_to_double(ref s1, ref num))
                            v.Add(num);

                        s1.Remove(0);
                    }
                }
            return true;
        }
        public static bool cast_string_to_doubles(ref string b, ref List<int> v)
        {



            v.Clear();
            List<double> d = new List<double>();
            cast_string_to_doubles(ref b, ref d);
            for (int i = 0; i < (int)(d.Count()); i++)
                v.Add((int)(d[i]));

            return true;
        }
        public static bool separate_strings(ref string b, ref List<string> v)
        {
            v.Clear();
            string s1 = System.String.Empty;
            for (int i = 0; i < (int)(b.Length); i++)
            {
                if (b[i] == ' ' || b[i] == '\t' || b[i] == '\n' || b[i] == ',')
                {
                    if (s1.Length > 0)
                        v.Add(s1);

                    s1.Remove(0);


                }
                else
                    s1 += b[i];


                if (i == (int)(b.Length) - 1)
                {
                    if (s1.Length > 0)
                        v.Add(s1);
                    s1.Remove(0);
                }
            }
            return true;
        }
        public static bool separate_strings(ref string b, ref LinkedList<string> v)
        {
            v.Clear();
            string s1 = System.String.Empty;
            for (int i = 0; i < (int)(b.Length); i++)
            {
                if (b[i] == ' ' || b[i] == '\t' || b[i] == '\n' || b[i] == ',')
                {
                    if (s1.Length > 0)
                        v.AddLast(s1);
                    s1.Remove(0);
                }
                else
                    s1 += b[i];


                if (i == (int)(b.Length) - 1)
                {
                    if (s1.Length > 0)
                        v.AddLast(s1);
                    s1.Remove(0);
                }
            }
            return true;
        }
        public static double approx(double a, int digits)
        {
            digits--;
            bool neg = false;
            if (a < 0)
            {
                neg = true;
                a = -a;
            }
            //cout<<a<<endl;

            int tpow = 0;
            while (a < Math.Pow(10, digits))
            {

                tpow++;
                a *= 10;


            }
            while (a > Math.Pow(10, digits + 1))
            {

                tpow--;
                a /= 10;


            }


            if (neg == false)
                return (int)(a) / Math.Pow(10, tpow);
            else
                return -(int)(a) / Math.Pow(10, tpow);



        }

    }

    /*public class Seq<T> //mcp 7-18-17; may not need, due to List awesomeness.
    {
        public double average_func(ref List<T> sq)
        {
            if (sq.Count==0)
                return 0;

            double av = 0;
            foreach(T it in sq)
                av += it;

            av = av / sq.Count();

            return av;

        }

    }*/
    public class Combinatorics
    {
        public static double variance_func(ref List<double> sq)
        {

            if (sq.Count == 0)
                return 0;

            double av = 0;
            double var = 0;

            foreach (double it in sq)
            {
                av += it;
                var += (it) * (it);
            }


            av = av / sq.Count();
            var = var / sq.Count();
            var -= av * av;

            if (var < 1e-7)
                return 0;

            return var;

        }
        public static double variance_func(ref List<int> sq)
        {

            if (sq.Count == 0)
                return 0;

            double av = 0;
            double var = 0;

            foreach (int it in sq)
            {
                av += (double)it;
                var += (double)(it) * (double)(it);
            }


            av = av / sq.Count();
            var = var / sq.Count();
            var -= av * av;

            if (var < 1e-7)
                return 0;

            return var;

        }

        public static double average_pf(ref List<double> sq)
        {
            double av = 0;
            int h = 0;
            foreach (double it in sq)
            {
                av += it * h;
                h++;
            }
            return av;
        }
        public static double average_pf(ref List<int> sq)
        {
            double av = 0;
            int h = 0;
            foreach (int it in sq)
            {
                av += (double)it * h;
                h++;
            }
            return av;
        }

        public static double variance_pf(ref List<double> sq)
        {


            double av = 0;
            double var = 0;
            int h = 0;

            /* typename Seq::iterator it = sq.begin();
             while (it != sq.end())*/
            foreach (double it in sq)
            {

                av += it * h;
                var += (it) * h * h;
                h++;
            }


            var -= av * av;

            if (var < 1e-7)
                return 0;

            return var;

        }
        public static double variance_pf(ref List<int> sq)
        {


            double av = 0;
            double var = 0;
            int h = 0;
            foreach (int it in sq)
            {

                av += (double)it * h;
                var += ((double)it) * h * h;
                h++;
            }


            var -= av * av;

            if (var < 1e-7)
                return 0;

            return var;

        }

        public static double log_factorial(int num)
        {

            double log_result = 0;
            for (int i = 1; i <= num; i++)
                log_result += Math.Log(i);

            return (log_result);

        }

        public static double log_combination(int n, int k)
        {
            if (k == 0)
                return 0;
            if (n < k)
                return 0;
            if (n - k < k)
                k = n - k;
            double log_c = 0;
            for (int i = n - k + 1; i <= n; i++)
                log_c += Math.Log(i);
            for (int i = 1; i <= k; i++)
                log_c -= Math.Log(i);
            return log_c;
        }

        public static double binomial(int n, int x, double p)
        {       //	returns the binomial distribution, n trials, x successes, p probability

            if (p == 0)
            {
                if (x == 0)
                    return 1;
                else
                    return 0;
            }
            if (p >= 1)
            {
                if (x == n)
                    return 1;
                else
                    return 0;
            }
            double log_b = 0;
            log_b += log_combination(n, x) + x * Math.Log(p) + (n - x) * Math.Log(1 - p);
            return (Math.Exp(log_b));
        }

        public static int binomial_cumulative(int n, double p, ref List<double> cum)
        {
            cum.Clear();
            double c = 0;
            for (int i = 0; i <= n; i++)
            {
                c += binomial(n, i, p);
                cum.Add(c);
            }
            return 0;
        }

        public static int powerlaw(int n, int min, double tau, ref List<double> cumulative)
        {
            cumulative.Clear();
            double a = 0;
            for (double h = min; h < n + 1; h++)
                a += Math.Pow((1.0 / h), tau);
            double pf = 0;
            for (double i = min; i < n + 1; i++)
            {
                pf += 1 / a * Math.Pow((1.0 / (i)), tau);
                cumulative.Add(pf);
            }
            return 0;
        }

        public static int distribution_from_cumulative(List<double> cum, ref List<double> distr) //MCP note that in c++, cum was sent as a /*const*/ant, and by Ref...
        {
            distr.Clear();
            double previous = 0;
            for (int i = 0; i < (int)(cum.Count()); i++)
            {
                distr.Add(cum[i] - previous);
                previous = cum[i];
            }
            return 0;
        }

        public static int cumulative_from_distribution(ref List<double> cum, List<double> distr)
        {		// cum is set equal to the cumulative, distr is the distribution
            //note that the Distr was sent by ref, and /*const*/, in c++.
            cum.Clear();
            double sum = 0;
            for (int i = 0; i < (int)(distr.Count()); i++)
            {
                sum += distr[i];
                cum.Add(sum);
            }
            return 0;
        }
        public static double poisson(int x, double mu)
        {
            return (Math.Exp(-mu + x * Math.Log(mu) - log_factorial(x)));

        }

        public static int shuffle_and_set(ref List<int> due, int dim)
        {       // it sets due as a random sequence of integers from 0 to dim-1
            //note that due was originally an in pointer.

            //multimap<double, int> uno;
            List<KeyValuePair<double, int>> uno = new List<KeyValuePair<double, int>>();
            for (int i = 0; i < dim; i++)
            {
                //uno.Add(new Dictionary<double, int>((double)MyRandom.ran4(), i));
                KeyValuePair<double, int> kvp = new KeyValuePair<double, int>(MyRandom.ran4(), i);
                uno.Add(kvp);
            }
            //multimap<double, int>::iterator it;
            int h = 0;
            //for (it = uno.begin(); it != uno.end(); it++)
            foreach (KeyValuePair<double, int> it in uno)
            {
                due[h++] = it.Value;
            }
            return 0;
        }

        public static int shuffle_s(ref List<int> sq)
        {

            int siz = sq.Count();
            if (siz == 0)
                return -1;

            for (int i = 0; i < (int)(sq.Count()); i++)
            {
                int random_pos = MyRandom.irand(siz - 1);
                int random_card_ = sq[random_pos];
                sq[random_pos] = sq[siz - 1];
                sq[siz - 1] = random_card_;
                siz--;
            }
            return 0;
        }
        public static int shuffle_s(ref List<double> sq)
        {

            int siz = sq.Count();
            if (siz == 0)
                return -1;

            for (int i = 0; i < (int)(sq.Count()); i++)
            {
                int random_pos = MyRandom.irand(siz - 1);
                int random_card_ = (int)sq[random_pos];
                sq[random_pos] = sq[siz - 1];
                sq[siz - 1] = random_card_;
                siz--;
            }
            return 0;
        }

        public static double compute_r(int x, int k, int kout, int m)
        {
            double r = 0;
            for (int i = x; i <= k; i++)
                r += binomial(k, i, (double)(kout) / (double)(m));
            return r;
        }

        public static int add_factors(ref List<double> num, ref List<double> den, int n, int k)
        {
            if (n < k)
                return -1;

            if (n - k < k)
                k = n - k;

            if (k == 0)
                return 0;

            for (int i = n - k + 1; i <= n; i++)
                num.Add((double)(i));

            for (int i = 1; i <= k; i++)
                den.Add((double)(i));

            return 0;
        }

        public static double compute_hypergeometric(int i, int k, int kout, int m)
        {
            if (i > k || i > kout || k > m || kout > m)
                return 0;
            double prod = 1;
            List<double> num = new List<double>();
            List<double> den = new List<double>();
            if (add_factors(ref num, ref den, kout, i) == -1)
                return 0;
            if (add_factors(ref num, ref den, m - kout, k - i) == -1)
                return 0;
            if (add_factors(ref den, ref num, m, k) == -1)
                return 0;
            num.Sort();
            den.Sort();

            //prints(den);

            for (int h = 0; h < (int)(den.Count()); h++)
            {
                if (den[h] <= 0)
                {
                    System.Diagnostics.Trace.WriteLine("denominator has zero or less (in the hypergeometric)");
                    return 0;
                }
            }
            for (int h = 0; h < (int)(num.Count()); h++)
            {
                if (num[h] <= 0)
                {
                    System.Diagnostics.Trace.WriteLine("numerator has zero or less (in the hypergeometric)");
                    return 0;
                }
            }
            //cout<<"sizes: "<<num.Count()<<" "<<den.Count()<<endl;
            for (int j = 0; j < (int)(num.Count()); j++)
                prod = prod * num[j] / den[j];
            return prod;
        }

        public static int random_from_set(ref HashSet<int> s)
        {


            int pos1 = MyRandom.irand(s.Count() - 1);
            /*set<int>::iterator it1 = s.begin();
            for (int i = 0; i < pos1; i++)
                it1++;*/
            int it1 = s.ElementAt(pos1);
            return it1;



        }

    }
    public class DN
    {//DN -> List_numeric. 
        public static void deque_to_set_app(List<int> a, ref HashSet<int> s)
        {
            for (int i = 0; i < (int)(a.Count()); i++)
                s.Add(a[i]);
        }
        public static bool compare(ref List<double> one, ref List<double> two)
        {
            if (one.Count() != two.Count())
                return false;

            for (int i = 0; i < (int)(one.Count()); i++)
            {
                if (Math.Abs(Math.Floor(one[i] - two[i])) > 1e-7)
                    return false;
            }
            return true;
        }

        public static double Euclidean_norm(/*const ref*/ List<double> a)
        {


            double norm = 0;
            for (int i = 0; i < (int)(a.Count()); i++)
            {
                norm += a[i] * a[i];
            }

            return Math.Sqrt(norm);


        }
        public static int Euclidean_normalize(ref List<double> a)
        {
            double norm = Euclidean_norm(a);
            for (int i = 0; i < (int)(a.Count()); i++)
            {
                a[i] /= norm;
            }

            return 0;
        }

        public static double scalar_product(ref List<double> a, /*ref */List<double> b)
        {
            double norm = 0;
            for (int i = 0; i < (int)(a.Count()); i++)
            {
                norm += a[i] * b[i];
            }
            return norm;
        }

        public static int orthogonalize(ref List<double> a, ref List<List<double>> M)
        {

            Euclidean_normalize(ref a);
            for (int i = 0; i < (int)(M.Count()); i++)
            {
                double w = scalar_product(ref a, M[i]);

                for (int j = 0; j < (int)(a.Count()); j++)
                    a[j] -= w * M[i][j];


            }

            Euclidean_normalize(ref a);
            return 0;

        }



        public static int matrix_time_vector(ref List<List<double>> Q, ref List<double> v, ref List<double> new_s)
        {
            new_s.Clear();

            for (int i = 0; i < (int)(Q.Count()); i++)
            {
                double n = 0;
                for (int j = 0; j < (int)(Q[i].Count()); j++)
                    n += Q[i][j] * v[j];

                new_s.Add(n);
            }


            return 0;

        }


        public static void set_to_List(/*const ref*/ HashSet<int> s, ref List<int> a)
        {

            a.Clear();

            /*for (HashSet<int>::iterator its = s.begin(); its != s.end(); its++)*/
            foreach (int its in s)
            {
                a.Add(its);
            }

        }

        public static void set_to_List(/*const ref*/ HashSet<int> s, ref LinkedList<int> a)
        {
            a.Clear();
            /*for (HashSet<int>::iterator its = s.begin(); its != s.end(); its++)*/
            foreach (int its in s)
            {
                a.AddLast(its);
            }
        }
        public static void set_to_deque(/*const ref*/ HashSet<int> s, ref LinkedList<int> a)
        {
            a.Clear();
            /*for (HashSet<int>::iterator its = s.begin(); its != s.end(); its++)*/
            foreach (int its in s)
            {
                a.AddLast(its);
            }
        }
        public static void set_to_List(/*const*/ ref HashSet<double> s, ref List<double> a)
        {

            a.Clear();

            /*for (HashSet<double>::iterator its = s.begin(); its != s.end(); its++)
                a.push_back(*its);*/
            foreach (double its in s)
            {
                a.Add(its);
            }

        }
        public static void set_to_List(/*const ref*/ HashSet<double> s, ref LinkedList<double> a)
        {
            a.Clear();
            /*for (HashSet<int>::iterator its = s.begin(); its != s.end(); its++)*/
            foreach (int its in s)
            {
                a.AddLast(its);
            }
        }
        public static void set_to_deque(/*const ref*/ HashSet<double> s, ref LinkedList<double> a)
        {
            a.Clear();
            /*for (HashSet<int>::iterator its = s.begin(); its != s.end(); its++)*/
            foreach (int its in s)
            {
                a.AddLast(its);
            }
        }

        public static void List_to_set(/*const ref*/ List<double> a, ref HashSet<double> s)
        {

            s.Clear();
            for (int i = 0; i < (int)(a.Count()); i++)
            {
                s.Add(a[i]);
            }
        }

        public static void List_to_set(/*const ref*/ List<int> a, ref HashSet<int> s)
        {

            s.Clear();
            for (int i = 0; i < (int)(a.Count()); i++)
                s.Add(a[i]);
        }

        public static void List_to_set_app(/*const ref*/ List<int> a, ref HashSet<int> s)
        {

            for (int i = 0; i < (int)(a.Count()); i++)
                s.Add(a[i]);
        }
        public static double norm_one(/*const ref*/ List<double> a)
        {
            double norm = 0;
            for (int i = 0; i < (int)(a.Count()); i++)
            {
                norm += a[i];
            }
            return norm;
        }

        public static int normalize_one(ref List<double> a)
        {
            double norm = norm_one(a);
            for (int i = 0; i < (int)(a.Count()); i++)
            {
                a[i] /= norm;
            }
            return 0;
        }

        /*double jaccard(ref HashSet<int> a1, ref HashSet<int> a2)
        {//I'm not sure the extent to which it's supposed to modify a1, a2...
            //I'm also not sure if it's actually USED.
            List<int> group_intsec = new List<int>();
            List<int> group_union = new List<int>();

            //set_intersection(a1.begin(), a1.end(), a2.begin(), a2.end(), back_inserter(group_intsec));
            //set_union(a1.begin(), a1.end(), a2.begin(), a2.end(), back_inserter(group_union));

            return (double)(group_intsec.Count()) / group_union.Count();
        }*/


    }
    public class Histograms
    {
        public static int intlog_binning(List<int> c, int number_of_bins, ref List<double> Xs, ref List<double> Ys, ref List<double> var)
        {

            // this function is to make a log_histogram along the x axis and to compute y-errors

            //prints(c);

            Xs.Clear();
            Ys.Clear();
            var.Clear();

            List<int> d = new List<int>();
            for (int i = 0; i < (int)(c.Count()); i++)
                if (c[i] > 0)
                    d.Add(c[i]);

            c.Clear();
            c = d;
            c.Sort();

            int max = c[c.Count() - 1];
            int min = c[0];




            List<double> bins = new List<double>();
            double step = Math.Log(min);
            if (max == min)
                max++;

            double bin = (Math.Log(max) - Math.Log(min)) / number_of_bins;      // bin width



            while (step <= Math.Log(max) + 4 * bin)
            {

                //cout<<"step: "<<(exp(step))<<endl;

                bins.Add(Math.Exp(step));
                step += bin;
            }

            //cout<<"bins"<<endl;
            //prints(bins);

            List<int> hist = new List<int>();
            List<double> hist2 = new List<double>();
            int index = 0;

            for (int i = 0; i < (int)(c.Count()); i++)
            {
                while (c[i] - bins[index] > -1e-6)
                {
                    index++;
                    hist.Add(0);
                    hist2.Add(0);
                }
                hist[index - 1]++;
                hist2[index - 1] += (double)(c[i]);

            }


            List<int> integers = new List<int>();
            index = 0;
            for (int i = min; i < bins[bins.Count() - 1] - 1; i++)
            {

                while (i - bins[index] > -1e-6)
                {
                    index++;
                    integers.Add(0);
                }

                //cout<<i<<" "<<index<<" "<<integers[index-1]<<" ********"<<endl;
                integers[index - 1]++;
            }

            for (int i = 0; i < (int)(hist.Count()); i++)
            {
                if (hist[i] > 0)
                {

                    Xs.Add(hist2[i] / hist[i]);
                    double y = (double)(hist[i]) / (c.Count() * integers[i]);
                    Ys.Add(y);

                    //cout<<h1<<" "<<h2<<" "<<y<<" "<<(hist2[i]/hist[i])<<" ***"<<endl;

                    var.Add((double)(hist[i]) / (c.Count() * c.Count() * integers[i] * integers[i]));

                    //cout<<". "<<hist[i]<<" "<<(double)(hist[i])/(c.Count()*c.Count()*integers[i]*integers[i])<<endl;


                }
            }
            return 0;
        }

        //template<typename type>
        //int variation;
        public static int xybinning(ref List<int> c, ref List<int> d, int number_of_bins, ref List<double> xs, ref List<double> ys, ref List<double> var, ref List<int> nums)
        {


            // so, this function takes two datasets (c and d) and gathers the data in bin, takes xs and ys as the average in each bin, var is the variance of the y average 
            // the difference with the same stuff called not_norm_histogram is that the other one averages x with y weights.

            xs.Clear();
            ys.Clear();
            var.Clear();
            nums.Clear();

            double min = (double)(c[0]);
            double max = (double)(c[0]);

            for (int i = 0; i < (int)(c.Count()); i++)
            {
                if (min > (double)(c[i]))
                    min = (double)(c[i]);

                if (max < (double)(c[i]))
                    max = (double)(c[i]);
            }



            min -= 1e-6;
            max += 1e-6;

            if (max == min)
                max += 1e-3;

            List<List<double>> hist_x = new List<List<double>>();      // x values in the bin
            List<List<double>> hist_y = new List<List<double>>();      // y values in the bin

            double step = min;
            double bin = (max - min) / number_of_bins;      // bin width

            List<double> f = new List<double>();
            while (step <= max + 2 * bin)
            {
                hist_x.Add(f);
                hist_y.Add(f);
                step += bin;
            }
            for (int i = 0; i < (int)(c.Count()); i++)
            {

                double data = (double)(c[i]);

                if (data >= min && data <= max)
                {
                    int index = (int)((data - min) / bin);
                    //cout<<data<<" "<<exp(data)<<" "<<index<<endl;

                    hist_x[index].Add((double)(c[i]));
                    hist_y[index].Add((double)(d[i]));

                }

            }

            for (int i = 0; i < hist_x.Count() - 1; i++)
            {




                double x = hist_x[i].Average();
                double y = hist_y[i].Average();



                //cout<<x<<" "<<exp(x)<<" "<<y<<endl;

                if (hist_y[i].Count() > 0)
                {
                    xs.Add(x);
                    ys.Add(y);
                    List<double> hist_y_i = hist_y[i]; //MCP so I can send by ref. Since it's a "property or referencer". 
                    var.Add(Combinatorics.variance_func(ref hist_y_i) / (double)(hist_y[i].Count()));
                    hist_y[i] = hist_y_i;
                    nums.Add(hist_y[i].Count());
                }
            }
            for (int i = 0; i < var.Count(); i++)
                if (var[i] < 1e-8)
                    var[i] = 1e-8;
            return 0;

        }

        //double variation
        public static int xybinning(ref List<double> c, ref List<double> d, int number_of_bins, ref List<double> xs, ref List<double> ys, ref List<double> var, ref List<int> nums)
        {


            // so, this function takes two datasets (c and d) and gathers the data in bin, takes xs and ys as the average in each bin, var is the variance of the y average 
            // the difference with the same stuff called not_norm_histogram is that the other one averages x with y weights.

            xs.Clear();
            ys.Clear();
            var.Clear();
            nums.Clear();

            double min = (double)(c[0]);
            double max = (double)(c[0]);

            for (int i = 0; i < (int)(c.Count()); i++)
            {
                if (min > (double)(c[i]))
                    min = (double)(c[i]);

                if (max < (double)(c[i]))
                    max = (double)(c[i]);
            }



            min -= 1e-6;
            max += 1e-6;

            if (max == min)
                max += 1e-3;

            List<List<double>> hist_x = new List<List<double>>();      // x values in the bin
            List<List<double>> hist_y = new List<List<double>>();      // y values in the bin

            double step = min;
            double bin = (max - min) / number_of_bins;      // bin width

            List<double> f = new List<double>();
            while (step <= max + 2 * bin)
            {
                hist_x.Add(f);
                hist_y.Add(f);
                step += bin;
            }
            for (int i = 0; i < (int)(c.Count()); i++)
            {

                double data = (double)(c[i]);

                if (data >= min && data <= max)
                {
                    int index = (int)((data - min) / bin);
                    //cout<<data<<" "<<exp(data)<<" "<<index<<endl;

                    hist_x[index].Add((double)(c[i]));
                    hist_y[index].Add((double)(d[i]));

                }

            }

            for (int i = 0; i < hist_x.Count() - 1; i++)
            {




                double x = hist_x[i].Average();
                double y = hist_y[i].Average();



                //cout<<x<<" "<<exp(x)<<" "<<y<<endl;

                if (hist_y[i].Count() > 0)
                {
                    xs.Add(x);
                    ys.Add(y);
                    List<double> hist_y_i = hist_y[i];
                    var.Add(Combinatorics.variance_func(ref hist_y_i) / (double)(hist_y[i].Count()));
                    hist_y[i] = hist_y_i;
                    nums.Add(hist_y[i].Count());
                }
            }
            for (int i = 0; i < var.Count(); i++)
                if (var[i] < 1e-8)
                    var[i] = 1e-8;
            return 0;

        }

        // template<typename type>
        //int variation
        public static int xybinning(ref List<int> c, ref List<int> d, int number_of_bins, ref List<double> xs, ref List<double> ys, ref List<double> var)
        {
            List<int> nums = new List<int>();
            return xybinning(ref c, ref d, number_of_bins, ref xs, ref ys, ref var, ref nums);

        }

        //double var
        public static int xybinning(ref List<double> c, ref List<double> d, int number_of_bins, ref List<double> xs, ref List<double> ys, ref List<double> var)
        {
            List<int> nums = new List<int>();
            return xybinning(ref c, ref d, number_of_bins, ref xs, ref ys, ref var, ref nums);

        }

        public static void compute_quantiles(double q, ref List<double> y, ref List<double> qs)
        {
            int qv = (int)((1 - q) / 2 * y.Count());
            if (qv < 0)
                qv = 0;
            if (qv >= (int)(y.Count()))
                qv = y.Count() - 1;

            qs.Add(y[qv]);

            qv = (int)((1 + q) / 2 * y.Count());
            if (qv < 0)
                qv = 0;
            if (qv >= (int)(y.Count()))
                qv = y.Count() - 1;

            qs.Add(y[qv]);
        }


        //template<typename type>
        //int version
        public static int xybinning_quantiles(ref List<int> c, ref List<int> d, int number_of_bins, ref List<double> xs, ref List<double> ys, ref List<double> var, ref List<int> nums, ref List<List<double>> Mq, double qa, double qb)
        {


            // so, this function takes two datasets (c and d) and gathers the data in bin, takes xs and ys as the average in each bin, var is the variance of the y average 
            // the difference with the same stuff called not_norm_histogram is that the other one averages x with y weights.

            xs.Clear();
            ys.Clear();
            var.Clear();
            nums.Clear();
            Mq.Clear();


            double min = (double)(c[0]);
            double max = (double)(c[0]);

            for (int i = 0; i < (int)(c.Count()); i++)
            {

                if (min > (double)(c[i]))
                    min = (double)(c[i]);

                if (max < (double)(c[i]))
                    max = (double)(c[i]);

            }

            min -= 1e-6;
            max += 1e-6;

            if (max == min)
                max += 1e-3;

            List<List<double>> hist_x = new List<List<double>>();      // x values in the bin
            List<List<double>> hist_y = new List<List<double>>();      // y values in the bin

            double step = min;
            double bin = (max - min) / number_of_bins;      // bin width

            List<double> f = new List<double>();
            while (step <= max + 2 * bin)
            {

                hist_x.Add(f);
                hist_y.Add(f);
                step += bin;
            }
            for (int i = 0; i < (int)(c.Count()); i++)
            {
                double data = (double)(c[i]);

                if (data >= min && data <= max)
                {
                    int index = (int)((data - min) / bin);
                    //cout<<data<<" "<<exp(data)<<" "<<index<<endl;

                    hist_x[index].Add((double)(c[i]));
                    hist_y[index].Add((double)(d[i]));

                }

            }

            for (int i = 0; i < hist_x.Count() - 1; i++)
            {
                double x = hist_x[i].Average();
                double y = hist_y[i].Average();

                //cout<<x<<" "<<exp(x)<<" "<<y<<endl;

                if (hist_y[i].Count() > 0)
                {
                    xs.Add(x);
                    ys.Add(y);
                    List<double> hist_y_i = hist_y[i];
                    var.Add(Combinatorics.variance_func(ref hist_y_i) / (double)(hist_y[i].Count()));
                    hist_y[i] = hist_y_i;
                    nums.Add(hist_y[i].Count());
                    hist_y[i].Sort();

                    List<double> qs = new List<double>();
                    hist_y_i = hist_y[i];
                    compute_quantiles(qa, ref hist_y_i, ref qs);
                    hist_y[i] = hist_y_i;
                    compute_quantiles(qb, ref hist_y_i, ref qs);
                    hist_y[i] = hist_y_i;

                    Mq.Add(qs);
                    //cout<<x<<" "<<exp(x)<<" "<<y<<" "<<(hist_y[i].Count())<<" "<<variance_func(hist_y[i])<<endl;
                }



            }
            for (int i = 0; i < var.Count(); i++)
                if (var[i] < 1e-8)
                    var[i] = 1e-8;

            return 0;

        }

        //double version
        public static int xybinning_quantiles(ref List<double> c, ref List<double> d, int number_of_bins, ref List<double> xs, ref List<double> ys, ref List<double> var, ref List<int> nums, ref List<List<double>> Mq, double qa, double qb)
        {


            // so, this function takes two datasets (c and d) and gathers the data in bin, takes xs and ys as the average in each bin, var is the variance of the y average 
            // the difference with the same stuff called not_norm_histogram is that the other one averages x with y weights.

            xs.Clear();
            ys.Clear();
            var.Clear();
            nums.Clear();
            Mq.Clear();


            double min = (double)(c[0]);
            double max = (double)(c[0]);

            for (int i = 0; i < (int)(c.Count()); i++)
            {

                if (min > (double)(c[i]))
                    min = (double)(c[i]);

                if (max < (double)(c[i]))
                    max = (double)(c[i]);

            }

            min -= 1e-6;
            max += 1e-6;

            if (max == min)
                max += 1e-3;

            List<List<double>> hist_x = new List<List<double>>();      // x values in the bin
            List<List<double>> hist_y = new List<List<double>>();      // y values in the bin

            double step = min;
            double bin = (max - min) / number_of_bins;      // bin width

            List<double> f = new List<double>();
            while (step <= max + 2 * bin)
            {

                hist_x.Add(f);
                hist_y.Add(f);
                step += bin;
            }
            for (int i = 0; i < (int)(c.Count()); i++)
            {
                double data = (double)(c[i]);

                if (data >= min && data <= max)
                {
                    int index = (int)((data - min) / bin);
                    //cout<<data<<" "<<exp(data)<<" "<<index<<endl;

                    hist_x[index].Add((double)(c[i]));
                    hist_y[index].Add((double)(d[i]));

                }

            }

            for (int i = 0; i < hist_x.Count() - 1; i++)
            {
                double x = hist_x[i].Average();
                double y = hist_y[i].Average();

                //cout<<x<<" "<<exp(x)<<" "<<y<<endl;

                if (hist_y[i].Count() > 0)
                {
                    xs.Add(x);
                    ys.Add(y);
                    List<double> hist_y_i = hist_y[i];
                    var.Add(Combinatorics.variance_func(ref hist_y_i) / (double)(hist_y[i].Count()));
                    hist_y[i] = hist_y_i;
                    nums.Add(hist_y[i].Count());
                    hist_y[i].Sort();

                    List<double> qs = new List<double>();
                    hist_y_i = hist_y[i];
                    compute_quantiles(qa, ref hist_y_i, ref qs);
                    hist_y[i] = hist_y_i;
                    compute_quantiles(qb, ref hist_y_i, ref qs);
                    hist_y[i] = hist_y_i;

                    Mq.Add(qs);
                    //cout<<x<<" "<<exp(x)<<" "<<y<<" "<<(hist_y[i].Count())<<" "<<variance_func(hist_y[i])<<endl;
                }



            }
            for (int i = 0; i < var.Count(); i++)
                if (var[i] < 1e-8)
                    var[i] = 1e-8;

            return 0;

        }


        public static void int_histogram(int c, ref Dictionary<int, int> hist)
        {
            if (hist.ContainsKey(c))
            {
                hist[c]++;
            }
            else
            {
                hist.Add(c, 1);
            }


        }

        public static void int_histogram(int c, ref Dictionary<int, double> hist, double w)
        {
            /*   map<int, double>::iterator itf = hist.find(c);
               if (itf == hist.end())
                   hist.Add(make_pair(c, w));
               else
                   itf.second += w;*/
            if (hist.ContainsKey(c))
            {
                hist[c] += w;
            }
            else
            {
                hist.Add(c, w);
            }
        }


        /*public static int print_cumulative(List<double> && kws, string file, int number_of_step)
        {
            char buffer[100];
            cast_string_to_char(file, buffer);

            ofstream expout (buffer);
            sort(kws.begin(), kws.end());

            int step = (kws.Count() - 1) / number_of_step;
            step = Math.Max(step, 1);

            for (int i = 0; i < (int)(kws.Count()); i++)
                if (i % step == 0)
                    expout << kws[i] << " " << (double)(i + 1) / (kws.Count()) << endl;
            return 0;
        }

        public static int print_cumulative(List<int> && kws, string file, int number_of_step)
        {



            char buffer[100];
            cast_string_to_char(file, buffer);

            ofstream expout (buffer);
            sort(kws.begin(), kws.end());

            int step = (kws.Count() - 1) / number_of_step;
            step = Math.Max(step, 1);

            for (int i = 0; i < (int)(kws.Count()); i++)
                if (i % step == 0)
                    expout << kws[i] << " " << (double)(i + 1) / (kws.Count()) << endl;





            return 0;


        }


        int print_cumulative(vector<double> && kws, string file, int number_of_step)
        {



            char buffer[100];
            cast_string_to_char(file, buffer);

            ofstream expout (buffer);
            sort(kws.begin(), kws.end());

            int step = (kws.Count() - 1) / number_of_step;
            step = Math.Max(step, 1);

            for (int i = 0; i < (int)(kws.Count()); i++)
                if (i % step == 0)
                    expout << kws[i] << " " << (double)(i + 1) / (kws.Count()) << endl;






            return 0;


        }


        int print_cumulative(vector<int> && kws, string file, int number_of_step)
        {



            char buffer[100];
            cast_string_to_char(file, buffer);

            ofstream expout (buffer);
            sort(kws.begin(), kws.end());

            int step = (kws.Count() - 1) / number_of_step;
            step = Math.Max(step, 1);

            for (int i = 0; i < (int)(kws.Count()); i++)
                if (i % step == 0)
                    expout << kws[i] << " " << (double)(i + 1) / (kws.Count()) << endl;






            return 0;


        }*/

        /*void int_histogram(string infile, string outfile)
        {

            // this makes a int_histogram of integers from a file


            char b[1000];
            cast_string_to_char(infile, b);

            ifstream ing(b);
            List<int> H;
            int h;
            while (ing >> h)
                H.Add(h);


            cast_string_to_char(outfile, b);
            ofstream outg(b);
            int_histogram(H, outg);



        }*/

        public static void int_histogram(int c, ref Dictionary<int, int> hist, int w)
        {

            /*map<int, int>::iterator itf = hist.find(c);
            if (itf == hist.end())
                hist.Add(make_pair(c, w));
            else
                itf.second += w;*/
            if (hist.ContainsKey(c))
            {
                hist[c] += w;
            }
            else
            {
                hist.Add(c, w);
            }
        }

        public static void int_histogram(/*const ref */ int c, ref Dictionary<int, KeyValuePair<int, double>> hist, /*const ref */int w1, /*const ref*/ double w2)
        {
            /*map<int, pair<int, double>> ::iterator itf = hist.find(c);
            if (itf == hist.end())
                hist.Add(make_pair(c, make_pair(w1, w2)));
            else
            {

                itf.second.first += w1;
                itf.second.second += w2;

            }*/
            if (hist.ContainsKey(c))
            {
                int newKey = hist[c].Key + w1;
                double newVal = hist[c].Value + w2;
                KeyValuePair<int, double> kvp = new KeyValuePair<int, double>(newKey, newVal);
                hist[c] = kvp;
            }
            else
            {
                KeyValuePair<int, double> kvp = new KeyValuePair<int, double>(w1, w2);
                hist.Add(c, kvp);
            }
        }

        public static void int_histogram(int c, ref Dictionary<int, KeyValuePair<double, double>> hist, double w1, double w2)
        {
            /*map<int, pair<double, double>>::iterator itf = hist.find(c);
            if (itf == hist.end())
                hist.Add(make_pair(c, make_pair(w1, w2)));
            else
            {

                itf.second.first += w1;
                itf.second.second += w2;

            }*/
            if (hist.ContainsKey(c))
            {
                double newKey = hist[c].Key + w1;
                double newVal = hist[c].Value + w2;
                KeyValuePair<double, double> kvp = new KeyValuePair<double, double>(newKey, newVal);
                hist[c] = kvp;
            }
            else
            {
                KeyValuePair<double, double> kvp = new KeyValuePair<double, double>(w1, w2);
                hist.Add(c, kvp);
            }

        }

        public static void int_histogram(int c, ref Dictionary<int, KeyValuePair<int, int>> hist, int w1, int w2)
        {
            /*map<int, pair<int, int>>::iterator itf = hist.find(c);
            if (itf == hist.end())
                hist.Add(make_pair(c, make_pair(w1, w2)));
            else
            {

                itf.second.first += w1;
                itf.second.second += w2;

            }*/
            if (hist.ContainsKey(c))
            {
                int newKey = hist[c].Key + w1;
                int newVal = hist[c].Value + w2;
                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(newKey, newVal);
                hist[c] = kvp;
            }
            else
            {
                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(w1, w2);
                hist.Add(c, kvp);
            }
        }
    }
    public class Mutual
    {
        public static int overlap_grouping(List<List<int>> ten, int unique)
        {       //hrepiguhpueh


            HashSet<int> conta = new HashSet<int>();
            int all = 0;
            for (int i = 0; i < (int)(ten.Count()); i++)
            {
                for (int j = 0; j < (int)(ten[i].Count()); j++)
                    conta.Add(ten[i][j]);
                all += ten[i].Count();
            }
            unique = conta.Count();
            int overlap = all - unique;
            return overlap;
        }

        public static double mutual(List<List<int>> en, List<List<int>> ten)
        {
            //MCP 7-20-17: I have confirmed that this returns the same values as the .cpp version.
            // en e ten are two partitions of integer numbers
            int dim;

            {
                HashSet<int> conta = new HashSet<int>();
                //HashSet <int> ten_;
                //HashSet <int> en_;

                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    ten[i].Sort();
                    //sort(ten[i].begin(), ten[i].end());
                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                    {
                        conta.Add(ten[i][j]);
                        //ten_.Insert(ten[i][j]);
                    }
                }

                for (int i = 0; i < (int)(en.Count()); i++)
                {
                    en[i].Sort();
                    //sort(en[i].begin(), en[i].end());
                    for (int j = 0; j < (int)(en[i].Count()); j++)
                    {
                        conta.Add(en[i][j]);
                        //en_.Insert(en[i][j]);
                    }
                }
                dim = conta.Count();
            }

            List<List<double>> N = new List<List<double>>();
            //List<double> first = new List<double>(en.Count());
            /*
            first.assign(en.size(), 0);
	        for (int i = 0; i<int(ten.size()); i++)
		        N.push_back(first);
            */
            List<double> first = Enumerable.Repeat(0.0, en.Count()).ToList();
            //first.Insert(en.Count(), 0);
            //first.Add(0);
            for (int i = 0; i < (int)(ten.Count()); i++)
                N.Add(first);



            //List<int> s (dim);
            List<int> copy_for_intersect1 = new List<int>();
            List<int> copy_for_intersect2 = new List<int>();
            List<int> copy_for_intersect3 = new List<int>();
            List<double> s = new List<double>(dim);//Christy this will be used for "N"
            for (int i = 0; i < (int)(ten.Count()); i++)
            {
                for (int j = 0; j < (int)(en.Count()); j++)
                {
                    //N[i][j] = set_intersection(ten[i].begin(), ten[i].end(), en[j].begin(), en[j].end(), s.begin()) - s.begin();
                    //N[i][j] = ten[i].Intersect(en[j], s); ///MCP 7-19-17 pick up here.
                    copy_for_intersect1 = ten[i];
                    copy_for_intersect2 = en[j];
                    copy_for_intersect3 = copy_for_intersect1.Intersect(copy_for_intersect2).ToList<int>();
                    N[i][j] = copy_for_intersect3.Count();

                }
            }
            //printv(N);


            /*
            cout<<"one:"<<endl;
            printm(ten);


            cout<<"two:"<<endl;
            printm(en);


            cout<<"confusion matrix"<<endl;
            printm(N, cout);
            */


            //cout<<"confusion matrix"<<endl;
            //printm(N, cout);
            //List<double> NR = new List<double>(ten.Count());
            //NR.Assign(ten.Count(), 0);
            List<double> NR = Enumerable.Repeat(0.0, ten.Count()).ToList();
            //List<double> NC = new List<double>(en.Count());
            List<double> NC = Enumerable.Repeat(0.0, en.Count()).ToList();
            //NC.Assign(en.Count(), 0);
            double NTOT = dim;
            for (int i = 0; i < (int)(ten.Count()); i++)
            {
                for (int j = 0; j < (int)(en.Count()); j++)
                {
                    NR[i] += N[i][j];
                    NC[j] += N[i][j];
                }
            }

            double IN = 0;
            double ID1 = 0;
            double ID2 = 0;

            for (int i = 0; i < (int)(ten.Count()); i++)
                for (int j = 0; j < (int)(en.Count()); j++)
                    if (N[i][j] != 0)
                        IN += N[i][j] * Math.Log(N[i][j] * NTOT / (NR[i] * NC[j]));

            IN = -2.0 * IN;


            for (int i = 0; i < (int)(ten.Count()); i++)
                if (NR[i] != 0)
                    ID1 += NR[i] * Math.Log(NR[i] / (NTOT));
            for (int j = 0; j < (int)(en.Count()); j++)
                if (NC[j] != 0)
                    ID2 += NC[j] * Math.Log(NC[j] / (NTOT));
            double I = IN / (ID1 + ID2);

            if ((ID1 + ID2) == 0)
                I = -2;
            return I;
        }


        public static double H(double a)
        {
            if (a <= 0)
                return 0;
            else
                return (-a * Math.Log(a));

        }


        public static double H(ref List<double> p)
        {
            double h = 0;
            /* for (List<double>::iterator it = p.begin(); it != p.end(); it++)
                 if (*it != 0)
                     h += (*it) * Math.Log(*it);*/
            foreach (double it in p)
            {
                if (it != 0)
                    h += it * Math.Log(it);
            }
            return (-h);
        }


        public static double H_x_given_y(ref List<List<int>> en, ref List<List<int>> ten, int dim)
        {

            // you know y and you want to find x according to a certain index labelling.
            // so, for each x you look for the best y.

            double H_x_y = 0;
            double H2 = 0;

            for (int j = 0; j < (int)(en.Count()); j++)
            {


                List<double> p = new List<double>();
                double I2 = (double)(en[j].Count());
                double O2 = (dim - I2);
                p.Add(I2 / dim);
                p.Add(O2 / dim);
                double H2_ = H(ref p); //note this is a function, not Mathing.
                p.Clear();
                H2 += H2_;
                double diff = H2_;


                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    double I1 = (double)(ten[i].Count());
                    double O1 = (dim - I1);
                    //cout<<"I1 "<<I1<<" O1 "<<O1<<endl;
                    p.Add(I1 / dim);
                    p.Add(O1 / dim);
                    double H1_ = H(ref p);
                    p.Clear();

                    //prints(ten[i]);
                    //cout<<"H1_: "<<H1_<<"\t";
                    List<int> s = new List<int>(dim);
                    //double I1_I2 = set_intersection(ten[i].begin(), ten[i].end(), en[j].begin(), en[j].end(), s.begin()) - s.begin();   // common
                    double I1_I2 = ten[i].Intersect(en[j]).ToList<int>().Count();
                    //double I1_02 = set_difference(ten[i].begin(), ten[i].end(), en[j].begin(), en[j].end(), s.begin()) - s.begin();
                    double I1_02 = ten[i].Except<int>(en[j]).ToList<int>().Count();
                    //double O1_I2 = set_difference(en[j].begin(), en[j].end(), ten[i].begin(), ten[i].end(), s.begin()) - s.begin();
                    double O1_I2 = en[j].Except<int>(ten[i]).ToList<int>().Count();
                    double O1_02 = dim - I1_I2 - I1_02 - O1_I2;


                    p.Add(I1_I2 / dim);
                    p.Add(O1_02 / dim);

                    double H12_positive = H(ref p);

                    p.Clear();
                    p.Add(I1_02 / dim);
                    p.Add(O1_I2 / dim);


                    double H12_negative = H(ref p);

                    double H12_ = H12_negative + H12_positive;

                    p.Clear();

                    if (H12_negative > H12_positive)
                    {

                        H12_ = H1_ + H2_;
                        //cout<<"the negative part is bigger"<<endl;
                        //prints(en[j]);
                        //prints(ten[i]);
                    }


                    /*

                    cout<<"worst case "<<H1_+H2_<<"\ttotal "<<H12_negative+H12_positive<<"\tnegative part "<<H12_negative<<"\tpositive part "<<H12_positive<<endl;
                    prints(en[j]);
                    prints(ten[i]);

                    */

                    //cout<<"entropies "<<H1_<<" "<<H2_<<" "<<H12_<<endl;

                    if ((H12_ - H1_) < diff)
                    {
                        diff = (H12_ - H1_);
                    }
                }
                //H_x_y+=diff;
                if (H2_ == 0)
                    H_x_y += 1;
                else
                    H_x_y += (diff / H2_);

            }
            return (H_x_y / (en.Count()));
        }


        public static double mutual2(List<List<int>> en, List<List<int>> ten)
        {



            if (en.Count() == 0 || ten.Count() == 0)
                return 0;



            // en e ten are two partitions of integer numbers
            int dim;


            //printm(ten);
            //printm(en);


            {
                Dictionary<int, int> all = new Dictionary<int, int>();      // node, index 
                                                                            //HashSet <int> ten_;
                                                                            //HashSet <int> en_;

                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                    {
                        all.Add(ten[i][j], all.Count());
                        //ten_.Insert(ten[i][j]);
                    }
                }

                for (int i = 0; i < (int)(en.Count()); i++)
                {
                    for (int j = 0; j < (int)(en[i].Count()); j++)
                    {
                        all.Add(en[i][j], all.Count());
                        //en_.Insert(en[i][j]);

                    }
                }




                dim = all.Count();


                /*
                for (Dictionary<int, int>::iterator its=all.begin(); its!=all.end(); its++) {

                    if(ten_.find(its.first)==ten_.end()) {

                        List <int> first;
                        first.Add(its.first);
                        ten.Add(first);
                    }

                    if(en_.find(its.first)==en_.end()) {

                        List <int> first;
                        first.Add(its.first);
                        en.Add(first);
                    }


                }
                */


                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                        ten[i][j] = all[ten[i][j]];

                    //sort(ten[i].begin(), ten[i].end());
                    ten[i].Sort();
                }

                for (int i = 0; i < (int)(en.Count()); i++)
                {
                    for (int j = 0; j < (int)(en[i].Count()); j++)
                        en[i][j] = all[en[i][j]];
                    en[i].Sort();
                    //sort(en[i].begin(), en[i].end());
                }





            }



            return (0.5 * (2.0 - H_x_given_y(ref ten, ref en, dim) - H_x_given_y(ref en, ref ten, dim)));

        }

        public static double H_x_given_y3(ref List<List<int>> en, ref List<List<int>> ten, int dim)
        {

            // you know y and you want to find x according to a certain index labelling.
            // so, for each x you look for the best y.


            List<List<int>> mems = new List<List<int>>();

            List<int> first = new List<int>();
            for (int i = 0; i < dim; i++)
                mems.Add(first);

            for (int ii = 0; ii < (int)(ten.Count()); ii++)
                for (int i = 0; i < (int)(ten[ii].Count()); i++)
                    mems[ten[ii][i]].Add(ii);



            double H_x_y = 0;

            for (int k = 0; k < (int)(en.Count()); k++)
            {



                List<int> c = en[k];//MCP note there was an "&" before the "c"...


                List<double> p = new List<double>();
                double I2 = (double)(c.Count());
                double O2 = (dim - I2);
                p.Add(I2 / dim);
                p.Add(O2 / dim);
                double H2_ = H(ref p);
                p.Clear();



                double diff = H2_;

                // I need to know all the group wuth share nodes with en[k]

                Dictionary<int, int> com_ol = new Dictionary<int, int>();        // it Dictionarys the index of the ten into the overlap with en[k]

                for (int i = 0; i < (int)(c.Count()); i++)
                {
                    for (int j = 0; j < (int)(mems[c[i]].Count()); j++)
                        Histograms.int_histogram(mems[c[i]][j], ref com_ol);
                }



                //for (Dictionary<int, int>::iterator itm = com_ol.begin(); itm != com_ol.end(); itm++)
                foreach (KeyValuePair<int, int> itm in com_ol)
                {
                    double I1 = (double)(ten[itm.Key].Count());
                    double O1 = (dim - I1);
                    p.Add(I1 / dim);
                    p.Add(O1 / dim);
                    double H1_ = H(ref p);
                    p.Clear();

                    double I1_I2 = itm.Value;
                    double I1_02 = ten[itm.Key].Count() - I1_I2;
                    double O1_I2 = c.Count() - I1_I2;
                    double O1_02 = dim - I1_I2 - I1_02 - O1_I2;
                    p.Add(I1_I2 / dim);
                    p.Add(O1_02 / dim);

                    double H12_positive = H(ref p);

                    p.Clear();
                    p.Add(I1_02 / dim);
                    p.Add(O1_I2 / dim);

                    double H12_negative = H(ref p);

                    double H12_ = H12_negative + H12_positive;

                    p.Clear();

                    if (H12_negative > H12_positive)
                    {
                        H12_ = H1_ + H2_;
                    }
                    if ((H12_ - H1_) < diff)
                    {
                        diff = (H12_ - H1_);
                    }
                }
                if (H2_ == 0)
                    H_x_y += 1;
                else
                    H_x_y += (diff / H2_);
            }
            return (H_x_y / (en.Count()));

        }


        public static double mutual3(List<List<int>> en, List<List<int>> ten)
        {
            if (en.Count() == 0 || ten.Count() == 0)
                return 0;

            // en e ten are two partitions of integer numbers
            int dim;
            {
                Dictionary<int, int> all = new Dictionary<int, int>();      // node, index 
                                                                            //HashSet <int> ten_;
                                                                            //HashSet <int> en_;

                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                    {
                        all.Add(ten[i][j], all.Count());
                        //ten_.Insert(ten[i][j]);
                    }
                }

                for (int i = 0; i < (int)(en.Count()); i++)
                {
                    for (int j = 0; j < (int)(en[i].Count()); j++)
                    {
                        all.Add(en[i][j], all.Count());
                    }
                }
                dim = all.Count();
                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                        ten[i][j] = all[ten[i][j]];
                    ten[i].Sort();
                }

                for (int i = 0; i < (int)(en.Count()); i++)
                {
                    for (int j = 0; j < (int)(en[i].Count()); j++)
                        en[i][j] = all[en[i][j]];
                    en[i].Sort();
                }
            }




            return (0.5 * (2.0 - H_x_given_y3(ref ten, ref en, dim) - H_x_given_y3(ref en, ref ten, dim)));

        }

    }
    //MCP 7-20-17: Pick up with TabDeg, move on to figuring out filestreams. 
    //note this is a class in the .cpp as well.
    public class TabDeg
    {
        public bool is_internal(int a)
        {

            //muspi: multiset<pair<double, int>>
            //map<int, muspi::iterator>::iterator itm = nodes_indeg.find(a);
            Dictionary<int, List<KeyValuePair<double, int>>> itm = new Dictionary<int, List<KeyValuePair<double, int>>>();
            /*if(itm==nodes_indeg.end())
		        return false;
	        else
		        return true;
            */
            foreach (KeyValuePair<int, List<KeyValuePair<double, int>>> itr in nodes_indeg)
            {
                foreach (KeyValuePair<double, int> itr2 in itr.Value)
                {
                    if (itr2.Value == a)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void edinsert(int a, double kp)
        {       // this function inserts element a (or edit it if it was already inserted)

            erase(a);
            //muspi: multiset<pair<double, int>>
            //. List<KeyValuePair<double,int>>
            //muspi::iterator itms = number_label.insert(make_pair(kp, a));
            //nodes_indeg.insert(make_pair(a, itms));
            KeyValuePair<double, int> itms = new KeyValuePair<double, int>(kp, a);
            number_label.Insert(a, itms);
            List<KeyValuePair<double, int>> ltoadd = new List<KeyValuePair<double, int>>(); ltoadd.Add(itms);
            nodes_indeg.Add(a, ltoadd);
        }

        public bool erase(int a)
        {       // this function erases element a if exists (and returns true)



            //Dictio<int, muspi::iterator>::iterator itm = nodes_indeg.find(a);
            /*if (itm != nodes_indeg.end())
            {

                number_label.erase(itm.second);
                nodes_indeg.erase(itm);
                return true;

            }*/
            foreach (KeyValuePair<int, List<KeyValuePair<double, int>>> itr in nodes_indeg)
            {
                foreach (KeyValuePair<double, int> itr2 in itr.Value)
                {
                    if (itr2.Value == a)
                    {
                        number_label.Remove(itr2);
                        nodes_indeg.Remove(itr.Key);
                        return true;
                    }
                }
            }
            return false;
        }


        public double indegof(int a)
        {       // return the internal degree of a, 0 if it's not internal

            /* map<int, muspi::iterator>::iterator itm = nodes_indeg.find(a);
             if (itm != nodes_indeg.end())
                 return itm.second.first;
             else
                 return 0;*/
            foreach (KeyValuePair<int, List<KeyValuePair<double, int>>> itr in nodes_indeg)
            {
                foreach (KeyValuePair<double, int> itr2 in itr.Value)
                {
                    if (itr2.Value == a)
                    {
                        return itr2.Key;
                    }
                }
            }
            return 0;
        }
        public int size() { return nodes_indeg.Count(); }
        //public void print_nodes(ostream &);
        public int best_node()
        {

            //muspi: multiset<pair<double, int>>
            SortedDictionary<double, KeyValuePair<double, int>> sdkvp = new SortedDictionary<double, KeyValuePair<double, int>>();
            foreach (KeyValuePair<double, int> kvp in number_label)
            {
                sdkvp.Add(kvp.Key, kvp);
            }
            return sdkvp.Values.Last().Value;
            /*muspi::iterator itm = number_label.end();
            if (number_label.size() == 0)
                return -1;


            itm--;
            return itm.second;*/
            //return 0;


        }
        public int worst_node()
        {
            SortedDictionary<double, KeyValuePair<double, int>> sdkvp = new SortedDictionary<double, KeyValuePair<double, int>>();
            foreach (KeyValuePair<double, int> kvp in number_label)
            {
                sdkvp.Add(kvp.Key, kvp);
            }
            return sdkvp.Values.First().Value;

        }


        //private map<int, muspi::iterator> nodes_indeg;              // for each node belonging to the cluster, here you have where to find the internal degree
        //Note: muspi: multiset<pair<double, int>>
        private Dictionary<int, List<KeyValuePair<double, int>>> nodes_indeg = new Dictionary<int, List<KeyValuePair<double, int>>>(); //MCP: be careful. List doesn't automatically sort, and doesn' have the operations.

        //private multiset<pair<double, int>> number_label;
        List<KeyValuePair<double, int>> number_label = new List<KeyValuePair<double, int>>();

    }

    /*Undirected prestuff, I hope*/
    public class MyRandom
    {
        public static int R2_IM1 = 2147483563;
        public static int R2_IM2 = 2147483399;
        public static double R2_AM = (1.0 / R2_IM1);
        public static int R2_IMM1 = (R2_IM1 - 1);
        public static int R2_IA1 = 40014;
        public static int R2_IA2 = 40692;
        public static int R2_IQ1 = 53668;
        public static int R2_IQ2 = 52774;
        public static int R2_IR1 = 12211;
        public static int R2_IR2 = 3791;
        public static int R2_NTAB = 32;
        public static double R2_NDIV = (1 + R2_IMM1 / R2_NTAB);
        public static double R2_EPS = 1.2e-7;
        public static double R2_RNMX = (1.0 - R2_EPS);




        public static double ran2(ref long idum) //MCP 7-17-17: Originally long*. I think that's so we can change values of The Idum.
        {
            int j;
            long k;
            long idum2 = 123456789; //MCP 7-17-17 Originally Static long.
            long? iy = 0;//MCP 7-17-17 Originally Static long.
            long[] iv = new long[R2_NTAB];//MCP 7-17-17 Originally Static long.
            double temp;

            if (idum <= 0 || !(iy != null)) ///MCP 7-17-17 originally !iy. 
            {
                if (-(idum) < 1) idum = 1 * (idum); //got rid of all dereferencers.
                //else *idum = -(*idum);
                else idum = -(idum);
                //idum2 = (*idum);
                idum2 = (idum);
                for (j = R2_NTAB + 7; j >= 0; j--)
                {
                    //k = (*idum) / R2_IQ1;
                    k = (idum) / R2_IQ1;
                    //*idum = R2_IA1 * (*idum - k * R2_IQ1) - k * R2_IR1;
                    idum = R2_IA1 * (idum - k * R2_IQ1) - k * R2_IR1;
                    //if (*idum < 0) *idum += R2_IM1;
                    if (idum < 0) idum += R2_IM1;
                    //if (j < R2_NTAB) iv[j] = *idum;
                    if (j < R2_NTAB) iv[j] = idum;
                }
                iy = iv[0];
            }
            //k = (*idum) / R2_IQ1;
            k = (idum) / R2_IQ1;
            //*idum = R2_IA1 * (*idum - k * R2_IQ1) - k * R2_IR1;
            idum = R2_IA1 * (idum - k * R2_IQ1) - k * R2_IR1;
            //if (*idum < 0) *idum += R2_IM1;
            if (idum < 0) idum += R2_IM1;
            k = (idum2) / R2_IQ2;
            idum2 = R2_IA2 * (idum2 - k * R2_IQ2) - k * R2_IR2;
            if (idum2 < 0) idum2 += R2_IM2;
            j = (int)(iy / R2_NDIV);
            iy = iv[j] - idum2;
            //iv[j] = *idum;
            iv[j] = idum;
            if (iy < 1) iy += R2_IMM1;
            if ((temp = R2_AM * (double)iy) > R2_RNMX) return R2_RNMX;
            else return temp;
        }



        public static double ran4(bool t, long s)
        {

            double r = 0;


            long seed_ = 1;

            if (t)
                r = ran2(ref seed_);
            else
                seed_ = s;


            return r;
        }


        public static double ran4()
        {

            return ran4(true, 0);
        }


        public static void srand4()
        {

            long s = time(null);
            ran4(false, s);



        }

        private static long time(object nULL)
        {
            throw new NotImplementedException();
        }

        public static void srand5(int rank)
        {

            long s = (long)(rank);
            ran4(false, s);

        }



        public static int irand(int n)
        {

            return ((int)(ran4() * (n + 1)));

        }


        public static void srand_file()
        {
            ///MCP 7-17-17 TRY TO FIGURE OUT WHAT THE ORIGINAL IS DOING HERE.
            //ifstream in("time_seed.dat");
            //System.IO.FileStream inStream = new System.IO.FileStream("time_seed.dat",System.IO.FileMode.Open);
            System.IO.StreamReader inStream = new System.IO.StreamReader("time_seed.dat");
            //inStream.

            int seed;

            if (!inStream.EndOfStream) //MCP 7-17-17 I THINK this should work...? Not sure what happens if time_seed.dat isn't valid, though...
                seed = 21111983; //if stream NOT open, set seed = (this.)
            else
                seed = inStream.Read(); //otherwise, set Seed to whatever the instream is.

            if (seed < 1 || seed > R2_IM2)
                seed = 1;

            inStream.Close();
            srand5(seed);
            System.IO.StreamWriter outStream = new System.IO.StreamWriter("time_seed.dat");

            outStream.WriteLine(seed + 1);

        }




        public static int configuration_model(ref List<HashSet<int>> en, ref List<int> degrees)
        {


            // this function is to build a network with the degree seq in degrees which is sorted (correspondence is based on the vectorial index)

            if (degrees.Count() < 3)
            {
                System.Diagnostics.Trace.WriteLine("it seems that some communities should have only 2 nodes! This does not make much sense (in my opinion) Please change some parameters!");
                // System.Diagnostics.Trace.WriteLine( "it seems that some communities should have only 2 nodes! This does not make much sense (in my opinion) Please change some parameters!");
                return -1;

            }


            degrees.Sort();
            //sort(degrees.First(), degrees.Last());

            {
                //HashSet<int> first;
                for (int i = 0; i < (int)(degrees.Count()); i++)
                    en.Add(new HashSet<int>());
            }



            //Dictionary<int, int> degree_node = new Dictionary<int, int>();
            Dictionary<int, KeyValuePair<int, int>> degree_node = new Dictionary<int, KeyValuePair<int, int>>();
            for (int i = 0; i < (int)(degrees.Count()); i++)
            {
                degree_node.Add(degree_node.Count(), new KeyValuePair<int, int>(degrees[i], i));
            }

            int var = 0;

            while (degree_node.Count() > 0)
            {

                //multimap<int, int>::iterator itlast = degree_node.end();
                //itlast--;
                KeyValuePair<int, KeyValuePair<int, int>> itlast = degree_node.ElementAt(degree_node.Count() - 2); // accounts for the itlast--;.

                KeyValuePair<int, KeyValuePair<int, int>> itit = itlast;
                //multimap<int, int>::iterator itit = itlast;
                //List<multimap<int, int>::iterator> erasenda;
                List<KeyValuePair<int, KeyValuePair<int, int>>> erasenda = new List<KeyValuePair<int, KeyValuePair<int, int>>>();
                int inserted = 0;
                int keyValToCheckForitit = degree_node.Count() - 2;
                for (int i = 0; i < itlast.Key; i++)
                {

                    if (itit.Key != degree_node.ElementAt(1).Key && itit.Value.Key != degree_node.ElementAt(1).Value.Key && itit.Value.Value != degree_node.ElementAt(1).Value.Value)
                    {

                        keyValToCheckForitit--;
                        if (keyValToCheckForitit >= 0)
                            itit = degree_node.ElementAt(keyValToCheckForitit);


                        en[itlast.Value.Key].Add(itit.Value.Key);
                        en[itit.Value.Key].Add(itlast.Value.Key);
                        inserted++;

                        //erasenda.Add(itit.Key, itit.Value);
                        erasenda.Add(itit);

                    }

                    else
                        break;

                }


                for (int i = 0; i < (int)(erasenda.Count()); i++)
                {


                    if (erasenda.ElementAt(i).Key > 1)
                        degree_node.Add(erasenda.ElementAt(i).Key - 1, erasenda.ElementAt(i).Value);

                    degree_node.Remove(erasenda.ElementAt(i).Key);

                }


                var += itlast.Key - inserted;
                degree_node.Remove(itlast.Key);

            }



            // this is to randomize the subgraph -------------------------------------------------------------------

            for (int node_a = 0; node_a < (int)(degrees.Count()); node_a++)
                for (int krm = 0; krm < (int)(en[node_a].Count()); krm++)
                {



                    int random_mate = irand(degrees.Count() - 1);///MCP left off here 7-17-17, 1408.
                    while (random_mate == node_a)
                        random_mate = irand(degrees.Count() - 1);

                    if (en[node_a].Add(random_mate))
                    {

                        List<int> out_nodes = new List<int>();
                        /*for (set<int>::iterator it_est = en[node_a].begin(); it_est != en[node_a].end(); it_est++)
                            if ((*it_est) != random_mate)
                                out_nodes.push_back(*it_est);*/
                        foreach (int it_est in en[node_a])
                        {
                            if (it_est != random_mate)
                            {
                                out_nodes.Add(it_est);
                            }
                        }



                        int old_node = out_nodes[irand(out_nodes.Count() - 1)];

                        en[node_a].Remove(old_node);
                        en[random_mate].Add(node_a);
                        en[old_node].Remove(node_a);


                        List<int> not_common = new List<int>();
                        /*for (set<int>::iterator it_est = en[random_mate].begin(); it_est != en[random_mate].end(); it_est++)
                            if ((old_node != (*it_est)) && (en[old_node].find(*it_est) == en[old_node].end()))
                                not_common.push_back(*it_est);*/
                        foreach (int it_est in en[random_mate])
                        {
                            if (old_node != it_est && (en[old_node].Contains(it_est) && en[old_node].Last() == it_est)) ///MCP 7-17-17 I'm VERY unsure about this.
                            {
                                not_common.Add(it_est);
                            }
                        }


                        int node_h = not_common[irand(not_common.Count() - 1)];

                        en[random_mate].Remove(node_h);
                        en[node_h].Remove(random_mate);
                        en[node_h].Add(old_node);
                        en[old_node].Add(node_h);
                    }
                }
            return 0;
        }
    }
    public static class Globals
    {
        public static double log_table_pr = 1e-5;
        public static log_fact_table LOG_TABLE = new log_fact_table();
       // public static Parameters paras;
        public static double sqrt_two = 1.41421356237;
        public static int num_up_to = 5;
        public static double bisection_precision = 1e-2;
    }
    public class ClasslessMethods
    {
        public static void oslom_level(ref oslom_net_global_h.oslom_net_global luca, string directory_char)
        {
            int level = 0;
            int original_dim = 0;
            while (true)
            {
                //cout << "network:: " << luca.size() << " nodes and " << luca.stubs() << " stubs;\t average degree = " << luca.stubs() / luca.size() << endl;
                System.Console.WriteLine("network:: {0} nodes and {1} stubs;\t average degree = {2}", luca.size(), luca.stubs(), (luca.stubs() / luca.size()));
                //System.Console.WriteLine(luca.stubs() / luca.size());
                if (level == 0)
                    original_dim = luca.size();
                System.Console.WriteLine("STARTING! HIERARCHICAL LEVEL: {0}",level);
                if (hierarchies.write_tp_of_this_level(level, ref luca, directory_char, original_dim) == false)//mcp 8-28-17 this is where it starts to break.
                    break;
                //cout << "Back from Level." << endl;
                //system("PAUSE");
                ++level;
            }
        }
        public static void general_program_statement(string b)
        {
            System.Console.WriteLine("USAGE: {0} -f network.dat -uw(-w)\n", b );
            System.Console.WriteLine("-uw must be used if you want to use the unweighted null model; -w otherwise.");
            System.Console.WriteLine("network.dat is the list of edges. Please look at ReadMe.pdf for more details.");
            System.Console.WriteLine("\n\n\n");
            System.Console.WriteLine("***************************************************************************************************************************************************");
            System.Console.WriteLine("OPTIONS");
            System.Console.WriteLine("\n  [-r R]:\t\t\tsets the number of runs for the first hierarchical level, bigger this value, more accurate the output (of course, it takes more). Default value is 10.");
            System.Console.WriteLine("\n  [-hr R]:\t\t\tsets the number of runs  for higher hierarchical levels. Default value is 50 (the method should be faster since the aggregated network is usually much smaller).");
            System.Console.WriteLine("\n  [-seed m]:\t\t\tsets m equal to the seed for the random number generator. (instead of reading from time_seed.dat)");
            System.Console.WriteLine("\n  [-hint filename]:\t\ttakes a partition from filename. The file is expected to have the nodes belonging to the same cluster on the same line.");
            System.Console.WriteLine("\n  [-load filename]:\t\ttakes modules from a tp file you already got in a previous run.");
            System.Console.WriteLine("\n  [-t T]:\t\t\tsets the threshold equal to T, default value is 0.1");
            System.Console.WriteLine("\n  [-singlet]:\t\t\t finds singletons. If you use this flag, the program generally finds a number of nodes which are not assigned to any module.\n\t\t\t\t");
            System.Console.WriteLine("the program will assign each node with at least one not homeless neighbor. This only applies to the lowest hierarchical level.");
            System.Console.WriteLine("\n  [-cp P]:\t\t\tsets a kind of resolution parameter equal to P. This parameter is used to decide if it is better to take some modules or their union.\n\t\t\t\tDefault value is 0.5. ");
            System.Console.WriteLine("Bigger value leads to bigger clusters. P must be in the interval (0, 1).");
            System.Console.WriteLine("\n  [-fast]:\t\t\tis equivalent to \"-r 1 -hr 1\" (the fastest possible execution).");
            System.Console.WriteLine("\n  [-infomap runs]:\t\tcalls infomap and uses its output as a starting point. runs is the number of times you want to call infomap.");
            System.Console.WriteLine("\n  [-copra runs]:\t\tsame as above using copra.");
            System.Console.WriteLine("\n  [-louvain runs]:\t\tsame as above using louvain method.");
            System.Console.WriteLine("\n\nPlease look at ReadMe.pdf for a more detailed explanation.");
            System.Console.WriteLine("\n\n\n");
            System.Console.WriteLine("***************************************************************************************************************************************************");
            System.Console.WriteLine("OUTPUT FILES \n");


            System.Console.WriteLine("The program will create a directory called \"[network.dat]_oslo_files\". If the directory is not empty it will cleared, so be careful if you want to save some previous output files.\n");
            System.Console.WriteLine("All the files will be written in this directory. ");
            System.Console.WriteLine("The first level partition will be written in a file called \"tp\", the next ");
            System.Console.WriteLine("hierchical network will be recorded as \"net1\", ");
            System.Console.WriteLine("the second level partition will be called \"tp1\" and so on.");
            System.Console.WriteLine("For convenience, the first level partition will be also written in a file called \"tp\" located in the same folder where the program is.");
            System.Console.WriteLine("***************************************************************************************************************************************************");
            System.Console.WriteLine("\n\n");
            System.Console.WriteLine("PLEASE LOOK AT ReadMe.pdf for more details. Thanks!\n\n" );
        }


        public static void error_statement(String b)
        {

            System.Console.WriteLine("\n\n************************************************************");
            /*System.Diagnostics.Trace.WriteLine("ERROR while reading parameters from command line... Please read program instructions or type: \n {0}",b);
             System.Diagnostics.Trace.WriteLine("*DoesThisDoAnything***********************************************************");*/
            System.Console.WriteLine("ERROR while reading parameters from command line... Please read program instructions or type: \n {0}", b);
            System.Console.WriteLine("*DoesThisDoAnything***********************************************************");

        }
        public static double topological_05(int kin_node, int kout_g, int tm, int degree_node)
        {

            System.Console.WriteLine("8-28-17 test 3114");
            //elements for return, to test The Things.
            double firstPart = Globals.LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node + 1);
            System.Console.WriteLine("8-28-17 test 3117");
            double secondPart = MyRandom.ran4();
            System.Console.WriteLine("8-28-17 test 3119");
            double thirdPart = hyper_table(kin_node, kout_g, tm, degree_node); //mcp 8-28-17 1351 problem really here.
            System.Console.WriteLine("8-28-17 test 3121");
            //return Globals.LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node + 1) + MyRandom.ran4() * (hyper_table(kin_node, kout_g, tm, degree_node)); //mcp 8-28-17 1318 problem here
            return firstPart + secondPart * thirdPart;
            //mcp 8-28-17 1322 actually seemed to work...
        }
        public static double hyper_table(int kin_node, int kout_g, int tm, int degree_node)
        {
            System.Console.WriteLine("8-28-17 test 3128");
            return Globals.LOG_TABLE.hyper(kin_node, kout_g, tm, degree_node); //mcp 8-28-17 pass the buck... 1351


        }
    }

    class Program
    {
        static void program_statement(ref string b)
        {
            System.Console.WriteLine("\n\n\n***************************************************************************************************************************************************");

            System.Console.WriteLine("This program implements the OSLO-method for undirected networks");

            ClasslessMethods.general_program_statement(b);
        }


        static int Main(string[] argv)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(argv[1]);
            string line = string.Empty;
           /* while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
            }*/
            int argc = argv.Count();
            //string[] argv = args;
            if (argc < 2)
            {
                System.Console.WriteLine("argc<2; return -1");
                string arg0 = argv[0];
                program_statement(ref arg0);
                argv[0] = arg0;
                return -1;
            }


            if (Parameters._set_(argc, argv) == false) {
                System.Console.WriteLine("_set_ returned false; kill program");
                return -1;
            }

            Parameters.print();

            string netfile = Parameters.file1;


            {   /* check if file_name exists */
                string b = string.Empty ;//new char[netfile.Count() + 1];
                //cast.cast_string_to_char(netfile, ref b);
                b = netfile;
                //ifstream inb(b);
                System.IO.FileStream inb = System.IO.File.OpenRead(b.ToString());
                //if (inb.is_open() == false)
                if(inb.CanRead == false)
                {
                    System.Console.WriteLine("File {0} not found; kill program.",netfile);
                    return -1;

                }
            }   /* check if file_name exists */


            
            oslom_net_global_h.oslom_net_global luca = new oslom_net_global_h.oslom_net_global(netfile); //mcp 8-23-17 this is where the next problem is happening.
            
            if (luca.size() == 0 || luca.stubs() == 0)
            {
                //System.Diagnostics.Trace.WriteLine("network empty");
                System.Console.WriteLine("luca.size: {0}. luca.stubs: {1}", luca.size(), luca.stubs());
                return -1;
            }
            System.Console.WriteLine("About to _set_");
            System.Console.WriteLine("Stubs: {0}", luca.stubs());
            int set_num = cast.cast_int(luca.stubs());
            System.Console.WriteLine("set_num: {0}", set_num);
            Globals.LOG_TABLE._set_(set_num);//cast.cast_int(luca.stubs()));
            System.Console.WriteLine("Here\n");

            //8-24-17 string directory_char = string.Empty ;//new char[1000];
            //cast.cast_string_to_char(Parameters.file1, ref directory_char);
            
            //8-24-17 directory_char = Parameters.file1;
            string directory_char = Parameters.file1;
            string char_to_use = string.Empty ;//new char[1000];
            //sprintf(char_to_use, "mkdir %s_oslo_files", directory_char);
            string.Format(char_to_use.ToString(), "mkdir %s_oslo_files", directory_char);
            //int sy = system(char_to_use); //mcp 8-8-17 I think these are consol commands...? SO able to be commented out??
            //sprintf(char_to_use, "rm -r %s_oslo_files/*", directory_char);
            string.Format(char_to_use.ToString(), "rm -r $s_oslo_files", directory_char);
            //sy = system(char_to_use);


            System.Console.WriteLine("output files will be written in directory: {0} _oslo_files",directory_char);

            //luca.draw_with_weight_probability("prob");
              ClasslessMethods.oslom_level(ref luca, directory_char);
            return 0;
            /*wsarray mywsarray = new wsarray(5);
            log_fact_table myLogFactTable = new log_fact_table();

            myLogFactTable._set_(15);

            for (int i = 0; i < 15; i++)
            {
                System.Console.WriteLine(myLogFactTable.log_factorial(i));
            }
            System.Console.WriteLine(myLogFactTable.cum_hyper_right(3, 3, 12, 6));
            System.Console.WriteLine(myLogFactTable.cum_hyper_left(3, 3, 12, 6));
            System.Console.WriteLine("Hello, world!");
            */
        }
    }
    //Classdefs, from classes.txt, copied over as close as possible. Starting with object variables, 7/11/17, 1404.

    public static class Parameters
    {

        //void print()
        public static void print()
        {
            //cout << "**************************************" << endl;
            System.Console.WriteLine("**************************************");
            //cout << "Threshold:\t\t\t" << threshold << endl;
            System.Console.WriteLine("Threshold: \t\t\t {0}", threshold);
            //cout << "Network file:\t\t\t" << file1 << endl;
            System.Console.WriteLine("Network file:\t\t\t {0}", file1);


            if (weighted)
                //cout << "Weighted: yes" << endl;
                System.Console.WriteLine("Weighted: Yes");
            else
                System.Console.WriteLine("Weighted: no");

            if (fast)
                System.Console.WriteLine("-fast option selected");

            if (value)
                System.Console.WriteLine("Hint from file:\t\t\t {0}", file2);
            if (value_load)
                System.Console.WriteLine("tp-file:\t\t\t {0}", file_load);

            System.Console.WriteLine("First Level Runs:\t\t\t {0}", Or);
            System.Console.WriteLine("Higher Level Runs:\t\t\t {0}", hier_gather_runs);
            System.Console.WriteLine("-cp:\t\t\t {0}", coverage_percentage_fusion_or_submodules);

            if (seed_random != -1)
                System.Console.WriteLine("Random number generator seed:\t\t\t, {0}", seed_random);

            if (homeless_anyway == false)
                System.Console.WriteLine("-singlet option selected");
            for (int i = 0; i < to_run.Count(); i++)
                System.Console.WriteLine("String to run: [{0}]\t\t\t\t\t\tModule file: [{1}]", to_run[i], to_run_part[i]);
            System.Console.WriteLine("**************************************\n");
        }


        //bool _set_(int argc, char* argv[]);
        public static bool _set_(int argc, string[] argv)
        {
            System.Console.WriteLine("In _set_");
            int argct = 0;
            string temp;
           // System.Console.WriteLine("argc: {0}", argc);
            if (argc <= 1)
            {           /* if no arguments, return error_statement about program usage.*/
                System.Console.WriteLine("Error Statement to occur");
                ClasslessMethods.error_statement(argv[0]);
                return false;
            }


            bool f_set = false;
            bool set_weighted = false;

            System.Console.WriteLine("About to While");
            while (argct < argc)
            {           // input file name

                System.Console.WriteLine("setting {0}", argv[argct]);
                temp = argv[argct];
                
                //map<string, int>::iterator itf = command_flags.find(temp);

                System.Console.WriteLine("temp: {0}", temp);
                //if (itf == command_flags.end())
                if (!command_flags.ContainsKey(temp))
                {
                    System.Console.WriteLine("No temp; about to error and return false.");
                    ClasslessMethods.error_statement(argv[0]);
                    return false;
                }

                //int vp = itf->second;
                int vp = command_flags[temp];

                switch (vp)
                {

                    case 1:
                        weighted = true;
                        set_weighted = true;
                        break;
                    case 2:
                        weighted = false;
                        set_weighted = true;
                        break;
                    case 3:
                        homeless_anyway = false;
                        break;
                    case 4:
                        argct++;
                        if (argct == argc)
                        {
                            ClasslessMethods.error_statement(argv[0]);
                            return false;
                        }
                        file1 = argv[argct];
                        f_set = true;
                        break;
                    case 5:
                        argct++;
                        if (argct == argc)
                        {
                            ClasslessMethods.error_statement(argv[0]);
                            return false;
                        }
                        file2 = argv[argct];
                        value = true;
                        break;
                    case 6:
                        argct++;
                        if (argct == argc)
                        {
                            ClasslessMethods.error_statement(argv[0]);
                            return false;
                        }
                        file_load = argv[argct];
                        value_load = true;
                        break;
                    case 7:
                        if (set_flag_and_number(ref threshold, ref argct, argc, argv, 0.0, 1.0, "threshold") == false)
                            return false;
                        break;
                    case 8:
                        double orD = (double)Or;
                        if (set_flag_and_number(ref orD, ref argct, argc, argv, 0, MyRandom.R2_IM2, "runs") == false) {
                            Or = (int)orD;
                            return false;
                        }
                        break;
                    case 9:
                        double hgrd = (double)hier_gather_runs;
                        if (set_flag_and_number(ref /*hier_gather_runs*/ hgrd, ref argct, argc, argv, 0, MyRandom.R2_IM2, "higher-level runs") == false) {
                            hier_gather_runs = (int)hgrd;
                            return false;
                        }
                        break;
                    case 10:
                        double seedD = (double)seed_random;
                        if (set_flag_and_number(ref /*seed_random*/seedD, ref argct, argc, argv, 1, MyRandom.R2_IM2, "seed of the random number generator") == false) {
                            seed_random = (int)seedD;
                            return false;
                        }
                        break;
                    case 11:
                        if (set_flag_and_number(ref coverage_percentage_fusion_or_submodules, ref argct, argc, argv, 0.0, 1.0, "resolution parameter") == false)
                            return false;
                        break;
                    case 12:
                        fast = true;
                        break;
                    case 13:
                        if (set_flag_and_number_external_program("runs for infomap", ref argct, ref infomap_runs, argc, ref argv) == false)
                            return false;
                        break;
                    case 14:
                        if (set_flag_and_number_external_program("runs for copra", ref argct, ref copra_runs, argc, ref argv) == false)
                            return false;
                        break;
                    case 15:
                        if (set_flag_and_number_external_program("runs for louvain method", ref argct, ref louvain_runs, argc, ref argv) == false)
                            return false;
                        break;
                    default:
                        ClasslessMethods.error_statement(argv[0]);
                        return false;
                }
                argct++;
            }

            /*******************************************************************/


            if (f_set == false)
            {
                System.Diagnostics.Trace.WriteLine("\n\n************************************************************");
                System.Diagnostics.Trace.WriteLine("ERROR: you didn't set the file with the network.  Please read program instructions or type: \n {0}", argv[0]);
                System.Diagnostics.Trace.WriteLine("************************************************************");

                return false;

            }

            if (set_weighted == false)
            {

                //System.Diagnostics.Trace.WriteLine("\n\n************************************************************");
                System.Console.WriteLine("\n\n************************************************************");
                //System.Diagnostics.Trace.WriteLine("ERROR: you didn't set the option -w (weighted network) or -uw (unweighted network).  Please read program instructions or type: \n {0}", argv[0]);
                System.Console.WriteLine("ERROR: you didn't set the option -w (weighted network) or -uw (unweighted network).  Please read program instructions or type: \n {0}", argv[0]);
                //System.Diagnostics.Trace.WriteLine("************************************************************");
                System.Console.WriteLine("************************************************************");
                return false;
            }

            if (seed_random == -1)
                MyRandom.srand_file();
            else
                MyRandom.srand5(seed_random);

            if (fast)
            {
                Or = 1;
                hier_gather_runs = 1;
            }

            for (int i = 0; i < infomap_runs; i++)
            {

                string number_r = string.Empty ;//new char[1000];

                //cout<<"************** "<<string(argv[0])<<endl;
                string pros = argv[0].ToString();

                if (pros == "./oslom_undir")
                    //sprintf(number_r, "./infomap_undir_script NETx %d %d", MyRandom.irand(10000000), 1);
                    string.Format(number_r.ToString(), "./infomap_undir_script NETx %d %d", MyRandom.irand(10000000), 1);
                else
                    //sprintf(number_r, "./infomap_dir_script NETx %d %d", irand(10000000), 1);
                    string.Format(number_r.ToString(), "./infomap_dir_script NETx %d %d", MyRandom.irand(10000000), 1);

                string sr = number_r.ToString();

                //cout<<"here "<<endl;
                to_run.Add(sr);
                to_run_part.Add("infomap.part");
            }

            for (int i = 0; i < copra_runs; i++)
            {
                string number_r = string.Empty ;//new char[1000];
                //sprintf(number_r, "java -cp copra.jar COPRA NETx -v 5 -w");
                string.Format(number_r.ToString(), "java -cp copra.jar COPRA NETx -v 5 -w");
                string sr = number_r.ToString();

                to_run.Add(sr);
                to_run_part.Add("clusters-NETx");
            }
            for (int i = 0; i < louvain_runs; i++)
            {
                string number_r = string.Empty ;//new char[1000];
                //sprintf(number_r, "./louvain_script -f NETx");
                string.Format(number_r.ToString(), "./louvain_script -f NETx");
                string sr = number_r.ToString();

                to_run.Add(sr);
                to_run_part.Add("louvain.part");
            }
            return true;
        }




        //*******************************************************
        public static string file1;
        public static string file2;
        public static string file_load;


        //public static int seed_random;

        //public static double threshold;

        //public static int clean_up_runs;
        //public static int inflate_runs;
        //public static int inflate_stopper;
        //public static double equivalence_parameter;
        //public static int CUT_Off;

        //public static int maxborder_nodes;
        //public static double maxbg_ordinary;
        //public static int iterative_stopper;
        //public static int minimality_stopper;
        //public static double hierarchy_convergence;

        //public static int Or = 10;
        //public static int hier_gather_runs = 50;

        //public static double coverage_inclusion_module_collection;
        //public static double coverage_percentage_fusion_left;
        //public static double check_inter_p;
        //public static double coverage_percentage_fusion_or_submodules = .5;

        //public static bool print_flag_subgraph;

        //public static bool value;
        //public static bool value_load;
        //public static bool fast;
        //public static bool weighted;
        //public static bool homeless_anyway = true;

        //public static int max_iteration_convergence;



        public static List<string> to_run = new List<string>();
        public static List<string> to_run_part = new List<string>();

        //public static int infomap_runs;
        //public static int copra_runs;
        //public static int louvain_runs;
        /*~~~~~~~~~~~~~*/
        public static int seed_random = -1;//-1;	
	
	public static double threshold= 0.1;											// this is the P-value for the significance of the module
	
	public static int clean_up_runs=25;										// the number of runs in the clean up procedure
	public static int inflate_runs=3;											// the number of runs in the clean up of the inflate procedure
	public static int inflate_stopper=5;										// the number of runs in the inflate procedure
	public static double equivalence_parameter=0.33;								// this parameters tells when nodes are considered equivalent in the clean up procedure
	public static int CUT_Off=200;											// this is used in the inflate function
	
	public static int maxborder_nodes=100;									// this is to speed up the code in looking for "reasonably good" neighbors
	public static double maxbg_ordinary=0.1;										// same as above
	public static int iterative_stopper=10;									// this is to prevent the iterative procedure to last too long. this can happen in case of strong backbones (just an idea, not sure)
	public static int minimality_stopper=10;									// this is to prevent too many minimality checks
	public static double hierarchy_convergence=0.05;								// this parameter is used to stop the hierarchical process when not enough modules are found
	
	public static int Or=10;													// this is the number of global runs in the gather function		(first level)
	public static int hier_gather_runs=50;									// this is the number of global runs in the gather function		(higher level)
	
	public static double coverage_inclusion_module_collection=0.49999;			// this is used to see if two modules are higly similar in processing the clusters (big_module)
	public static double coverage_percentage_fusion_left=0.8;					// this is used to see when fusing clusters how much is left
	public static double check_inter_p=0.05;										// this parameter is a check parameter for the fusion of quite similar clusters
	public static double coverage_percentage_fusion_or_submodules=0.5;			// this is the resolution parameter to decide between split clusters or unions, if you increase this value the program tends to find bigger clusters 
		
	
	public static bool print_flag_subgraph=true;										// this flag is used to print things when necessary
	
	/* these are some flags to read input files */
	public static bool value=false;
	public static bool value_load=false;		
	public static bool fast=false;
	public static bool weighted=false;
	public static bool homeless_anyway=true;


	//********************* collect_groups	
	public static int max_iteration_convergence=10;							// parameter for the convergence of the collect_groups function
	
	
	
	public static int infomap_runs=0;
	public static int copra_runs=0;
    public static int louvain_runs = 0;
        //  public static Dictionary<string, int> command_flags = new Dictionary<string, int>(); //I think I can make this public not private, b/c c# protects...?
        //private bool set_flag_and_number(ref double threshold, ref int argct, int argc, char* argv[], double min_v, double max_v, string warning);
        //private bool set_flag_and_number(int && , int && argct, int argc, char* argv[], int min_v, int max_v, string warning);
        public static Dictionary<string, int> command_flags = new Dictionary<string, int> {
            {"-w", 1}, {"-uw", 2},{"-singlet", 3},{"-f", 4 },{"-hint", 5 }, { "-load", 6 }, { "-t", 7 }, { "-r", 8 }, { "-hr", 9 }, { "-seed", 10 }, { "-cp", 11 }, { "-fast", 12 }, { "-infomap", 13 }, { "-copra", 14 }, { "-louvain", 15 }
        };
private static bool set_flag_and_number(ref double number_to_set, ref int argct, int argc, String[] argv, double min_v, double max_v, string warning)
        {
            argct++;
            if (argct == argc)
            {
                System.Console.WriteLine("you didn't set any number for the {0}",warning);
                ClasslessMethods.error_statement(argv[0]); //MCP changed argv -> string rather than Char array.
                return false;
            }

            string tt = argv[argct];
            double ttt = new double();
            if (cast.cast_string_to_double(ref tt, ref ttt) == false)
            {

                System.Console.WriteLine("you didn't set any number for the {0}",warning);
                ClasslessMethods.error_statement(argv[0]);
                return false;
            }

            number_to_set = ttt;

            if (number_to_set < min_v || number_to_set > max_v)
            {
                System.Console.WriteLine("the {0} must be between {1} and ",warning ,min_v ,max_v);
                ClasslessMethods.error_statement(argv[0]);
                return false;
            }

            return true;
        }

        //private bool set_flag_and_number_external_program(string program_name, int && argct, int && number_to_set, int argc, char* argv[]);
        private static bool set_flag_and_number_external_program(string program_name, ref int argct, ref int number_to_set, int argc, /*char* argv[]*/ ref string[] argv)
        {
            argct++;
            if (argct == argc)
            {
                System.Console.WriteLine("you didn't set the number of {0}",program_name);

                ClasslessMethods.error_statement(argv[0].ToString());
                return false;
            }

            string tt = argv[argct].ToString();
            double ttt = new double();
            if (cast.cast_string_to_double(ref tt, ref ttt) == false)
            {
                System.Console.WriteLine("you didn't set the number of {0}",program_name);
                ClasslessMethods.error_statement(argv[0].ToString());
                return false;
            }

            number_to_set = cast.cast_int(ttt);

            if (number_to_set < 0)
            {

                System.Console.WriteLine(" the number of {0} must be positive", program_name);

                ClasslessMethods.error_statement(argv[0].ToString());
                return false;
            }
            return true;
        }

        /*private static bool set_flag_and_number(ref int number_to_set, ref int argct, int argc,ref string argv, int min_v, int max_v, string warning)
        {
            argct++;
            if (argct == argc)
            {
                System.Console.WriteLine("you didn't set any number for the {0}", warning);
                ClasslessMethods.error_statement(argv[0].ToString());
                return false;
            }

            string tt = argv[argct].ToString();
            double ttt = new double();
            if (cast.cast_string_to_double(ref tt, ref ttt) == false)
            {
                System.Console.WriteLine("you didn't set any number for the {0}", warning);
                ClasslessMethods.error_statement(argv[0].ToString());
                return false;
            }
            number_to_set = cast.cast_int(ttt);

            if (number_to_set < min_v || number_to_set > max_v)
            {
                System.Console.WriteLine("the {0} must be between {1} and {2}" ,warning , min_v, max_v);
                ClasslessMethods.error_statement(argv[0].ToString());
                return false;
            }
            return true;
        }
        */
        private static bool set_flag_and_number(ref int number_to_set, ref int argct, int argc, string[] argv, int min_v, int max_v, string warning)
        {
            argct++;
            if (argct == argc)
            {
                System.Console.WriteLine("you didn't set any number for the {0}", warning);
                ClasslessMethods.error_statement(argv[0]);
                return false;
            }

            string tt = argv[argct];
            double ttt = new double();
            if (cast.cast_string_to_double(ref tt, ref ttt) == false)
            {
                System.Console.WriteLine("you didn't set any number for the {0}", warning);
                ClasslessMethods.error_statement(argv[0]);
                return false;
            }
            number_to_set = cast.cast_int(ttt);

            if (number_to_set < min_v || number_to_set > max_v)
            {
                System.Console.WriteLine("the {0} must be between {1} and {2}", warning, min_v, max_v);
                ClasslessMethods.error_statement(argv[0]);
                return false;
            }
            return true;
        }
    }

    public class log_fact_table
    {
        //MCP 7-13-17 functions
        public void _set_(int size)
        {
            System.Console.WriteLine("allocating {0} factorials...", size);
            lnf.Clear();
            //lnf.reserve(size + 1);
            double f = 0;
            lnf.Add(0);
            for (int i = 1; i <= size; i++)
            {

                f += Math.Log(i);
                lnf.Add(f);
            }

            System.Console.WriteLine("Done.");
        }
        public double log_factorial(int a)
        {
            if (lnf.Count() >= a)
                return lnf[a];
            else {
                System.Console.Write("Out of Range");
                throw new IndexOutOfRangeException();
            }
        }
        public double log_choose(int tm, int degree_node) { return lnf[tm] - lnf[tm - degree_node] - lnf[degree_node]; }
        public double log_hyper(int kin_node, int kout_g, int tm, int degree_node) { 
            return log_choose(kout_g, kin_node) + log_choose(tm - kout_g, degree_node - kin_node) - log_choose(tm, degree_node); 
        }
        public double hyper(int kin_node, int kout_g, int tm, int degree_node) {
            System.Console.WriteLine("8-28-17 test 3760");
            //8-28-17 1552 components for return statement. Because breakage.
            double innest = log_hyper(kin_node, kout_g, tm, degree_node); //mcp 8-28-17 breakage. 1354
            System.Console.WriteLine("8-28-17 test 3762");
            double notInnest = Math.Exp(innest);
            System.Console.WriteLine("8-28-17 test 3764");
            return Math.Max(0, Math.Exp(log_hyper(kin_node, kout_g, tm, degree_node))); 
        }
        public double binom(int x, int N, double p) { return Math.Exp(log_choose(N, x) + x * Math.Log(p) + (N - x) * Math.Log(1 - p)); }
        private double sym_ratio(ref int k1, ref int k2, ref int H, double i) { return 0.5 * (k1 - i + 1) / ((i + H) * i) * (k2 - i + 1); }

        public double cum_hyper_right(int kin_node, int kout_g, int tm, int degree_node)
        {

            //cout<<"kin_node... "<<kin_node<<" "<<kout_g<<" "<<tm<<" "<<degree_node<<endl; 
            // this is bigger  or equal p(x >= kin_node)   *** EQUAL ***
            //int schlock = 1;
            if (kin_node > Math.Min(degree_node, kout_g))
                return 0;
            if (tm - kout_g - degree_node + kin_node <= 0)
                return 1;

            if (kin_node <= 0)
                return 1;


            if (kin_node < (double)(kout_g + 1) / (double)(tm + 2) * (double)(degree_node + 1))
                return (1.0 - cum_hyper_left(kin_node, kout_g, tm, degree_node));
            int x = kin_node;
            double pzero = hyper(x, kout_g, tm, degree_node);


            //*
            if (pzero <= 1e-40)
                return 0;
            //*/


            ///I think the previous are checks on whether or not the numbers work for the RH function?

            double ga = tm - kout_g - degree_node;
            int kout_g_p = kout_g + 1;
            double degree_node_p = degree_node + 1;
            double z_zero = 1.0;
            double sum = z_zero;



            while (true)
            {
                /*if(schlock%100==0){
                    cout << "while (true) in log_table -> cum_hyper_right()");
                }*/
                ++x;
                z_zero *= (double)(kout_g_p - x) / (x * (ga + x)) * (degree_node_p - x);
                if (z_zero < Globals.log_table_pr * sum)
                    break;

                if (pzero * sum > 1)
                    return pzero;

                sum += z_zero;
                //schlock++;
            }
            return pzero * sum;

        }
        public double cum_hyper_left(int kin_node, int kout_g, int tm, int degree_node)
        {
            // this is strictly less  p(x < kin_node)   *** NOT EQUAL ***
            //cout<<kin_node<<" node: "<<degree_node<<" group: "<<tm<<" "<<degree_node<<endl;


            if (kin_node <= 0)
                return 0;

            if (tm - kout_g - degree_node + kin_node <= 0)
                return 0;

            if (kin_node > Math.Min(degree_node, kout_g))
                return 1;



            if (kin_node > (double)(kout_g + 1) / (double)(tm + 2) * (double)(degree_node + 1))
                return (1.0 - cum_hyper_right(kin_node, kout_g, tm, degree_node));

            int x = kin_node - 1;
            double pzero = hyper(x, kout_g, tm, degree_node);

            //cout<<"pzero: "<<pzero<<" "<<log_hyper(x, kout_g, tm, degree_node)<<" gsl: "<<(gsl_ran_hypergeometric_pdf(x, kout_g, tm - kout_g,  degree_node))<<endl;

            if (pzero <= 1e-40)
                return 0;

            double ga = tm - kout_g - degree_node;
            int kout_g_p = kout_g + 1;
            double degree_node_p = degree_node + 1;
            double z_zero = 1.0;
            double sum = z_zero;

            //cout<<"pzero "<<pzero<<" "<<z_zero<<" "<<kin_node<<endl;

            while (true)
            {
                z_zero *= (ga + x) / ((degree_node_p - x) * (kout_g_p - x)) * x;
                --x;
                //cout<<"zzero sum "<<z_zero<<" "<<sum<<" "<<(ga + x)<<endl;
                if (z_zero < Globals.log_table_pr * sum)
                    break;

                if (pzero * sum > 1)
                    return pzero;

                sum += z_zero;
            }
            return pzero * sum;

        }

        public double cum_binomial_left(int x, int N, double prob)
        {

            // this is less strictly p(x < kin_node)   *** NOT EQUAL ***
            if (x <= 0)
                return 0;

            if (x > N)
                return 1;
            if (prob < 1e-11)
                return 1;
            if (x > N * prob)
                return 1 - cum_binomial_right(x, N, prob);
            --x;
            double pzero = binom(x, N, prob);
            if (pzero <= 1e-40)
                return 0;
            double z_zero = 1.0;
            double sum = z_zero;
            while (true)
            {
                --x;
                z_zero *= (1 - prob) * (double)(x + 1) / ((N - x) * prob);

                //cout<<"zzero sum "<<z_zero<<" "<<sum<<" "<<(ga + x)<<endl;

                if (z_zero < Globals.log_table_pr * sum)
                    break;

                sum += z_zero;
            }


            return pzero * sum;
        }

        public double cum_binomial_right(int x, int N, double prob)
        {

            // this is bigger  or equal p(x >= kin_node)   *** EQUAL ***

            //cout<<"x "<<x<<" N "<<N <<"  prob "<<prob<<endl;


            if (x <= 0)
                return 1;

            if (x > N)
                return 0;


            if (prob - 1 > -1e-11)
                return 1;

            if (x < N * prob)
                return 1 - cum_binomial_left(x, N, prob);

            double pzero = binom(x, N, prob);

            if (pzero <= 1e-40)
                return 0;

            double z_zero = 1.0;
            double sum = z_zero;

            while (true)
            {
                z_zero *= prob * (double)(N - x) / ((x + 1) * (1 - prob));
                x++;
                //cout<<"zzero sum "<<z_zero<<" "<<sum<<" "<<endl;

                if (z_zero < Globals.log_table_pr * sum)
                    break;

                sum += z_zero;
            }

            return pzero * sum;
        }

        public double log_symmetric_eq(int k1, int k2, int H, int x) { return -x * lnf[2] - lnf[k1 - x] - lnf[k2 - x] - lnf[x + H] - lnf[x]; }

        public double fast_right_cum_symmetric_eq(int k1, int k2, int H, int x, int mode, int tm)
        {
            if (k1 > k2)
                return fast_right_cum_symmetric_eq(k2, k1, H, x, mode, tm);

            double ri = 1;
            double q1 = 0;
            double q2 = 0;
            double ratio;

            if (x == mode)
                ++q2;
            else
                ++q1;

            int l1 = Math.Max(0, -H);
            double ii = mode - 1;

            while (ii >= l1)
            {
                ratio = sym_ratio(ref k1, ref k2, ref H, ii + 1);
                ri /= ratio;
                q1 += ri;
                if (q1 > 1e280)
                    return cum_hyper_right(x, k2, tm, k1);

                if (ri < Globals.log_table_pr * q1)
                    break;

                --ii;
            }
            ri = 1;
            ii = mode + 1;
            //for(double i=mode+1; i<x; i++) 
            while (ii < x)
            {
                ratio = sym_ratio(ref k1, ref k2, ref H, ii);
                ri *= ratio;

                q1 += ri;
                if (q1 > 1e280)
                    return cum_hyper_right(x, k2, tm, k1);

                if (ri < Globals.log_table_pr * q1)
                    break;
                //cout<<ii<<" "<<ratio<<" "<<ri/q1<<" b"<<endl;;
                ++ii;

                //cout<<"dx-.: "<<ii<<" "<<exp(log_symmetric_eq(k1, k2, H, ii))<<" "<<exp(lg0) * ri<<" "<<sym_ratio(k1, k2, H, ii+1)<<endl;
            }

            ii = Math.Max(x, mode + 1);
            ri = Math.Exp(log_symmetric_eq(k1, k2, H, (int)(ii - 1)) - log_symmetric_eq(k1, k2, H, mode));

            while (ii <= k1)
            {
                ratio = sym_ratio(ref k1, ref k2, ref H, ii);
                ri *= ratio;
                q2 += ri;
                if (q2 > 1e280)
                    return cum_hyper_right(x, k2, tm, k1);
                //cout<<ii<<" "<<ratio<<" "<<ri/q2<<" c "<<x<<" "<<q2<<endl;;
                ++ii;
                if (ri < Globals.log_table_pr * q2)
                    break;
                //cout<<"ddx-.: "<<i<<" "<<exp(log_symmetric_eq(k1, k2, H, i))<<" "<<exp(lg0) * ri<<" "<<sym_ratio(k1, k2, H, i+1)<<endl;

            }
            return Math.Max(q2 / (q1 + q2), 1e-100);
        }

        public double right_cumulative_function(int k1, int k2, int tm, int x)
        {
            ///MCP 7-10-17, note that this is probably CORRECT cumulative function...
            System.Console.WriteLine("8-28-17 test 4020");///Or maybe not. There is a cum_hyper_LEFT function.
            if (x > k1 || x > k2) {
                System.Console.WriteLine("8-28-17 test 4022");
                return 0;
            }
            System.Console.WriteLine("8-28-17 test 4025");
            if (k1 * k1 < tm) {
                System.Console.WriteLine("8-28-17 test 4027");
                return cum_hyper_right(x, k2, tm, k1);
            }

            // k1 is the degree of the node
            // k2 is the degree of the other node (the bigger)
            // k3 is 2m - k1 - k2

            System.Console.WriteLine("8-28-17 test 4035");
            int k3 = tm - k1;
            System.Console.WriteLine("8-28-17 test 4037");
            int H = (k3 - k1 - k2) / 2;
            System.Console.WriteLine("8-28-17 test 4039");
            int l1 = Math.Max(0, -H);
            System.Console.WriteLine("8-28-17 test 4041");

            if (x == l1) {
                System.Console.WriteLine("8-28-17 test 4044");
                return 1;
            }
            System.Console.WriteLine("8-28-17 test 4047");

            int mode = Math.Max((int)(k2 / (double)(k1 + k3) * k1), l1);        // this mode in underestimated anyway
            System.Console.WriteLine("8-28-17 test 4050");
            if (mode > k2) {
                System.Console.WriteLine("8-28-17 test 4052");
                mode = k2;
                System.Console.WriteLine("8-28-17 test 4054");
            }
            System.Console.WriteLine("8-28-17 test 4056");
            //cout<<"mode: "<<mode<<endl;
            if (x < mode) {
                System.Console.WriteLine("8-28-17 test 4059");
                return cum_hyper_right(x, k2, tm, k1);
                System.Console.WriteLine("8-28-17 test 4061");
            }
            System.Console.WriteLine("8-28-17 test 4063");

            return fast_right_cum_symmetric_eq(k1, k2, H, x, mode, tm);

        }

        private List<double> lnf = new List<double>();

    }
    public class wsarray
    {
        public wsarray(int a)
        {
            position = 0;
            _size_ = a;

            l = new List<int>(_size_);
            w = new List<KeyValuePair<int, double>>(_size_);
        }

        //public pair<int, double>* w;
        public List<KeyValuePair<int, double>> w; //Possibly from lecture notes? See how this goes.
        //public int* l;
        public List<int> l; //Note that the usage in original constructor suggests it's used for arrays.
        private int _size_;
        private int position;

        public int find(int a)
        {
            int one = 0;
            int two = position - 1;

            if (position == 0)
                return -1;

            if (a < l[one] || a > l[two])
                return -1;
            if (a == l[one])
                return one;
            if (a == l[two])
                return two;

            while (two - one > 1)
            {
                int middle = (two - one) / 2 + one;
                if (a == l[middle])
                    return middle;
                if (a > l[middle])
                    one = middle;
                else
                    two = middle;
            }
            return -1;
        }

        public KeyValuePair<int, KeyValuePair<int, double>> posweightof(int x)
        {

            int i = find(x);
            if (i == -1)
                return (new KeyValuePair<int, KeyValuePair<int, double>>(-1, new KeyValuePair<int, double>(0, 0.0)));

            return (new KeyValuePair<int, KeyValuePair<int, double>>(i, w.ElementAt(i)));
        }
        public void push_back(int a, int bb, double b)
        {
            //l[position] = a;
            l.Add(a);
            //w[position++] = new KeyValuePair<int, double>(bb, b);
            w.Add(new KeyValuePair<int, double>(bb, b));
            position++;
        }
        public int size() { return position; }
        public void freeze()
        {
            Dictionary<int, KeyValuePair<int, double>> M = new Dictionary<int, KeyValuePair<int, double>>();
            for (int i = 0; i < position; i++)
            {
                /*	//this is to sum up multiple entries
                map<int, double>::iterator itf=M.find(l[i]);
                if (itf==M.end())
                    M.insert(make_pair(l[i], w[i]));
                else
                    itf.second+=w[i];
                //*/
                M.Add(l[i], new KeyValuePair<int, double>(w.ElementAt(i).Key, w.ElementAt(i).Value));
            }
            if (_size_ != (int)(M.Count()))
            {
                //delete[] l;
                //l = new List<int>();
                //l = NULL;

                //delete[] w;
                //w = new List<KeyValuePair<int, double>>();
                //w = NULL;


                _size_ = M.Count();
                position = M.Count();

                l = new List<int>(_size_);//int[_size_];
                w = new List<KeyValuePair<int, double>>(_size_); //Lis<int, double>[_size_];

            }


            int poi = 0;
            //for (map<int, pair<int, double>>::iterator itm = M.begin(); itm != M.end(); itm++)
            foreach (KeyValuePair<int, KeyValuePair<int, double>> itm in M)
            {
                l[poi] = itm.Key;
                w[poi] = itm.Value;
                poi++;
            }
        }

    }

    //MCP 7-24-17 undirected_network.h
    public static class undirected_network
    {
        public class static_network
        {
            public bool set_graph(string file_name)
            {
                clear();
                string b = string.Empty ;//new char[file_name.Count() + 1];
                //cast.cast_string_to_char(file_name, ref b);
                b = file_name;
                Dictionary<int, int> newlabels = new Dictionary<int, int>();
                List<int> link_i = new List<int>();

                bool good_file = true;
                {
                    int label = 0;
                    //ifstream inb(b);
                    System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());

                    string ins;
                    //while (getline(inb, ins))
                    while((ins = inb.ReadLine())!=null)
                        if (ins.Count() > 0 && ins[0] != '#')
                        {
                            List<double> ds = new List<double>();
                            cast.cast_string_to_doubles(ref ins, ref ds);

                            if (ds.Count() < 2)
                            {
                                string errormessage1 = "From file " + file_name + ": string not readable " + ins + " ";
                                //cerr << "From file " << file_name << ": string not readable " << ins << " " << endl;
                                System.Diagnostics.Trace.WriteLine(errormessage1);
                                good_file = false;
                                break;
                            }
                            else
                            {
                                int innum1 = cast.cast_int(ds[0]);
                                int innum2 = cast.cast_int(ds[1]);
                                //map<int, int>::iterator itf = newlabels.find(innum1);
                                //if (itf == newlabels.end())
                                if(!newlabels.ContainsKey(innum1))
                                {
                                    newlabels.Add(innum1, label++);
                                    link_i.Add(1);
                                }
                                else { 
                                    //link_i[itf->second]++;
                                    link_i[newlabels[innum1]] += 1;//++;
                                }
                                //itf = newlabels.find(innum2);
                                //if (itf == newlabels.end())
                                if(!newlabels.ContainsKey(innum2))
                                {
                                    newlabels.Add(innum2, label++);
                                    link_i.Add(1);
                                }
                                else {
                                    //link_i[itf->second]++;
                                    link_i[newlabels[innum2]]+=1;//++;
                                }
                            }
                        }
                }
                dim = newlabels.Count();

                for (int i = 0; i < dim; i++)
                    vertices.Add(new vertex(0, 0, link_i[i]));

                //for (map<int, int>::iterator itm = newlabels.begin(); itm != newlabels.end(); itm++)
                foreach(KeyValuePair<int,int> itm in newlabels)
                    vertices[itm.Value].id_num = itm.Key;
                if (good_file)
                {
                    //ifstream inb(b);
                    System.IO.StreamReader inb = new System.IO.StreamReader(b.ToString());
                    string ins;
                    //while (getline(inb, ins))
                    while ((ins = inb.ReadLine()) != null) { 
                        //System.Console.Write("While readline. ");
                        if (ins.Count() > 0 && ins[0] != '#')
                        {
                            //System.Console.Write("Ins: {0} ",ins);
                            //System.Console.ReadKey();//pause equivalent.
                            //cout<<ins<<endl;
                            List<double> ds = new List<double>();
                            cast.cast_string_to_doubles(ref ins, ref ds);

                            /*cout<<"ds: ";
                            prints(ds);*/

                            int innum1 = cast.cast_int(ds[0]);
                            int innum2 = cast.cast_int(ds[1]);

                            double w = 1;
                            int multiple_l = 1;

                            //--------------------------------------------------------------
                            //--------------------------------------------------------------
                            if (ds.Count() >= 4)
                            {
                                if (Parameters.weighted == false)
                                {
                                    if (ds[2] > 0.99)
                                    {
                                        multiple_l = cast.cast_int(ds[2]);
                                    }
                                }
                                if (Parameters.weighted == true)
                                {
                                    //---------------------------------------------
                                    if (ds[2] > 0)
                                    {
                                        w = ds[2];
                                    }
                                    else
                                    {
                                        //cerr << "error: not positive weights" << endl;
                                        System.Diagnostics.Trace.WriteLine("error: not positive weights");
                                        return false;
                                    }
                                    //---------------------------------------------
                                    if (ds[3] > 0.99)
                                    {
                                        //cout<<ds[2]<<"<- "<<endl;
                                        multiple_l = cast.cast_int(ds[3]);
                                    }
                                    //---------------------------------------------
                                }
                            }

                            if (ds.Count() == 3)
                            {
                                if (Parameters.weighted)
                                {
                                    if (ds[2] > 0)
                                        w = ds[2];
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine("error: not positive weights");
                                        return false;
                                    }
                                }
                                else
                                {

                                    if (ds[2] > 0.99)
                                        multiple_l = cast.cast_int(ds[2]);
                                }
                            }
                            //--------------------------------------------------------------
                            //--------------------------------------------------------------

                            int new1 = newlabels[innum1];
                            int new2 = newlabels[innum2];


                            if (new1 != new2 && w > 0)
                            {       // no self loops!
                                vertices[new1].links.push_back(new2, multiple_l, w);
                                vertices[new2].links.push_back(new1, multiple_l, w);
                            }
                        }
                    }
                    oneM = 0;
                    System.Console.WriteLine("oneM (aka stubs) reset to 0.");
                    for (int i = 0; i < dim; i++)
                    {
                        //System.Console.WriteLine("Stubs should be increasing here.");
                        vertices[i].links.freeze();

                        int stub_number_i = 0;
                        double strength_i = 0; //MCP 8-24-17; there are *issues* with vertices.links.size.
                        //System.Console.WriteLine("About to for loop vertex numbers.");
                        //System.Console.WriteLine("i: {0}; vertices[i].links.size(): {1}", i, vertices[i].links.size());
                        for (int j = 0; j < vertices[i].links.size(); j++)
                        {
                            stub_number_i += vertices[i].links.w[j].Key;
                            strength_i += vertices[i].links.w[j].Value;
                            //System.Console.Write("stub_number_i: {0}; strength_i: {1}. ", stub_number_i, strength_i);
                        }
                        vertices[i].stub_number = stub_number_i;
                        vertices[i].strength = strength_i;
                        oneM += stub_number_i;
                        //System.Console.WriteLine("oneM: {0}", oneM);
                    }
                    System.Console.WriteLine("Through for");
                }
                else
                    System.Diagnostics.Trace.WriteLine("File corrupted");

                //draw("before_set");
                if (Parameters.weighted)
                    set_proper_weights();
                return good_file;
            }
            public int draw(string file_name)
            {
                int h = file_name.Count();

                string b = string.Empty ;//new char[h + 1];
                /*for (int i = 0; i < h; i++)
                    b[i] = file_name[i];
                b[h] = '\0';*/
                b = file_name;

                //ofstream graph_out(b);
                System.IO.StreamWriter graph_out = new System.IO.StreamWriter(b.ToString());
                
                if (Parameters.weighted)
                {
                    for (int i = 0; i < (int)(vertices.Count()); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            if (vertices[i].id_num <= vertices[vertices[i].links.l[j]].id_num)
                                //graph_out << vertices[i]->id_num << "\t" << vertices[vertices[i]->links->l[j]]->id_num << "\t" << vertices[i]->original_weights[j] << "\t" << vertices[i]->links->w[j].first << "\t" << endl;
                                graph_out.WriteLine("{0} \t {1} \t {2} \t {3}", vertices[i].id_num, vertices[vertices[i].links.l[j]].id_num, vertices[i].original_weights[j], vertices[i].links.w[j].Key);
                }
                else
                {
                    for (int i = 0; i < (int)(vertices.Count()); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            if (vertices[i].id_num <= vertices[vertices[i].links.l[j]].id_num)
                                //graph_out << vertices[i]->id_num << "\t" << vertices[vertices[i]->links->l[j]]->id_num << "\t" << vertices[i]->links->w[j].first << endl;
                                graph_out.WriteLine("{0} \t {1} \t {2} \t", vertices[i].id_num, vertices[vertices[i].links.l[j]].id_num, vertices[i].links.w[j].Key);
                }
                return 0;
            }
            public void clear()
            {
                vertices = new List<vertex>();
                dim = 0;
                oneM = 0;
            }
            public void set_graph(ref Dictionary<int, Dictionary<int, KeyValuePair<int, double>>> A)
            {
                // this maps the id into the usual stuff neighbors-weights
                List<List<int>> link_per_node = new List<List<int>>();
                List<List<KeyValuePair<int, double>>> weights_per_node = new List<List<KeyValuePair<int, double>>>();
                List<int> label_rows = new List<int>();

                //for (map<int, map<int, pair<int, double>>>:: iterator itm = A.begin(); itm != A.end(); itm++)
                foreach (KeyValuePair<int, Dictionary<int, KeyValuePair<int, double>>> itm in A)
                {
                    label_rows.Add(itm.Key);
                    List<int> n = new List<int>();
                    List<KeyValuePair<int, double>> w = new List<KeyValuePair<int, double>>();


                    //for (map<int, pair<int, double>>:: iterator itm2 = itm.second.begin(); itm2 != itm.second.end(); itm2++)
                    foreach (KeyValuePair<int, KeyValuePair<int, double>> itm2 in itm.Value)
                        if (itm2.Value.Key > 0)
                        {
                            n.Add(itm2.Key);
                            w.Add(itm2.Value);
                        }
                    link_per_node.Add(n);
                    weights_per_node.Add(w);
                }

                /*
                prints(label_rows);
                printm(link_per_node);
                printm(weights_per_node);*/
                set_graph(ref link_per_node, ref weights_per_node, ref label_rows);
            }
            public void set_graph(ref List<List<int>> link_per_node, ref List<List<KeyValuePair<int, double>>> weights_per_node, ref List<int> label_rows)
            {
                clear();
                // there is no check between label_rows and link per node but they need to have the same labels
                // link_per_node and weights_per_node are the list of links and weights. label_rows[i] is the label corresponding to row i
                Dictionary<int, int> newlabels = new Dictionary<int, int>();        // this maps the old labels with the new one
                for (int i = 0; i < (int)(label_rows.Count()); i++)
                    newlabels.Add(label_rows[i], newlabels.Count());
                dim = newlabels.Count();
                for (int i = 0; i < dim; i++)
                    vertices.Add(new vertex(0, 0, link_per_node[i].Count()));


                //for (map<int, int>::iterator itm = newlabels.begin(); itm != newlabels.end(); itm++)
                foreach (KeyValuePair<int, int> itm in newlabels)
                    vertices[itm.Value].id_num = itm.Key;




                for (int i = 0; i < (int)(link_per_node.Count()); i++)
                {


                    for (int j = 0; j < (int)(link_per_node[i].Count()); j++)
                    {

                        int new2 = newlabels[link_per_node[i][j]];
                        //vertices[i].links.
                        vertices[i].links.push_back(new2, weights_per_node[i][j].Key, weights_per_node[i][j].Value);
                    }
                }

                oneM = 0;

                for (int i = 0; i < dim; i++)
                {

                    vertices[i].links.freeze();


                    int stub_number_i = 0;
                    double strength_i = 0;
                    for (int j = 0; j < vertices[i].links.size(); j++)
                    {

                        stub_number_i += vertices[i].links.w[j].Key;
                        strength_i += vertices[i].links.w[j].Value;
                    }


                    vertices[i].stub_number = stub_number_i;
                    vertices[i].strength = strength_i;
                    oneM += stub_number_i;



                }
                //draw_consecutive();
                //draw("GIIO");
                if (Parameters.weighted)
                    set_proper_weights();
            }

            /*void set_graph(ref List<List<int>> link_per_node, ref List<List<KeyValuePair<int, double>>> weights_per_node, ref List<int> label_rows)
            {
                clear();
                // there is no check between label_rows and link per node but they need to have the same labels
                // link_per_node and weights_per_node are the list of links and weights. label_rows[i] is the label corresponding to row i
                Dictionary<int, int> newlabels = new Dictionary<int, int>();        // this maps the old labels with the new one
                for (int i = 0; i < (int)(label_rows.Count()); i++)
                    newlabels.insert(new KeyValuePair<(label_rows[i], newlabels.Count()));



                dim = newlabels.size();



                for (int i = 0; i < dim; i++)
                    vertices.push_back(new vertex(0, 0, link_per_node[i].size()));


                for (map<int, int>::iterator itm = newlabels.begin(); itm != newlabels.end(); itm++)
                    vertices[itm.second].id_num = itm.first;




                for (int i = 0; i < int(link_per_node.size()); i++)
                {


                    for (int j = 0; j < int(link_per_node[i].size()); j++)
                    {

                        int new2 = newlabels[link_per_node[i][j]];
                        vertices[i].links.push_back(new2, weights_per_node[i][j].first, weights_per_node[i][j].second);

                    }

                }

                oneM = 0;

                for (int i = 0; i < dim; i++)
                {

                    vertices[i].links.freeze();


                    int stub_number_i = 0;
                    double strength_i = 0;
                    for (int j = 0; j < vertices[i].links.size(); j++)
                    {

                        stub_number_i += vertices[i].links.w[j].first;
                        strength_i += vertices[i].links.w[j].second;


                    }


                    vertices[i].stub_number = stub_number_i;
                    vertices[i].strength = strength_i;
                    oneM += stub_number_i;



                }


                //draw_consecutive();
                //draw("GIIO");
                if (paras.weighted)
                    set_proper_weights();




            }
            */
            public void set_proper_weights()
            {
                // this function id to normalize the weights in order to have the -log(prob(Weiight>w)) which is simply w[i].second / <w_ij>
                if (dim == 0)
                {
                    System.Diagnostics.Trace.WriteLine("Network empty");
                    //cout<<"network empty"<<endl;
                    //cherr();
                }
                else
                {
                    for (int i = 0; i < dim; i++)
                    {

                        vertices[i].original_weights = new List<double>();

                        for (int j = 0; j < vertices[i].links.size(); j++)
                        {
                            vertices[i].original_weights.Add(vertices[i].links.w[j].Value);
                        }
                    }


                    for (int i = 0; i < dim; i++)
                    {

                        for (int j = 0; j < vertices[i].links.size(); j++)
                        {

                            double w1 = (vertices[i].strength / vertices[i].stub_number) * vertices[i].links.w[j].Key;
                            double w2 = (vertices[vertices[i].links.l[j]].strength / vertices[vertices[i].links.l[j]].stub_number) * vertices[i].links.w[j].Key;
                            //vertices[i].links.w[j].Value /= 2.0/ (1.0/ w1 + 1./ w2);
                            vertices[i].links.w[j] = new KeyValuePair<int, double>(vertices[i].links.w[j].Key, vertices[i].links.w[j].Value / (2.0 / (1.0 / w1 + 1.0 / w2)));

                        }

                    }
                }
            }
            //public int draw(string);
            //public int draw_consecutive(string file_name1, string file_name2);
            //public int draw_with_weight_probability(string file_name);


            //public void print_id(const deque<int> & a, ostream &);
            //public void print_id(const deque<deque<int>> & , ostream &);
            //public void print_id(const deque<set<int>> & , ostream &);
            //public void print_id(const set<int> & , ostream & );



            //public int translate(deque<deque<int>> &);
            public int translate(ref List<List<int>> ten)
            {

                Dictionary<int, int> A = new Dictionary<int, int>();
                get_id_label(ref A);

                List<List<int>> ten2 = new List<List<int>>();

                for (int i = 0; i < (int)(ten.Count()); i++)
                {

                    List<int> ff = new List<int>();

                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                    {

                        //Dictionary<int, int>::iterator itf = A.find(ten[i][j]);
                        //if (itf == A.end())
                        foreach (KeyValuePair<int, int> itf in A)
                        {
                            if (itf.Value == ten[i][j])
                            {
                                System.Diagnostics.Trace.WriteLine("warning: the nodes in the communities are different from those ones in the network!");
                                break;
                            }
                            else
                                ff.Add(itf.Value);
                            //  cerr << "warning: the nodes in the communities are different from those ones in the network!" << endl;
                            //return -1;
                        }
                    }

                    if (ff.Count() > 0)
                        ten2.Add(ff);
                }
                ten = ten2;
                return 0;
            }

            //public int translate_anyway(deque<deque<int>> & ten);
            public int translate_anyway(ref List<List<int>> ten)
            {

                Dictionary<int, int> A = new Dictionary<int, int>();
                get_id_label(ref A);

                List<List<int>> ten2 = new List<List<int>>();
                bool broken = false;
                for (int i = 0; i < (int)(ten.Count()); i++)
                {
                    if (broken)
                    {
                        System.Console.WriteLine("Broken, in outer for.");
                    }
                    List<int> ff = new List<int>();

                    for (int j = 0; j < (int)(ten[i].Count()); j++)
                    {
                        if (broken)
                        {
                            System.Console.WriteLine("Broken, in inner for.");
                        }

                        //Dictionary<int, int>::iterator itf = A.find(ten[i][j]);
                        //if (itf != A.end())
                        foreach (KeyValuePair<int, int> itf in A)
                        {
                            if (itf.Value == ten[i][j])
                            {
                                ff.Add(itf.Value);
                                System.Console.WriteLine("Confirm that this breaks to Inner Forloop, not out of the nested Fors...");
                                broken = true;
                                break;
                            }
                            else
                                broken = false;
                        }


                    }

                    if (ff.Count() > 0)
                        ten2.Add(ff);
                }
                ten = ten2;
                return 0;
            }

            //public void set_subgraph(deque<int> & group, deque<deque<int>> & link_per_node, deque<deque<pair<int, double>>> & weights_per_node);
            public void set_subgraph(ref List<int> group, ref List<List<int>> link_per_node, ref List<List<KeyValuePair<int, double>>> weights_per_node)
            {
                // in this function I'm not using id's... because I want to work with the same labels (don't want to translate)
                //sort(group.begin(), group.end());
                group.Sort();
                weights_per_node = new List<List<KeyValuePair<int, double>>>();
                link_per_node = new List<List<int>>();

                for (int i = 0; i < (int)(group.Count()); i++)
                {
                    int nodei = group[i];
                    List<int> link_i = new List<int>();
                    List<KeyValuePair<int, double>> weight_i = new List<KeyValuePair<int, double>>();


                    for (int j = 0; j < vertices[nodei].links.size(); j++)
                        if (group.Contains(vertices[nodei].links.l[j]))//binary_search(group.begin(), group.end(), vertices[nodei].links.l[j]))
                        {
                            link_i.Add(vertices[nodei].links.l[j]);
                            //weight_i.push_back(make_pair(vertices[nodei].links.w[j].first,   vertices[nodei].original_weights[j]));
                            if (Parameters.weighted)
                                weight_i.Add(new KeyValuePair<int, double>(vertices[nodei].links.w[j].Key, vertices[nodei].original_weights[j]));
                            else
                                weight_i.Add(new KeyValuePair<int, double>(vertices[nodei].links.w[j].Key, 1));
                            //weight_i.push_back(make_pair(vertices[nodei].links.w[j].first, vertices[nodei].links.w[j].second));
                        }
                    link_per_node.Add(link_i);
                    weights_per_node.Add(weight_i);
                }
            }
            public void set_subgraph(ref LinkedList<int> group, ref List<List<int>> link_per_node, ref List<List<KeyValuePair<int, double>>> weights_per_node)
            {
                List<int> group2 = group.ToList<int>();
                set_subgraph(ref group2, ref link_per_node, ref weights_per_node);
                group = new LinkedList<int>();
                foreach (int i in group2)
                {
                    group.AddLast(i);
                }
            }


            public void set_connected_components(ref List<List<int>> comps)
            {
                comps = new List<List<int>>();
                HashSet<int> not_assigned = new HashSet<int>();//MCP yes, I realize the irony of assigning to not_assigned. IT'S IN THE ORIGINAL. (More or less. THis is c#-ified.
                for (int i = 0; i < dim; i++)
                    not_assigned.Add(i);

                while (not_assigned.Count() > 0)
                {
                    int source = not_assigned.First<int>();

                    HashSet<int> mates = new HashSet<int>();
                    same_component(source, ref mates);


                    List<int> ccc = new List<int>();
                    //for (set<int>::iterator its = mates.begin(); its != mates.end(); its++)
                    foreach (int its in mates)
                    {
                        ccc.Add(its);
                        not_assigned.Remove(its);
                    }
                    comps.Add(ccc);
                }
            }
            void same_component(int source, ref HashSet<int> already_gone)
            {
                already_gone = new HashSet<int>();
                already_gone.Add(source);

                List<int> this_shell = new List<int>();
                this_shell.Add(source);
                while (this_shell.Count() > 0)
                {
                    List<int> next_shell = new List<int>();

                    for (int i = 0; i < (int)(this_shell.Count()); i++)
                        for (int j = 0; j < vertices[this_shell[i]].links.size(); j++)
                        {
                            if (!already_gone.Contains(vertices[this_shell[i]].links.l[j]))
                            {
                                already_gone.Add(vertices[this_shell[i]].links.l[j]);
                                next_shell.Add(vertices[this_shell[i]].links.l[j]);
                            }
                            this_shell = next_shell;
                        }
                }
            }
            public int propagate_distances(ref List<int> new_shell, ref HashSet<int> already_gone, ref List<KeyValuePair<int, int>> distances_node, int shell, ref List<double> ML, ref int reached, int step)
            {

                shell++;
                List<int> next_shell = new List<int>();
                for (int i = 0; i < (int)(new_shell.Count()); i++)
                    for (int j = 0; j < vertices[new_shell[i]].links.size(); j++)
                    {
                        //if (already_gone.insert(vertices[new_shell[i]].links.l[j]).second == true)
                        if (!already_gone.Contains(vertices[new_shell[i]].links.l[j]))
                        {
                            already_gone.Add(vertices[new_shell[i]].links.l[j]);
                            distances_node.Add(new KeyValuePair<int, int>(shell, vertices[new_shell[i]].links.l[j]));
                            next_shell.Add(vertices[new_shell[i]].links.l[j]);
                        }
                    }
                /*
                cout<<"new shell "<<shell<<endl;
                print_id(next_shell, cout);
                prints(ML);
                */
                if (next_shell.Count() > 0)
                {
                    if (shell >= (int)(ML.Count()))
                        ML.Add(dim * step);

                    reached += next_shell.Count();
                    ML[shell] += reached;
                    return propagate_distances(ref next_shell, ref already_gone, ref distances_node, shell, ref ML, ref reached, step);
                }
                return 0;
            }
            //public void get_id_label(map<int, int> &);
            public int id_of(int a) { return vertices[a].id_num; }

            public int size() { return dim; }
            public double stubs() { return oneM; }

            //public int kin_m(const deque<int> &);
            public int kin_m(List<int> seq)
            {
                if (seq.Count() > (double)(oneM) / dim)
                {

                    HashSet<int> H = new HashSet<int>();
                    //deque_to_set(seq, H);
                    seq.Sort();
                    foreach (int adder in seq)
                    {
                        H.Add(adder);
                    }
                    return kin_m(H);
                }
                int k = 0;
                for (int i = 0; i < (int)(seq.Count()); i++)
                    k += vertices[seq[i]].kplus_m(seq);

                return k;
            }
            public int kin_m(HashSet<int> s)
            {

                int k = 0;
                //for (set<int>::iterator it = s.begin(); it != s.end(); it++)
                foreach (int it in s)
                    k += vertices[it].kplus_m(s.ToList<int>());
                return k;
            }


            public int ktot_m(List<int> seq)
            {
                int k = 0;
                for (int i = 0; i < (int)(seq.Count()); i++)
                    k += vertices[seq[i]].stub_number;
                return k;
            }

            public int ktot_m(HashSet<int> s)
            {
                int k = 0;
                //for (set<int>::iterator it = s.begin(); it != s.end(); it++)
                foreach (int it in s)
                    k += vertices[it].stub_number;
                return k;
            }

            //public int kin_m(const set<int> &);
            //public int ktot_m(const deque<int> &);
            //public int ktot_m(const set<int> &);

            public void get_id_label(ref Dictionary<int, int> a)
            {
                for (int i = 0; i < dim; i++)
                    a.Add(vertices[i].id_num, i);
            }
            //public void deque_id(deque<int> & );
            public void deque_id(ref List<int> a)
            {

                for (int i = 0; i < (int)(a.Count()); i++)
                    a[i] = vertices[a[i]].id_num;
            }

            public void deque_id(ref LinkedList<int> a)
            {

                for (int i = 0; i < (int)(a.Count()); i++)
                    //a[i] = vertices[a[i]].id_num;
                    a.Find(a.ElementAt(i)).Value = vertices[a.ElementAt(i)].id_num;
            }


            public void list_id(ref List<int> a)
            {

                for (int i = 0; i < (int)(a.Count()); i++)
                    a[i] = vertices[a[i]].id_num;
            }

            //public void set_graph(map<int, map<int, pair<int, double>>> & A);
            //public bool set_graph(string file_name);
            //public void clear();

            //public void set_proper_weights();


            //public void set_connected_components(deque<deque<int>> & );
            //public int propagate_distances(deque<int> & new_shell, set<int> & already_gone, deque<pair<int, int>> & distances_node, int shell, deque<double> & ML, int &, int);
            //public void same_component(int , set<int> &);


            //public int set_upper_network(map<int, map<int, pair<int, double>>> & neigh_weight_f, module_collection & Mcoll);
            //public void print_degree_of_homeless(DI & homel, ostream & outt);
            public void print_degree_of_homeless(ref List<int> homel, ref System.IO.StreamWriter outt)
            {
                List<int> degree_of_homeless = new List<int>();
                for (int i = 0; i < homel.Count(); i++)
                    degree_of_homeless.Add(vertices[homel[i]].stub_number);

                outt.WriteLine("average degree of homeless nodes: {0} dev: {1}",/*average_func(degree_of_homeless)*/degree_of_homeless.Average() ,Math.Sqrt(Combinatorics.variance_func(ref degree_of_homeless)));

            }
            protected class vertex
            {
                public vertex(int b, int c, int preall)
                {
                    id_num = b;
                    links = new wsarray(preall);
                }

                //public void kplus_global_and_quick(deque<int> & a, int & stubs_in, double & strength_in);
                /*public void kplus_global_and_quick(ref List<int> a, ref int stubs_in,  ref double strength_in)
                {
                    // a must be sorted, otherwise it does not work
                    // this function has never been used (so, it should be checked)
                    List<int> a2 = a;
                    a2.Sort();
                    stubs_in = 0;
                    strength_in = 0;
                    if ((int)(a.Count()) > stub_number)
                    {
                        // in this case there must be a loop on links because a is longer

                        for (int i = 0; i < links.Count(); i++)
                        {
                            a2.BinarySearch(links[i].l[i]);
                            if (binary_search(a.begin(), a.end(), links.l[i]))
                            {
                                stubs_in += links.w[i].first;
                                strength_in += links.w[i].second;
                            }
                        }
                    }
                    else
                    {

                        for (int i = 0; i < int(a.size()); i++)
                        {

                            pair<int, double> A = links.posweightof(a[i]).second;
                            stubs_in += A.first;
                            strength_in += A.second;
                        }

                    }

                }

                */
                public int kplus_m(List<int> a)
                {

                    // computes the internal degree of the vertex respect with a

                    int s = 0;
                    //double f=0;
                    for (int i = 0; i < (int)(a.Count()); i++)
                    {
                        KeyValuePair<int, double> A = links.posweightof(a[i]).Value;
                        s += A.Key;
                        //f+=A.second;
                    }
                    return s;

                }
                //public double kplus_w(const deque<int> &);
                public double kplus_w(List<int> a)
                {

                    // computes the internal degree of the vertex respect with a

                    double s = 0;
                    //double f=0;
                    for (int i = 0; i < (int)(a.Count()); i++)
                    {
                        KeyValuePair<int, double> A = links.posweightof(a[i]).Value;
                        s += A.Value;
                        //f+=A.second;
                    }
                    return s;
                }
                //public int kplus_m(const set<int> &);
                int kplus_m(HashSet<int> a)
                {

                    // computes the internal degree of the vertex respect with a (a is supposed to be sorted)
                    int s = 0;
                    //double f=0;

                    for (int i = 0; i < links.l.Count(); i++)
                    {
                        if (a.Contains(links.l[i]))
                        {
                            s += links.w[i].Key;
                        }
                        /*if (a.find(links.l[i]) != a.end())
                        {

                            s += links.w[i].first;
                            //f+=links.w[i].second;
                        }*/
                    }
                    return s;
                }




                public int id_num;                     // id
                public double strength;                // sum of the weights
                public int stub_number;                // number of stubs
                public wsarray links;                 // array with label of neighbor, multiple links, sm of the weights towards it 
                //originally a pointer. Not sure...
                public List<double> original_weights = new List<double>();
            }
            public int set_upper_network(ref Dictionary<int, Dictionary<int, KeyValuePair<int, double>>> neigh_weight_f, ref module_collection Mcoll)
            {
                // loop on all the edges of the network...
                neigh_weight_f = new Dictionary<int, Dictionary<int, KeyValuePair<int, double>>>();//.clear();

                if (Mcoll.size() == 0)
                    return 0;

                //map<int, map<int, pair<double, double>>> neigh_weight_s;
                Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> neigh_weight_s = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();

                //for (map<int, double>::iterator its = Mcoll.module_bs.begin(); its != Mcoll.module_bs.end(); its++)
                foreach (KeyValuePair<int, double> its in Mcoll.module_bs)
                {
                    Dictionary<int, KeyValuePair<double, double>> neigh_weight = new Dictionary<int, KeyValuePair<double, double>>();
                    Dictionary<int, KeyValuePair<int, double>> ooo = new Dictionary<int, KeyValuePair<int, double>>();
                    neigh_weight_s.Add(its.Key, neigh_weight);
                    neigh_weight_f.Add(its.Key, ooo);
                }
                for (int i = 0; i < dim; i++)
                {
                    HashSet<int> mem1 = Mcoll.memberships[i]; //MCP note this had the & in front of it.

                    for (int j = 0; j < vertices[i].links.size(); j++)
                    {
                        int neigh = vertices[i].links.l[j];
                        HashSet<int> mem2 = Mcoll.memberships[neigh];

                        double denominator = mem1.Count() * mem2.Count();
                        // I add a link between all different modules

                        if (Parameters.weighted)
                        {
                            //for (set<int>:: iterator itk = mem1.begin(); itk != mem1.end(); itk++)
                            foreach (int itk in mem1)
                                foreach (int itkk in mem2)
                                    //for (set<int>:: iterator itkk = mem2.begin(); itkk != mem2.end(); itkk++)
                                    if (itk != itkk)
                                    {
                                        Dictionary<int, KeyValuePair<double, double>> neigh_weight_s_itk = neigh_weight_s[itk];
                                        Histograms.int_histogram(itkk, ref neigh_weight_s_itk, (double)(vertices[i].links.w[j].Key) / denominator, vertices[i].original_weights[j] / denominator);
                                        neigh_weight_s[itk] = neigh_weight_s_itk;
                                    }
                        }
                        else
                        {
                            foreach (int itk in mem1)
                                foreach (int itkk in mem2)
                                    //for (set<int>:: iterator itk = mem1.begin(); itk != mem1.end(); itk++)
                                    //for (set<int>:: iterator itkk = mem2.begin(); itkk != mem2.end(); itkk++)
                                    if (itk != itkk)
                                    {
                                        Dictionary<int, KeyValuePair<double, double>> neigh_weight_s_itk = neigh_weight_s[itk];
                                        Histograms.int_histogram(itkk, ref neigh_weight_s_itk, (double)(vertices[i].links.w[j].Key) / denominator, (double)(vertices[i].links.w[j].Key) / denominator);
                                        neigh_weight_s[itk] = neigh_weight_s_itk;
                                    }
                        }
                    }
                }
                //for (map<int, map<int, pair<double, double>>>:: iterator itm = neigh_weight_s.begin(); itm != neigh_weight_s.end(); itm++)
                foreach (KeyValuePair<int, Dictionary<int, KeyValuePair<double, double>>> itm in neigh_weight_s)
                {
                    foreach (KeyValuePair<int, KeyValuePair<double, double>> itm_ in itm.Value)
                        //for (map<int, pair<double, double>>::iterator itm_ = itm.second.begin(); itm_ != itm.second.end(); itm_++)
                        if (itm_.Key < itm.Key)
                        {
                            int intml = cast.cast_int(itm_.Value.Key);
                            if (intml > 0)
                            {
                                //neigh_weight_f[itm.first].insert(make_pair(itm_.first, make_pair(intml, itm_.second.second)));
                                //Dictionary<int, KeyValuePair<int, double>> thingamawhatsis = new Dictionary<int, KeyValuePair<int, double>>();
                                neigh_weight_f[itm.Key].Add(itm_.Key, new KeyValuePair<int, double>(intml, itm_.Value.Value));
                                neigh_weight_f[itm_.Key].Add(itm.Key, new KeyValuePair<int, double>(intml, itm_.Value.Value)); //MCP I have no idea if this is correct. The itm_.key < itm.key may be making some assumptions about Maps that aren't fulfilled in dictionaries.
                            }
                        }
                }
                return 0;
            }

            public int dim = new int();                                    // number of nodes
            public int oneM = new int();                                   // number of stubs

            protected List<vertex> vertices = new List<vertex>();
        }
        //   all this stuff here should be improved
        //   all this stuff here should be improved
        //   all this stuff here should be improved
        /*
            bool static_network::set_graph(string file_name)
            {


                clear();


                char b[file_name.size() + 1];
                cast_string_to_char(file_name, b);




                map<int, int> newlabels;
                deque<int> link_i;

                bool good_file = true;


                {

                    int label = 0;


                    ifstream inb(b);

                    string ins;


                    while (getline(inb, ins))
                        if (ins.size() > 0 && ins[0] != '#')
                        {


                            deque<double> ds;
                            cast_string_to_doubles(ins, ds);

                            if (ds.size() < 2)
                            {
                                cerr << "From file " << file_name << ": string not readable " << ins << " " << endl;
                                good_file = false;
                                break;
                            }


                            else
                            {


                                int innum1 = cast_int(ds[0]);
                                int innum2 = cast_int(ds[1]);


                                map<int, int>::iterator itf = newlabels.find(innum1);
                                if (itf == newlabels.end())
                                {
                                    newlabels.insert(make_pair(innum1, label++));
                                    link_i.push_back(1);
                                }
                                else
                                    link_i[itf.second]++;


                                itf = newlabels.find(innum2);
                                if (itf == newlabels.end())
                                {
                                    newlabels.insert(make_pair(innum2, label++));
                                    link_i.push_back(1);
                                }
                                else
                                    link_i[itf.second]++;





                            }



                        }

                }


                dim = newlabels.size();

                for (int i = 0; i < dim; i++)
                    vertices.push_back(new vertex(0, 0, link_i[i]));


                for (map<int, int>::iterator itm = newlabels.begin(); itm != newlabels.end(); itm++)
                    vertices[itm.second].id_num = itm.first;



                if (good_file)
                {


                    ifstream inb(b);
                    string ins;
                    while (getline(inb, ins))
                        if (ins.size() > 0 && ins[0] != '#')
                        {


                            //cout<<ins<<endl;
                            deque<double> ds;
                            cast_string_to_doubles(ins, ds);

                            //cout<<"ds: ";
                            //prints(ds);

                            int innum1 = cast_int(ds[0]);
                            int innum2 = cast_int(ds[1]);

                            double w = 1;
                            int multiple_l = 1;

                            //--------------------------------------------------------------
                            //--------------------------------------------------------------
                            if (ds.size() >= 4)
                            {



                                if (paras.weighted == false)
                                {

                                    if (ds[2] > 0.99)
                                    {
                                        //cout<<ds[2]<<"<- "<<endl;
                                        multiple_l = cast_int(ds[2]);

                                    }

                                }


                                if (paras.weighted == true)
                                {


                                    //---------------------------------------------
                                    if (ds[2] > 0)
                                    {
                                        w = ds[2];
                                    }
                                    else
                                    {
                                        cerr << "error: not positive weights" << endl;
                                        return false;
                                    }
                                    //---------------------------------------------



                                    if (ds[3] > 0.99)
                                    {
                                        //cout<<ds[2]<<"<- "<<endl;
                                        multiple_l = cast_int(ds[3]);

                                    }
                                    //---------------------------------------------

                                }

                            }

                            if (ds.size() == 3)
                            {


                                if (paras.weighted)
                                {

                                    if (ds[2] > 0)
                                        w = ds[2];
                                    else
                                    {
                                        cerr << "error: not positive weights" << endl;
                                        return false;
                                    }
                                }
                                else
                                {

                                    if (ds[2] > 0.99)
                                        multiple_l = cast_int(ds[2]);
                                }

                            }
                            //--------------------------------------------------------------
                            //--------------------------------------------------------------

                            int new1 = newlabels[innum1];
                            int new2 = newlabels[innum2];


                            if (new1 != new2 && w > 0)
                            {       // no self loops!

                                //cout<<"W: "<<w<<endl;

                                vertices[new1].links.push_back(new2, multiple_l, w);
                                vertices[new2].links.push_back(new1, multiple_l, w);

                            }

                        }


                    oneM = 0;

                    for (int i = 0; i < dim; i++)
                    {

                        vertices[i].links.freeze();

                        int stub_number_i = 0;
                        double strength_i = 0;
                        for (int j = 0; j < vertices[i].links.size(); j++)
                        {

                            stub_number_i += vertices[i].links.w[j].first;

                            //cout<<". "<<vertices[i].links.w[j].second<<endl;
                            strength_i += vertices[i].links.w[j].second;


                        }


                        vertices[i].stub_number = stub_number_i;
                        vertices[i].strength = strength_i;
                        oneM += stub_number_i;

                    }




                }
                else
                    cerr << "File corrupted" << endl;

                //draw("before_set");
                if (paras.weighted)
                    set_proper_weights();



                return good_file;

            }

            int static_network::draw(string file_name)
            {



                int h = file_name.size();

                char b[h + 1];
                for (int i = 0; i < h; i++)
                    b[i] = file_name[i];
                b[h] = '\0';



                ofstream graph_out(b);


                if (paras.weighted)
                {

                    for (int i = 0; i < int(vertices.size()); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            if (vertices[i].id_num <= vertices[vertices[i].links.l[j]].id_num)
                                graph_out << vertices[i].id_num << "\t" << vertices[vertices[i].links.l[j]].id_num << "\t" << vertices[i].original_weights[j] << "\t" << vertices[i].links.w[j].first << "\t" << endl;

                }
                else
                {

                    for (int i = 0; i < int(vertices.size()); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            if (vertices[i].id_num <= vertices[vertices[i].links.l[j]].id_num)
                                graph_out << vertices[i].id_num << "\t" << vertices[vertices[i].links.l[j]].id_num << "\t" << vertices[i].links.w[j].first << endl;

                }


                return 0;

            }


            void static_network::print_id(deque<int> a, ostream & pout)
            {

                for (int i = 0; i < int(a.size()); i++)
                    pout << vertices[a[i]].id_num << "\t";
                pout << endl;


            }


            void static_network::print_id(set<int> a, ostream & pout)
            {

                for (set<int>::iterator its = a.begin(); its != a.end(); its++)
                    pout << vertices[*its].id_num << "\t";
                pout << endl;


            }



            void static_network::print_id(deque<deque<int>> a, ostream & pout)
            {

                for (int i = 0; i < int(a.size()); i++)
                    print_id(a[i], pout);



            }

            void static_network::print_id(deque<set<int>> a, ostream & pout)
            {

                for (int i = 0; i < int(a.size()); i++)
                    print_id(a[i], pout);



            }


            int static_network::draw_consecutive(string file_name1, string file_name2)
            {


                char b[128];
                cast_string_to_char(file_name1, b);


                //cout<<"drawing in file "<<b<<endl;
                ofstream graph_out(b);

                if (paras.weighted)
                {
                    for (int i = 0; i < int(vertices.size()); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            if (i < vertices[i].links.l[j])
                                graph_out << i << "\t" << vertices[i].links.l[j] << "\t" << cast_int(vertices[i].original_weights[j]) << endl;
                }
                else
                {

                    for (int i = 0; i < int(vertices.size()); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            if (i < vertices[i].links.l[j])
                                graph_out << i << "\t" << vertices[i].links.l[j] << "\t" << vertices[i].links.w[j].first << endl;
                }


                char bb[128];

                cast_string_to_char(file_name2, bb);
                ofstream graph_out2(bb);
                for (int i = 0; i < int(vertices.size()); i++)
                    graph_out2 << i << " " << vertices[i].id_num << endl;



                return 0;

            }


            int static_network::draw_with_weight_probability(string file_name)
            {



                int h = file_name.size();

                char b[h + 1];
                for (int i = 0; i < h; i++)
                    b[i] = file_name[i];
                b[h] = '\0';



                ofstream graph_out(b);


                if (paras.weighted)
                {

                    for (UI i = 0; i < vertices.size(); i++)
                        for (int j = 0; j < vertices[i].links.size(); j++)
                            graph_out << vertices[i].id_num << "\t" << vertices[vertices[i].links.l[j]].id_num << "\t" << vertices[i].original_weights[j] << "\t" << vertices[i].links.w[j].first << endl;

                }





                return 0;

            }

            void static_network::print_degree_of_homeless(DI & homel, ostream & outt)
            {

                deque<int> degree_of_homeless;
                for (UI i = 0; i < homel.size(); i++)
                    degree_of_homeless.push_back(vertices[homel[i]].stub_number);

                outt << "average degree of homeless nodes: " << average_func(degree_of_homeless) << " dev: " << sqrt(variance_func(degree_of_homeless)) << endl;



            }
                */
    }

    //MCP 7-25-17 undir_weighted_tabdeg.h
    public static class undir_weighted_tabdeg
    {
        public static double compare_r_variables(double a, double b, double c, double d)
        {
            //cout << "In Compare r_variables" << endl;
            // r1 \in (a,b)
            // r2 \in (c,d)
            // compute the probability p(r2<r1)
            //cout<<a<<" "<<b<<" "<<c<<" "<<d<<endl;	
            if (c < a)
                return (1 - compare_r_variables(c, d, a, b));
            if (c > b)
                return 0;
            if (d > b)
                return 0.5 * (b - c) * (b - c) / ((d - c) * (b - a));
            else
                return (b - 0.5 * (d + c)) / (b - a);
        }
        static double erfc(double x)
        {
            //adapted from https://www.johndcook.com/blog/csharp_erf/ and C++ implementation of erfc. 
            return 1 - Erf(x);
        }
        static double Erf(double x)
        {
            //taken from https://www.johndcook.com/blog/csharp_erf/
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }
        public static double right_error_function(double x)
        {
            return 0.5 * erfc(x / Globals.sqrt_two);
        }
        public static double log_together(double minus_log_total, int number)
        {
            if (number < 11)
            {
                double fa = 1;
                double zum = 1;
                for (int i = 1; i < number; i++)
                {
                    fa *= minus_log_total / i;
                    zum += fa;
                }
                return Math.Max(zum * Math.Exp(-minus_log_total), 1e-100);
            }
            double mu = number;
            return Math.Max(right_error_function((minus_log_total - mu) / Math.Sqrt(mu)), 1e-100);
        }
        public static double fitted_exponent(int N)
        {
            double l = Math.Log((double)(N));
            if (N > 100)
                return 4.2 * l - 8.5;
            if (N > 30)
                return 3.5 * l - 5.5;
            if (N > 7)
                return 2.5 * l - 2;
            if (N > 1)
                return 1.3 * l + 0.1;
            return 1;
        }
        public static double order_statistics_left_cumulative(int N, int pos, double x)
        {
            //cout << "In order_statistics_left_cumulative" << endl;

            // the routine computes the probality c_pos=  p(X_pos <= x)
            // N is the total number of variables, pos is from 1 to N. N is the smallest.

            //   cout << ""; ///MCP 7-6-17 DO NOT REMOVE THIS FOR FEAR OF HANGING THE COMPUTER.
            return Globals.LOG_TABLE.cum_binomial_right(N - pos + 1, N, x);
        }
        public static double inverse_order_statistics(int sample_dim, int pos, double zerof, double lo, double hi)
        {

            // anyway it's possible that I will tabulated this stuff for N small like sample_dim < 10000 which can already help a lot.
            // moreover, i should not use bisection but something better
            // finally there is the gaussian approx which could be studied more...
            //file: /Users/admin/Desktop/ambiente/right_binomial_cum/approx.cpp

            //double zerof= - log(1-threshold)/fitted_exponent(sample_dim);
            double mid = (hi + lo) / 2;

            while ((mid != lo) && (mid != hi))
            {
                double fmid = order_statistics_left_cumulative(sample_dim, pos, mid);
                if (Math.Floor(Math.Abs(fmid - zerof)) < Globals.bisection_precision * zerof)
                    break;
                if ((fmid - zerof) <= 0)
                    lo = mid;
                else
                    hi = mid;
                mid = (hi + lo) / 2;
            }
            return mid;
        }
        public static double pron_min_exp(int N, double xi)
        {
            // this should return the probability that the minimum of the quantiles p(c_min<=xi)
            //cout<<". "<<fitted_exponent(N)<<endl;
            return 1 - Math.Exp(-fitted_exponent(N) * xi);
        }
        public static double compute_probability_to_stop(double a, double b, double critical_xi, int Nstar, int pos)
        {
            /*	this routine is to compute the bootstrap probaility that the node with extremes a and b will be below threshold 
                when I already know that the average is below critical_xi */
            if (order_statistics_left_cumulative(Nstar, pos, b) <= critical_xi)
                return 1;

            return (inverse_order_statistics(Nstar, pos, critical_xi, (a + b) * 0.5, b) - a) / (b - a);
        }
        public static bool equivalent_check(int pos_first, int pos_last, ref double A_average, ref double B_average, int equivalents, int Nstar, double critical_xi)
        {
            //cout << "equivalent_check" << endl;
            // returns true is the test was passed

            /*small_simulation(pos_first, pos_last, A_average, B_average, equivalents, Nstar, critical_xi);
            cout<<pos_first<<" "<<pos_last<<" A, B "<<A_average<<" "<<B_average<<" "<<equivalents<<" "<<Nstar<<" "<<critical_xi<<endl;*/

            int pos = pos_first;
            double cr_previous = A_average;
            for (int i = equivalents; i >= 1; i--)
            {
                //cout << "in for loop, line 218" << endl;
                // loop which starts from the best node

                //cout<<"i... "<<i<<endl;
                //cout << "About to go into order_statistics_left_cumulative, line 222" << endl;
                if (order_statistics_left_cumulative(Nstar, pos, cr_previous) <= critical_xi)
                {
                    //cout << "About to go into order_statistics again. (In 2nd level if.)" << endl;
                    if (order_statistics_left_cumulative(Nstar, pos, B_average) <= critical_xi)
                    {
                        //cout << "In final level if, about to return true." << endl;
                        return true;
                    }
                    //cout << "Not about to return true. Instead, look at inverse_order_statistics." << endl;
                    double cr = inverse_order_statistics(Nstar, pos, critical_xi, cr_previous, B_average);
                    //cout<<i<<" cr: "<<cr<<" "<<order_statistics_left_cumulative(equivalents, i, (cr-A_average)/(B_average-A_average))<<endl;
                    //cout<<" this,  "<<order_statistics_left_cumulative(Nstar, pos, cr)<<" "<<Nstar<<" "<<pos<<endl;
                    //cout << "inverse_order_stats worked. Now try orderstatsleftcumulative" << endl;
                    if (order_statistics_left_cumulative(equivalents, i, (cr - A_average) / (B_average - A_average)) > 0.5)
                    {
                        //cout << "";
                        return true;
                    }
                    //cout << "orderstaticsleftcumulative did not was not>.5, but still worked. set a variable = cr" << endl;
                    cr_previous = cr;
                }

                //cout << "out of order_statics left cumulative thing. (line 242.)" << endl;
                --pos;

            }
            //cout << "About to return false." << endl;
            return false;
        }
        public static bool equivalent_check_gather(ref Dictionary<double, List<KeyValuePair<int, double>>> a /*Note this was a multimap, be careful of Sizing*/, ref int until, double probability_a, double probability_b, int Nstar, double critical_xi)
        {
            //cout << "Got to equivalent check gather" << endl;
            int nodes_added = -1;
            double A_average = 0;
            double B_average = 0;
            int pos_first = -1;
            int pos_last = -1;

            //while (itl != a.end())
            foreach (KeyValuePair<double, List<KeyValuePair<int, double>>> itl1 in a)
            {
                //cout << "Start while" << endl;
                if (nodes_added == until)
                    break;
                //cout << "Past first if" << endl;
                ++nodes_added;
                //if (compare_r_variables(probability_a, probability_b, itl.Key - itl.Value.second, itl.Key + itl.Value.second) > paras.equivalence_parameter)
                //if(compare_r_variables(probability_a,probability_b,itl1.Key - itl1.Value))
                foreach (KeyValuePair<int, double> itl2 in itl1.Value)
                {
                    if (compare_r_variables(probability_a, probability_b, itl1.Key - itl2.Value, itl1.Key + itl2.Value) > Parameters.equivalence_parameter)
                    {
                        //cout << "In second if" << endl;
                        if (pos_first == -1)
                            pos_first = Nstar - nodes_added;

                        A_average += itl1.Key - itl2.Value;
                        B_average += itl1.Key + itl2.Value;//itl.Key + itl.Value.second;
                        pos_last = Nstar - nodes_added;
                        //cout<<"pos_first: "<<pos_first<<" ... "<<pos_last<<endl;
                        //cout << "About to leave second if" << endl;
                    }
                }
                //cout << "Out of first if" << endl;
            }
            //cout << "Out of While" << endl;


            int equivalents = pos_first - pos_last + 1;
            A_average /= equivalents;
            B_average /= equivalents;

            if (equivalents == 1)
                return true;

            //cout << "Was  THIS where it broke?" << endl;
            if (equivalent_check(pos_first, pos_last, ref A_average, ref B_average, equivalents, Nstar, critical_xi) == true)
            {
                //cout << "Nope, not where it broke" << endl;
                //cout<<"check passed"<<endl;
                return true;
            }
            else
            {
                until = -1;
                //cout<<"check not passed"<<endl;
                return false;
            }
        }
        public static double hyper_table(int kin_node, int kout_g, int tm, int degree_node)
        {
            return Globals.LOG_TABLE.hyper(kin_node, kout_g, tm, degree_node);
        }
        public static double topological_05(int kin_node, int kout_g, int tm, int degree_node)
        {
            return Globals.LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node + 1) + MyRandom.ran4() * (hyper_table(kin_node, kout_g, tm, degree_node));
        }
        public static double compute_global_fitness(int kin_node, int kout_g, int tm, int degree_node, double minus_log_total, int number_of_neighs, int Nstar, ref double boot_interval)
        {
            /*  kin_node is referred to the node and not to the module */
            /* boot_interval is half the domain of the fitness. We assume that also in the weighted case the fitness can be linearized */
            /* which is true if the boot_interval is small enough	*/
            boot_interval = (0.5 + 1e-6 * (MyRandom.ran4() - 0.5)) * hyper_table(kin_node, kout_g, tm, degree_node);
            double topologic = Globals.LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node + 1) + boot_interval;
            //cout<<"---------. "<<LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node+1)<<"  boot_interval "<<boot_interval<<" kin_node: "<<kin_node<<" / "<<degree_node<<endl;
            //cout<<"<> "<<LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node)<<"  boot_interval "<<boot_interval<<" kin_node: "<<kin_node<<" / "<<degree_node<<endl;
            if (Parameters.weighted == false)
            {
                if (topologic > 1)
                    topologic = 1;

                if (1.0 - topologic < boot_interval)
                    boot_interval = 1.0 - topologic;
                if (topologic < boot_interval)
                    boot_interval = topologic;
                return Math.Max(topologic, 1e-100);
            }

            topologic *= (Nstar + 1.0) / (number_of_neighs + 1.0);
            boot_interval *= (Nstar + 1.0) / (number_of_neighs + 1.0);

            if (topologic > 1)
            {
                topologic = 1;
                boot_interval = 1e-100;
            }
            //cout<<"to: "<<topologic<<endl;
            double weight_part = log_together(minus_log_total, kin_node);
            //cout<<"we: "<<weight_part<<" - "<<minus_log_total<<endl;

            if (topologic <= 1e-100 || weight_part <= 1e-100)
            {
                boot_interval = 1e-100;
                return 1e-100;
            }

            double _log_sum_ = -Math.Log(topologic * weight_part);
            boot_interval *= weight_part * _log_sum_;

            double global_score = log_together(_log_sum_, 2);
            if (1.0 - global_score < boot_interval)
                boot_interval = 1.0 - global_score;
            if (global_score < boot_interval)
                boot_interval = global_score;

            return global_score;
        }
        public static double compute_global_fitness_step(int kin_node, int kout_g, int tm, int degree_node, double minus_log_total, int number_of_neighs, int Nstar, double _step_)
        {

            double topologic = Globals.LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node + 1) + _step_ * (hyper_table(kin_node, kout_g, tm, degree_node));

            if (Parameters.weighted == false)
                return Math.Max(topologic, 1e-100);
            topologic *= (Nstar + 1.0) / (number_of_neighs + 1.0);

            if (topologic > 1)
                topologic = 1;

            double weight_part = log_together(minus_log_total, kin_node);

            if (topologic <= 1e-100 || weight_part <= 1e-100)
                return 1e-100;

            return log_together(-Math.Log(topologic * weight_part), 2);
        }
        public static double compute_global_fitness_ofive(int kin_node, int kout_g, int tm, int degree_node, double minus_log_total, int number_of_neighs, int Nstar)
        {
            return compute_global_fitness_step(kin_node, kout_g, tm, degree_node, minus_log_total, number_of_neighs, Nstar, 0.5);
        }


        public static double compute_global_fitness_randomized(int kin_node, int kout_g, int tm, int degree_node, double minus_log_total, int number_of_neighs, int Nstar)
        {
            return compute_global_fitness_step(kin_node, kout_g, tm, degree_node, minus_log_total, number_of_neighs, Nstar, MyRandom.ran4());
        }
        public static double compute_global_fitness_randomized_short(int kin_node, int kout_g, int tm, int degree_node, double minus_log_total)
        {
            // this function is used in try_to_assign_homeless. 
            // the usual problem is that we don't know the number of neighbors of the module.
            // this could be taken in account with some more thinking...

            double b2 = Globals.LOG_TABLE.right_cumulative_function(degree_node, kout_g, tm, kin_node + 1);

            double topologic = b2 + 0.5 * (hyper_table(kin_node, kout_g, tm, degree_node));

            if (Parameters.weighted == false)
                return Math.Max(topologic, 1e-100);

            double weight_part = log_together(minus_log_total, kin_node);

            if (topologic <= 1e-100 || weight_part <= 1e-100)
                return 1e-100;

            return Math.Min(topologic, weight_part);
        }
        public class facts
        {
            public facts(int a, double b, KeyValuePair<double, List<int>> c,/* multimap<double, int>::iterator c,*/ int d)
            {
                internal_degree = a;
                minus_log_total_wr = b;
                fitness_iterator = c;
                degree = d;
            }

            public int degree;
            public int internal_degree;
            public double minus_log_total_wr;                              // wr is the right part of the exponential for the weights, this is the sum over the internal stubs of that
            public KeyValuePair<double, List<int>> fitness_iterator;//multimap<double, int>::iterator fitness_iterator;
        }
        public class weighted_tabdeg
        {
            //   public:

            //public void _set_(weighted_tabdeg &);
            public void _set_(ref weighted_tabdeg one)
            {
                clear();
                //for (map<int, facts>::iterator itm = one.lab_facts.begin(); itm != one.lab_facts.end(); itm++)
                foreach (KeyValuePair<int, facts> itm in one.lab_facts)
                    edinsert(itm.Key, itm.Value.internal_degree, itm.Value.degree, itm.Value.minus_log_total_wr, (itm.Value.fitness_iterator).Key);
            }

            //public void clear();
            public void clear()
            {
                lab_facts = new Dictionary<int, facts>();
                fitness_lab = new Dictionary<double, List<int>>();
            }
            //public void edinsert(int a, int kp, int kt, double mtlw, double fit);
            public void edinsert(int a, int kp, int kt, double mtlw, double fit)
            {       // this function inserts element a (or edit it if it was already inserted)
                erase(a);
                //multimap<double, int>::iterator fiit = fitness_lab.insert(make_pair(fit, a));
                KeyValuePair<double, List<int>> fiit = new KeyValuePair<double, List<int>>();
                List<int> fiitList = fitness_lab[fit];
                fiitList.Add(a);
                fitness_lab[fit] = fiitList;
                //fiit = fitness_lab[fit];
                fiit = new KeyValuePair<double, List<int>>(fit, fiitList);
                facts F = new facts(kp, mtlw, fiit, kt);

                lab_facts.Add(a, F);
            }

            //public bool erase(int a);
            public bool erase(int a)
            {       // this function erases element a if exists (and returns true)
                //map<int, facts>::iterator itm = lab_facts.find(a);
                //if (itm != lab_facts.end())
                foreach (KeyValuePair<int, facts> itm in lab_facts)
                {
                    if (itm.Key == a)
                    {
                        //int x = itm.Value.fitness_iterator.Value[0];
                        //fitness_lab.Remove(itm.Value.fitness_iterator.Value[0]);
                        //foreach(int rmitl in )
                        fitness_lab[itm.Key].Remove(itm.Value.fitness_iterator.Value[0]); //MCP added. I think this accounts for list-ness.
                        lab_facts.Remove(itm.Key);

                        return true;
                    }
                }

                return false;

            }

            //public void set_deque(deque<int> & );
            public void set_deque(ref List<int> vv)
            {

                vv = new List<int>();

                //for (map<int, facts>::iterator itm = lab_facts.begin(); itm != lab_facts.end(); itm++)
                foreach (KeyValuePair<int, facts> itm in lab_facts)
                    vv.Add(itm.Key);
            }
            public int size() { return lab_facts.Count(); }
            //public void print_nodes(ostream &, deque<int> & );

            /*public void print_nodes(ostream & outb, deque<int> & lab_id)
        {


            cout << "printing nodes:.. (lab intk mtlw fitness degree) " << size() << endl;

            for (map<int, facts>::iterator itm = lab_facts.begin(); itm != lab_facts.end(); itm++)
                cout << lab_id[itm.Key] << " " << itm.Value.internal_degree << " " << itm.Value.minus_log_total_wr << " " << (itm.Value.fitness_iterator).Key << " " << itm.Value.degree << endl;



        }
        */

            //public void set_and_update_group(int nstar, int nn, int kout_g, int tm, weighted_tabdeg & one);
            public void set_and_update_group(int nstar, int nn, int kout_g, int tm, ref weighted_tabdeg one)
            {
                /*this function is to set and update the fitnesses of all the nodes in cgroup*/
                clear();
                //for (map<int, facts>::iterator itm = one.lab_facts.begin(); itm != one.lab_facts.end(); itm++)
                foreach (KeyValuePair<int, facts> itm in one.lab_facts)
                {

                    double fit = compute_global_fitness_ofive(itm.Value.internal_degree, kout_g + 2 * itm.Value.internal_degree - itm.Value.degree,
                                                                  tm + itm.Value.degree, itm.Value.degree, itm.Value.minus_log_total_wr, nn + 1, nstar + 1);
                    edinsert(itm.Key, itm.Value.internal_degree, itm.Value.degree, itm.Value.minus_log_total_wr, fit);

                }


            }
            //public void set_and_update_neighs(int nstar, int nn, int kout_g, int tm, weighted_tabdeg & one);
            public void set_and_update_neighs(int nstar, int nn, int kout_g, int tm, ref weighted_tabdeg one)
            {
                /*this function is to set and update the fitnesses of all the nodes in neighs*/
                clear();
                //for (map<int, facts>::iterator itm = one.lab_facts.begin(); itm != one.lab_facts.end(); itm++)
                foreach (KeyValuePair<int, facts> itm in one.lab_facts)
                {
                    double fit = compute_global_fitness_ofive(itm.Value.internal_degree, kout_g, tm, itm.Value.degree, itm.Value.minus_log_total_wr, nn, nstar);
                    edinsert(itm.Key, itm.Value.internal_degree, itm.Value.degree, itm.Value.minus_log_total_wr, fit);
                }
            }

            //public bool update_group(int a, int delta_degree, double delta_mtlw, int nstar, int nn, int kout_g, int tm, int kt, deque<int> & to_be_erased);
            public bool update_group(int a, int delta_degree, double delta_mtlw, int nstar, int nn, int kout_g, int tm, int kt, ref List<int> to_be_erased)
            {
                // this function is to change the internal degree and mtlw of a certain node (to insert it or erase if necessary)
                //map<int, facts>::iterator itm = lab_facts.find(a);//MCP. finds the first one with key a. Given Map, not MultiMap, only ONE with "a". So, that's good.
                //if (itm == lab_facts.end())
                //  return false;
                if (!lab_facts.ContainsKey(a))
                {
                    return false;
                }
                KeyValuePair<int, facts> itm = new KeyValuePair<int, facts>(a, lab_facts[a]);
                itm.Value.minus_log_total_wr += delta_mtlw;
                itm.Value.internal_degree += delta_degree;

                if (itm.Value.internal_degree == 0 && size() > 1)
                {
                    to_be_erased.Add(a);
                    return true;
                }
                //cout<<"UPdating... group "<<a<<endl;

                double fit = compute_global_fitness_ofive(itm.Value.internal_degree, kout_g + 2 * itm.Value.internal_degree - itm.Value.degree,
                                                              tm + itm.Value.degree, itm.Value.degree, itm.Value.minus_log_total_wr, nn + 1, nstar + 1);

                //itm.Value.fitness_iterator.Key
                //itm
                //fitness_lab[itm.Key].Remove(itm.Value.fitness_iterator.Key)
                //fitness_lab.erase(itm.Value.fitness_iterator);
                fitness_lab[itm.Key].Remove(itm.Value.fitness_iterator.Value[0]); //MCP 7-25-17 I Don't know if this is correct. It depends on sorting and stuff. And whether or not there are ever more than 1 Value for the Fitness Iterator Value.
                //itm.Value.fitness_iterator
                //fitness_lab
                //multimap<double, int>::iterator fiit = fitness_lab.insert(make_pair(fit, a));
                fitness_lab[fit].Add(a);
                List<int> fiitlist = new List<int>(a);
                KeyValuePair<double, List<int>> fiit = new KeyValuePair<double, List<int>>(fit, fiitlist);
                itm.Value.fitness_iterator = fiit; //itm originally from lab_facts. Thus, need to update lab_facts iterator...
                lab_facts[a].fitness_iterator = fiit; //mcp 7-25-17. Not 100% sure this is right. MAY NEED TO CHANGE THIS.
                return true;
            }

            //public bool update_neighs(int a, int delta_degree, double delta_mtlw, int nstar, int kout_g, int tm, int kt);
            public bool update_neighs(int a, int delta_degree, double delta_mtlw, int nstar, int kout_g, int tm, int kt)
            {
                // this function is to change the internal degree and mtlw of a certain node (to insert it or erase if necessary)

                //cout<<"UPdating... neighs "<<a<<" "<<kt<<endl;

                KeyValuePair<int, facts> itm = new KeyValuePair<int, facts>();

                //map<int, facts>::iterator itm = lab_facts.find(a);
                /* if (itm == lab_facts.end())
                 {
                     edinsert(a, 0, kt, 0, 1);
                     itm = lab_facts.find(a);
                 }*/
                if (!lab_facts.ContainsKey(a))
                {
                    edinsert(a, 0, kt, 0, 1);
                    itm = new KeyValuePair<int, facts>(a, lab_facts[a]);
                }


                itm.Value.internal_degree += delta_degree;
                //lab_facts[a].internal_degree += delta_degree;
                if (itm.Value.internal_degree == 0)
                {
                    //cout<<"erased from neigh update "<<a<<endl;
                    erase(a);
                    return true;
                }

                itm.Value.minus_log_total_wr += delta_mtlw;

                double fit = compute_global_fitness_ofive(itm.Value.internal_degree, kout_g, tm, itm.Value.degree, itm.Value.minus_log_total_wr, size(), nstar);

                //fitness_lab[itm.Key]
                //litm.Value.fitness_iterator
                //fitness_lab.erase(itm.Value.fitness_iterator);
                fitness_lab[itm.Key].Remove(itm.Value.fitness_iterator.Value[0]);//MCP 7-25-17 I'm not sure if this is right...
                List<int> fiitlist = new List<int>();
                fiitlist.Add(a);
                KeyValuePair<double, List<int>> fiit = new KeyValuePair<double, List<int>>(fit, fiitlist);
                //multimap<double, int>::iterator fiit = fitness_lab.insert(make_pair(fit, a));
                itm.Value.fitness_iterator = fiit;//MCP: I think this needs to update the Thing as well too, then...
                lab_facts[itm.Key].fitness_iterator = fiit; //So, this is part of the code I'm not entirely sure about.
                return true;
            }

            //public int best_node(int & lab, double & best_fitness, int kout_g, int Nstar, int nneighs, int tm);
            public int best_node(ref int lab, ref double best_fitness, int kout_g, int Nstar, int nneighs, int tm)
            {
                // I can try to compute the fitness here

                /*cout<<"NE BEST NODE "<<endl;

                cout<<"fitness_lab  "<<endl;
                prints(fitness_lab);*/
                lab = -1;
                best_fitness = 1;

                //multimap<double, int>:: iterator bit = fitness_lab.begin();
                //KeyValuePair<double, List<int>> bit = new KeyValuePair<double, List<int>>(fitness_lab.First().Key, fitness_lab.First().Value);
                //if (bit == fitness_lab.end())
                if (fitness_lab.Count() <= 1)
                {
                    return -1;
                }

                int stopper = 0;
                //while (bit != fitness_lab.end())
                foreach (KeyValuePair<double, List<int>> bit_outer in fitness_lab)
                    foreach (int bit_inner in bit_outer.Value)
                    {
                        //map<int, facts> :: iterator itm = lab_facts.find(bit.Value);
                        KeyValuePair<int, facts> itm = new KeyValuePair<int, facts>(bit_inner, lab_facts[bit_inner]);
                        double F = compute_global_fitness_randomized(itm.Value.internal_degree, kout_g, tm, itm.Value.degree, itm.Value.minus_log_total_wr, nneighs, Nstar);

                        //cout<<itm.Key<<" "<<F<<" ... node-fit"<<endl;


                        if (F < best_fitness)
                        {
                            best_fitness = F;
                            lab = itm.Key;
                        }
                        stopper++;
                        if (stopper == Globals.num_up_to)
                            break;

                        //bit++; //MCP foreach, so this makes no sense anymore.
                    }
                return 0;

            }

            //public int worst_node(int & lab, double & worst_fitness, int kout_g, int Nstar, int nneighs, int tm);
            public int worst_node(ref int lab, ref double worst_fitness, int kout_g, int Nstar, int nneighs, int tm)
            {
                //cout<<"worst_node fitness - lab - (cgroup)"<<endl;
                //prints(fitness_lab);

                lab = -1;
                worst_fitness = -1;


                //multimap<double, int>:: iterator bit = fitness_lab.end();
                KeyValuePair<double, List<int>> bit = fitness_lab.Last();

                if (fitness_lab.Count() <= 1)
                {
                    return -1;
                }
                List<double> fitness_lab_keys = new List<double>(); //I need to be able to march backwards through my fitness_lab thingy.
                foreach (KeyValuePair<double, List<int>> kvp in fitness_lab)
                {
                    fitness_lab_keys.Add(kvp.Key);
                }
                //if (bit == fitness_lab.begin())
                // return -1;


                int stopper = 0;
                //while (bit != fitness_lab.begin())
                double x = 0;
                for (int i = fitness_lab_keys.Count() - 1; i >= 0; i--)
                {
                    //x = fitness_lab_keys[i];
                    bit = new KeyValuePair<double, List<int>>(x, fitness_lab[x]);//work backwards.
                    //bit--;
                    //map<int, facts> :: iterator itm = lab_facts.find(bit.Value);
                    foreach (int bitInt in bit.Value)
                    {
                        //KeyValuePair<int, facts> itm = lab_facts[]
                        KeyValuePair<int, facts> itm = new KeyValuePair<int, facts>(bitInt, lab_facts[bitInt]);
                        double F = compute_global_fitness_randomized(itm.Value.internal_degree, kout_g + 2 * itm.Value.internal_degree - itm.Value.degree,
                                                                    tm + itm.Value.degree, itm.Value.degree, itm.Value.minus_log_total_wr, nneighs + 1, Nstar + 1);
                        if (F > worst_fitness)
                        {

                            worst_fitness = F;
                            lab = itm.Key;
                        }
                        stopper++;
                        if (stopper == Globals.num_up_to)
                            break;
                    }
                }
                return 0;
            }
            //public bool is_internal(int a);
            public bool is_internal(int a)
            {
                //map<int, facts>::iterator itm = lab_facts.find(a);

                //if (itm == lab_facts.end())
                if (!lab_facts.ContainsKey(a))
                    return false;
                return true;
            }
            public Dictionary<int, facts> lab_facts = new Dictionary<int, facts>();                  // maps the label into the facts
            public Dictionary<double, List<int>> fitness_lab = new Dictionary<double, List<int>>();          // maps the fitness into the label  (this can be optimized)
        }




    }

    //MCP 7-25-17 louvain_oslomnet.h
    public static class louvain_oslomnet
    {
        public class oslomnet_louvain : undirected_network.static_network
        {
            //public int collect_raw_groups_once(deque<deque<int>> & );
            public int collect_raw_groups_once(ref List<List<int>> P)
            {
                System.Console.WriteLine("8-28-17 test 6275");
                module_initializing(); //mcp 8-28-17 problem here. //8-28-17 fixed.
                System.Console.WriteLine("8-28-17 test 6277");
                int stopper = 0;
                int previous_nodes_changed = dim;
                int iteration = 0;
                while (true)
                {
                    nodes_changed = 0;
                    for (int i = 0; i < (int)(vertex_to_check.Count()); i++) {
                        System.Console.WriteLine("8-28-17 test 6285");
                        vertex_to_check_next[i] = false;
                        System.Console.WriteLine("8-28-17 test 6287");
                    }
                    Combinatorics.shuffle_s(ref vertex_order);
                    System.Console.WriteLine("8-28-17 test 6290");
                    if (Parameters.weighted){
                        System.Console.WriteLine("8-28-17 test 6292");
                        single_pass_weighted();
                        System.Console.WriteLine("8-28-17 test 6294");
                    }
                    else {
                        System.Console.WriteLine("8-28-17 test 6297");
                        single_pass_unweighted(); //mcp 8-28-17 problem here.
                        System.Console.WriteLine("8-28-17 test 6299");
                    }

                    if (Parameters.print_flag_subgraph && iteration % 20 == 0) { 
                        //cout << "iteration: " << iteration << " number of modules: " << label_module.size() << endl;
                        System.Console.WriteLine("Iteration: {0}. Number of Modules: {1}.", iteration, label_module.Count());
                    }

                    ++iteration;

                    /* this conditions means that at least max_iteration_convergence iterations are done and, after that, the number of nodes changed has to decrease (up to a facto 1e-3) */
                    if ((double)(nodes_changed - previous_nodes_changed) > 1e-3 * previous_nodes_changed && iteration > Parameters.max_iteration_convergence)
                        stopper++;

                    if (stopper == Parameters.max_iteration_convergence || nodes_changed == 0 || iteration == dim)
                        break;

                    vertex_to_check = vertex_to_check_next;
                    previous_nodes_changed = nodes_changed;
                }
                set_partition_collected(ref P);

                if (Parameters.print_flag_subgraph)
                    //cout << "collection done " << endl << endl << endl;
                    System.Console.WriteLine("Collection done.\n\n");
                label_module = new Dictionary<int, oslom_module>();//.clear();
                vertex_label = new List<int>();//.clear();
                vertex_order = new List<int>();//.clear();
                vertex_to_check = new List<bool>();//.clear();
                vertex_to_check_next = new List<bool>();// .clear();
                nodes_changed = 0;
                return 0;
            }
            //private 
            //private void weighted_favorite_of(const int & node, int & fi, int & kp, int & kop);
            private void weighted_favorite_of(/*const*/ int node, ref int fi, ref int kp, ref int kop)
            {
                double min_fitness = 10;
                fi = vertex_label[node];
                kp = 0;
                kop = 0;

                //typedef map< int, pair < int, double> > mapip;
                Dictionary<int, KeyValuePair<int, double>> M = new Dictionary<int, KeyValuePair<int, double>>();
                //mapip M;        // M is a map module_label -> kin - win (internal stubs, internal weight)

                for (int j = 0; j < vertices[node].links.size(); j++)
                {
                    List<int> toSendCopy = vertex_label;
                    Histograms.int_histogram(vertex_label[vertices[node].links.l[j]], ref M, vertices[node].links.w[j].Key, vertices[node].links.w[j].Value);
                }

                //for (mapip::iterator itM = M.begin(); itM != M.end(); itM++)
                foreach (KeyValuePair<int, KeyValuePair<int, double>> itM in M)
                {
                    //map_int_om::iterator itOM = label_module.find(itM.first);
                    KeyValuePair<int, oslom_module> itOM = label_module.ElementAt(itM.Key);

                    double to_fit;

                    if (itM.Key != vertex_label[node])
                    {
                        to_fit = ClasslessMethods.topological_05(itM.Value.Key, itOM.Value.kout, oneM - itOM.Value.ktot, vertices[node].stub_number);
                        to_fit *= (double)(dim - itOM.Value.nc + 1) / (Math.Min(dim - itOM.Value.nc, itOM.Value.kout / itM.Value.Key + 1) + 1);

                        if (to_fit > 1)
                            to_fit = 1;
                    }
                    else
                    {

                        kop = itM.Value.Key;
                        int kout_prime = itOM.Value.kout - vertices[node].stub_number + 2 * kop;
                        to_fit = ClasslessMethods.topological_05(itM.Value.Key, kout_prime, oneM - itOM.Value.ktot + vertices[node].stub_number, vertices[node].stub_number);
                        to_fit *= (double)(dim - itOM.Value.nc + 2) / (Math.Min(dim - itOM.Value.nc + 1, kout_prime / kop + 1) + 1);


                        if (to_fit > 1)
                            to_fit = 1;
                        to_fit *= 0.999;        // to break possible ties 

                    }
                    double weight_fit = undir_weighted_tabdeg.log_together(itM.Value.Value, itM.Value.Key);
                    double fitness = undir_weighted_tabdeg.log_together(-Math.Log(to_fit) - Math.Log(weight_fit), 2);




                    if (fitness < min_fitness)
                    {

                        kp = itM.Value.Key;
                        min_fitness = fitness;
                        fi = itM.Key;
                    }

                }
            }

            //private void unweighted_favorite_of(const int & node, int & fi, int & kp, int & kop);
            private void unweighted_favorite_of(int node, ref int fi, ref int kp, ref int kop)
            {
                System.Console.WriteLine("8-28-17 test 6401");
                double min_fitness = 10;
                fi = vertex_label[node];
                System.Console.WriteLine("8-28-17 test 6404");
                kp = 0;
                kop = 0;
                Dictionary<int, int> M = new Dictionary<int, int>();        // M is a map module_label -> kin (internal stubs)
                for (int j = 0; j < vertices[node].links.size(); j++) {
                    System.Console.WriteLine("8-28-17 test 6409");
                    Histograms.int_histogram(vertex_label[vertices[node].links.l[j]], ref M, vertices[node].links.w[j].Key);
                }
                System.Console.WriteLine("8-28-17 test 6412");
                //for (map<int, int>:: iterator itM = M.begin(); itM != M.end(); itM++)
                foreach (KeyValuePair<int, int> itM in M)
                {
                    System.Console.WriteLine("8-28-17 test 6416");
                    //map_int_om::iterator itOM = label_module.find(itM.first);
                    KeyValuePair<int, oslom_module> itOM = label_module.ElementAt(itM.Key);
                    System.Console.WriteLine("8-28-17 test 6419");
                    double to_fit;

                    if (itM.Key != vertex_label[node])
                    {
                        System.Console.WriteLine("8-28-17 test 6424");
                        to_fit = ClasslessMethods.topological_05(itM.Value, itOM.Value.kout, oneM - itOM.Value.ktot, vertices[node].stub_number);
                        System.Console.WriteLine("8-28-17 test 6426");
                    }
                    else
                    {
                        System.Console.WriteLine("8-28-17 test 6430");
                        kop = itM.Value;
                        System.Console.WriteLine("8-28-17 test 6432");
                        int kout_prime = itOM.Value.kout - vertices[node].stub_number + 2 * kop;
                        System.Console.WriteLine("8-28-17 test 6434");
                        to_fit = ClasslessMethods.topological_05(itM.Value, kout_prime, oneM - itOM.Value.ktot + vertices[node].stub_number, vertices[node].stub_number); //mcp 8-28-17 problem here.
                        System.Console.WriteLine("8-28-17 test 6436");
                        to_fit *= 0.999;        // to break possible ties 
                        System.Console.WriteLine("8-28-17 test 6438");
                    }

                    if (to_fit < min_fitness)
                    {
                        System.Console.WriteLine("8-28-17 test 6440");
                        kp = itM.Value;
                        min_fitness = to_fit;
                        fi = itM.Key;
                        System.Console.WriteLine("8-28-17 test 6444");
                    }
                }
            }
            //private void single_pass_unweighted();
            private void single_pass_unweighted()
            {
                System.Console.WriteLine("8-28-17 test 6443");
                int fi = new int();
                int kp = new int();
                int kop = new int();    // fi is the label node i likes most, kp is the number od internal stubs in module fi, kop is the same for vertex_label[i]  

                //for (deque<int> :: iterator itd = vertex_order.begin(); itd != vertex_order.end(); itd++)
                foreach (int itd in vertex_order)
                {
                    System.Console.WriteLine("8-28-17 test 6451");
                    if (vertex_to_check[itd] == true)
                    {
                        System.Console.WriteLine("8-28-17 test 6454");
                        unweighted_favorite_of(itd, ref fi, ref kp, ref kop); //mcp 8-28-17 problem here.
                        System.Console.WriteLine("8-28-17 test 6456");
                        update_modules(itd, fi, kp, kop);
                        System.Console.WriteLine("8-28-17 test 6458");
                    }
                }
            }

            //private void single_pass_weighted();
            private void single_pass_weighted()
            {

                int fi = new int();
                int kp = new int();
                int kop = new int();    // fi is the label node i likes most, kp is the number od internal stubs in module fi, kop is the same for vertex_label[i] 
                //for (deque<int> :: iterator itd = vertex_order.begin(); itd != vertex_order.end(); itd++)
                foreach (int itd in vertex_order)
                {
                    if (vertex_to_check[itd] == true)
                    {
                        weighted_favorite_of(itd, ref fi, ref kp, ref kop);
                        update_modules(itd, fi, kp, kop);
                    }
                }
            }

            //private void update_modules(const int & i, const int & fi, const int & kp, const int & kpo);
            public void update_modules(/*const &*/ int i, /*const &*/int fi, /*const &*/int kp, /*const &*/int kop)
            {
                if (fi != vertex_label[i])
                {
                    nodes_changed++;
                    for (int j = 0; j < vertices[i].links.size(); j++)
                        vertex_to_check_next[vertices[i].links.l[j]] = true;
                    //map_int_om::iterator itm = label_module.find(vertex_label[i]);
                    KeyValuePair<int, oslom_module> itm = label_module.ElementAt(vertex_label[i]);
                    --(itm.Value.nc);
                    if (itm.Value.nc == 0)
                    {
                        label_module.Remove(i); //this should work. It's the Key we used to SET itm, so...
                    }
                    else
                    {
                        itm.Value.kout -= vertices[i].stub_number - 2 * kop;
                        itm.Value.ktot -= vertices[i].stub_number;
                    }

                    itm = label_module.ElementAt(fi);
                    ++(itm.Value.nc);
                    itm.Value.kout += vertices[i].stub_number - 2 * kp;
                    itm.Value.ktot += vertices[i].stub_number;
                    vertex_label[i] = fi;
                }
            }
            //private void module_initializing();
            private void module_initializing()
            {
                System.Console.WriteLine("8-28-17 test 6498");
                for (int i = 0; i < dim; i++)
                {
                    System.Console.WriteLine("8-28-17 test 6501");
                    vertex_label.Add(i); //mcp 8-28-17 problem here.
                    System.Console.WriteLine("8-28-17 test 6503");
                    vertex_order.Add(i);
                    System.Console.WriteLine("8-28-17 test 6504");
                    vertex_to_check.Add(true);
                    System.Console.WriteLine("8-28-17 test 6506");
                    vertex_to_check_next.Add(false);
                    System.Console.WriteLine("8-28-17 test 6508");
                    oslom_module newm = new oslom_module(vertices[i].stub_number);
                    System.Console.WriteLine("8-28-17 test 6510");
                    label_module.Add(i, newm);
                    System.Console.WriteLine("8-28-17 test 6512");
                }
            }

            //private void set_partition_collected(deque<deque<int>> & M);
            private void set_partition_collected(ref List<List<int>> ten2)
            {
                ten2.Clear();
                List<List<int>> M = new List<List<int>>();


                // take partition from vertex_label  //******************************
                Dictionary<int, int> mems = new Dictionary<int, int>();
                bool added = false;
                for (int i = 0; i < dim; i++)
                {
                    //   pair<map<int, int>::iterator, bool> itm_bool = mems.insert(make_pair(vertex_label[i], mems.size()));
                    if (!mems.ContainsKey(vertex_label[i]))
                    {
                        mems.Add(vertex_label[i], mems.Count());
                        added = true;
                    }
                    else
                    {
                        added = false;
                    }
                    KeyValuePair<KeyValuePair<int, int>, bool> itm_bool = new KeyValuePair<KeyValuePair<int, int>, bool>(mems.ElementAt(vertex_label[i]), added);

                    if (itm_bool.Value == true)
                    {
                        //deque<int> first;
                        List<int> first = new List<int>();
                        //M.push_back(first);
                        M.Add(first);
                    }
                    //M[itm_bool.Key.Value].push_back(i);
                    M[itm_bool.Key.Value].Add(i);
                }
                // check if subgraphs are connected  //******************************
                for (int i = 0; i < (int)(M.Count()); i++)
                {

                    List<List<int>> link_per_node = new List<List<int>>();
                    List<List<KeyValuePair<int, double>>> weights_per_node = new List<List<KeyValuePair<int, double>>>();
                    List<int> MtoSend = M[i];
                    set_subgraph(ref MtoSend, ref link_per_node, ref weights_per_node);
                    M[i] = MtoSend; //should be sending M[i] by ref.
                    undirected_network.static_network giovanni = new undirected_network.static_network();
                    MtoSend = M[i];
                    giovanni.set_graph(ref link_per_node, ref weights_per_node, ref MtoSend);
                    M[i] = MtoSend; //should be sending M[i] by ref.
                    List<List<int>> gM = new List<List<int>>();
                    giovanni.set_connected_components(ref gM);
                    if (gM.Count() == 1)
                        ten2.Add(M[i]);
                    else
                    {
                        for (int j = 0; j < (int)(gM.Count()); j++)
                        {
                            List<int> gMtoSend = gM[j];
                            //giovanni.deque_id(gM[j]);
                            giovanni.deque_id(ref gMtoSend);
                            gM[i] = gMtoSend;
                            ten2.Add(gM[j]);
                        }
                    }
                }
            }

            private Dictionary<int, oslom_module> label_module = new Dictionary<int,oslom_module>();
            private List<int> vertex_label = new List<int>();
            private List<int> vertex_order = new List<int>();
            private List<bool> vertex_to_check = new List<bool>();
            private List<bool> vertex_to_check_next = new List<bool>();
            private int nodes_changed = new int();
        }
    }


    public class module_collection
    {

        /* all the labels refers to the index in int_matrix modules */


        public module_collection(int dim)
        {
            _set_(dim);
        }
        public void _set_(int dim)
        {
            HashSet<int> first = new HashSet<int>();
            for (int i = 0; i < dim; i++)
                memberships.Add(first);
        }

        public int size() { return module_bs.Count(); }

        //public bool insert(deque<int> & c, double bs, int & new_name);
        //public bool insert(deque<int> & c, double bs);
        public bool insert(ref List<int> c, double bs)
        {
            int new_name = new int();
            return insert(ref c, bs, ref new_name);

        }
        public bool insert(ref List<int> c, double bs, ref int new_name)
        {
            if (bs == 0)
                bs = MyRandom.ran4() * 1e-100;

            c.Sort();
            //sort(c.begin(), c.end());
            new_name = -1;

            if (check_already(c) == true)
            {

                new_name = modules.Count();
                for (int i = 0; i < (int)(c.Count()); i++)
                    memberships[c[i]].Add(new_name);


                modules.Add(c);
                module_bs[new_name] = bs;


                return true;

            }

            return false;

        }


        //public bool erase(int);
        public bool contains(Dictionary<int, double> dict, double a)
        {
            foreach (KeyValuePair<int, double> itr in dict)
            {
                if (itr.Value == a)
                {
                    return true;
                }
            }
            return false;
        }
        public bool erase(int a)
        {
            // it erases module a 
            if (!contains(module_bs, (double)(a)))
                //if (module_bs.Contains((double)a) == module_bs.end())       // it only erases not empty modules
                return false;
            List<int> nodes_a = modules[a];

            for (int i = 0; i < (int)(nodes_a.Count()); i++)
                memberships[nodes_a[i]].Remove(a);

            modules[a] = new List<int>();
            module_bs.Remove(a);
            return true;
        }



        //public void print(ostream & outt, deque<int> & netlabels, bool);

        public void print(ref System.IO.StreamWriter outt, ref List<int> netlabels, bool not_homeless)
        {
            int nmod = 0;
         //   for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
         foreach(KeyValuePair<int,double> itm in module_bs)
                if (not_homeless == false || modules[itm.Key].Count() > 1)
                {
                    nmod++;
                    //deque < int > &module_nodes = modules[itm->first];
                    List<int> module_nodes = modules[itm.Key];
                    outt.WriteLine("#module {0} size: {1} bs: {2}", itm.Key,modules[itm.Key].Count(),module_bs[itm.Key]);

                    List<int> labseq = new List<int>();
                    for (int i = 0; i < (int)(module_nodes.Count()); i++)
                    {
                        labseq.Add(netlabels[module_nodes[i]]);
                    }

                    //sort(labseq.begin(), labseq.end());
                    labseq.Sort();

                    for (int i = 0; i < (int)(labseq.Count()); i++)
                    {
                        outt.Write("{0} ",labseq[i]);
                    }
                    outt.WriteLine("");
                }
        }
        //public void fill_gaps();
        public void fill_gaps()
        {

            for (int i = 0; i < (int)(memberships.Count()); i++)
                if (memberships[i].Count() == 0)
                {
                    List<int> new_d = new List<int>();
                    new_d.Add(i);
                    insert(ref new_d, 1.0);
                }
        }
        public void put_gaps()
        {
            List<int> to_erase = new List<int>();

            for (int i = 0; i < (int)(modules.Count()); i++)
            {
                if (modules[i].Count() == 1)
                    to_erase.Add(i);
            }
            for (int i = 0; i < (int)(to_erase.Count()); i++)
                erase(to_erase[i]);

        }

        //public void put_gaps();
        //public void homeless(deque<int> & h);
        public void homeless(ref List<int> h)
        {

            h = new List<int>();

            for (int i = 0; i < (int)(memberships.Count()); i++)
                if (memberships[i].Count() < 1)
                    h.Add(i);

            for (int i = 0; i < (int)(modules.Count()); i++)
            {

                if (modules[i].Count() == 1)
                    h.Add(modules[i][0]);

            }
            h.Sort();
        }

        //public int coverage();

        public int coverage()
        {
            // this function returns the number of nodes which are covered by at least one module
            int cov = 0;
            for (int i = 0; i < (int)(memberships.Count()); i++)
                if (memberships[i].Count() > 0)
                    cov++;

            return cov;
        }


        //public int effective_groups();
        public int effective_groups()
        {
            int nmod = 0;
            //for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            foreach (KeyValuePair<int, double> itm in module_bs)
                if (modules[itm.Key].Count() > 1)
                    nmod++;
            return nmod;
        }
        //public void set_partition(deque<deque<int>> & A);
        //public void set_partition(deque<deque<int>> & A, deque<double> & b);
        public void set_partition(ref List<List<int>> A)
        {

            A = new List<List<int>>();

            //for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            foreach (KeyValuePair<int, double> itm in module_bs)
                if (modules[itm.Key].Count() > 1)
                    A.Add(modules[itm.Key]);
        }
        public void set_partition(ref List<List<int>> A, ref List<double> b)
        {


            A = new List<List<int>>();
            b = new List<double>();

            //for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            foreach (KeyValuePair<int, double> itm in module_bs)
                if (modules[itm.Key].Count() > 1)
                {
                    A.Add(modules[itm.Key]);
                    b.Add(module_bs[itm.Key]);
                }
        }


        //public void compute_inclusions();
        public void compute_inclusions()
        {

            put_gaps();
            erase_included();
            compact();

        }

        //public void erase_included();
        public void erase_included()
        {
            Dictionary<int, List<int>> erase_net = new Dictionary<int, List<int>>();
            //for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            foreach (KeyValuePair<int, double> itm in module_bs)
            {
                List<int> smaller = new List<int>();
                almost_equal(itm.Key, ref smaller);
                erase_net[itm.Key] = smaller;
            }
            while (true)
            {
                if (erase_first_shell(ref erase_net) == false)
                    break;
            }
        }


        //public bool almost_equal(int module_id, deque<int> & smaller);

        public bool almost_equal(int module_id, ref List<int> smaller)
        {

            // c is the module you want to know about
            // smaller is set to contain the module ids contained by module_id

            smaller = new List<int>();

            List<int> c = modules[module_id];

            Dictionary<int, int> com_ol = new Dictionary<int, int>();       // it maps the index of the modules into the overlap (overlap=numeber of overlapping nodes)

            for (int i = 0; i < (int)(c.Count()); i++)
            {
                //for (set<int>:: iterator itj = memberships[c[i]].begin(); itj != memberships[c[i]].end(); itj++)
                foreach (int itj in memberships[c[i]])
                    Histograms.int_histogram(itj, ref com_ol);
            }
            //for (map<int, int>::iterator itm = com_ol.begin(); itm != com_ol.end(); itm++)
            foreach (KeyValuePair<int, int> itm in com_ol)
                if (itm.Key != module_id && modules[itm.Key].Count() <= c.Count())
                {
                    int other_size = modules[itm.Key].Count(); //changed from const UI.
                    if ((double)(itm.Value) / other_size >= Parameters.coverage_inclusion_module_collection)
                    {
                        if (c.Count() > other_size)
                            smaller.Add(itm.Key);
                        else if (c.Count() == other_size && module_bs[module_id] < module_bs[itm.Key])
                            smaller.Add(itm.Key);
                    }
                }
            return true;
        }



        //public void compact();

        public void compact()
        {


            /* this function is used to have continuos ids */

            put_gaps();


            Dictionary<int, int> from_old_index_to_new = new Dictionary<int, int>();


            {

                List<List<int>> modules2 = new List<List<int>>();
                Dictionary<int, double> module_bs2 = new Dictionary<int, double>();


                //for (map<int, double> :: iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
                foreach (KeyValuePair<int, double> itm in module_bs)
                {
                    from_old_index_to_new.Add(itm.Key, from_old_index_to_new.Count());
                    modules2.Add(modules[itm.Key]);
                    module_bs2[from_old_index_to_new.Count() - 1] = itm.Value;
                }
                modules = modules2;
                module_bs = module_bs2;
            }
            for (int i = 0; i < memberships.Count(); i++)
            {
                HashSet<int> first = new HashSet<int>();
                //for (set<int>:: iterator its = memberships[i].begin(); its != memberships[i].end(); its++)
                foreach (int its in memberships[i])
                    first.Add(from_old_index_to_new[its]);

                memberships[i] = first;
            }
        }

        //public void sort_modules(DI &);
        public void sort_modules(ref List<int> module_order)
        {
            module_order = new List<int>();
            //multimap<double, int> rank_id ;      /* modules are sorted from the biggest to the smallest. if they have equal size, we look at the score */
            Dictionary<double, List<int>> rank_id = new Dictionary<double, List<int>>();

            //for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            foreach (KeyValuePair<int, double> itm in module_bs)
            {

                //cout<<modules[itm.Key].size()<<" ... "<<endl;
                //rank_id.insert(make_pair(-double(modules[itm.Key].size()) + 1e-2 * itm.Value, itm.Key));
                double ky = -(double)(modules[itm.Key].Count() + 1e02 * itm.Value);
                if (rank_id.ContainsKey(ky))
                {
                    List<int> l1 = new List<int>();
                    l1.Add(itm.Key);
                    rank_id.Add(ky, l1);
                }
                else
                {
                    rank_id[ky].Add(itm.Key);
                    rank_id[ky].Sort();
                }

            }
            //cout<<"rank_id"<<endl;
            //prints(rank_id);
            //for (multimap<double, int>::iterator itm = rank_id.begin(); itm != rank_id.end(); itm++)
            foreach (KeyValuePair<double, List<int>> itm in rank_id)
                foreach (int i2 in itm.Value)
                    module_order.Add(i2);

        }


        //public void merge(DI & c);
        public void merge(ref List<int> c)
        {

            List<int> to_merge = new List<int>();
            egomodules_to_merge(ref c, ref to_merge);

            //cout<<"module c: "<<endl;
            //prints(c);

            if (to_merge.Count() == 0)
                insert(ref c, 1.0);
            else
            {
                for (int i = 0; i < to_merge.Count(); i++)
                {
                    //cout<<"to_merge"<<endl;
                    //prints(modules[to_merge[i]]);
                    HashSet<int> si = new HashSet<int>();
                    //deque_to_set_app(modules[to_merge[i]], si);
                    foreach (int schlock in modules[to_merge[i]])
                    {
                        si.Add(schlock);
                    }
                    //deque_to_set_app(c, si);
                    foreach (int schlock in c)
                    {
                        si.Add(schlock);
                    }
                    erase(to_merge[i]);

                    //prints(si);


                    List<int> to_insert = new List<int>();
                    //set_to_deque(si, to_insert);
                    to_insert = si.ToList<int>();
                    insert(ref to_insert, 1.0);
                }
            }
            erase_included();
        }




        /*************************** DATA ***************************/


        public List<HashSet<int>> memberships = new List<HashSet<int>>();
        public List<List<int>> modules = new List<List<int>>();
        public Dictionary<int, double> module_bs = new Dictionary<int, double>();                     /* it maps the module id into the b-score */

        /***********************************************************/

        //private void _set_(int dim);
        //private bool check_already(const deque<int> & c);
        private bool check_already(List<int> c)
        {

            // returns false if the module is already present
            Dictionary<int, int> com_ol = new Dictionary<int, int>();       // it maps the index of the modules into the overlap (overlap=numeber of overlapping nodes)

            for (int i = 0; i < (int)(c.Count()); i++)
            {
                //for (set<int>:: iterator itj = memberships[c[i]].begin(); itj != memberships[c[i]].end(); itj++)
                foreach (int itj in memberships[c[i]])
                    Histograms.int_histogram(itj, ref com_ol);
            }
            //for (map<int, int>::iterator itm = com_ol.begin(); itm != com_ol.end(); itm++)
            foreach (KeyValuePair<int, int> itm in com_ol)
            {
                if (itm.Value == (int)(c.Count()) && itm.Value == (int)(modules[itm.Key].Count()))
                    return false;
            }
            return true;
        }

        //private bool erase_first_shell(map<int, deque<int>> & erase_net);

        private bool erase_first_shell(ref Dictionary<int, List<int>> erase_net)
        {
            bool again = false;
            HashSet<int> roots = new HashSet<int>();

            //for (Dictionary<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            foreach (KeyValuePair<int, double> itm in module_bs)
                roots.Add(itm.Key);
            //for (map<int, deque<int>>::iterator itm = erase_net.begin(); itm != erase_net.end(); itm++)
            foreach (KeyValuePair<int, List<int>> itm in erase_net)
            {
                List<int> smaller = itm.Value;

                for (int i = 0; i < (int)(smaller.Count()); i++)
                    roots.Remove(smaller[i]);
            }
            //cout<<"roots:"<<endl;
            //prints(roots);
            //for (set<int>::iterator its = roots.begin(); its != roots.end(); its++)
            foreach (int its in roots)
            {
                List<int> smaller = erase_net[its];
                for (int i = 0; i < (int)(smaller.Count()); i++)
                {
                    if (contains(module_bs, (double)smaller[i])) //if (module_bs.find(smaller[i]) != module_bs.end())
                    {
                        erase(smaller[i]);
                        erase_net.Remove(smaller[i]);
                        again = true;
                    }
                }
            }
            return again;
        }
        //private bool egomodules_to_merge(deque<int> & egom, deque<int> & smaller);
        private bool egomodules_to_merge(ref List<int> egom, ref List<int> smaller)
        {

            // egom is the module you want to know about
            // smaller is set to contain the module ids to merge with egom

            //smaller.clear();
            smaller = new List<int>();


            Dictionary<int, int> com_ol = new Dictionary<int, int>();       // it maps the index of the modules into the overlap (overlap=numeber of overlapping nodes)

            for (int i = 0; i < (int)(egom.Count()); i++)
            {

                //for (set<int>:: iterator itj = memberships[egom[i]].begin(); itj != memberships[egom[i]].end(); itj++)
                foreach (int itj in memberships[egom[i]])
                    Histograms.int_histogram(itj, ref com_ol);
            }
            //cout<<"egomodules_to_merge"<<endl;
            //prints(egom);

            //for (map<int, int>::iterator itm = com_ol.begin(); itm != com_ol.end(); itm++)
            foreach (KeyValuePair<int, int> itm in com_ol)
            {
                //cout<<" other group "<<itm.Value<<endl;
                //prints(modules[itm.Key]);

                int other_size = Math.Min(modules[itm.Key].Count(), egom.Count());
                if ((double)(itm.Value) / other_size >= Parameters.coverage_inclusion_module_collection)
                    smaller.Add(itm.Key);
            }
            return true;
        }
    }

    /*void module_collection::print(ostream & outt, deque<int> & netlabels, bool not_homeless)
    {




        int nmod = 0;
        for (map<int, double>::iterator itm = module_bs.begin(); itm != module_bs.end(); itm++)
            if (not_homeless == false || modules[itm.Key].size() > 1)
            {


                nmod++;


                deque < int > &module_nodes = modules[itm.Key];
                outt << "#module " << itm.Key << " size: " << modules[itm.Key].size() << " bs: " << module_bs[itm.Key] << endl;

                deque<int> labseq;
                for (int i = 0; i < int(module_nodes.size()); i++)
                {
                    labseq.push_back(netlabels[module_nodes[i]]);
                }

                sort(labseq.begin(), labseq.end());

                for (int i = 0; i < int(labseq.size()); i++)
                {
                    outt << labseq[i] << " ";
                }
                outt << endl;
            }
    }
    */

    //MCP 8-1-17 undirected_oslomnet_evaluate.h
    public static class undirected_oslomnet_evaluate
    {
        public static double log_zero(double a)
        {
            if (a <= 0)
                return -1e20;
            else
                return Math.Log(a);
        }

        public class oslomnet_evaluate : louvain_oslomnet.oslomnet_louvain
        {
            //public 
            public oslomnet_evaluate(ref List<List<int>> b, ref List<List<KeyValuePair<int, double>>> c, ref List<int> d)
            {
                set_graph(ref b, ref c, ref d);
                set_maxbord();
                set_changendi_cum();
            }
            public oslomnet_evaluate(string a){
                set_graph(a);
                set_maxbord();
                set_changendi_cum();
            } //MCP WORK ON STRINGS AND STUFFS.

            public oslomnet_evaluate(ref Dictionary<int, Dictionary<int, KeyValuePair<int, double>>> A)
            {
                set_graph(ref A);
                set_maxbord();
                set_changendi_cum();
            }

            //public double CUP_both(const deque<int> & _c_, deque<int> & gr_cleaned, int);
            public double CUP_both(/*const ref */LinkedList<int> _c_, ref LinkedList<int> gr_cleaned, int number_of_runs /*= paras.clean_up_runs*/)
            {
                int x = 0;
                if (number_of_runs.GetType() != x.GetType())
                {
                    number_of_runs = Parameters.clean_up_runs;
                }
                //cout << "CUP both function" << endl;

                /*_c_ is the module to clean up and gr_cleaned is the result */


                undir_weighted_tabdeg.weighted_tabdeg previous_tab_c = new undir_weighted_tabdeg.weighted_tabdeg();
                undir_weighted_tabdeg.weighted_tabdeg previous_tab_n = new undir_weighted_tabdeg.weighted_tabdeg();
                int kin_cgroup_prev = new int();
                int ktot_cgroup_prev = new int();
                double bscore = new double();
                //cout << "eval" << endl;
                initialize_for_evaluation(_c_.ToList<int>(), ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);
                //cout << "CUP runs" << endl;
                List<int> gr_cleaned_to_send = gr_cleaned.ToList<int>();
                bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, false, number_of_runs);
                gr_cleaned = new LinkedList<int>();
                foreach (int i in gr_cleaned_to_send)
                {
                    gr_cleaned.AddLast(i);
                }
                //cout << "End cup runs, -> initialize for eval" << endl;
                initialize_for_evaluation(gr_cleaned_to_send, ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);

                //cout << "End initialize for eval, -> CUP runs" << endl;
                bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, true, number_of_runs);     /*this "true" means I can only look at nodes in previous_tab_c*/
                foreach (int i in gr_cleaned_to_send)
                {
                    gr_cleaned.AddLast(i);
                }
                return bscore;
            }

            public double CUP_both(/*const ref */List<int> _c_, ref List<int> gr_cleaned, int number_of_runs /*= paras.clean_up_runs*/)
            {
                int x = 0;
                if (number_of_runs.GetType() != x.GetType())
                {
                    number_of_runs = Parameters.clean_up_runs;
                }
                //cout << "CUP both function" << endl;

                /*_c_ is the module to clean up and gr_cleaned is the result */


                undir_weighted_tabdeg.weighted_tabdeg previous_tab_c = new undir_weighted_tabdeg.weighted_tabdeg();
                undir_weighted_tabdeg.weighted_tabdeg previous_tab_n = new undir_weighted_tabdeg.weighted_tabdeg();
                int kin_cgroup_prev = new int();
                int ktot_cgroup_prev = new int();
                double bscore = new double();
                //cout << "eval" << endl;
                initialize_for_evaluation(_c_.ToList<int>(), ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);
                //cout << "CUP runs" << endl;
                List<int> gr_cleaned_to_send = gr_cleaned.ToList<int>();
                bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, false, number_of_runs);
                gr_cleaned = new List<int>();
                foreach (int i in gr_cleaned_to_send)
                {
                    gr_cleaned.Add(i);
                }
                //cout << "End cup runs, -> initialize for eval" << endl;
                initialize_for_evaluation(gr_cleaned_to_send, ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);

                //cout << "End initialize for eval, -> CUP runs" << endl;
                bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, true, number_of_runs);     /*this "true" means I can only look at nodes in previous_tab_c*/
                foreach (int i in gr_cleaned_to_send)
                {
                    gr_cleaned.Add(i);
                }
                return bscore;
            }


            //public double CUP_check(const deque<int> & _c_, deque<int> & gr_cleaned, int);
            public double CUP_check(/*const ref */ LinkedList<int> _c_, ref LinkedList<int> gr_cleaned, int number_of_runs /*= Parameters.clean_up_runs*/)
            {
                int x = 0;
                if (number_of_runs.GetType() != x.GetType())
                {
                    number_of_runs = Parameters.clean_up_runs;
                }

                /*_c_ is the module to clean up and gr_cleaned is the result */


                undir_weighted_tabdeg.weighted_tabdeg previous_tab_c = new undir_weighted_tabdeg.weighted_tabdeg();
                undir_weighted_tabdeg.weighted_tabdeg previous_tab_n = new undir_weighted_tabdeg.weighted_tabdeg();
                int kin_cgroup_prev = new int();
                int ktot_cgroup_prev = new int();
                double bscore = new double();

                List<int> gr_cleaned_to_send = gr_cleaned.ToList<int>();
                initialize_for_evaluation(_c_.ToList<int>(), ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);
                bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, true, number_of_runs);
                //gr_cleaned = gr_cleaned_to_send;
                gr_cleaned = new LinkedList<int>();
                foreach (int i in gr_cleaned_to_send)
                {
                    gr_cleaned.AddLast(gr_cleaned_to_send[i]); //should convert list to linkedList.
                }
                //cout << "Going to return bscore from CUP_check" << endl;
                //system("PAUSE");
                return bscore;
            }

            public double CUP_check(/*const ref */ List<int> _c_, ref List<int> gr_cleaned, int number_of_runs /*= Parameters.clean_up_runs*/)
            {
                LinkedList<int> a1 = new LinkedList<int>();
                foreach (int i in _c_)
                {
                    a1.AddLast(i);
                }
                LinkedList<int> gr_cleaned_LL = new LinkedList<int>();
                foreach (int i in gr_cleaned)
                {
                    gr_cleaned_LL.AddLast(i);
                }
                return CUP_check(a1, ref gr_cleaned_LL, number_of_runs);
            }

            public double CUP_check(/*const ref */ List<int> _c_, ref LinkedList<int> gr_cleaned, int number_of_runs /*= Parameters.clean_up_runs*/)
            {
                LinkedList<int> a1 = new LinkedList<int>();
                foreach (int i in _c_)
                {
                    a1.AddLast(i);
                }
                return CUP_check(a1, ref gr_cleaned, number_of_runs);
            }

            //public double group_inflation(const deque<int> & _c_, deque<int> & gr_cleaned, int);
            public double group_inflation(/*const ref */LinkedList<int> _c_, ref LinkedList<int> gr_cleaned, int number_of_runs /*= paras.inflate_runs*/)
            {
                int x = 0;
                if (x.GetType() != number_of_runs.GetType())
                {
                    number_of_runs = Parameters.inflate_runs;
                }


                /* preliminary check */
                double bscore = CUP_iterative(_c_, ref gr_cleaned, number_of_runs);

                if (gr_cleaned.Count() > 0)
                {
                    return bscore;
                }
                /* preliminary check */

                //cout<<"group inflating... "<<endl;
                undir_weighted_tabdeg.weighted_tabdeg _c_tab_c = new undir_weighted_tabdeg.weighted_tabdeg();
                undir_weighted_tabdeg.weighted_tabdeg _c_tab_n = new undir_weighted_tabdeg.weighted_tabdeg();
                int kin_cgroup_c = new int();
                int ktot_cgroup_c = new int();

                initialize_for_evaluation(_c_.ToList<int>(), ref _c_tab_c, ref _c_tab_n, ref kin_cgroup_c, ref ktot_cgroup_c);


                undir_weighted_tabdeg.weighted_tabdeg previous_tab_c = new undir_weighted_tabdeg.weighted_tabdeg();
                undir_weighted_tabdeg.weighted_tabdeg previous_tab_n = new undir_weighted_tabdeg.weighted_tabdeg();
                int kin_cgroup_prev = new int();
                int ktot_cgroup_prev = new int();

                int stopper = 0;
                while (true)
                {
                    cgroup._set_(ref _c_tab_c);
                    neighs._set_(ref _c_tab_n);
                    kin_cgroup = kin_cgroup_c;
                    ktot_cgroup = ktot_cgroup_c;
                    //int changendi = lower_bound(changendi_cum.begin(), changendi_cum.end(), ran4()) - changendi_cum.begin() + 1; //mcp this whole thing returns the index of the first thing greater than the value...?
                    int changendi = new int();
                    double val_to_beat = MyRandom.ran4();
                    int indexer = 0;
                    foreach (int i in changendi_cum)
                    {
                        if (i >= val_to_beat)
                        {
                            break;
                        }
                        else
                        {
                            indexer++;
                        }
                    }
                    changendi = indexer + 1; // remove a 0 index. Useful for confirming not OutOfBounds.
                    changendi = Math.Min(changendi, neighs.size());
                    insertion(changendi);

                    if (cgroup.size() == dim)
                        return 1;

                    /*here it make a CUP_search using c_group with the nodes added*/
                    initialize_for_evaluation(ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);
                    List<int> gr_cleaned_to_send = gr_cleaned.ToList<int>();
                    CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, false, number_of_runs);
                    gr_cleaned = new LinkedList<int>();

                    if (gr_cleaned_to_send.Count() > 0)
                    {

                        /*the first clean up passed. now it makes the CUP_check*/
                        initialize_for_evaluation(gr_cleaned_to_send, ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);
                        bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, true, Parameters.clean_up_runs);

                        //cout<<"exiting... "<<gr_cleaned.size()<<endl;
                        if (gr_cleaned_to_send.Count() > 0)
                        {
                            gr_cleaned = new LinkedList<int>();
                            foreach (int i in gr_cleaned_to_send)
                            {
                                gr_cleaned.AddLast(i);
                            }
                            return bscore;
                        }
                    }
                    gr_cleaned = new LinkedList<int>();
                    foreach (int i in gr_cleaned_to_send)
                    {
                        gr_cleaned.AddLast(i);
                    }

                    ++stopper;
                    if (stopper == Parameters.inflate_stopper)
                        break;
                }
                return 1;
            }
            //private 

            //private void erase_cgroup(int wnode);
            private void erase_cgroup(int wnode)
            {
                //map<int, facts>::iterator itm = cgroup.lab_facts.find(wnode);
                //Dictionary<int, undir_weighted_tabdeg.facts> itm = 
                //KeyValuePair<int, undir_weighted_tabdeg.facts> itm = cgroup.lab_facts.ElementAt(wnode);
                //if (itm != cgroup.lab_facts.end())
                if (cgroup.lab_facts.ContainsKey(wnode))
                {
                    KeyValuePair<int, undir_weighted_tabdeg.facts> itm = cgroup.lab_facts.ElementAt(wnode);
                    int kp = itm.Value.internal_degree;
                    int kt = itm.Value.degree;
                    double mtlw = itm.Value.minus_log_total_wr;

                    kin_cgroup -= 2 * kp;
                    ktot_cgroup -= kt;
                    int kout_g = ktot_cgroup - kin_cgroup;
                    int tm = oneM - ktot_cgroup;



                    double fi = undir_weighted_tabdeg.compute_global_fitness_ofive(kp, kout_g, tm, kt, mtlw, neighs.size() + 1, dim - cgroup.size() + 1);
                    neighs.edinsert(wnode, kp, kt, mtlw, fi);

                    cgroup.erase(wnode);

                    List<int> tobe = new List<int>();
                    for (int i = 0; i < vertices[wnode].links.size(); i++)
                    {
                        if (cgroup.update_group(vertices[wnode].links.l[i], -vertices[wnode].links.w[i].Key, -vertices[wnode].links.w[i].Value,
                                               dim - cgroup.size(), neighs.size(), kout_g, tm, vertices[vertices[wnode].links.l[i]].stub_number, ref tobe) == false)
                            neighs.update_neighs(vertices[wnode].links.l[i], -vertices[wnode].links.w[i].Key, -vertices[wnode].links.w[i].Value,
                                                dim - cgroup.size(), kout_g, tm, vertices[vertices[wnode].links.l[i]].stub_number);

                    }
                    for (int i = 0; i < (int)(tobe.Count()); i++)
                        erase_cgroup(tobe[i]);
                }
            }

            //private void insert_cgroup(int wnode);
            private void insert_cgroup(int wnode)
            {
                // this function is to insert wnode into cgroup  updating all the system, neighs - kin_cgroup - ktot_cgroup
                // it needs to be differenciated between weighted and unweighted
                int kp = new int();
                int kt = new int();
                double mtlw = new double();
                {
                    //map<int, facts>::iterator itm = neighs.lab_facts.find(wnode);
                    KeyValuePair<int, undir_weighted_tabdeg.facts> itm = new KeyValuePair<int, undir_weighted_tabdeg.facts>();
                    //if (itm != neighs.lab_facts.end())
                    if (neighs.lab_facts.ContainsKey(wnode))
                    {
                        itm = neighs.lab_facts.ElementAt(wnode);
                        kp = itm.Value.internal_degree;
                        kt = itm.Value.degree;
                        mtlw = itm.Value.minus_log_total_wr;

                    }
                    else
                    {
                        kp = 0;
                        kt = vertices[wnode].stub_number;
                        mtlw = 0;
                    }
                }
                int kout_g = ktot_cgroup - kin_cgroup;
                int tm = oneM - ktot_cgroup;
                double fi = undir_weighted_tabdeg.compute_global_fitness_ofive(kp, kout_g, tm, kt, mtlw, neighs.size(), dim - cgroup.size());
                kin_cgroup += 2 * kp;
                ktot_cgroup += kt;
                kout_g = ktot_cgroup - kin_cgroup;
                tm = oneM - ktot_cgroup;

                cgroup.edinsert(wnode, kp, kt, mtlw, fi);
                neighs.erase(wnode);

                List<int> tobe = new List<int>();

                for (int i = 0; i < vertices[wnode].links.size(); i++)
                {
                    if (cgroup.update_group(vertices[wnode].links.l[i], vertices[wnode].links.w[i].Key, vertices[wnode].links.w[i].Value,
                                           dim - cgroup.size(), neighs.size(), kout_g, tm, vertices[vertices[wnode].links.l[i]].stub_number, ref tobe) == false)
                        neighs.update_neighs(vertices[wnode].links.l[i], vertices[wnode].links.w[i].Key, vertices[wnode].links.w[i].Value,
                                            dim - cgroup.size(), kout_g, tm, vertices[vertices[wnode].links.l[i]].stub_number);
                }
            }

            //private bool erase_the_worst(int & wnode);
            private bool erase_the_worst(ref int wnode)
            {
                // this function is to look for the worst node in cgroup and to erase it
                int Nstar = dim - cgroup.size();
                int nn = neighs.size();
                int kout_g = ktot_cgroup - kin_cgroup;
                int tm = oneM - ktot_cgroup;

                double wf = new double();
                cgroup.worst_node(ref wnode, ref wf, kout_g, Nstar, nn, tm);

                if (cgroup.size() == 0)
                {
                    return false;
                }
                erase_cgroup(wnode);
                return true;
            }

            //private int set_maxbord();
            private int set_maxbord()
            {
                max_r_bord = Parameters.maxbg_ordinary;
                maxb_nodes = Parameters.maxborder_nodes;
                return 0;
            }

            //private void set_cgroup_and_neighs(const deque<int> & G);
            private void set_cgroup_and_neighs(/*const ref */List<int> G)
            {
                // this function initially sets the data structures for the group and its neighbors
                kin_cgroup = 0;
                ktot_cgroup = 0;
                cgroup.clear();
                neighs.clear();
                for (int i = 0; i < (int)(G.Count()); i++)
                    insert_cgroup(G[i]);
            }

            //private double all_external_test(int kout_g, int tm, int Nstar, int nneighs, const double & max_r_one, const double & maxr_two, deque<int> & gr_cleaned, bool only_c, weighted_tabdeg & previous_tab_c);
            private double all_external_test(int kout_g, int tm, int Nstar, int nneighs, /*const ref*/ double max_r_one, /*const ref*/ double maxr_two, ref List<int> gr_cleaned, bool only_c, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_c)
            {
                double max_r = Math.Min(max_r_one, maxr_two);
                Dictionary<double, List<KeyValuePair<int, double>>> fitness_label_to_sort = new Dictionary<double, List<KeyValuePair<int, double>>>();
                //cout << "About to get external scores" << endl;
                get_external_scores(ref neighs, ref fitness_label_to_sort, kout_g, tm, Nstar, nneighs, max_r, only_c, ref previous_tab_c);
                //cout << "Got external score" << endl;
                //cout << "Going to return from \"all_external_test\" with cup_on_list" << endl;
                //system("PAUSE");
                return cup_on_list(ref fitness_label_to_sort, ref gr_cleaned);

            }

            //private double cup_on_list(cup_data_struct & a, deque<int> & gr_cleaned);
            //cup_data_struct = Dictionary<double,List<KeyValuePair<int, double>>>
            private double cup_on_list(ref Dictionary<double, List<KeyValuePair<int, double>>> a, ref List<int> gr_cleaned)
            {
                ////cout << "Cup on list, from the return statement" << endl;
                //cout << "Checking the MultiMap: ";
                //cout << a.begin()->first <<" "<< a.begin()->first << endl;;

                int Nstar;
                if (Parameters.weighted)
                    Nstar = neighs.size();
                else
                    Nstar = dim - cgroup.size();

                double critical_xi = -Math.Log(1 - Parameters.threshold) / undir_weighted_tabdeg.fitted_exponent(Nstar);
                int pos = Nstar;

                int until = -1;                             // until tells how many nodes should be included into the cluster - actually the number of good nodes are (until +1)
                double probability_a = new double();
                double probability_b = new double();        // these are the two extremes of a possible good node I could have found
                double c_min = 1;                               // this is the score we give to the border we are evaluating here
                                                                ////cout<<"critical_xi: "<<critical_xi<<" --------------------------------------- "<<neighs.size()<<" cgroup "<<cgroup.size()<<endl<<endl<<endl;

                //cup_data_struct::iterator itl = a.begin();
                //cup_data_struct::iterator MCPitl = a.begin();
                //Dictionary < double, List < KeyValuePair < int, double>>>
                //cup_data_struct = Dictionary<double,List<KeyValuePair<int, double>>>
                bool brokeEarly = false;
                //while (itl != a.end())
                foreach (KeyValuePair<double, List<KeyValuePair<int, Double>>> outerItl in a)
                    foreach (KeyValuePair<int, double> itl in outerItl.Value)
                    {
                        double c_pos = undir_weighted_tabdeg.order_statistics_left_cumulative(Nstar, pos, outerItl.Key);
                        c_min = Math.Min(c_pos, c_min);
                        if (c_pos < critical_xi)
                        {
                            /*	
                            this is the basic condition of the order statistics test
                            it's saying: look, this guy (itl->second.Key) has an average fitness (itl->first) 
                            whose order_statistics_left_cumulative is below the threshold 
                            */
                            if (until == -1)
                            {           // this node is the first node to be below the threshold
                                until = Nstar - pos;
                                c_min = c_pos;
                                probability_a = outerItl.Key - itl.Value;//.Value; //MCP I think this is looking at the value for a particular key. Since I'm going through all the values, through the inner foreach, this SHOULD accomplish the same things...?
                                //DO ensure that the Key is looking to the Outer Key (as it should have been) rather than the Inner Key the C++ doesn't think exists.
                                probability_b = outerItl.Key + itl.Value;//.Value;
                            }
                            else
                            {
                                /* 
                                the previous node was already below the threshold. 
                                In this case I need to know if I should stop now or go on.
                                The condition is related to the probability_to_overtake the previous guy
                                */
                                double probability_to_overtake = undir_weighted_tabdeg.compare_r_variables(probability_a, probability_b, outerItl.Key - itl.Value/*.Value*/, outerItl.Key + itl.Value/*.Value*/);

                                if (probability_to_overtake > 0.4999)
                                {       /*preliminary check: this node is basically equivalent to the previous guy, I consider it good*/
                                    until = Nstar - pos;
                                    c_min = c_pos;
                                    probability_a = outerItl.Key - itl.Value;//.Value;
                                    probability_b = outerItl.Key + itl.Value;//.Value;
                                }
                                else
                                {
                                    /*now I need to compute the bootstrap probability that the previous guy would have stopped the process*/
                                    if ((probability_to_overtake == 0) || ((1.0 - probability_to_overtake) * undir_weighted_tabdeg.compute_probability_to_stop(probability_a, probability_b, critical_xi, Nstar, pos + 1) > 0.5001))
                                    {
                                        if (undir_weighted_tabdeg.equivalent_check_gather(ref a, ref until, probability_a, probability_b, Nstar, critical_xi))
                                        {
                                            brokeEarly = true;
                                            break;
                                        }
                                    }
                                    until = Nstar - pos;
                                    c_min = c_pos;
                                    probability_a = outerItl.Key - itl.Value;//.Value;
                                    probability_b = outerItl.Key + itl.Value;//.Value;
                                }
                            }
                        }
                        else
                        {       /* this node is not below the threshold */

                            if (until != -1)
                            {       /* this means that this node is not good and the previous one was good. So, I stop here */
                                if (undir_weighted_tabdeg.equivalent_check_gather(ref a, ref until, probability_a, probability_b, Nstar, critical_xi))
                                {
                                    brokeEarly = true;
                                    break;
                                }
                            }
                        }
                        --pos;
                    }
                // equalizer check
                // this check is important to see if the procedure stopped just because there were a lot of equivalents nodes
                if (until != -1 && brokeEarly == false) //MCP this SHOULD match conditions. It was testing whether the Iterator was at the end...
                {
                    undir_weighted_tabdeg.equivalent_check_gather(ref a, ref until, probability_a, probability_b, Nstar, critical_xi);
                }
                // inserting nodes in gr_cleaned
                int nodes_added = -1;
                //itl = a.begin();

                //while (itl != a.end())
                brokeEarly = false;
                foreach (KeyValuePair<double, List<KeyValuePair<int, Double>>> outerItl in a)
                    foreach (KeyValuePair<int, double> itl in outerItl.Value)
                    {

                        if (nodes_added == until)
                        {
                            brokeEarly = true;
                            break;
                        }

                        gr_cleaned.Add(itl.Key);
                        //++itl;
                        ++nodes_added;

                    }
                return undir_weighted_tabdeg.pron_min_exp(Nstar, c_min);
            }

            //private void get_external_scores(weighted_tabdeg & ne_, cup_data_struct & fitness_label_to_sort, int kout_g, int tm, int Nstar, int nneighs, const double & max_r, bool only_c, weighted_tabdeg & previous_tab_c);
            private void get_external_scores(ref undir_weighted_tabdeg.weighted_tabdeg neighs, ref Dictionary<double, List<KeyValuePair<int, double>>> fitness_label_to_sort, int kout_g, int tm, int Nstar, int nneighs, /*const ref*/ double max_r, bool only_c, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_c)
            {
                //multimap<double, int>:: iterator bit = neighs.fitness_lab.begin();
                //KeyValuePair<double, List<int>> bit = new KeyValuePair<double, List<int>>();

                int counter = 0;

                //while (bit != neighs.fitness_lab.end())
                foreach (KeyValuePair<double, List<int>> bit_outer in neighs.fitness_lab)
                    foreach (int bit_inner in bit_outer.Value)
                    {
                        //map<int, facts> :: iterator itm = neighs.lab_facts.find(bit.Value);

                        KeyValuePair<int, undir_weighted_tabdeg.facts> itm = neighs.lab_facts.ElementAt(bit_inner);
                        double interval = new double();
                        double F = undir_weighted_tabdeg.compute_global_fitness(itm.Value.internal_degree, kout_g, tm, itm.Value.degree, itm.Value.minus_log_total_wr, nneighs, Nstar, ref interval);
                        if (F > max_r)
                        {
                            /*if(only_c == false || previous_tab_c.is_internal(itm->first))		
                                cout<<"no node: "<<vertices[itm->first]->id_num<<"  "<<itm->second.internal_degree<<" / "<< itm->second.degree<<" fitness: "<<F<<endl;*/

                            counter++;
                            if (counter > Globals.num_up_to)
                                break;
                        }
                        else
                        {

                            /*if(only_c == false || previous_tab_c.is_internal(itm->first))
                                cout<<"node: "<<"  "<<itm->second.internal_degree<<" / "<< itm->second.degree<<" fitness: "<<F<<" "<<interval<<endl;*/

                            /*if (only_c == false || previous_tab_c.is_internal(itm.first))
                                fitness_label_to_sort.insert(make_pair(F, make_pair(itm->first, interval)));*/
                            if (only_c == false || previous_tab_c.is_internal(itm.Key))
                            {

                                fitness_label_to_sort[F].Add(new KeyValuePair<int, double>(itm.Key, interval)); //MCP pick up here.
                            }
                        }
                        //bit++;
                    }
            }

            //private double CUP_runs(weighted_tabdeg & previous_tab_c, weighted_tabdeg & previous_tab_n, int kin_cgroup_prev, int ktot_cgroup_prev, deque<int> & gr_cleaned, bool only_c, int runs);
            private double CUP_runs(ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_c, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_n, int kin_cgroup_prev, int ktot_cgroup_prev, ref List<int> gr_cleaned, bool only_c, int number_of_runs)
            {
                //cout << "In CUP runs function" << endl;

                /* this if statemets are here to speed up the program if there are big clusters */
                //cout << "Set number of runs" << endl;
                if (previous_tab_c.size() > 100000)
                    number_of_runs = 3;
                else if (previous_tab_c.size() > 10000)
                    number_of_runs = 5;
                else if (previous_tab_c.size() > 1000)
                    number_of_runs = 10;
                //cout << "Num runs set, about to clear" << endl;
                gr_cleaned = new List<int>(); //.clear();
                //cout << "Cleared" << endl;

                if (previous_tab_c.size() == 0)
                    return 1;

                int max_gr_size = 0;
                double bscore = 1;

                int good_runs = 0;

                for (int i = 0; i < number_of_runs; i++)
                {
                    //cout << "For loop for less than numRuns." << endl;
                    List<int> gr_run_i = new List<int>();
                    //cout << "About to PartialCUP for score." << endl;
                    double score_i = partial_CUP(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_run_i, only_c);
                    //cout << "End PartialCUP" << endl;
                    if (cgroup.size() + (int)(gr_run_i.Count()) > max_gr_size)
                    {
                        bscore = score_i;
                        cgroup.set_deque(ref gr_cleaned);
                        for (int j = 0; j < (int)(gr_run_i.Count()); j++)
                        {

                            gr_cleaned.Add(gr_run_i[j]);
                        }

                        max_gr_size = gr_cleaned.Count();
                        //sort(gr_cleaned.begin(), gr_cleaned.end());
                        gr_cleaned.Sort();
                    }

                    if (gr_run_i.Count() > 0)
                    {
                        ++good_runs;
                        if (good_runs >= 0.55 * number_of_runs)
                            return bscore;
                    }
                }

                if (good_runs < 0.55 * number_of_runs)
                {
                    gr_cleaned = new List<int>();//.clear();
                    bscore += Parameters.threshold;
                    bscore = Math.Min(1.0, bscore);
                }
                return bscore;
            }


            //private void initialize_for_evaluation(const deque<int> & _c_, weighted_tabdeg & previous_tab_c, weighted_tabdeg & previous_tab_n, int & kin_cgroup_prev, int & ktot_cgroup_prev);
            private void initialize_for_evaluation(/*const ref*/ List<int> _c_, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_c, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_n, ref int kin_cgroup_prev, ref int ktot_cgroup_prev)
            {
                set_cgroup_and_neighs(_c_);

                int Nstar = dim - cgroup.size();
                int nn = neighs.size();
                int kout_g = ktot_cgroup - kin_cgroup;
                int tm = oneM - ktot_cgroup;

                previous_tab_c.set_and_update_group(Nstar, nn, kout_g, tm, ref cgroup);
                previous_tab_n.set_and_update_neighs(Nstar, nn, kout_g, tm, ref neighs);
                kin_cgroup_prev = kin_cgroup;
                ktot_cgroup_prev = ktot_cgroup;
            }
            //private void initialize_for_evaluation(weighted_tabdeg & previous_tab_c, weighted_tabdeg & previous_tab_n, int & kin_cgroup_prev, int & ktot_cgroup_prev);
            private void initialize_for_evaluation(ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_c, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_n, ref int kin_cgroup_prev, ref int ktot_cgroup_prev)
            {
                int Nstar = dim - cgroup.size();
                int nn = neighs.size();
                int kout_g = ktot_cgroup - kin_cgroup;
                int tm = oneM - ktot_cgroup;

                previous_tab_c.set_and_update_group(Nstar, nn, kout_g, tm, ref cgroup);
                previous_tab_n.set_and_update_neighs(Nstar, nn, kout_g, tm, ref neighs);
                kin_cgroup_prev = kin_cgroup;
                ktot_cgroup_prev = ktot_cgroup;
            }

            //private double partial_CUP(weighted_tabdeg & previous_tab_c, weighted_tabdeg & previous_tab_n, int kin_cgroup_prev, int ktot_cgroup_prev, deque<int> & gr_cleaned, bool only_c);
            private double partial_CUP(ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_c, ref undir_weighted_tabdeg.weighted_tabdeg previous_tab_n, int kin_cgroup_prev, int ktot_cgroup_prev, ref List<int> border_group, bool only_c)
            {

                //cout << "partialCUP begin" << endl;
                // still there is some stochasticity due to possible ties

                /*	previous_stuff is the module-stuff before the CUP (Clean Up Procedure)
                    cgroup + border_group is the module cleaned					*/


                //border_group.clear();
                border_group = new List<int>();

                cgroup._set_(ref previous_tab_c);
                neighs._set_(ref previous_tab_n);
                kin_cgroup = kin_cgroup_prev;
                ktot_cgroup = ktot_cgroup_prev;

                if (cgroup.size() == dim)
                {
                    return 1;
                }

                double bscore = 1;
                while (true)
                {
                    //cout << "About to go to ALL EXTERNAL test" << endl;
                    bscore = all_external_test(ktot_cgroup - kin_cgroup, oneM - ktot_cgroup, dim - cgroup.size(), neighs.size(), maxb_nodes / (double)(dim - cgroup.size()), max_r_bord, ref border_group, only_c, ref previous_tab_c);
                    //cout << "tested" << endl;
                    if (border_group.Count() > 0)
                        break;

                    if (cgroup.size() == 0)
                        break;

                    int wnode = new int();
                    //cout << "About to erase worst" << endl;
                    erase_the_worst(ref wnode);
                    //cout << "Erased" << endl;
                }

                //cout << "going to return bscore from partial_CUP" << endl;
                //system("PAUSE");
                return bscore;
            }


            //private void set_changendi_cum();
            private void set_changendi_cum()
            {

                if (dim != 0 && oneM != 0)
                {
                    int flat_until = cast.cast_int(oneM / dim * 3);
                    flat_until = Math.Min(dim / 2, flat_until);

                    int max_p = Math.Max(Parameters.CUT_Off, flat_until);     // this is something which might be optimized
                    max_p = Math.Min(dim / 2, max_p);

                    Combinatorics.powerlaw(max_p, flat_until + 1, 3, ref changendi_cum);
                    List<double> distr = new List<double>();
                    Combinatorics.distribution_from_cumulative(changendi_cum, ref distr);
                    double ac = 1;

                    if (distr.Count()/*size()*/ > 0)
                        ac = distr[0];

                    List<double> distrCopy = new List<double>();

                    for (int i = 0; i < flat_until; i++)
                    {
                        distrCopy = new List<double>();
                        distrCopy.Add(ac); //originally a "push_front" thing.
                        foreach (double x in distr)
                        {
                            distrCopy.Add(x);
                        }
                        distr = distrCopy;
                    }


                    DN.normalize_one(ref distr);
                    Combinatorics.cumulative_from_distribution(ref changendi_cum, distr);
                }

            }

            //private void insertion(int changendi);
            private void insertion(int changendi)
            {
                for (int i = 0; i < changendi; i++)
                    insert_the_best();
            }

            //private bool insert_the_best();
            private bool insert_the_best()
            {
                int Nstar = dim - cgroup.size();
                int nn = neighs.size();
                int kout_g = ktot_cgroup - kin_cgroup;
                int tm = oneM - ktot_cgroup;

                double lowest_r = new double();
                int benode = new int();
                neighs.best_node(ref benode, ref lowest_r, kout_g, Nstar, nn, tm);

                if (benode == -1)
                    return false;

                insert_cgroup(benode);
                //cout << "going to return true after having inserted into cgroup benode" << endl;
                //system("PAUSE");
                return true;
            }

            //private double CUP_iterative(const deque<int> & _c_, deque<int> & gr_cleaned, int);
            private double CUP_iterative(/*const ref */ LinkedList<int> _c_, ref LinkedList<int> gr_cleaned, int number_of_runs /*= paras.clean_up_runs*/)
            {
                int x = 0;
                if (number_of_runs.GetType() != x.GetType())
                {
                    number_of_runs = Parameters.clean_up_runs;
                }

                double bs = CUP_both(_c_, ref gr_cleaned, number_of_runs);

                int stopp = 0;

                do
                {
                    LinkedList<int> _c_temp = gr_cleaned;

                    bs = CUP_search(_c_temp, ref gr_cleaned, number_of_runs);
                    ++stopp;

                    if (stopp == Parameters.iterative_stopper)
                        break;

                } while (gr_cleaned.Count() > _c_.Count());
                return bs;
            }


            //private double CUP_search(const deque<int> & _c_, deque<int> & gr_cleaned, int);
            private double CUP_search(/*const ref */LinkedList<int> _c_, ref LinkedList<int> gr_cleaned, int number_of_runs /*= paras.clean_up_runs*/)
            {
                int x = 0;
                if (number_of_runs.GetType() != x.GetType())
                {
                    number_of_runs = Parameters.clean_up_runs;
                }


                /*_c_ is the module to clean up and gr_cleaned is the result */


                undir_weighted_tabdeg.weighted_tabdeg previous_tab_c = new undir_weighted_tabdeg.weighted_tabdeg();
                undir_weighted_tabdeg.weighted_tabdeg previous_tab_n = new undir_weighted_tabdeg.weighted_tabdeg();
                int kin_cgroup_prev = new int();
                int ktot_cgroup_prev = new int();
                double bscore = new double();

                initialize_for_evaluation(_c_.ToList(), ref previous_tab_c, ref previous_tab_n, ref kin_cgroup_prev, ref ktot_cgroup_prev);

                List<int> gr_cleaned_to_send = gr_cleaned.ToList<int>();
                bscore = CUP_runs(ref previous_tab_c, ref previous_tab_n, kin_cgroup_prev, ktot_cgroup_prev, ref gr_cleaned_to_send, false, number_of_runs);

                gr_cleaned = new LinkedList<int>();
                foreach (int i in gr_cleaned_to_send)
                {
                    gr_cleaned.AddLast(gr_cleaned_to_send[i]); //should convert list to linkedList.
                }
                //cout << "Going to return bscore from CUP_search" << endl;
                //system("PAUSE");
                return bscore;
            }




            /* DATA ***************************************************/

            private double max_r_bord;                              // this is the maximum r allowed for the external nodes (we don't want to look at all the graph, it would take too long)
            private int maxb_nodes;                                 // this is the maximum number of nodes allowed in the border (similar as above)
            private List<double> changendi_cum = new List<double>();                    // this is the cumulative distribution of the number of nodes to add to the cluster in the group_inflation function 

            // ************* things to update *************************
            private undir_weighted_tabdeg.weighted_tabdeg cgroup = new undir_weighted_tabdeg.weighted_tabdeg();                                 //*
            private undir_weighted_tabdeg.weighted_tabdeg neighs = new undir_weighted_tabdeg.weighted_tabdeg();                                 //*
                                                                                                                                                //*
            private int kin_cgroup;                                         //*
            private int ktot_cgroup;                                        //*
                                                                            /*********************************************************/
        }

    }


    //MCP 8-2-17 "oslom_net_global.h"
    public static class oslom_net_global_h
    {
        //void from_int_matrix_and_deque_to_deque(int_matrix & its_submodules, /*const*/ DI & A, DI & group)
        public static void from_int_matrix_and_deque_to_deque(ref List<List<int>> its_submodules, /*const ref*/ LinkedList<int> A, ref LinkedList<int> group)
        {

            // it merges A and its_submodules in group
            HashSet<int> all_the_groups = new HashSet<int>();
            for (int i = 0; i < its_submodules.Count(); i++)
            {
                for (int j = 0; j < its_submodules[i].Count(); j++)
                    all_the_groups.Add(its_submodules[i][j]);
            }

            for (int i = 0; i < A.Count(); i++)
                all_the_groups.Add(A.ElementAt(i));
            DN.set_to_List(all_the_groups, ref group);



        }
        public static void from_int_matrix_and_deque_to_deque(ref List<List<int>> its_submodules, /*const ref*/ List<int> A, ref LinkedList<int> group)
        {

            // it merges A and its_submodules in group
            HashSet<int> all_the_groups = new HashSet<int>();
            for (int i = 0; i < its_submodules.Count(); i++)
            {
                for (int j = 0; j < its_submodules[i].Count(); j++)
                    all_the_groups.Add(its_submodules[i][j]);
            }

            for (int i = 0; i < A.Count(); i++)
                all_the_groups.Add(A.ElementAt(i));
            DN.set_to_List(all_the_groups, ref group);



        }


        public class oslom_net_global : undirected_oslomnet_evaluate.oslomnet_evaluate
        {


            //public:

            //public:oslom_net_global(int_matrix & b, deque<deque<pair<int, double>>> & c, deque<int> & d);
            public oslom_net_global(ref List<List<int>> b, ref List<List<KeyValuePair<int, double>>> c, ref List<int> d) : base(ref b, ref c, ref d) //mcp 8-2-17 I'm not sure why I needed to create a 0-parameter constructor in oslomnet_evaluate...
            {

            }
            public oslom_net_global(string a) : base(a) { }
            //public oslom_net_global(map<int, map<int, pair<int, double>>> & A)
            public oslom_net_global(ref Dictionary<int, Dictionary<int, KeyValuePair<int, double>>> A) : base(ref A)
            {


            }
            /*public oslom_net_global(ref string a) : base(ref a)
            {


            }*/ //MCP ADD STRING FUNCTIONALITY.

            //public:void hint(module_collection & minimal_modules, string filename);
            public void hint(ref module_collection minimal_modules, string filename)
            {
                //int_matrix good_modules_to_prune;
                List<List<int>> good_modules_to_prune = new List<List<int>>();
                LinkedList<double> bscores_good = new LinkedList<double>();
                
                System.Console.WriteLine("getting partition from file: {0}",filename);
                ///int_matrix A;
                List<List<int>> A = new List<List<int>>();

                partition.get_partition_from_file(filename, ref A);

                translate(ref A);

                //cout << A.size() << " groups found" << endl;
                System.Console.WriteLine("{0} groups found", A.Count());
                for (int ii = 0; ii < (int)(A.Count()); ii++)
                {
                    List<int> group = new List<int>();

                    System.Console.WriteLine("processing group number {0}. Size: {1}",ii ,A[ii].Count());
                    double bcu = CUP_both(A[ii], ref group, Parameters.clean_up_runs);
                    if (group.Count() > 0)
                    {
                        good_modules_to_prune.Add(group);
                        bscores_good.AddLast(bcu);
                    }
                    else
                        System.Console.WriteLine("bad group");
                }
                System.Console.WriteLine("***************************************************************************");
                from_matrix_to_module_collection(ref good_modules_to_prune, ref bscores_good, ref minimal_modules);
            }
            //public:void load(string filename, module_collection & Mall);
            public void load(string filename, ref module_collection Mall)
            {
                // this function is to read a file in the tp-format
                System.Console.WriteLine("getting partition from tp-file: {0}",filename);
                //deque<double> bss;
                LinkedList<double> bss = new LinkedList<double>();
                //deque<deque<int>> A;
                List<List<int>> A = new List<List<int>>();

                partition.get_partition_from_file_tp_format(filename, ref A, ref bss);
                translate(ref A);

                System.Console.WriteLine("{0} groups found", A.Count());
                System.Console.WriteLine("{0} bss found", bss.Count());

                for (int ii = 0; ii < A.Count(); ii++)
                {
                    //cout<<"inserting group number "<<ii<<" size: "<<A[ii].size()<<endl;
                    List<int> Aii = A[ii];
                    Mall.insert(ref Aii, bss.ElementAt(ii));
                    A[ii] = Aii;
                }
            }

            //public:void print_modules(bool not_homeless, string tp, module_collection & Mcoll);
            public void print_modules(bool not_homeless, string tp, ref module_collection Mcoll)
            {
                
                string b = string.Empty ;//new char[1000];
                //cast.cast_string_to_char(tp,ref b);
                b = tp;
                //ofstream out1(b);
                System.IO.StreamWriter out1 = new System.IO.StreamWriter(b.ToString());

                print_modules(not_homeless, ref out1, ref Mcoll);




            }


            //public:void print_modules(bool not_homeless, ostream & out1, module_collection & Mcoll);
            public void print_modules(bool not_homeless, ref System.IO.StreamWriter out1, ref module_collection Mcoll)
            {
                int nmod = 0;
                //for (map<int, double>::iterator itm = Mcoll.module_bs.begin(); itm != Mcoll.module_bs.end(); itm++)
                foreach(KeyValuePair<int,double> itm in Mcoll.module_bs)
                    if (Mcoll.modules[itm.Key].Count() > 1)
                        nmod++;

                System.Console.WriteLine("******** module_collection ******** {0} modules. writing... " ,nmod);
                //system("PAUSE");

                //deque<int> netlabs;
                List<int> netlabs = new List<int>();
                for (int i = 0; i < dim; i++)
                    netlabs.Add(id_of(i));

                Mcoll.print(ref out1, ref netlabs, not_homeless);
                System.Console.WriteLine("DONE   ****************************");
                //system("PAUSE");
            }




            //public:int try_to_assign_homeless(module_collection & Mcoll, bool anyway);
            public int try_to_assign_homeless(ref module_collection Mcoll, bool anyway)
            {
                Mcoll.put_gaps();

                //if(paras.print_cbs)
                //cout<<"checking homeless nodes "<<endl;

                //deque<int> homel;
                List<int> homel = new List<int>();
                Mcoll.homeless(ref homel);

                int before_procedure = homel.Count();
                if (homel.Count() == 0)
                    return before_procedure;

                /*cout<<"homel"<<endl;
                print_id(homel, cout);*/


                HashSet<int> called = new HashSet<int>();                        // modules connected to homeless nodes
                Dictionary<int, HashSet<int>> homel_module = new Dictionary<int, HashSet<int>>();        // maps the homeless node with the modules it's connected to
                for (int i = 0; i < homel.Count(); i++)
                {
                    HashSet<int> thish = new HashSet<int>();
                    for (int j = 0; j < vertices[homel[i]].links.size(); j++)
                    {

                        int neigh = vertices[homel[i]].links.l[j];

                        //for (set<int>:: iterator itk = Mcoll.memberships[neigh].begin(); itk != Mcoll.memberships[neigh].end(); itk++)
                        foreach(int itk in Mcoll.memberships[neigh])
                        {
                            //called.insert(*itk);
                            called.Add(itk);
                            //thish.insert(*itk);
                            thish.Add(itk);
                        }
                    }
                    if (thish.Count() > 0)
                        homel_module[homel[i]] = thish;
                }
                //map<int, int> module_kin;
                Dictionary<int, int> module_kin = new Dictionary<int, int>();
                //map<int, int> module_ktot;
                Dictionary<int, int> module_ktot = new Dictionary<int, int>();

                //for (set<int>:: iterator its = called.begin(); its != called.end(); its++)
                foreach(int its in called)
                {
                    module_kin[its] = cast.cast_int(kin_m(Mcoll.modules[its]));
                    module_ktot[its] = cast.cast_int(ktot_m(Mcoll.modules[its]));
                }
                //map<int, deque<int>> to_check;          // module - homeless nodes added to that
                Dictionary<int, List<int>> to_check = new Dictionary<int, List<int>>();
                //for (map<int, set<int>> :: iterator itm = homel_module.begin(); itm != homel_module.end(); itm++)
                foreach(KeyValuePair<int, HashSet<int>> itm in homel_module)
                {
                    double cmin = 1.1;
                    int belongs_to = -1;
                    //cout<<"homeless node: "<<id_of(itm->first)<<endl;
                    //for (set<int>:: iterator its = itm->second.begin(); its != itm->second.end(); its++)
                    foreach(int its in itm.Value)
                    {
                        int kin_node = cast.cast_int(vertices[itm.Key].kplus_m(Mcoll.modules[its]));

                        /*cout<<"module: "<<*its<<" kin: "<<module_kin[*its]<<"  ktot: "<<module_ktot[*its]<<" kin h "<<kin_node<<endl;
                        print_ri(Mcoll.modules[*its]);*/

                        int kout_g = module_ktot[its] - module_kin[its];
                        int tm = oneM - module_ktot[its];
                        //double rh= compute_r_hyper(kin_node, kout_g, tm, vertices[itm->first]->stub_number);
                        double kinw = vertices[itm.Key].kplus_w(Mcoll.modules[its]);
                        //double weight_part= log_together(kinw, kin_node);

                        double rh = undir_weighted_tabdeg.compute_global_fitness_randomized_short(kin_node, kout_g, tm, vertices[itm.Key].stub_number, kinw);

                        //double cs=  1 - pow(1 - rh, dim - Mcoll.modules[*its].size());
                        //cout<<"rh: "<<rh<<" ..."<<endl;
                        if (rh < cmin)
                        {
                            cmin = rh;
                            belongs_to = its;
                        }
                    }

                    if (belongs_to != -1)
                    {
                        //if (to_check.find(belongs_to) == to_check.end())
                        if(!to_check.ContainsKey(belongs_to))
                        {
                            List<int> void_d = new List<int>();
                            to_check[belongs_to] = void_d;
                        }
                        to_check[belongs_to].Add(itm.Key);
                    }
                    //if(paras.print_cbs)
                    //cout<<"homeless node: "<<id_of(itm->first)<<" belongs_to "<<belongs_to<<" cmin... "<<cmin<<endl;
                    //cherr();
                }
                //if(paras.print_cbs)
                //cout<<"homeless node: "<<homel.size()<<" try_to_assign: "<<homel_module.size()<<" modules to check: "<<to_check.size()<<endl;
                // **** try the groups with the homeless //******************
                bool something = false;

                //for (map<int, deque<int>> :: iterator itm = to_check.begin(); itm != to_check.end(); itm++)
                foreach(KeyValuePair<int, List<int>> itm in to_check)
                {
                    List<int> union_deque = Mcoll.modules[itm.Key];
                    for (int i = 0; i < itm.Value.Count(); i++)
                        union_deque.Add(itm.Value[i]);
                    if (anyway)
                    {
                        something = true;
                        Mcoll.insert(ref union_deque, MyRandom.ran4() + Parameters.threshold);
                    }
                    else
                    {
                        List<int> grbe = new List<int>(); //note: This WAS a Deque.
                        double bs = CUP_check(union_deque, ref grbe, Parameters.clean_up_runs);

                        //cout<<"union_deque after "<<itm->first<<" size: "<<grbe.size()<<endl;
                        if (grbe.Count() > 1)
                        {
                            something = true;
                            Mcoll.insert(ref grbe, bs);
                        }
                    }
                }
                if (something)
                {
                    Mcoll.compute_inclusions();
                }
                return before_procedure;
            }

            //public:void get_covers(string cover_file, int & soft_partitions_written, int gruns);
            public void get_covers(string cover_file, ref int soft_partitions_written, int gruns)
            {
                /* this function is to collect different covers of the network
                   they are written in file cover_file (appended)
                   their number is added to soft_partitions_written */


                string b = string.Empty ;//new char[1000];
                //cast.cast_string_to_char(cover_file, ref b);
                b = cover_file;
                //ofstream out1(b, ios::app);
                System.IO.StreamWriter out1 = new System.IO.StreamWriter(b.ToString()); //note that there are other parameters in the C++ code, but I don't know what they do / where to find the equivalents here. They come from namespace ios.


                for (int i = 0; i < gruns; i++)
                {

                    System.Console.WriteLine("***************************************************************** RUN: #{0}",i + 1);

                    module_collection Mcoll = new module_collection(dim);
                    
                    get_cover(ref Mcoll); //8-28-17 problem here.
                    System.Console.WriteLine("8-28-17 test");

                    if (Mcoll.size() > 0)
                    {
                        print_modules(true, ref out1, ref Mcoll);               // not homeless nodes
                        soft_partitions_written++;
                    }
                }

                if (Parameters.value)
                {
                    module_collection Mcoll = new module_collection(dim);
                    hint(ref Mcoll, Parameters.file2);

                    if (Mcoll.size() > 0)
                    {
                        print_modules(true, ref out1, ref Mcoll);               // not homeless nodes
                        soft_partitions_written++;
                    }
                }


                if (Parameters.value_load)
                {
                    module_collection Mcoll = new module_collection(dim);
                    load(Parameters.file_load, ref Mcoll);

                    if (Mcoll.size() > 0)
                    {
                        print_modules(true, ref out1, ref Mcoll);               // not homeless nodes
                        soft_partitions_written++;
                    }
                }
            }
            //public:void ultimate_cover(string cover_file, int soft_partitions_written, string final_cover_file);
            public void ultimate_cover(string cover_file, int soft_partitions_written, string final_cover_file)
            {
                System.Console.WriteLine("pruning all the modules collected. Partitions found: {0}", soft_partitions_written);
                module_collection Mall = new module_collection(dim);
                load(cover_file, ref Mall);

                if (soft_partitions_written > 1)
                    check_unions_and_overlap(ref Mall, true);

                System.Console.WriteLine("checking homeless nodes");
                if (Parameters.homeless_anyway == false)
                {
                    try_to_assign_homeless(ref Mall, false);
                }
                else
                {
                    List<int> homel = new List<int>();
                    Mall.homeless(ref homel);

                    int before_procedure = homel.Count();

                    while (homel.Count() > 0)
                    {
                       System.Console.WriteLine("assigning homeless nodes. Homeless at this point: {0}", before_procedure );

                        try_to_assign_homeless(ref Mall, true);
                        Mall.homeless(ref homel);
                        if (homel.Count() >= before_procedure)
                            break;
                        before_procedure = homel.Count();
                    }
                }
                Mall.fill_gaps();
                System.Console.WriteLine("writing final solution in file {0}",final_cover_file );
                print_modules(false, final_cover_file, ref Mall);               // homeless nodes printed
            }

            //public:void print_statistics(ostream & outt, module_collection & Mcoll);
            public void print_statistics(ref System.IO.StreamWriter outt, ref module_collection Mcoll)
            {
                int nmod = 0;
                int cov = 0;
                //for (map<int, double>::iterator itm = Mcoll.module_bs.begin(); itm != Mcoll.module_bs.end(); itm++)
                foreach(KeyValuePair<int,double> itm in Mcoll.module_bs)
                    if (Mcoll.modules[itm.Key].Count() > 1)
                    {
                        nmod++;
                        cov += Mcoll.modules[itm.Key].Count();
                    }
                List<int> homel = new List<int>();
                Mcoll.homeless(ref homel);
                outt.WriteLine("number of modules: {0}",nmod);
                outt.WriteLine("number of covered nodes: {0} fraction of homeless nodes: {1}", dim - homel.Count() ,(double)(homel.Count()) / dim);
                outt.WriteLine("average number of memberships of covered nodes: {0}" ,(double)(cov) / (dim - homel.Count()) );
                outt.WriteLine("average community size: {0}", (double)(cov) / nmod);

                print_degree_of_homeless(ref homel, ref outt);

            }


            //private:


            //private void from_matrix_to_module_collection(int_matrix & good_modules_to_prune, DD & bscores_good, module_collection & minimal_modules);
            private void from_matrix_to_module_collection(ref List<List<int>> good_modules_to_prune, ref LinkedList<double> bscores_good, ref module_collection minimal_modules)
            {
                check_minimality_all(ref good_modules_to_prune, ref bscores_good, ref minimal_modules);
                System.Console.WriteLine("***************************************************************************");
                System.Console.WriteLine("MINIMALITY CHECK DONE");

                check_unions_and_overlap(ref minimal_modules);
                System.Console.WriteLine("***************************************************************************");
                System.Console.WriteLine("CHECK UNIONS AND SIMILAR MODULES DONE");
            }

            //private void get_cover(module_collection & minimal_modules);
            public void get_cover(ref module_collection minimal_modules)
            {
                //cout << "Get cover, singular" << endl;
                /* this function collects the modules using single_gather */
                /* then the good modules are inserted in minimal_modules afetr the check minimality */
                
                Parameters.print_flag_subgraph = true;

                List<List<int>> good_modules_to_prune = new List<List<int>>();
                LinkedList<double> bscores_good = new LinkedList<double>();
                System.Console.WriteLine("8-28-17 test 8456");
                //cout << "About to Single Gather" << endl;
                single_gather(ref good_modules_to_prune, ref bscores_good); //mcp 8-28-17 problem here.
                System.Console.WriteLine("8-28-17 test 8459");
                System.Console.WriteLine("***************************************************************************");
                System.Console.WriteLine("COLLECTING SIGNIFICANT MODULES DONE");

                from_matrix_to_module_collection(ref good_modules_to_prune, ref bscores_good, ref minimal_modules);
            }

            //private int try_to_merge_discarded(int_matrix & discarded, int_matrix & good_modules_to_prune, int_matrix & new_discarded, deque<double> & bscores_good);
            private int try_to_merge_discarded(ref List<List<int>> discarded, ref List<List<int>> good_modules_to_prune, ref List<List<int>> new_discarded, ref LinkedList<double> bscores_good)
            {
                new_discarded = new List<List<int>>();//.clear();
                /* this function is implemented to check if merging discarded modules we can get significant clusters */
                /* discarded is the input, the results are appended, except new_discarded which is cleared */

                if (discarded.Count() == 0)
                    return -1;

                if (Parameters.print_flag_subgraph)
                {
                    //cout << "checking unions of not significant modules, modules to check: " << discarded.size() << endl;
                    System.Console.WriteLine("Checking unions of not significant modules, modules to check: {0}", discarded.Count());
                }


                module_collection discarded_modules = new module_collection(dim);
                for (int i = 0; i < (int)(discarded.Count()); i++)
                {
                    List<int> discardedi = discarded[i];
                    discarded_modules.insert(ref discardedi, 1);
                    discarded[i] = discardedi;
                }

                Dictionary<int, Dictionary<int, KeyValuePair<int, double>>> neigh_weight_s = new Dictionary<int, Dictionary<int, KeyValuePair<int, double>>>();       // this maps the module id into the neighbor module ids and weights
                set_upper_network(ref neigh_weight_s, ref discarded_modules);

                if (neigh_weight_s.Count() == 0)
                    return -1;


                oslom_net_global community_net = new oslom_net_global(ref neigh_weight_s);
                //community_net.draw("community_net");	

                List<List<int>> M_raw = new List<List<int>>();       /* M_raw contains the module_id of discarded_modules */
                community_net.collect_raw_groups_once(ref M_raw);

                /*cout<<"community_net partition: "<<endl;
                printm(M_raw);
                cout<<"trying unions of discarded modules... "<<endl;*/


                for (int i = 0; i < (int)(M_raw.Count()); i++)
                    if (M_raw[i].Count() > 1)
                    {
                        HashSet<int> l1 = new HashSet<int>();
                        for (int j = 0; j < (int)(M_raw[i].Count()); j++)
                        {
                            //deque_to_set_app(discarded_modules.modules[M_raw[i][j]], l1);
                            List<int> discarded_modules_modules_mrawij = discarded_modules.modules[M_raw[i][j]];
                            DN.List_to_set_app(discarded_modules_modules_mrawij, ref l1);
                            discarded_modules.modules[M_raw[i][j]] = discarded_modules_modules_mrawij;
                        }

                        LinkedList<int> _M_i_ = new LinkedList<int>();
                        List<int> m_i_list = _M_i_.ToList<int>();
                        DN.set_to_List(l1, ref m_i_list);
                        _M_i_ = new LinkedList<int>();
                        foreach (int x in m_i_list)
                        {
                            _M_i_.AddLast(x);
                        }
                        //cout<<"merged discarded: "<<M_raw[i].size()<<endl;
                        //print_id(_M_i_, cout);

                        //List<int> l = new List<int>();
                        LinkedList<int> l = new LinkedList<int>();
                        double bscore = base.CUP_check(_M_i_, ref l, Parameters.clean_up_runs);

                        if (l.Count() > 0)
                        {
                            //good_modules_to_prune.push_back(l);
                            good_modules_to_prune.Add(l.ToList<int>());
                            //bscores_good.push_back(bscore);
                            bscores_good.AddLast(bscore);

                        }
                        else
                            //new_discarded.push_back(_M_i_);
                            new_discarded.Add(_M_i_.ToList<int>());
                    }
                return 0;
            }

            //private void get_single_trial_partition(int_matrix & good_modules_to_prune, deque<double> & bscores_good);
            private void get_single_trial_partition(ref List<List<int>> good_modules_to_prune, ref List<double> bscores_good)
            {
                System.Console.WriteLine("8-28-17 test 8554");
                /* this function collects significant modules in two steps: 
                   1. using collect_raw_groups_once and cleaning
                   2. putting together discarded modules                   
                   the results are appended in the input data	*/

                List<List<int>> discarded = new List<List<int>>();
                List<List<int>> M = new List<List<int>>();
                //*****************************************************************************
                //cout << "about to cllect raw groups once." << endl;
                System.Console.WriteLine("8-28-17 test 8564");
                collect_raw_groups_once(ref M); //mcp 8-28-17: Problem here.
                System.Console.WriteLine("8-28-17 test 8566");

                //print_id(M, cout);


                //*****************************************************************************

                int total_nodes_tested = 0;

                for (int i = 0; i < M.Count(); i++)
                {

                    if (Parameters.print_flag_subgraph && i % 100 == 0)
                    {
                        //cout << "checked " << i << " modules " << good_modules_to_prune.size() << " were found significant.  Modules to check: " << M.size() - i << ". Percentage nodes done: " << double(total_nodes_tested) / dim << endl;
                        System.Console.WriteLine("checked {0} modules. {1} were found significant. Modules left to check: {2}. Percentage nodes done: {3}", i, good_modules_to_prune.Count(), M.Count() - i, (double)(total_nodes_tested / dim));
                    }

                    /*if(paras.print_flag_subgraph && M[i].size()>1000)
                        cout<<"M[i].size(): "<<M[i].size()<<endl;*/

                    total_nodes_tested += M[i].Count();

                    LinkedList<int> l = new LinkedList<int>();
                    double bscore = new double();

                    if (M[i].Count() < 1000)
                    {
                        //cout << "About to calculate group inflation" << endl;
                        List<int> Mi = M[i];

                        LinkedList<int> Mi2 = new LinkedList<int>();
                        foreach (int z in Mi)
                        {
                            Mi2.AddLast(z);
                        }
                        bscore = group_inflation(Mi2, ref l, Parameters.clean_up_runs);
                        //M[i] = Mi;
                    }
                    else
                    {       /* if M[i] is big enough the check is faster to save time */
                            //cout << "About to CUP_both" << endl;
                        List<int> Mi = M[i];

                        LinkedList<int> Mi2 = new LinkedList<int>();
                        foreach (int z in Mi)
                        {
                            Mi2.AddLast(z);
                        }
                        bscore = base.CUP_both(Mi2, ref l, Parameters.clean_up_runs);
                        //cout << "Cuped both" << endl;
                    }

                    if (l.Count() > 0)
                    {
                        good_modules_to_prune.Add(l.ToList<int>());
                        bscores_good.Add(bscore);
                    }
                    else
                        discarded.Add(M[i]);
                }


                if (Parameters.print_flag_subgraph)
                    System.Console.WriteLine("significance check done \n\n\n");


                //*****************************************************************************



                List<List<int>> new_discarded = new List<List<int>>();
                LinkedList<double> bscores_good_to_send = new LinkedList<double>();
                foreach (double x in bscores_good)
                {
                    bscores_good_to_send.AddLast(x);
                }
                try_to_merge_discarded(ref discarded, ref good_modules_to_prune, ref new_discarded, ref bscores_good_to_send);
                bscores_good = bscores_good_to_send.ToList<double>();
                discarded = new_discarded;
                try_to_merge_discarded(ref discarded, ref good_modules_to_prune, ref new_discarded, ref bscores_good_to_send);
                bscores_good = bscores_good_to_send.ToList<double>();

                if (Parameters.print_flag_subgraph)
                    System.Console.WriteLine("checking unions of not significant modules done \n\n");

                /* actually here it is also possible to check the new_discarded modules more than twice but I believe this should be enough */
                /* in principle one could do while(try_to_merge_discarded(...)!=-1) */
            }
            //private void single_gather(int_matrix & good_modules_to_prune, deque<double> & bscores_good, int );
            private void single_gather(ref List<List<int>> good_modules_to_prune, ref LinkedList<double> bscores_good, int runs = 1)
            {
                System.Console.WriteLine("8-28-17 test 8655");
                //cout << "in single gather" << endl;
                good_modules_to_prune = new List<List<int>>();//.clear();
                bscores_good = new LinkedList<double>();//.clear();
                List<double> bscores_good_to_send = new List<double>();
                System.Console.WriteLine("8-28-17 test 8660");
                bscores_good_to_send = bscores_good.ToList<double>();
                System.Console.WriteLine("8-28-17 test 8662");
                for (int i = 0; i < runs; i++)
                {
                    System.Console.WriteLine("8-28-17 test 8665");
                    get_single_trial_partition(ref good_modules_to_prune, ref bscores_good_to_send); //mcp 8-28-17 problem here.
                    System.Console.WriteLine("8-28-17 test 8667");
                }
                
                bscores_good = new LinkedList<double>();
                foreach (double x in bscores_good_to_send)
                {
                    bscores_good.AddLast(x);
                }

            }



            //private void check_minimality_all(int_matrix & A, DD & bss, module_collection & minimal_modules);
            private void check_minimality_all(ref List<List<int>> A, ref LinkedList<double> bss, ref module_collection minimal_modules)
            {
                Parameters.print_flag_subgraph = false;

                {
                    /* simplifying A*/
                    module_collection suggestion_mall = new module_collection(dim);
                    for (int i = 0; i < A.Count(); i++)
                    {
                        List<int> Ai = A[i];
                        suggestion_mall.insert(ref Ai, 1);
                        A[i] = Ai;
                    }

                    suggestion_mall.erase_included();
                    suggestion_mall.set_partition(ref A);
                }
                int counter = 0;
                while (A.Count() > 0)
                {
                    List<List<int>> suggestion_matrix = new List<List<int>>();
                    LinkedList<double> suggestion_bs = new LinkedList<double>();

                    check_minimality_matrix(ref A, ref bss, ref minimal_modules, ref suggestion_matrix, ref suggestion_bs, counter);

                    module_collection suggestion_mall = new module_collection(dim);
                    for (int i = 0; i < suggestion_matrix.Count(); i++)
                    {
                        List<int> suggestion_matrix_i = new List<int>();
                        suggestion_mall.insert(ref suggestion_matrix_i, 1);
                        suggestion_matrix[i] = suggestion_matrix_i;
                    }

                    suggestion_mall.erase_included();
                    suggestion_mall.set_partition(ref A);

                    bss = suggestion_bs;
                    ++counter;

                }
            }


            //private void check_minimality_matrix(int_matrix & A, DD & bss, module_collection & minimal_modules, int_matrix & suggestion_matrix, deque<double> & suggestion_bs, int counter);
            private void check_minimality_matrix(ref List<List<int>> A, ref LinkedList<double> bss, ref module_collection minimal_modules, ref List<List<int>> suggestion_matrix, ref LinkedList<double> suggestion_bs, int counter)
            {
                if (A.Count() > 4)
                {
                    System.Console.WriteLine("minimality check: {0}. modules to check, run: {1}", A.Count(), counter);
                    //system("PAUSE");
                }

                if (counter < Parameters.minimality_stopper)
                {
                    for (int i = 0; i < A.Count(); i++)
                    {
                        /*if(i%100==0)		
                            cout<<"checked: "<<i<<" modules.  Modules to check... "<<A.size() - i<<endl;*/
                        LinkedList<int> Ai = new LinkedList<int>();
                        foreach (int x in A[i])
                        {
                            Ai.AddLast(x);
                        }
                        double bssi = bss.ElementAt(i);

                        check_minimality(ref Ai, ref bssi, ref minimal_modules, ref suggestion_matrix, ref suggestion_bs);
                        A[i] = Ai.ToList<int>();
                        bss.Find(bss.ElementAt(i)).Value = bssi; // should work to replace.
                    }
                }
                else
                {
                    for (int i = 0; i < A.Count(); i++)
                    {
                        List<int> Ai = A[i];
                        minimal_modules.insert(ref Ai, bss.ElementAt(i));
                        A[i] = Ai;
                    }
                }
            }

            //private bool check_minimality(deque<int> & group, double & bs_group, module_collection & minimal_modules, int_matrix & suggestion_matrix, deque<double> & suggestion_bs);
            private bool check_minimality(ref LinkedList<int> group, ref double bs_group, ref module_collection minimal_modules, ref List<List<int>> suggestion_matrix, ref LinkedList<double> suggestion_bs)
            {
                /*	this function checks the minimality of group 
                    minimality means that group doesn't have internal structures up to a factor coverage_percentage_fusion_left
                    returns true is group is inserted in minimal_modules	*/
                List<List<int>> subM = new List<List<int>>();
                LinkedList<double> bss = new LinkedList<double>();

                {   //******************  module_subgraph stuff   ******************

                    List<List<int>> link_per_node = new List<List<int>>();
                    //LinkedList<LinkedList<KeyValuePair<int, double>>> weights_per_node = new LinkedList<LinkedList<KeyValuePair<int, double>>>();
                    List<List<KeyValuePair<int, double>>> weights_per_node = new List<List<KeyValuePair<int, double>>>();
                    List<int> group_to_send = group.ToList<int>();
                    set_subgraph(ref group_to_send, ref link_per_node, ref weights_per_node);
                    oslom_net_global module_subgraph = new oslom_net_global(ref link_per_node, ref weights_per_node, ref group_to_send);
                    group = new LinkedList<int>();
                    foreach (int x in group_to_send)
                    {
                        group.AddLast(x);
                    }

                    LinkedList<double> bscores_good_temp = new LinkedList<double>();
                    module_subgraph.single_gather(ref subM, ref bscores_good_temp);

                    for (int i = 0; i < (int)(subM.Count()); i++)
                    {
                        List<int> subMi = subM[i];
                        module_subgraph.deque_id(ref subMi);
                        subM[i] = subMi;

                        LinkedList<int> grbe = new LinkedList<int>();
                        LinkedList<int> subMiLL = new LinkedList<int>();
                        foreach (int x in subM[i])
                        {
                            subMiLL.AddLast(x);
                        }
                        bss.AddLast(CUP_check(subMiLL, ref grbe, Parameters.clean_up_runs));
                        subM[i] = grbe.ToList<int>();
                    }           /* so now you know these modules are cleaned (but you are not sure they are minimal) */

                }   //******************  module_subgraph stuff   ******************

                for (int i = 0; i < subM.Count(); i++)
                    if (subM[i].Count() == group.Count())
                    {
                        List<int> group_list_to_send = group.ToList<int>();
                        minimal_modules.insert(ref group_list_to_send, bs_group);
                        group = new LinkedList<int>();
                        foreach (int x in group_list_to_send)
                        {
                            group.AddLast(x);
                        }
                        return true;
                    }


                HashSet<int> a = new HashSet<int>();
                for (int i = 0; i < subM.Count(); i++)
                    for (int j = 0; j < (int)(subM[i].Count()); j++)
                    {
                        a.Add(subM[i][j]);
                    }

                if (a.Count() > Parameters.coverage_percentage_fusion_left * group.Count())
                {
                    /* this means the group cannot be accepted */

                    for (int i = 0; i < subM.Count(); i++)
                        if (subM[i].Count() > 0)
                        {
                            suggestion_matrix.Add(subM[i]);
                            suggestion_bs.AddLast(bss.ElementAt(i));
                        }
                    return false;
                }
                else
                {
                    List<int> group_to_send = group.ToList<int>();
                    minimal_modules.insert(ref group_to_send, bs_group);
                    group = new LinkedList<int>();
                    foreach (int x in group_to_send)
                    {
                        group.AddLast(x);
                    }
                    return true;
                }
            }

            //private int check_unions_and_overlap(module_collection & mall, bool only_similar = false);
            private int check_unions_and_overlap(ref module_collection mall, bool only_similar = false)
            {
                mall.put_gaps();

                if (mall.effective_groups() == 0)
                    return 0;


                //   cout << "checking similar modules" << endl << endl;
                System.Console.WriteLine("Checking similar modueles.");
                check_existing_unions(ref mall);

                if (only_similar == false)
                {

                    if (check_fusion_with_gather(ref mall))
                        check_fusion_with_gather(ref mall);
                }

                //cout << "checking highly intersecting modules" << endl << endl;
                System.Console.WriteLine("Checking highly intersecting modules");
                check_intersection(ref mall);
                mall.compute_inclusions();
                return 0;
            }


            //private void check_existing_unions(module_collection & mall);

            private void check_existing_unions(ref module_collection mall)
            {

                /* this function is to check unions of existing modules*/

                /* sorting from the biggest to the smallest module */
                /*cout<<"before check_existing_unions"<<endl;
                print_modules(false, cout, mall);*/

                LinkedList<int> sm = new LinkedList<int>();
                List<int> sm_to_send = sm.ToList<int>();
                mall.sort_modules(ref sm_to_send);
                sm = new LinkedList<int>();
                foreach (int x in sm_to_send)
                {
                    sm.AddLast(x);
                }

                /*cout<<"sm"<<endl;
                prints(sm);*/


                LinkedList<bool> still_good = new LinkedList<bool>();
                for (int i = 0; i < sm.Count(); i++)
                {
                    still_good.AddLast(true);
                }

                HashSet<int> modules_to_erase = new HashSet<int>();
                for (int i = 0; i < sm.Count(); i++)
                {
                    /* for each module I check if it's better to take it or its submodules */
                    //DI smaller;
                    LinkedList<int> smaller = new LinkedList<int>();
                    List<int> smaller_to_send = new List<int>();
                    mall.almost_equal(sm.ElementAt(i), ref smaller_to_send);
                    List<List<int>> its_submodules = new List<List<int>>();
                    for (int j = 0; j < smaller.Count(); j++)
                    {
                        if (still_good.ElementAt(smaller.ElementAt(j)))
                        {
                            its_submodules.Add(mall.modules[smaller.ElementAt(j)]);
                        }
                    }

                    /*cout<<"************************** module to check "<<sm[i]<<" size: "<<mall.modules[sm[i]].size()<<endl;
                    print_id(mall.modules[sm[i]], cout);
                    cout<<"its_submodules"<<endl;
                    print_id(its_submodules, cout);*/

                    // if (fusion_module_its_subs(mall.modules[sm[i]], its_submodules))
                    if (fusion_module_its_subs(mall.modules[sm.ElementAt(i)], ref its_submodules))
                    {
                        DN.List_to_set_app(smaller.ToList<int>(), ref modules_to_erase);
                        for (int j = 0; j < smaller.Count(); j++)
                            //still_good[smaller[j]] = false;
                            still_good.Find(still_good.ElementAt(smaller.ElementAt(j))).Value = false;
                    }
                    else
                    {
                        modules_to_erase.Add(sm.ElementAt(i));
                        still_good.Find(still_good.ElementAt(sm.ElementAt(i))).Value = false;
                    }
                }

                //for (set<int>:: iterator its = modules_to_erase.begin(); its != modules_to_erase.end(); its++)
                foreach (int its in modules_to_erase)
                    mall.erase(its);
                mall.compact();
                /*cout<<"after check_existing_unions --------------------------------------------------------"<<endl;
                print_modules(false, cout, mall);*/
            }

            //private bool fusion_module_its_subs(/*const*/ DI & A, int_matrix & its_submodules);
            private bool fusion_module_its_subs(/*const ref */ LinkedList<int> A, ref List<List<int>> its_submodules)
            {
                // A is supposed to be a good cluster
                // return true if A won against its submodules
                // ******************************************

                if (its_submodules.Count() < 2)
                    return true;
                LinkedList<int> group = new LinkedList<int>();
                from_int_matrix_and_deque_to_deque(ref its_submodules, A, ref group);


                {   //******************  sub_graph_module stuff   ******************



                    List<List<int>> link_per_node = new List<List<int>>();
                    List<List<KeyValuePair<int, double>>> weights_per_node = new List<List<KeyValuePair<int, double>>>();
                    List<int> group_to_send = group.ToList<int>();
                    set_subgraph(ref group_to_send, ref link_per_node, ref weights_per_node);

                    oslom_net_global sub_graph_module = new oslom_net_global(ref link_per_node, ref weights_per_node, ref group_to_send);
                    group = new LinkedList<int>();
                    foreach (int x in group_to_send)
                    {
                        group.AddLast(x);
                    }

                    sub_graph_module.translate(ref its_submodules);

                    //------------------------------------ cleaning up submodules --------------------------


                    module_collection sub_mall = new module_collection(sub_graph_module.dim);

                    for (int i = 0; i < its_submodules.Count(); i++)
                    {
                        List<int> its_submodulesi = its_submodules[i];
                        sub_mall.insert(ref its_submodulesi, 1e-3);
                        its_submodules[i] = its_submodulesi;
                    }

                    sub_mall.set_partition(ref its_submodules);

                    /*
                    cout<<"group*************************************************"<<endl;
                    print_id(group, cout);
                    cout<<"A"<<endl;
                    print_id(A, cout);
                    cout<<"fusion_module_its_subs"<<endl;
                    print_id(its_submodules, cout);
                    //*/

                    //------------------------------------ cleaning up submodules --------------------------

                    HashSet<int> a = new HashSet<int>();

                    for (int i = 0; i < its_submodules.Count(); i++)
                    {
                        LinkedList<int> grbe = new LinkedList<int>();
                        LinkedList<int> its_submodulesi = new LinkedList<int>();
                        foreach (int x in its_submodules[i])
                        {
                            its_submodulesi.AddLast(x);
                        }
                        sub_graph_module.CUP_check(its_submodulesi, ref grbe, Parameters.clean_up_runs);
                        //its_submodules[i] = its_submodulesi.ToList<int>();
                        DN.List_to_set_app(grbe.ToList<int>(), ref a);
                        //cout<<i<<" cleaned_up: "<<grbe.size()<<" "<<a.size()<<endl;

                        if (a.Count() > Parameters.coverage_percentage_fusion_or_submodules * A.Count())
                            return false;
                    }
                    //sub_graph_module.draw("sub");
                    //cherr();
                    return true;
                }   //******************  sub_graph_module stuff   ******************
            }
            private bool fusion_module_its_subs(/*const ref */ List<int> A, ref List<List<int>> its_submodules)
            {
                // A is supposed to be a good cluster
                // return true if A won against its submodules
                // ******************************************

                if (its_submodules.Count() < 2)
                    return true;
                LinkedList<int> group = new LinkedList<int>();
                from_int_matrix_and_deque_to_deque(ref its_submodules, A, ref group);


                {   //******************  sub_graph_module stuff   ******************



                    List<List<int>> link_per_node = new List<List<int>>();
                    List<List<KeyValuePair<int, double>>> weights_per_node = new List<List<KeyValuePair<int, double>>>();
                    List<int> group_to_send = group.ToList<int>();
                    set_subgraph(ref group_to_send, ref link_per_node, ref weights_per_node);

                    oslom_net_global sub_graph_module = new oslom_net_global(ref link_per_node, ref weights_per_node, ref group_to_send);
                    group = new LinkedList<int>();
                    foreach (int x in group_to_send)
                    {
                        group.AddLast(x);
                    }

                    sub_graph_module.translate(ref its_submodules);

                    //------------------------------------ cleaning up submodules --------------------------


                    module_collection sub_mall = new module_collection(sub_graph_module.dim);

                    for (int i = 0; i < its_submodules.Count(); i++)
                    {
                        List<int> its_submodulesi = its_submodules[i];
                        sub_mall.insert(ref its_submodulesi, 1e-3);
                        its_submodules[i] = its_submodulesi;
                    }

                    sub_mall.set_partition(ref its_submodules);

                    /*
                    cout<<"group*************************************************"<<endl;
                    print_id(group, cout);
                    cout<<"A"<<endl;
                    print_id(A, cout);
                    cout<<"fusion_module_its_subs"<<endl;
                    print_id(its_submodules, cout);
                    //*/

                    //------------------------------------ cleaning up submodules --------------------------

                    HashSet<int> a = new HashSet<int>();

                    for (int i = 0; i < its_submodules.Count(); i++)
                    {
                        LinkedList<int> grbe = new LinkedList<int>();
                        LinkedList<int> its_submodulesi = new LinkedList<int>();
                        foreach (int x in its_submodules[i])
                        {
                            its_submodulesi.AddLast(x);
                        }
                        sub_graph_module.CUP_check(its_submodulesi, ref grbe, Parameters.clean_up_runs);
                        //its_submodules[i] = its_submodulesi.ToList<int>();
                        DN.List_to_set_app(grbe.ToList<int>(), ref a);
                        //cout<<i<<" cleaned_up: "<<grbe.size()<<" "<<a.size()<<endl;

                        if (a.Count() > Parameters.coverage_percentage_fusion_or_submodules * A.Count())
                            return false;
                    }
                    //sub_graph_module.draw("sub");
                    //cherr();
                    return true;
                }   //******************  sub_graph_module stuff   ******************
            }


            //private bool fusion_with_empty_A(int_matrix & its_submodules, DI & grc1, double & bs);
            private bool fusion_with_empty_A(ref List<List<int>> its_submodules, ref LinkedList<int> A, ref double bs)
            {

                /*  
                    its_submodules are the modules to check. the question is if to take its_submodules or the union of them 
                    the function returns true if it's the union, grc1 is the union cleaned and bs the score
                 */

                LinkedList<int> group = new LinkedList<int>();
                from_int_matrix_and_deque_to_deque(ref its_submodules, A, ref group);

                //cout<<"trying a module of "<<group.size()<<" nodes"<<endl;
                //List<int> AList = A.ToList<int>();
                bs = CUP_check(group, ref A, Parameters.clean_up_runs);
                A = new LinkedList<int>();

                if (A.Count() <= Parameters.coverage_percentage_fusion_left * group.Count())
                {
                    A = new LinkedList<int>();//.clear();
                    bs = 1;
                    return false;
                }
                bool fus = fusion_module_its_subs(A, ref its_submodules);

                if (fus == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //private bool check_fusion_with_gather(module_collection & mall);
            private bool check_fusion_with_gather(ref module_collection mall)
            {
                /*	this function is used to check if we would like unions of modules 
                    returns true if it merges something	 */

                //   cout << "check unions of modules using community network" << endl << endl;
                System.Console.WriteLine("check unions of modules using community network");
                Parameters.print_flag_subgraph = true;

                mall.fill_gaps();
                Dictionary<int, Dictionary<int, KeyValuePair<int, double>>> neigh_weight_s = new Dictionary<int, Dictionary<int, KeyValuePair<int, double>>>();       // this maps the module id into the neighbor module ids and weights
                set_upper_network(ref neigh_weight_s, ref mall);

                if (neigh_weight_s.Count() == 0)
                    return false;

                bool wgather = true;
                bool real_paras_weighted = Parameters.weighted;

                if (wgather)
                {
                    //for (map<int, map<int, pair<int, double>>> :: iterator itm = neigh_weight_s.begin(); itm != neigh_weight_s.end(); itm++)
                    foreach (KeyValuePair<int, Dictionary<int, KeyValuePair<int, double>>> itm in neigh_weight_s)
                    {
                        //for (map<int, pair<int, double>>  :: iterator itm2 = itm->second.begin(); itm2 != itm->second.end(); itm2++)
                        foreach (KeyValuePair<int, KeyValuePair<int, double>> itm2 in itm.Value)
                        {
                            //itm2->second.first = 1;
                            //itm2 = new KeyValuePair<int, double>(1, itm2.Value.Value);
                            neigh_weight_s[itm.Key][itm2.Key] = new KeyValuePair<int, double>(1, itm2.Value.Value); //MCP: I THINK this works??
                        }
                    }
                    Parameters.weighted = true;
                }
                oslom_net_global community_net = new oslom_net_global(ref neigh_weight_s);
                List<List<int>> M_raw = new List<List<int>>();       /* M_raw contains the module_ids */
                community_net.collect_raw_groups_once(ref M_raw);

                Parameters.weighted = real_paras_weighted;

                bool something = false;
                List<List<int>> module_to_insert = new List<List<int>>();
                LinkedList<double> bs_to_insert = new LinkedList<double>();

                int fused_modules = 0;

                //cout << "possible fusions to check: " << M_raw.size() << endl;
                System.Console.WriteLine("possible fusions to check: {0}.", M_raw.Count());


                for (int i = 0; i < M_raw.Count(); i++)
                    if (M_raw[i].Count() > 1)
                    {
                        List<List<int>> ten = new List<List<int>>();
                        for (int j = 0; j < M_raw[i].Count(); j++)
                        {
                            ten.Add(mall.modules[M_raw[i][j]]);
                        }

                        //cout<<"trying fusion # "<<i<<" "<<ten.size()<<" modules to merge"<<endl;

                        //DI grc1;
                        LinkedList<int> grc1 = new LinkedList<int>();
                        double bs = new double();
                        if (fusion_with_empty_A(ref ten, ref grc1, ref bs))
                        {
                            something = true;
                            module_to_insert.Add(grc1.ToList<int>());
                            ++fused_modules;
                            bs_to_insert.AddLast(bs);
                        }


                        if (i % 100 == 0)
                            //cout << "checked " << i << " unions. Fused: " << fused_modules << endl;
                            System.Console.WriteLine("Checked {0} unions. Fused: {1}.", i, fused_modules);
                    }

                for (int i = 0; i < module_to_insert.Count(); i++)
                {
                    List<int> module_to_insert_i = module_to_insert[i];
                    mall.insert(ref module_to_insert_i, bs_to_insert.ElementAt(i));
                    module_to_insert[i] = module_to_insert_i;
                }

                mall.compute_inclusions();
                return something;
            }


            //private int check_intersection(module_collection & Mcoll);
            private int check_intersection(ref module_collection Mcoll)
            {
                Parameters.print_flag_subgraph = false;

                LinkedList<int> to_check = new LinkedList<int>();
                //for (map<int, double>::iterator itM = Mcoll.module_bs.begin(); itM != Mcoll.module_bs.end(); itM++)
                foreach (KeyValuePair<int, double> itM in Mcoll.module_bs)
                {
                    to_check.AddLast(itM.Key);
                }

                return check_intersection(ref to_check, ref Mcoll);

            }

            //private int check_intersection(deque<int> & to_check, module_collection & Moll);
            private int check_intersection(ref LinkedList<int> to_check, ref module_collection Mcoll)
            {
                HashSet<KeyValuePair<int, int>> pairs_to_check = new HashSet<KeyValuePair<int, int>>();

                //for (deque<int>::iterator itM = to_check.begin(); itM != to_check.end(); itM++)
                foreach (int itM in to_check)
                    //if (Mcoll.module_bs.find(itM) != Mcoll.module_bs.end())
                    if (Mcoll.module_bs.ContainsKey(itM))
                    {
                        List<int> c = Mcoll.modules[itM];
                        LinkedList<int> cLL = new LinkedList<int>();
                        foreach (int x in c)
                        {
                            cLL.AddLast(x);
                        }
                        Dictionary<int, int> com_ol = new Dictionary<int, int>();                       // it maps the index of the modules into the overlap (overlap=number of overlapping nodes)

                        for (int i = 0; i < c.Count(); i++)
                            //for (set<int>:: iterator itj = Mcoll.memberships[c[i]].begin(); itj != Mcoll.memberships[c[i]].end(); itj++)
                            foreach (int itj in Mcoll.memberships[c[i]])
                                Histograms.int_histogram(itj, ref com_ol);

                        //for (map<int, int> :: iterator cit = com_ol.begin(); cit != com_ol.end(); cit++)
                        foreach (KeyValuePair<int, int> cit in com_ol)
                        {
                            if (cit.Key != itM)
                            {
                                if ((double)(cit.Value / Math.Min(Mcoll.modules[cit.Key].Count(), c.Count())) > Parameters.check_inter_p)
                                {       // they have a few nodes in common
                                    //pairs_to_check.insert(make_pair(min(*itM, cit->first), max(*itM, cit->first)));
                                    pairs_to_check.Add(new KeyValuePair<int, int>(Math.Min(itM, cit.Key), Math.Max(itM, cit.Key)));
                                }
                            }
                        }
                    }
                return fusion_intersection(ref pairs_to_check, ref Mcoll);
            }



            //private int fusion_intersection(set<pair<int, int>> & pairs_to_check, module_collection & Mcoll);
            private int fusion_intersection(ref HashSet<KeyValuePair<int, int>> pairs_to_check, ref module_collection Mcoll)
            {
                //cout << "pairs to check: " << pairs_to_check.size() << endl;
                System.Console.WriteLine("Pairs to check: {0}.", pairs_to_check.Count());

                LinkedList<int> new_insertions = new LinkedList<int>();

                //for (set<pair<int, int>>::iterator ith = pairs_to_check.begin(); ith != pairs_to_check.end(); ith++)
                foreach (KeyValuePair<int, int> ith in pairs_to_check)
                    if (ith.Key < ith.Value)
                        if (Mcoll.module_bs.ContainsKey(ith.Key))
                            if (Mcoll.module_bs.ContainsKey(ith.Value))
                            {
                                //		first, you need to check if both the modules in the pair are still in mcoll
                                LinkedList<int> a1 = new LinkedList<int>(); //Mcoll.modules[ith.Key];
                                foreach (int x in Mcoll.modules[ith.Key])
                                {
                                    a1.AddLast(x);
                                }
                                LinkedList<int> a2 = new LinkedList<int>();//Mcoll.modules[ith.Value];
                                foreach (int x in Mcoll.modules[ith.Value])
                                {
                                    a2.AddLast(x);
                                }
                                int min_s = Math.Min(a1.Count(), a2.Count());
                                LinkedList<int> group_intsec = new LinkedList<int>();
                                //set_intersection(a1.begin(), a1.end(), a2.begin(), a2.end(), back_inserter(group_intsec));
                                //MCP note that intersect does the same thing whether a1 intersect a2, or a2 intersect a1...
                                List<int> group_intsec_list = new List<int>();
                                group_intsec_list = a1.Intersect(a2).ToList<int>();
                                group_intsec = new LinkedList<int>();
                                foreach (int i in group_intsec)
                                {
                                    group_intsec.AddLast(i);
                                }

                                //		if they are, you need to check if they are not almost equal.


                                if ((double)(group_intsec.Count()) / min_s >= Parameters.coverage_inclusion_module_collection)
                                {
                                    int em = ith.Key;
                                    if (a1.Count() < a2.Count())
                                        em = ith.Value;
                                    else if (a1.Count() == a2.Count() && Mcoll.module_bs[ith.Key] > Mcoll.module_bs[ith.Value])
                                        em = ith.Value;

                                    Mcoll.erase(em);
                                }
                                else
                                    decision_fusion_intersection(ith.Key, ith.Value, ref new_insertions, ref Mcoll, (double)(group_intsec.Count()) / min_s);
                            }


                if (new_insertions.Count() > 0)
                    return check_intersection(ref new_insertions, ref Mcoll);

                return 0;
            }

            //private bool decision_fusion_intersection(int ai1, int ai2, deque<int> & new_insertions, module_collection & Mcoll, double prev_over_percentage);

            private bool decision_fusion_intersection(int ai1, int ai2, ref LinkedList<int> new_insertions, ref module_collection Mcoll, double prev_over_percentage)
            {
                //deque < int > &a1 = Mcoll.modules[ai1];
                //deque < int > &a2 = Mcoll.modules[ai2];
                List<int> a1 = Mcoll.modules[ai1];
                LinkedList<int> a1ll = new LinkedList<int>();
                foreach (int i in a1)
                {
                    a1ll.AddLast(i);
                }
                List<int> a2 = Mcoll.modules[ai2];
                LinkedList<int> a2ll = new LinkedList<int>();
                foreach (int i in a2)
                {
                    a2ll.AddLast(i);
                }

                LinkedList<int> group = new LinkedList<int>();
                List<int> group_as_list = group.ToList<int>();
                //set_union(a1.begin(), a1.end(), a2.begin(), a2.end(), back_inserter(group));
                List<int> group2 = new List<int>();
                group2 = a1.Union(a2).ToList<int>();
                group = new LinkedList<int>();
                foreach (int i in group2)
                {
                    group.AddLast(i);
                }

                if ((int)(group.Count()) != dim)
                {           //******************  sub_graph_module stuff   ******************

                    //deque<deque<int>> link_per_node;
                    List<List<int>> link_per_node = new List<List<int>>();
                    //deque<deque<pair<int, double>>> weights_per_node;
                    List<List<KeyValuePair<int, double>>> weights_per_node = new List<List<KeyValuePair<int, double>>>();
                    set_subgraph(ref group, ref link_per_node, ref weights_per_node);
                    oslom_net_global sub_graph_module = new oslom_net_global(ref link_per_node, ref weights_per_node, ref group_as_list);
                    group = new LinkedList<int>();
                    foreach (int x in group_as_list)
                    {
                        group.AddLast(x);
                    }

                    //deque<deque<int>> A;
                    List<List<int>> A = new List<List<int>>();
                    A.Add(a1);
                    A.Add(a2);

                    sub_graph_module.translate(ref A);

                    //deque<int> grc1;
                    LinkedList<int> grc1 = new LinkedList<int>();
                    double bs = sub_graph_module.CUP_check(A[0], ref grc1, Parameters.clean_up_runs);
                    //deque<int> grc2;
                    LinkedList<int> grc2 = new LinkedList<int>();
                    bs = sub_graph_module.CUP_check(A[1], ref grc2, Parameters.clean_up_runs);

                    //deque<int> unions_grcs;
                    LinkedList<int> unions_grcs = new LinkedList<int>();
                    List<int> unions_grcs_list = new List<int>();
                    //set_union(grc1.begin(), grc1.end(), grc2.begin(), grc2.end(), back_inserter(unions_grcs));

                    if (unions_grcs.Count() <= Parameters.coverage_percentage_fusion_or_submodules * group.Count())
                    {       // in such a case you can take the fusion (if it's good)

                        /* actually the right check should be  unions_grcs.size() > paras.coverage_percentage_fusion_or_submodules*group_2.size() 
                           but this would require more time - it should not make a big difference anyway */

                        //deque<int> group_2;
                        LinkedList<int> group_2 = new LinkedList<int>();
                        bs = CUP_check(group, ref group_2, Parameters.clean_up_runs);

                        if (group_2.Count() > Parameters.coverage_percentage_fusion_left * group.Count())
                        {
                            Mcoll.erase(ai1);
                            Mcoll.erase(ai2);
                            //int_matrix _A_;
                            List<List<int>> _A_ = new List<List<int>>();
                            //DD _bss_;
                            LinkedList<double> _bss_ = new LinkedList<double>();
                            _A_.Add(group_2.ToList<int>());
                            _bss_.AddLast(bs);
                            check_minimality_all(ref _A_, ref _bss_, ref Mcoll);
                            return true;
                        }
                        else
                            return false;
                    }


                    sub_graph_module.deque_id(ref grc1);
                    sub_graph_module.deque_id(ref grc2);

                    //deque<int> cg1;
                    LinkedList<int> cg1 = new LinkedList<int>();
                    double bs__1 = CUP_check(grc1, ref cg1, Parameters.clean_up_runs);

                    //deque<int> cg2;
                    LinkedList<int> cg2 = new LinkedList<int>();
                    double bs__2 = CUP_check(grc2, ref cg2, Parameters.clean_up_runs);

                    //deque<int> inters;
                    LinkedList<int> inters = new LinkedList<int>();
                    List<int> intersList = new List<int>();
                    //set_intersection(cg1.begin(), cg1.end(), cg2.begin(), cg2.end(), back_inserter(inters));
                    intersList = cg1.Intersect(cg2).ToList<int>();
                    foreach (int i in intersList)
                    {
                        inters.AddLast(i);
                    }

                    //deque<int> unions;
                    LinkedList<int> unions = new LinkedList<int>();
                    List<int> unionsList = new List<int>();
                    //set_union(cg1.begin(), cg1.end(), cg2.begin(), cg2.end(), back_inserter(unions));
                    unionsList = cg1.Union(cg2).ToList<int>();
                    foreach (int i in unionsList)
                    {
                        unions.AddLast(i);
                    }

                    if ((double)(inters.Count()) / Math.Min(cg1.Count(), cg2.Count()) < prev_over_percentage - 1e-4)
                    {
                        if (cg1.Count() > 0 && cg2.Count() > 0 && (unions.Count() > Parameters.coverage_percentage_fusion_left * group.Count()))
                        {
                            Mcoll.erase(ai1);
                            Mcoll.erase(ai2);
                            int newi = new int();
                            List<int> cg1l = cg1.ToList<int>();
                            List<int> cg2l = cg2.ToList<int>();
                            Mcoll.insert(ref cg1l, bs__1, ref newi);
                            cg1 = new LinkedList<int>();
                            foreach (int i in cg1l)
                            {
                                cg1.AddLast(i);
                            }
                            new_insertions.AddLast(newi);

                            Mcoll.insert(ref cg2l, bs__2, ref newi);
                            cg2 = new LinkedList<int>();
                            foreach (int i in cg2l)
                            {
                                cg2.AddLast(i);
                            }
                            new_insertions.AddLast(newi);

                            //cout<<"pruned module"<<endl;

                            return true;
                        }
                    }
                }
                return false;
            }


            //MCP: Print functions Ignoring for now.
            private class printFunctionsToIgnoreForTheMoment
            {
                /*
                void oslom_net_global::print_modules(bool not_homeless, string tp, module_collection & Mcoll)
                {



                    char b[1000];
                    cast_string_to_char(tp, b);
                    ofstream out1(b);

                    print_modules(not_homeless, out1, Mcoll);




                }


                void oslom_net_global::print_modules(bool not_homeless, ostream & out1, module_collection & Mcoll)
                {


                    int nmod = 0;
                    for (map<int, double>::iterator itm = Mcoll.module_bs.begin(); itm != Mcoll.module_bs.end(); itm++)
                        if (Mcoll.modules[itm.Key].size() > 1)
                            nmod++;

                    cout << "******** module_collection ******** " << nmod << " modules. writing... " << endl;
                    //system("PAUSE");

                    deque<int> netlabs;
                    for (int i = 0; i < dim; i++)
                        netlabs.push_back(id_of(i));

                    Mcoll.print(out1, netlabs, not_homeless);
                    cout << "DONE   ****************************" << endl;
                    //system("PAUSE");

                }


                void oslom_net_global::load(string filename, module_collection & Mall)
                {


                    // this function is to read a file in the tp-format


                    cout << "getting partition from tp-file: " << filename << endl;
                    deque<double> bss;
                    deque<deque<int>> A;

                    get_partition_from_file_tp_format(filename, A, bss);
                    translate(A);

                    cout << A.size() << " groups found" << endl;
                    cout << bss.size() << " bss found" << endl;


                    for (UI ii = 0; ii < A.size(); ii++)
                    {
                        //cout<<"inserting group number "<<ii<<" size: "<<A[ii].size()<<endl;
                        Mall.insert(A[ii], bss[ii]);

                    }




                }

                void oslom_net_global::get_covers(string cover_file, int & soft_partitions_written, int gruns)
                {

                    /* this function is to collect different covers of the network
                       they are written in file cover_file (appended)
                       their number is added to soft_partitions_written //


                    char b[1000];
                    cast_string_to_char(cover_file, b);
                    ofstream out1(b, ios::app);


                    for (int i = 0; i < gruns; i++)
                    {

                        cout << "***************************************************************** RUN: #" << i + 1 << endl;

                        module_collection Mcoll(dim);
                        get_cover(Mcoll);

                        if (Mcoll.size() > 0)
                        {
                            print_modules(true, out1, Mcoll);               // not homeless nodes
                            soft_partitions_written++;
                        }
                    }

                    if (paras.value)
                    {

                        module_collection Mcoll(dim);
                        hint(Mcoll, paras.file2);

                        if (Mcoll.size() > 0)
                        {
                            print_modules(true, out1, Mcoll);               // not homeless nodes
                            soft_partitions_written++;
                        }
                    }


                    if (paras.value_load)
                    {

                        module_collection Mcoll(dim);
                        load(paras.file_load, Mcoll);

                        if (Mcoll.size() > 0)
                        {
                            print_modules(true, out1, Mcoll);               // not homeless nodes
                            soft_partitions_written++;
                        }
                    }


                }
                void oslom_net_global::ultimate_cover(string cover_file, int soft_partitions_written, string final_cover_file)
                {


                    cout << "pruning all the modules collected. Partitions found: " << soft_partitions_written << endl;
                    module_collection Mall(dim);
                    load(cover_file, Mall);

                    if (soft_partitions_written > 1)
                        check_unions_and_overlap(Mall, true);

                    cout << "checking homeless nodes" << endl;
                    if (paras.homeless_anyway == false)
                    {
                        try_to_assign_homeless(Mall, false);
                    }
                    else
                    {

                        deque<int> homel;
                        Mall.homeless(homel);

                        UI before_procedure = homel.size();

                        while (homel.size() > 0)
                        {

                            cout << "assigning homeless nodes. Homeless at this point: " << before_procedure << endl;

                            try_to_assign_homeless(Mall, true);
                            Mall.homeless(homel);
                            if (homel.size() >= before_procedure)
                                break;
                            before_procedure = homel.size();

                        }

                    }


                    Mall.fill_gaps();
                    cout << "writing final solution in file " << final_cover_file << endl;
                    print_modules(false, final_cover_file, Mall);               // homeless nodes printed


                }

                void oslom_net_global::hint(module_collection & minimal_modules, string filename)
                {



                    int_matrix good_modules_to_prune;
                    deque<double> bscores_good;


                    cout << "getting partition from file: " << filename << endl;
                    int_matrix A;

                    get_partition_from_file(filename, A);

                    translate(A);

                    cout << A.size() << " groups found" << endl;

                    for (int ii = 0; ii < int(A.size()); ii++)
                    {

                        deque<int> group;

                        cout << "processing group number " << ii << " size: " << A[ii].size() << endl;

                        double bcu = CUP_both(A[ii], group);

                        if (group.size() > 0)
                        {
                            good_modules_to_prune.push_back(group);
                            bscores_good.push_back(bcu);
                        }
                        else
                            cout << "bad group" << endl;


                    }


                    cout << "***************************************************************************" << endl;
                    from_matrix_to_module_collection(good_modules_to_prune, bscores_good, minimal_modules);



                }
                void oslom_net_global::print_statistics(ostream & outt, module_collection & Mcoll)
                {


                    int nmod = 0;
                    UI cov = 0;


                    for (map<int, double>::iterator itm = Mcoll.module_bs.begin(); itm != Mcoll.module_bs.end(); itm++)
                        if (Mcoll.modules[itm.Key].size() > 1)
                        {
                            nmod++;
                            cov += Mcoll.modules[itm.Key].size();
                        }


                    deque<int> homel;
                    Mcoll.homeless(homel);



                    outt << "number of modules: " << nmod << endl;
                    outt << "number of covered nodes: " << dim - homel.size() << " fraction of homeless nodes: " << double(homel.size()) / dim << endl;
                    outt << "average number of memberships of covered nodes: " << double(cov) / (dim - homel.size()) << endl;


                    outt << "average community size: " << double(cov) / nmod << endl;

                    print_degree_of_homeless(homel, outt);

                }*/
            }


        }
    }
    //MCP 8-4-17 Include hierarchies.h; but all the functions deal with filestreams / files / directories. So, not right now.
    public static class hierarchies
    {
        public static bool manipulate_string(string s, string netfile, ref string outs)
        {


            //outs.clear();
            //outs = new string(null);
            //outs = string.Empty;
            outs.Remove(0);
            string find_s = "NETx";
            bool netx_found = false;
            int jj = 0;
            string tmp = string.Empty;

            for (int j = 0; j < s.Count(); j++)
            {
                //tmp.push_back(s[j]);
                tmp += s[j];


                if (s[j] == find_s[jj])
                {
                    ++jj;
                    if (jj == (int)(find_s.Count()))
                    {
                        netx_found = true;
                        //tmp.clear();
                        tmp.Remove(0);
                        outs += netfile;
                    }
                }
                else
                {
                    jj = 0;
                    outs += tmp;
                    //tmp.clear();
                    tmp.Remove(0);
                }
            }
            return netx_found;
        }




        /* this function is to call a different program */
        public static void external_program_to_call(string network_file, ref oslom_net_global_h.oslom_net_global matteo, string plz_out, ref int soft_partitions_written)
        {

            int sy;

            string b = string.Empty ;//new char[1000];
            //cast.cast_string_to_char(plz_out, ref b);
            b = plz_out;
            //ofstream out1(b, ios::app);
            //System.IO.File out1 = new System.IO.File(b);
            //System.IO.FileStream out1 = System.IO.File.OpenWrite(b.ToString());
            System.IO.StreamWriter out1 = new System.IO.StreamWriter(b.ToString());
            for (int ei = 0; ei < Parameters.to_run.Count(); ei++)
            {
                string output_string = string.Empty;
                if (manipulate_string(Parameters.to_run[ei], network_file, ref output_string) == false)
                {
                    System.Console.WriteLine("In string: {0}, keyword NETx was missing. The string cannot be run",Parameters.to_run[ei]);
                }
                else
                {
                    string to_run_p = String.Empty;
                    manipulate_string(Parameters.to_run_part[ei], network_file, ref to_run_p);

                    string exec_this = string.Empty ;//new char[2000];
                    //cast.cast_string_to_char(output_string, ref exec_this);
                    exec_this = output_string;

                    System.Console.WriteLine("running {0}", exec_this);
                    //sy = system(exec_this);

                    module_collection Mcoll = new module_collection(matteo.size());
                    matteo.hint(ref Mcoll, to_run_p);

                    if (Mcoll.size() > 0)
                    {
                        matteo.print_modules(true, ref out1, ref Mcoll);                // not homeless nodes	
                        soft_partitions_written++;
                    }

                }

            }



        }
        public static void translate_covers(string previous_tp, string new_tp, string short_tp, /*ostream & */ ref System.IO.StreamWriter stout, int dim)
        {
            List<List<int>> M = new List<List<int>>();
            partition.get_partition_from_file_tp_format(previous_tp, ref M, true);
            string b = string.Empty ;//new char[1000];
            //cast.cast_string_to_char(new_tp, ref b);
            b = new_tp;
            //ofstream outt(b);
            System.IO.StreamWriter outt = new System.IO.StreamWriter(b.ToString());

            List<List<int>> M2 = new List<List<int>>();
            LinkedList<double> bs2 = new LinkedList<double>();

            partition.get_partition_from_file_tp_format_with_homeless(short_tp, ref M2, ref bs2);
            
            int nmod = 0;
            int cov = 0;
            int nhom = 0;


            for (int i = 0; i < M2.Count(); i++)
            {
                HashSet<int> S = new HashSet<int>();
                for (int j = 0; j < M2[i].Count(); j++)
                    DN.deque_to_set_app(M[M2[i][j]], ref S);

                outt.WriteLine("#module {0} Size: {1} bs: {2}" ,i ,S.Count() ,bs2.ElementAt(i));

                //for (set<int>:: iterator its = S.begin(); its != S.end(); its++)
                foreach(int its in S)
                {
                    outt.Write(" {0}",its);
                }
                outt.WriteLine("");
                if (S.Count() > 1)
                {
                    ++nmod;
                    cov += S.Count();
                }
                if (S.Count() == 1)
                    ++nhom;
            }
            stout.WriteLine("number of modules: {0}",nmod);
            stout.WriteLine("number of covered nodes: {0} fraction of homeless nodes: " ,dim - nhom,(double)(nhom)/dim);
            stout.WriteLine("average number of memberships of covered nodes: {0}",(double)(cov) / (dim - nhom));
            stout.WriteLine("average community size: {0}",(double)(cov) / nmod);
        }
        public static void no_singletons(string directory_char, ref oslom_net_global_h.oslom_net_global luca, ref module_collection Mcoll)
        {
            if (Parameters.homeless_anyway == false)
            {
                //deque<set<int>> memberships_;
                List<HashSet<int>> memberships_ = new List<HashSet<int>>();
                //deque<deque<int>> modules_;
                List<List<int>> modules_ = new List<List<int>>();
                Dictionary<int, double> module_bs_ = new Dictionary<int, double>();

                memberships_ = Mcoll.memberships;
                modules_ = Mcoll.modules;
                module_bs_ = Mcoll.module_bs;

                List<int> homel = new List<int>();
                Mcoll.homeless(ref homel);

                int before_procedure = homel.Count();

                while (homel.Count() > 0)
                {
                    luca.try_to_assign_homeless(ref Mcoll, true);
                    Mcoll.homeless(ref homel);
                    if (homel.Count() >= before_procedure)
                        break;
                    before_procedure = homel.Count();
                }

                string char_to_use = string.Empty ;//new char[1000];
                /*sprintf*/ string.Format(char_to_use.ToString(), "%s_oslo_files/tp_without_singletons", directory_char); //shouldn't one of these be by reference...?
                luca.print_modules(false, char_to_use.ToString(), ref Mcoll);              // homeless nodes printed

                Mcoll.memberships = memberships_;
                Mcoll.modules = modules_;
                Mcoll.module_bs = module_bs_;


            }

        }
        public static bool write_tp_of_this_level(int level, ref oslom_net_global_h.oslom_net_global luca, string directory_char, int original_dim)
        { //mcp 8-28-17
            System.Console.WriteLine("Write_tp...");
            //cout << "Write_tp_of_this_level" << endl;

            /*	this function is to compute the hierarchies 
                it returns false when the process can be stopped 
                luca will be set equal to the next network to run	*/

            int csy = new int();

            string char_to_use = string.Empty ;//new char[1000];
            //sprintf(char_to_use, "%s_oslo_files/partitions_level_%d", directory_char, level);
            //mcp 8-28-17 string.Format(char_to_use.ToString(), "%s_oslo_files/partitions_level_%d", directory_char, level);
            char_to_use = "oslo_files/partitions_level" + directory_char.ToString() + level.ToString();
            System.Console.WriteLine(char_to_use);
            string tps = char_to_use.ToString();
            System.Console.WriteLine("char to use: {0}", char_to_use.ToString());
            if (level == 0){
                //sprintf(char_to_use, "%s_oslo_files/tp", directory_char);
                string.Format(char_to_use.ToString(), "%s_oslo_files/tp", directory_char);
            }
            else
                //sprintf(char_to_use, "%s_oslo_files/short_tp%d", directory_char, level);
                string.Format(char_to_use.ToString(), "%s_oslo_files/short_tp%d", directory_char, level);
            string tp_ultimate = char_to_use.ToString();


            /*********   GETTING COVERS  ***********/

            int soft_partitions_written = 0;
            if (level == 0){
                System.Console.WriteLine("Iffing");//mcp 8-28-17 //mcp 8-28-17: Problems immediately follow.
                System.IO.Directory.CreateDirectory("oslo_files/short_tp");
                luca.get_covers(tps, ref soft_partitions_written, Parameters.Or);      //mcp 8-28 probs here              // here we get covers, which are written in file tps -without homeless-
                System.Console.WriteLine("Continued Iffing");//mcp 8-28-17
                external_program_to_call(Parameters.file1, ref luca, tps, ref soft_partitions_written);
                
                external_program_to_call(Parameters.file1, ref luca, tps, ref soft_partitions_written);
                System.Console.WriteLine("End Iffing");//mcp 8-28-17
            }
            else
            {
                Parameters.homeless_anyway = false;
                Parameters.value = false;
                Parameters.value_load = false;
                luca.get_covers(tps, ref soft_partitions_written, Parameters.hier_gather_runs);      // here we get covers, which are written in file tps -without homeless-
            }
            /*********   GETTING COVERS   ***********/



            /*********   extrenal programs ***********/


            if (level == 0)
            {
                
                
            }
            else if (Parameters.to_run.Count() > 0)
            {
                System.Console.WriteLine("copying network file to the main folder");

                string char_to_copy = string.Empty ;//new char[1000];
                string.Format(char_to_copy.ToString(), "cp %s_oslo_files/net%d oslo_network_h", directory_char, level);
                //csy = system(char_to_copy);
                external_program_to_call("oslo_network_h", ref luca, tps, ref soft_partitions_written);
            }
            /*********   extrenal programs ***********/
            luca.ultimate_cover(tps, soft_partitions_written, tp_ultimate);                 //here we get the final cover, which is written in file tp_(level) -with homeless-
            if (level == 0)
            {
                string.Format(char_to_use.ToString(), "cp %s_oslo_files/tp tp", directory_char);
                //csy = system(char_to_use);
            }

            /* now we get the clusters from the file */

            List<List<int>> A = new List<List<int>>();
            LinkedList<double> bs2 = new LinkedList<double>();
            partition.get_partition_from_file_tp_format_with_homeless(tp_ultimate, ref A,ref bs2);
            module_collection mall = new module_collection(luca.size());

            luca.translate(ref A);

            for (int ii = 0; ii < A.Count(); ii++) {
                List<int> Aii = A[ii];
                mall.insert(ref Aii, bs2.ElementAt(ii));
            }

            if (level == 0)
                no_singletons(directory_char, ref luca, ref mall);

            string.Format(char_to_use.ToString(), "%s_oslo_files/statistics_level_%d.dat", directory_char, level);
            //ofstream stout(char_to_use);
            System.IO.StreamWriter stout = new System.IO.StreamWriter(char_to_use.ToString());
            if (level == 0)
                luca.print_statistics(ref stout, ref mall);

            /* now we construct the community network */
            Dictionary< int, Dictionary< int, KeyValuePair< int, double> > > neigh_weight_s = new Dictionary<int, Dictionary<int, KeyValuePair<int, double>>>();       // this maps the module id into the neighbor module ids and weights
            luca.set_upper_network(ref neigh_weight_s, ref mall);
            if (level != 0 && (int)(neigh_weight_s.Count()) != luca.size())
            {
                // I need to translate the file short_tp%d into tp%d using the content of tp%d-1
                if (level == 1)
                    //sprintf(char_to_use, "%s_oslo_files/tp", directory_char);
                    string.Format(char_to_use.ToString(), "%s_oslo_files/tp", directory_char);
                else
                    string.Format(char_to_use.ToString(), "%s_oslo_files/tp%d", directory_char, level - 1);
                string previous_tp = char_to_use.ToString();
                string.Format(char_to_use.ToString(), "%s_oslo_files/tp%d", directory_char, level);
                string new_tp = char_to_use.ToString();
                translate_covers(previous_tp, new_tp, tp_ultimate, ref stout, original_dim);
            }
            double previous_dim = luca.size();

            luca.set_graph(ref neigh_weight_s);
            string.Format(char_to_use.ToString(), "%s_oslo_files/net%d", directory_char, level + 1);
            string net_level=char_to_use.ToString();
            if (previous_dim != luca.size())
                luca.draw(net_level);
            if (neigh_weight_s.Count() == 0)
                return false;

            if (neigh_weight_s.Count() >= (1.0- Parameters.hierarchy_convergence) * previous_dim || neigh_weight_s.Count() <= 2)
            {

                System.Console.WriteLine("hierarchies done ********* ");
                return false;
            }
            
            return true;
        }



        public static void oslom_level(ref oslom_net_global_h.oslom_net_global luca, string directory_char)
        {
            int level = 0;
            int original_dim = 0;
            while (true)
            {

                //cout << "network:: " << luca.size() << " nodes and " << luca.stubs() << " stubs;\t average degree = " << luca.stubs() / luca.size() << endl;
                System.Console.WriteLine("Network:: {0} nodes and {1} stubs; \t average degree = {2}", luca.size(), luca.stubs(), (luca.stubs() / luca.size()));
                System.Console.WriteLine(luca.stubs());
                if (level == 0)
                    original_dim = luca.size();
                System.Console.WriteLine("STARTING! HIERARCHICAL LEVEL: {0}",level);
                if (write_tp_of_this_level(level, ref luca, directory_char, original_dim) == false)
                    break;
                //cout << "Back from Level." << endl;
                //system("PAUSE");
                ++level;
            }
        }
    }
}