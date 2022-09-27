using System.Linq;
class _DFA_
{
    //สร้างDFA
    //เอาไว้สำหรับการนำdfaมาทำให้เป็นDictionaryเพื่อที่จะได้ง่ายต่อการเขียนโปรเเกรมโดยจะประกอบไปด้วย Dictionary คีย์เป็น intเเละvalเป็นDictionaryคีย์เป็นstringเเละvalเป็นint
    public static Dictionary<int, Dictionary<string, int>> dfa = new Dictionary<int, Dictionary<string, int>> {
            {
                0,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",30}}},
            {
                1,
                new Dictionary<string, int> {
                    {"dig",1},{"other",10},{"lett",31}}},
            {
                31,
                new Dictionary<string, int> {
                    {"lett",31},{"dig",31},{"other",14}}},
            {
                2,
                new Dictionary<string, int> {
                    {"lett",2},{"dig",2},{"other",12}}},
            {
                3,
                new Dictionary<string, int> {
                    {"other",13},{"+",11},{"-",11},{"*",11},{"/",11},{"<",11},{">",11},{"=",11}}},
            {
                4,
                new Dictionary<string, int> {
                    {"other",13},{"+",11},{"-",11},{"*",11},{"/",11},{"<",11},{">",11},{"=",11}}},
            {
                5,
                new Dictionary<string, int> {
                    {"other",13},{"+",11},{"-",11},{"*",11},{"/",11},{"<",11},{">",11},{"=",11}}},
            {
                6,
                new Dictionary<string, int> {
                    {"other",13},{"+",11},{"-",11},{"*",11},{"/",11},{"<",11},{">",11},{"=",11}}},
            {
                7,
                new Dictionary<string, int> {
                    {">",21},{"=",22},{"other",23},{"<",11}}},
            {
                8,
                new Dictionary<string, int> {
                    {"=",25},{"other",26},{"<",11},{">",11}}},
            {
                9,
                new Dictionary<string, int> {
                    {"<",11},{">",11},{"=",11},{"other",29}}},
            {
                10,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                11,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"other",0}}},
            {
                12,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                13,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                14,
                new Dictionary<string, int> {
                    {"dig",14},{"lett",14},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                21,
                new Dictionary<string, int> {
                    {"other",0}}},
            {
                22,
                new Dictionary<string, int> {
                    {"other",0}}},
            {
                23,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                25,
                new Dictionary<string, int> {
                    {"other",0}}},
            {
                26,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                27,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                28,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                29,
                new Dictionary<string, int> {
                    {"dig",1},{"lett",2},{"+",3},{"-",4},{"*",5},{"/",6},{"<",7},{">",8},{"=",9},{"other",0}}},
            {
                30,
                new Dictionary<string, int> {
                    {"other",0}}}};
      //สร้างDFA
      //ตัวที่เอาไว้บอกว่าสเตจใหนเป็นfin_stageบ้าง ตัว Dictionary คีย์เป็น int เเละvalเป็น string
    public static Dictionary<int, string> fin_stage_map = new Dictionary<int, string> {
            {10,"digit"},{11,"ERR"},{14,"ERR"},{12,"ID"},{13,"op"},{21,"relop"},{22,"relop"},{23,"relop"},{25,"relop"},
            {26,"relop"},{29,"relop"},{30,"ERR"}};
     //ตัวที่เอาไว้บอกว่าสเตจใหนเป็นfin_stageบ้าง

     //function ที่เอาไว้อ่านdfaโดยจะนำเข้า transitions หรือก็คือตัวdfa initialหรือตำเเหน่งเริ่มต้น accepting หรือ ตำเเหน่งที่ยอมรับ s หรือสิ่งที่นำเข้าไปอ่านในdfa _valคือค่าของตัวที่เอาไปอ่านเช่น a คือ s = lett _val = a
    static Tuple<List<string>, List<string>> accepts(Dictionary<int, Dictionary<string, int>> transitions, int initial
                        , List<int> accepting, List<string> s, List<string> _val)
    {
        var state = initial; //กำหนดให้ state = initial
        List<string> state_travel = new List<string>(); //สร้าง state_travel
        List<string> val_ = new List<string>(); //สร้าง val_
        List<string> fin_rem = new List<string>(); //fin_rem
        int num_elm_s = s.Count(); //สร้าง num_elm_s
        int i = 0;//สร้าง i
        while (i < num_elm_s) //หากiน้อยกว่าความยาวของstring
        {

            try //ให้ลอง
            {

                state = transitions[state][s[i]]; //state = transitionsตัวที่stateโดยอ่านs[i]หรือก็คือค่าที่อ่านจากสิ่งที่รับเข้ามา
                val_.Add(_val[i]);//addค่าของสิ่งนั้นๆเข้าไปในval_
                i += 1;//เพื่มiไป1
            }
            catch//หากลองเเล้วไม่สำเร็จ
            {
                state = transitions[state]["other"];//state = transitionsตัวที่stateโดยอ่านother
                i += 1;//เพื่มiไป1

            }
            if (accepting.Contains(state))//หากstateที่อยู่ปจุบันเป็นfin
            {
                    i -= 1;//ลด i ไป 1
                    state_travel.Add(fin_stage_map[state]);//เพิ่มค่าว่าเป็นfinของอะไรลงไปในstate_travel
                    val_.Add(_val[i]);//addค่าของสิ่งนั้นๆเข้าไปในval_
                    val_.Add(" ");//add  , เข้าไปในval_
            }


        }
        string fin_val = String.Join("", val_.ToArray()); //ทำการเเปลงค่าของval_ให้เป็นstringเเล้วใส่ไปในfin_val
       
        List<string> _fin_val = fin_val.Split(" ").ToList();//ทำการนำfin_valมาเเยกออกโดยเเบ่งด้วย,
        foreach (string j in _fin_val)//ให้เอาค่าที่อยูาใน _fin_valทุกตัวออกมา
        {
            try //ลอง
            {

                fin_rem.Add(j.Substring(0, j.Count() - 1));//ให้เอาสิ่งที่อยู่ในตัวjตั้งเเต่ตัวที่0ถึงตัวท้าย-1ออกมา
            }
            catch //หากพลาด
            {
                fin_rem.Add("");//ให้ใส่ค่าว่าง
            }
        }
        return (Tuple.Create(state_travel, fin_rem)); //ส่งออกTupleที่มีstate_travel คือstateที่accept เเละ fin_rem คือค่าของตัวนั้นๆ
    }
      //function ที่เอาไว้อ่านdfa
      //classที่เอาไว้ใช้งานRangeเเบบในpython
    public static class Py
    {
        // make a range over [start..end) , where end is NOT included (exclusive)
        public static IEnumerable<int> RangeExcl(int start, int end)
        {
            if (end <= start) return Enumerable.Empty<int>();
            // else
            return Enumerable.Range(start, end - start);
        }

        // make a range over [start..end] , where end IS included (inclusive)
        public static IEnumerable<int> RangeIncl(int start, int end)
        {
            return RangeExcl(start, end + 1);
        }
    } 
      //classที่เอาไว้ใช้งานRangeเเบบในpython

      //main function
    static void Main()
    {


        string input_string = "3x-y<<0"; //input
       
        List<string> _string = new List<string>(); 
        List<string> _type_string = new List<string>();

        int n = 0;
        foreach (var j in input_string)
        {
            if (new[] { '<', '>', '=', '+', '-', '*', '/' }.Contains(j))//ลองดูว่ามีพวกนี้ในjรึเปล่า
            {
                _type_string.Add(j.ToString());

            }
            else if (int.TryParse(j.ToString(), out n))/*ลองดูว่าจะเปลี่ยนเป็นintได้รึเปล่า*/
            {
                _type_string.Add("dig"); 
            }
            else
            {
                _type_string.Add("lett");
            }
            _string.Add(j.ToString());
        }
        _type_string.Add("\n");
        _string.Add("\n");
 

        var mySequence = Py.RangeExcl(10, 31);
        List<int> fin = mySequence.ToList(); //list สำหรับfin stageเพื่อเอาไปใช้ในfunction

        Tuple<List<string>, List<string>> acc = accepts(dfa, 0, fin, _type_string, _string); //ทำการใส่ทุกอย่างในfunction

        for (int a = 0; a < acc.Item1.Count(); a++)
        {
            Console.WriteLine(String.Format("[{0},{1}]", acc.Item1[a], acc.Item2[a])); //printสิ่งที่functionทำออกมา
        
        }

    }
}