using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace schedulejr
{
    public partial class Form1 : Form
    {
        public const int setvalue =99999;
        public class Edge {

            public Edge() { 
            }
            public Edge(int c, string n,string l)
            {
                _cost = c;
                _name = n;
                _line = l;
            }
            private int _cost { set; get; }
            private string _name { set; get; }
            private string _line { set; get; }

            public int cost { get { return _cost; } }
            public string name { get { return _name; } }
            public string line { get { return _line; } }

        }
        public class Node {
            public int sumcost = setvalue;
            public bool passThrough=false;
            public string previous;
            public List<Edge> nextStation=new List<Edge>();
        }

        string[] filename = Directory.GetFiles("./train","*.csv");
        string[] linename;
        
     //   List<string> linename = new List<string>();
        public Dictionary<string, Node> stations=new Dictionary<string,Node>();
        public Dictionary<string,List<string>> displist= new Dictionary<string,List<string>>();

        public Form1()
        {
            InitializeComponent();

          

            linename=new string[filename.Length];
            for(int i=0;i< filename.Length;i++)
            {
                linename[i] = Path.GetFileName(filename[i]);
                linename[i] = linename[i].Replace(".csv","");
                LineSelect.Items.Add(linename[i]);
                dlineselect.Items.Add(linename[i]);
                displist[linename[i]] = new List<string>();
            }
            LineSelect.SelectedIndex = 0;
            dlineselect.SelectedIndex = 0;
            foreach (var file in filename)
            {
                using (StreamReader sr = new StreamReader(file,Encoding.GetEncoding("Shift_JIS")))
                {
                    string[] tmpdata;
                    string[] datanext;
                    string line = Path.GetFileName(file).Replace(".csv", "");
                    tmpdata = sr.ReadLine().Split(',');
                    datanext = new string[tmpdata.Length];
                   
                    while (!sr.EndOfStream)
                    {
                        displist[line].Add(tmpdata[0]);
                        try
                        {
                            datanext = sr.ReadLine().Split(',');
                            Edge edge = new Edge(int.Parse(datanext[1])-int.Parse(tmpdata[1]), datanext[0], line);
                            if (!stations.ContainsKey(tmpdata[0]))
                            {
                                Node station = new Node();
                                station.nextStation.Add(edge);
                                stations[tmpdata[0]] = station;
                             
                            }
                            else
                            {
                                stations[tmpdata[0]].nextStation.Add(edge);

                            }
                            edge = new Edge(int.Parse(datanext[1]) - int.Parse(tmpdata[1]),tmpdata[0], line);
                            if (!stations.ContainsKey(datanext[0])) {
                                Node station = new Node();
                                station.nextStation.Add(edge);
                                stations[datanext[0]] = station;
                            }
                            else
                            {
                                stations[datanext[0]].nextStation.Add(edge);
                            }

                            for (int i = 0; i < tmpdata.Length; i++)
                            {
                                tmpdata[i] = datanext[i];
                            }
                            if (sr.EndOfStream && !displist[line].Contains(tmpdata[0]))  displist[line].Add(tmpdata[0]);
                        }
                        catch{

                        }
                    
                    }
                }
            }
            foreach (var n in displist[LineSelect.SelectedItem.ToString()] )
            {
                departurelist.Items.Add(n);
                destinationlist.Items.Add(n);
            }
        }

        public void reset(){
            
foreach(var station in stations)    {
    station.Value.passThrough = false;
    station.Value.sumcost = setvalue;
    station.Value.previous = "";
}        

        }
        public void dijkstra()
        {
            stations[departuretext.Text].sumcost = 0;
            int currentsum = stations[departuretext.Text].sumcost;
            string currentnode = departuretext.Text;
            string destinationnode = destinationtext.Text;
            List<string> edgecheck = new List<string>();

            while(currentnode!=destinationnode){

            foreach (var edge in stations[currentnode].nextStation) {
                string nextstation = edge.name;
                if (stations[nextstation].passThrough == false)
                {
                    int tempsum = currentsum;
                    tempsum += edge.cost;
                    if (stations[nextstation].sumcost > tempsum) { stations[nextstation].sumcost = tempsum; stations[nextstation].previous = currentnode; }
                    if (!edgecheck.Contains(nextstation)) edgecheck.Add(nextstation);
                }
        
                }
            stations[currentnode].passThrough = true;
            int currentmincost = 999;
            foreach (var ed in edgecheck)
            {
                if (stations[ed].sumcost < currentmincost) { currentmincost = stations[ed].sumcost; currentnode = ed; currentsum = currentmincost; }
            }

            edgecheck.RemoveAll(p => p == currentnode);



            }

            currentnode=departuretext.Text;

            List<string> disp =new List<string>();
         //   disp.Add(destinationnode+" "+stations[stations[destinationnode].previous].nextStation.Find(p=>p.name==destinationnode).line);
            List<int> sumcost=new List<int>();
            var linechange = new List<string>();
            disp.Add(destinationnode);
     
            while (destinationnode != currentnode)
            {
                
                disp.Add("|（"+stations[stations[destinationnode].previous].nextStation.Find(p => p.name == destinationnode).line+"）所要時間："+stations[stations[destinationnode].previous].nextStation.Find(p => p.name == destinationnode).cost+"分");
               
                disp.Add(stations[destinationnode].previous);
                try
                {
                    if (stations[stations[destinationnode].previous].nextStation.Find(p => p.name == destinationnode).line != stations[stations[stations[destinationnode].previous].previous].nextStation.Find(p => p.name == stations[destinationnode].previous).line) 
                    { linechange.Add(stations[stations[destinationnode].previous].nextStation.Find(p => p.name == destinationnode).line);
                        disp[disp.Count - 1] += "(乗り換え)";sumcost.Add( stations[stations[destinationnode].previous].sumcost); }
                }
                catch { }
                if (stations[destinationnode].previous == currentnode) { linechange.Add(stations[stations[destinationnode].previous].nextStation.Find(p => p.name == destinationnode).line); }     
                destinationnode = stations[destinationnode].previous;
            }
            sumcost.Reverse();
            linechange.Reverse();
            disp.Reverse();
            schedule.Items.Add("総コスト(分)：" + stations[destinationtext.Text].sumcost + "分");
            schedule.Items.Add("");
            for (int i = 0; i < disp.Count; i++)
            {
                schedule.Items.Add(disp[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                schedule.Items.Add(" ");
            }


            int j = 0;
            
            //if(linechange.Count==0){schedule.Items.Add(disp[0]+"("+ dlineselect.Text+")");}
            //else { schedule.Items.Add(disp[0] + "(" + linechange[j] + ")"); }

             schedule.Items.Add(disp[0] ); 
          

            for (int i = 0; i < disp.Count; i++)
            {
                if (disp[i].Contains("乗り換え")) {
                    if (j == 0) schedule.Items.Add("| " + "(" + linechange[j] + ")" + sumcost[j] + "分");
                    else
                    {
                        schedule.Items.Add("| " + "(" + linechange[j] + ")" + (sumcost[j] - sumcost[j - 1]) + "分");
                    }

                    schedule.Items.Add(disp[i] );
               
                    j++;
                    

               }
                
                  
                
            }
            if (sumcost.Count != 0) { schedule.Items.Add("| " + "(" + linechange[j] + ")" + (stations[destinationtext.Text].sumcost - sumcost[sumcost.Count - 1]) + "分"); }
            else { schedule.Items.Add("| " + "(" + linechange[j] + ")" + stations[destinationtext.Text].sumcost + "分"); }
            schedule.Items.Add(disp[disp.Count-1]);

            //while(destinationnode!=currentnode){
            //disp.Add(stations[destinationnode].previous + " " + stations[stations[destinationnode].previous].nextStation.Find(p => p.name == destinationnode).line);
            //destinationnode=stations[destinationnode].previous;            
            //}
            //disp.Reverse();
            //schedule.Items.Add("総コスト(分)："+stations[destinationtext.Text].sumcost+"分");
            //for (int i = 0; i < disp.Count; i++)
            //{
            //    schedule.Items.Add(disp[i]);
            //}
        }

        private void search_Click(object sender, EventArgs e)
        {
            schedule.Items.Clear();
            if (destinationtext.Text == ""|| departuretext.Text == "") { schedule.Items.Add("検索条件を確認してください。"); return; } 
            if (destinationtext.Text == departuretext.Text) { schedule.Items.Add("同名の駅を選んでいます。"); return; }
           

           
            reset();
            dijkstra();
        }

        private void departurelist_SelectedValueChanged(object sender, EventArgs e)
        {
            departuretext.Text = departurelist.SelectedItem.ToString();
        }

        private void LineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            departurelist.Items.Clear();
            foreach (var n in displist[LineSelect.SelectedItem.ToString()])
            {
                departurelist.Items.Add(n);
            }
        }

        private void dlineselect_SelectedIndexChanged(object sender, EventArgs e)
        {
        destinationlist.Items.Clear();
            foreach (var n in displist[dlineselect.SelectedItem.ToString()])
            {
                destinationlist.Items.Add(n);
            }
            
        }

        private void destinationlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            destinationtext.Text = destinationlist.SelectedItem.ToString();
        }

        private void schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            schedule.SelectedIndex = -1;
            return;
        }

        
    }
}
