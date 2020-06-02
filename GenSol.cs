using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace GenSol
{
    public class Program
    {
        public static Program instance;
        private static string putchToGr;
       // private static string putchFinal;
        public static Loader _loader;
        public static List<FerstGen> ferstGens = new List<FerstGen>();
        public static List<Solution> bestTrade = new List<Solution>();
      
        public static void Main(string[] args)
        {

            //instance = this;
            //Console.WriteLine("input");

            if (args.Length == 0)
            {
                //putchToGr = @"D:\2.gr";
              //putchFinal = @"C:\Users\Asus\Desktop\2out.tree";
                //string temp = Console.ReadLine();
              //  throw new Exception(temp + "no ag");
               // putchToGr = temp;                
            }
            else
            {
               // putchToGr = args[0];
                //Console.WriteLine(args[0]);
               //putchFinal = args[1];
               
            }

            //Console.WriteLine(putchToGr);
            _loader = new Loader();
            //_loader.Load(putchToGr);
            _loader.Input();

        }





        public static void Final(Solution sol)
        {
            _loader.Saver(sol, string.Empty);
        }

        public static void Execute()
        {
            //Console.WriteLine("execute");
            Random rand = new Random();
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
            ferstGens.Add(new FerstGen(1024, _loader.g, rand));
        }
    }


    public class Loader
    {
        public G g = null;

        public void Input()
        {
            string result = null;
            string temp;
            temp = Console.ReadLine();
            while(!temp.Contains("p tdp"))
            {
                temp = Console.ReadLine();
            }
            temp = temp.Substring(6);
            string subString2 = " ";
            string[] arr = temp.Split(" ");
            int index2 = temp.IndexOf(subString2);
            temp = temp.Substring(index2, temp.Length - index2);
            result = temp;
            g = new G(int.Parse(arr[0]) + 1);

            for (int i = 0; i < int.Parse(arr[1]); i++)
            {
                if (SetV() == false)
                {
                    Console.WriteLine("eer");
                    i--;
                }
            }
            Program.Execute();
        }
        public bool SetV()
        {
            string temp = Console.ReadLine();

            string[] arr = temp.Split(" ");
            if (arr.Length == 2)
            {

                //int indexV = temp.IndexOf(subString);
                string indexVStr = arr[0];
                string indexVStr2 = arr[1];
                g.SetBindingInV(int.Parse(indexVStr), int.Parse(indexVStr2));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Load(string path)
        {
            //path = Path.GetFullPath(path);
            //await Task.Run(() => Read(path));
            Read(path);

        }

        public void Read(string path)
        {
            // Console.WriteLine("load");
            string writePath = path;
            List<string> list = new List<string>();
            string result = null;

            using (StreamReader sr = new StreamReader(writePath))
            {
                int count = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        line = line.Substring(6);
                        string subString2 = " ";
                        int index2 = line.IndexOf(subString2);
                        line = line.Substring(0, index2);
                        result = line;
                        g = new G(int.Parse(result));

                    }
                    else
                    {
                        string subString = " ";
                        int indexV = line.IndexOf(subString);
                        string indexVStr = line.Substring(0, indexV);
                        string indexVStr2 = line.Substring(indexV + 1);
                        g.SetBindingInV(int.Parse(indexVStr), int.Parse(indexVStr2));

                    }
                    count++;

                }

            }
            // Console.WriteLine("load2");
            Program.Execute();

        }

        public void Saver(Solution sol, string Patch)
        {
            string PuthOutput = "C:/Users/Oleg/Desktop/out.tree";
            if (Patch == string.Empty)
            {
                PuthOutput = "C:/Users/Oleg/Desktop/out.tree";
            }
            else
            {
                PuthOutput = Patch;
            }
            // using (StreamWriter sw = new StreamWriter(PuthOutput, true, System.Text.Encoding.ASCII))
            {
                // sw.WriteLineAsync((sol.Depth + 1).ToString());
                Console.WriteLine((sol.Depth + 1).ToString());
                foreach (V v in sol.inputGraph.allV)
                {
                    try
                    {
                        Console.WriteLine(v.Parent);

                    }
                    catch
                    {
                        Console.WriteLine("0");
                    }

                }
            }
        }
    }

    public class Solution
    {
        public List<int> Key; // перестановка
        public G inputGraph; // граф для расчета
        public List<int> StrongKeys = new List<int>(); // не юзаеться пока
        public int Depth = 0; // глубина
        public Solution(List<int> key, G input) // конструктор для создания экземпляра особи
        {
            Key = key;
            inputGraph = new G(input, true);
            InitSolution();
        }

        public void InitSolution() // расчет параметров особи
        {
            for (int i = 0; i < Key.Count; i++)
            {
                Sprite(Key[i].ToString());
            }

            SetStrongKey();
        }

        public void Sprite(string NaneV) // разрезаем и переращитываем компоненты связности
        {
            V vCurrent = inputGraph.GetV(NaneV); // получаем вершину из ключа
            SetParentV(vCurrent);
            while (vCurrent.binding.Count != 0) // удаляем вершину и все ее связи
            {
                vCurrent.binding[0].binding.Remove(vCurrent);
                vCurrent.binding.RemoveRange(0, 1);
            }


        }

        public void SetStrongKey()
        {
            for (int i = 0; i < Key.Count; i++)
            {
                if (inputGraph.allV[i].Parent.Value != 0)
                {
                    inputGraph.allV[inputGraph.allV[i].Parent.Value - 1].strong++;
                }
            }

            for (int i = 0; i < Key.Count; i++)
            {
                StrongKeys.Add(inputGraph.allV[i].strong);
            }
        }

        public void SetParentV(V currentV) // Перерасчет компонентов сязности 
        {
            Queue<V> CheckOrder = new Queue<V>(); // очередь на переопределение 
            foreach (V v in currentV.binding)
            {
                v.Parent = int.Parse(currentV.Name);
                CheckOrder.Enqueue(v);
            }

            while (CheckOrder.Count != 0)
            {
                V checkV = CheckOrder.Peek();
                checkV.Parent = int.Parse(currentV.Name);
                foreach (V v in checkV.binding)
                {
                    if (v.Name != currentV.Name && v.Parent != int.Parse(currentV.Name))
                        CheckOrder.Enqueue(v);
                }
                CheckOrder.Dequeue();

            }

            if (currentV.grade == -1) // расчет глубины выбраной вершины
            {
                if (currentV.Parent != null)
                {
                    currentV.grade = inputGraph.GetV(currentV.Parent.ToString()).grade + 1;

                }
                else
                {
                    currentV.grade = 0;
                    currentV.Parent = 0;
                }

                if (currentV.grade > Depth)
                {
                    Depth = currentV.grade;
                }
            }
        }



    }

    public class V
    {
        public string Name; // имя вершины
        public List<V> binding = new List<V>(); // список прилегающих вершин
        public int grade = -1; // уровень вершины ( -1 - уровень вершины не установлен)
        public int? Parent = null; // Родитель вершины
        public int strong = 0;

        public V(string _name)
        {
            Name = _name;
        }

        public V()
        {

        }
    }

    public class GenAlg
    {
        public List<Solution> solutions = new List<Solution>();
        public List<Solution> NextSolutions = new List<Solution>();
        public Solution BestSolution;
        private int XmanCount = 0;



        public int GMaxCount;
        public int GCount = 0;
        private Random random;

        public GenAlg(List<Solution> _solutions, int gCount)
        {
            solutions = _solutions;
            GMaxCount = gCount;
            random = new Random();
            Start();
        }

        public void Start()
        {
            BestSolution = solutions[0];
            List<Solution> sol = new List<Solution>();


            while (GCount != GMaxCount)
            {
                sol = new List<Solution>();

                XmanCount = 0;
                if (GCount != 0)
                {
                    sol.Add(BestSolution);
                }
                for (int i = 0; i < solutions.Count; i += 2)
                {
                    sol.Add(Crosover(solutions[i], solutions[i + 1]));
                }

                if (GCount != 0)
                {
                    sol.RemoveAt(sol.Count - 1);
                }

                solutions = sol.OrderBy(o => o.Depth).ToList();

                if (solutions[0].Depth < BestSolution.Depth)
                    BestSolution = solutions[0];

                GCount++;


            }

            var res = sol.OrderBy(o => o.Depth);

            ShowBestSolution(res.ElementAt(0));


            Program.bestTrade.Add(res.ElementAt(0));
            if (Program.bestTrade.Count == 24)
            {
                Solution temp = null;
                foreach (Solution sols in Program.bestTrade)
                {
                    if (temp == null || temp.Depth > sols.Depth)
                    {
                        temp = sols;
                    }
                }
                Program.Final(temp);
            }
        }

        public void ShowBestSolution(Solution solution)
        {
            string result = string.Empty;
            foreach (int i in solution.Key)
            {
                result += i.ToString() + "/";
            }

            // MessageBox.Show("key " + result + "\n" + "костул дал ответ " + (solution.Depth + 1) + "\n");
        }


        public Solution Crosover(Solution firstSolution, Solution secondSolution)
        {
            List<int> newKey = new List<int>();
            List<int?> key1 = new List<int?>();
            List<int?> key2 = new List<int?>();

            foreach (int i in firstSolution.Key)
            {
                int tmp = i;
                key1.Add(tmp);
            }

            foreach (int i in secondSolution.Key)
            {
                int tmp = i;
                key2.Add(tmp);
            }

            // int temp = 0;
            // while(key1.Count != 0)
            // {
            //int randomValue = random.Next(0, 2);
            // if(firstSolution.StrongKeys[0] > secondSolution.StrongKeys[0])
            // if(randomValue == 0)
            // {
            // temp = (key1[0]);
            // }
            // else
            // {
            // temp =(key2[0]);
            // }

            // newKey.Add(temp);
            // key1.Remove(temp);
            // key2.Remove(temp);
            // }

            int? temp = 0;
            for (int i = 0; i < key1.Count; i++)
            {
                if (key1[i] == null)
                {
                    temp = (key2[i]);
                }
                if (key2[i] == null)
                {
                    temp = (key1[i]);
                }
                if (key1[i] != null && key2[i] != null)
                {
                    float cof = GenRole(firstSolution.StrongKeys[i], secondSolution.StrongKeys[i]);
                    int xMan = random.Next(0, 100);
                    if (xMan <= cof)
                    {
                        temp = (key2[i]);
                    }
                    else
                    {
                        temp = (key1[i]);
                    }

                    //if (firstSolution.StrongKeys[i] > secondSolution.StrongKeys[i])
                    // {
                    //temp = (key1[i]);
                    // }
                    // else
                    // {
                    // temp = (key2[i]);
                    // }
                }

                if (key1[i] == null && key2[i] == null)
                {
                    for (int j = 0; i < key1.Count; j++)
                    {
                        if (key1[j] != null)
                        {
                            temp = key1[j];
                            break;
                        }

                    }
                }

                newKey.Add(temp.Value);
                key1[key1.IndexOf(temp)] = null;
                key2[key2.IndexOf(temp)] = null;
            }



            newKey = GetXman(newKey, ((double)solutions.IndexOf(secondSolution) / (double)solutions.Count));
            return new Solution(newKey, Program._loader.g);
        }

        public float GenRole(int oneStrong, int twoStrong)
        {
            float cof = (float)oneStrong / (float)twoStrong;
            if (cof > 3)
                return 100;
            if (cof > 2)
                return 75;
            if (cof == 1)
                return 50;
            if (cof > 0.5)
                return 25;
            if (cof > 0.25)
                return 0;

            return 0;
        }
        public List<int> GetXman(List<int> key, double role)
        {
            int xMan = random.Next(0, 100);
            if (xMan <= role)
            {
                int xManStart = random.Next(0, key.Count - 1);
                int xManEnd = random.Next(xManStart, key.Count - 1);
                key.Reverse(xManStart, xManEnd - xManStart);
                XmanCount++;
            }
            return key;
        }


    }

    public class G
    {
        public List<V> allV = new List<V>(); // список всех вершин графа
        public G(int GDepth)
        {
            for (int i = 1; i < GDepth; i++)
            {
                allV.Add(new V(i.ToString()));
            }
        }

        public G(G copyG, bool newComp) // создаем копию графа
        {

            for (int i = 0; i < copyG.allV.Count; i++)
            {
                allV.Add(new V(copyG.allV[i].Name) { Parent = copyG.allV[i].Parent });
            }

            for (int i = 0; i < allV.Count; i++)
            {
                allV[i].Parent = copyG.allV[i].Parent;
                foreach (V v in copyG.allV[i].binding)
                {
                    allV[i].binding.Add(GetV(v.Name));
                }
            }

        }

        public V GetV(string _Name) // получаем вершину по имени по ее названию
        {
            for (int i = 0; i < allV.Count; i++)
            {
                if (allV[i].Name == _Name)
                    return allV[i];
            }
            return null;
        }

        public void SetBindingInV(int v, int value)
        {
            allV[v - 1].binding.Add(allV[value - 1]);
            allV[value - 1].binding.Add(allV[v - 1]);
        }



    }

    public class FerstGen
    {
        public List<List<int>> keys = new List<List<int>>();
        public List<Solution> solutions = new List<Solution>();
        public int countSrartChild;
        public G inputGr;
        Random random;

        public FerstGen(int _startChildCount, G _inputG, Random _rand)
        {
            countSrartChild = _startChildCount;
            inputGr = _inputG;
            random = _rand;
            Thread myThread = new Thread(new ThreadStart(Init));
            myThread.Start();
            // Init();

        }

        public FerstGen(List<Solution> _solutions, G _inputG, Random _rand)
        {
            // countSrartChild = _startChildCount;
            inputGr = _inputG;
            random = _rand;

            //  Thread myThread = new Thread(new ThreadStart(Init));
            // myThread.Start();
            // Init();

        }
        public void Init()
        {
            for (int i = 0; i < countSrartChild; i++)
            {
                keys.Add(GetRandomKey());
            }

            foreach (List<int> key in keys)
            {
                solutions.Add(new Solution(key, inputGr));
            }
            // MessageBox.Show("done");

            var sortSlution = solutions.OrderBy(o => o.Depth);

            ShowBestSolution(sortSlution.ElementAt(0));

            GenAlg alg = new GenAlg(sortSlution.ToList(), 9);


        }

        public void ShowBestSolution(Solution solution)
        {
            string result = string.Empty;
            foreach (int i in solution.Key)
            {
                result += i.ToString() + "/";
            }
            string result2 = string.Empty;
            // foreach(V v in solution.inputGraph.allV)
            {
                // result2 += v.Name + " " + v.Parent + "\n";
            }
            //  MessageBox.Show("key " + result + "\n" + "глубина " + (solution.Depth + 1) + "\n" );




        }

        public List<int> GetRandomKey()
        {

            List<int> result = new List<int>();
            foreach (V v in inputGr.allV)
            {
                result.Add(int.Parse(v.Name));
            }
            for (int i = 0; i < result.Count; i++)
            {
                int temp = result[i];
                int RandomIndex = random.Next(0, result.Count - 1);
                result[i] = result[RandomIndex];
                result[RandomIndex] = temp;
            }

            return result;
        }
    }
}
