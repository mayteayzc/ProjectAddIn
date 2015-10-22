using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSProject = Microsoft.Office.Interop.MSProject;
using HostApplication = Microsoft.Office.Interop.MSProject.Application;

namespace Project2013AddIn
{
    public partial class ThisAddIn
    {
        public void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.ProjectBeforeTaskDelete += Application_ProjectBeforeTaskDelete;
        }

        void Application_ProjectBeforeTaskDelete(MSProject.Task tsk, ref bool Cancel)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            //what if first task has been deleted? use i to find the first visible tasks
            int i = 1;
            string unary, binary, multiple;
            MSProject.PjCustomField UnaryField = MSProject.PjCustomField.pjCustomTaskText30;
            MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
            MSProject.PjCustomField MultipleField = MSProject.PjCustomField.pjCustomTaskText28;

            if (project.Application.CustomFieldGetName(UnaryField) != "Unary Relationship")
                project.Application.CustomFieldRename(UnaryField, "Unary Relationship", Type.Missing);
            if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);
            if (project.Application.CustomFieldGetName(MultipleField) != "Multiple Relationship")
                project.Application.CustomFieldRename(MultipleField, "Multiple Relationship", Type.Missing);

            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }

            multiple = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"));
            binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
            unary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"));
          
            if (tsk.Name.ToString() == project.Tasks.UniqueID[i].Name.ToString())
            {
                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.ID == 2)
                        i = task.UniqueID;
                }
                MSProject.Task tsk2 = project.Tasks.UniqueID[i];
                tsk2.SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"), multiple);
                tsk2.SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), binary);
                tsk2.SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), unary);
            }
            //delete everything related to taski
            DialogResult confirmed= MessageBox.Show("Delete this task will remove all the relationships related to this task.", "Confirm?", MessageBoxButtons.YesNo);
            if(confirmed==DialogResult.Yes)
            {
                //process Multiple relationship
                string newmultiple="";
                bool related=false;
                string MultipleData1,MultipleData2;
                int l5 = multiple.Length;
                //int l6;
                int p5 = multiple.IndexOf(";");
                int p6;
                string rela;
                string[] tasks = new string[5];
                int m = 0;

                while (p5 > 0)
                {
                    MultipleData1 = multiple.Substring(0, p5);
                    MultipleData2 = multiple.Substring(0, p5);
                    p6 = MultipleData2.IndexOf(",");
                    rela = MultipleData2.Substring(0, p6);
                    MultipleData2 = MultipleData2.Substring(p6 + 1);
                    p6 = MultipleData2.IndexOf(",");

                    while (p6 > 0)
                    {                        
                        tasks[m] = MultipleData2.Substring(0, p6);
                        MultipleData2 = MultipleData2.Substring(p6 + 1);
                        p6 = MultipleData2.IndexOf(",");
                        m++;
                    }
                    tasks[m] = MultipleData2;

                    for (m = 0; m < 5; m++)
                    {
                        if (tasks[m] == tsk.Name.ToString())
                            related = true;
                    }

                    if (!related)
                        newmultiple = newmultiple + MultipleData1 + ";";

                    multiple = multiple.Substring(p5 + 1);
                    p5 = multiple.IndexOf(";");
                    m = 0;

                }

                //process Binary relationship
                string BinaryData;
                string newbinary="";
                int l1 = binary.Length;
                int l2;
                int p1 = binary.IndexOf(";");
                int p2;
                string tk1, tk2, d;

                while (p1 > 0)
                {
                    BinaryData = binary.Substring(0, p1);
                    l2 = BinaryData.Length;
                    p2 = BinaryData.IndexOf(",");
                    tk1 = BinaryData.Substring(0, p2);

                    BinaryData = BinaryData.Substring(p2 + 1, l2 - p2 - 1);
                    p2 = BinaryData.IndexOf(",");
                    tk2 = BinaryData.Substring(0, p2);
                    l2 = BinaryData.Length;

                    BinaryData = BinaryData.Substring(p2 + 1, l2 - p2 - 1);
                    p2 = BinaryData.IndexOf(",");
                    rela = BinaryData.Substring(0, p2);
                    l2 = BinaryData.Length;

                    BinaryData = BinaryData.Substring(p2 + 1, l2 - p2 - 1);
                    d = BinaryData;

                    if (tk1 != tsk.Name.ToString() && tk2 != tsk.Name.ToString())
                        newbinary = newbinary + BinaryData + ";";

                    binary = binary.Substring(p1 + 1, l1 - p1 - 1);
                    p1 = binary.IndexOf(";");
                    l1 = binary.Length;
                }

                //process Unary relationship
                string UnaryData;
                string newunary = "";
                int l3 = unary.Length;
                int l4;
                int p3 = unary.IndexOf(";");
                int p4;
                string tk, d1, d2;

                while (p3 > 0)
                {
                    UnaryData = unary.Substring(0, p3);
                    l4 = UnaryData.Length;
                    p4 = UnaryData.IndexOf(",");
                    tk = UnaryData.Substring(0, p4);

                    UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 - 1);
                    p4 = UnaryData.IndexOf(",");
                    rela = UnaryData.Substring(0, p4);
                    l4 = UnaryData.Length;

                    UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 - 1);
                    p4 = UnaryData.IndexOf(",");
                    d1 = UnaryData.Substring(0, p4);
                    l4 = UnaryData.Length;

                    UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 - 1);
                    d2 = UnaryData;

                    if (tk == tsk.Name.ToString())
                        newunary = newunary + UnaryData;

                    unary = unary.Substring(p3 + 1, l3 - p3 - 1);
                    p3 = unary.IndexOf(";");
                    l3 = unary.Length;
                }

              //then re-store the relationships without the deleted task.
              project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"), newmultiple);
              project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), newbinary);
              project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), newunary);

            }
        }

        static public bool BinaryTGA(int id1, int id2, string binaryRelationship, int days)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            //check if there is exisiting binary relationships
            MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
            //problem with this method: must do sth like select a cell before applying pdm++
            if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);

            //check empty fileds.
            if (project.Tasks.UniqueID[id1].Duration == null)
                project.Tasks.UniqueID[id1].Duration = 480;

            if (project.Tasks.UniqueID[id2].Duration == null)
                project.Tasks.UniqueID[id2].Duration = 480;

            if (project.Tasks.UniqueID[id1].StartText == null || project.Tasks.UniqueID[id1].StartText=="")
                project.Tasks.UniqueID[id1].Start= DateTime.Today;


            if (project.Tasks.UniqueID[id2].StartText == null || project.Tasks.UniqueID[id2].StartText == "")
                project.Tasks.UniqueID[id2].Start = DateTime.Today;


            MSProject.Task first;
            MSProject.Task second;

            if (DateTime.Compare(project.Tasks.UniqueID[id2].Start, project.Tasks.UniqueID[id1].Start) < 0)
            {
                first = project.Tasks.UniqueID[id2];
                second = project.Tasks.UniqueID[id1];
            }
            else
            {
                first = project.Tasks.UniqueID[id1];
                second = project.Tasks.UniqueID[id2];
            }
            
            int i = 1;
            
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }
            string Binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
            string BinaryData;

            //process binary relationships, check if new rela contradicts existing relationships
            int l1 = Binary.Length;
            int l2;
            int p1 = Binary.IndexOf(";");
            int p2;
            string tk1, tk2, rela, d;

            while (p1 > 0)
            {
                BinaryData = Binary.Substring(0, p1);
                l2 = BinaryData.Length;
                p2 = BinaryData.IndexOf(",");
                tk1 = BinaryData.Substring(0, p2);

                BinaryData = BinaryData.Substring(p2 + 1, l2 - p2 - 1);
                p2 = BinaryData.IndexOf(",");
                tk2 = BinaryData.Substring(0, p2);
                l2 = BinaryData.Length;

                BinaryData = BinaryData.Substring(p2 + 1, l2 - p2 - 1);
                p2 = BinaryData.IndexOf(",");
                rela = BinaryData.Substring(0, p2);
                l2 = BinaryData.Length;

                BinaryData = BinaryData.Substring(p2 + 1, l2 - p2 - 1);
                d = BinaryData;

                if ((tk1 == first.Name.ToString() && tk2 == second.Name.ToString()) || (tk2 == first.Name.ToString() && tk1 == second.Name.ToString()))
                {
                    if (rela == binaryRelationship)
                        MessageBox.Show("Error: The binary relationship " + rela + " can not be assigned twice for the same two tasks.");
                    else
                        MessageBox.Show("Error: The binary relationship " + rela + " and " + binaryRelationship + " can not coexist for the same two tasks.");
                    return false;
                }
         
                Binary = Binary.Substring(p1 + 1, l1 - p1 - 1);
                p1 = Binary.IndexOf(";");
                l1 = Binary.Length;
            }
           
            //if no contradicting assignment
            first.Manual = true;
            second.Manual = true;
            bool processed = false;

            switch (binaryRelationship)
            {
                case "Contain":
                    bool contained = false;
                    MSProject.Task longer, shorter;
                    if (second.Duration > first.Duration)
                    {
                        longer = second;
                        shorter = first;
                    }
                    else
                    {
                        longer = first;
                        shorter = second;
                    }

                    //use new custome field 27
                    if (longer.Text27 != "" && longer.Text27 != null)
                        longer.Text27 = longer.Text27 + ",";
                        
                        longer.Text27 = longer.Text27 + "CN" + shorter.ID.ToString();

                    if (shorter.Text27 != "" && shorter.Text27 != null)
                        shorter.Text27 = shorter.Text27 + ",";
                        
                        shorter.Text27 = shorter.Text27 + "CN" + longer.ID.ToString();                

                    if (DateTime.Compare(first.Finish, second.Finish) < 0)
                    {
                        
                        while (!contained)
                        {
                            first.Start = first.Start.AddDays(1);
                            if (DateTime.Compare(first.Finish, second.Finish) == 0)
                            {
                                contained = true;
                                shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjFinishToFinish, 0);
                            }
                                
                            if (DateTime.Compare(first.Start, second.Start) == 0)
                            {
                                contained = true;
                                shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjStartToStart, 0);
                            }
                                
                        }   
                    }
                    else
                    {
                        shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjStartToStart, 0);
                        
                    }

                    ThisAddIn.SetGanttBarFormat(longer, shorter);
                    processed = true;
                    break;

                case "Disjoint":
                    //only change when overlap.
                    if (DateTime.Compare(first.Finish, second.Start) > 0)
                        second.Start = first.Finish;

                    if (first.Text27 != "" && first.Text27 != null)
                        first.Text27 = first.Text27 + ",";
                       
                        first.Text27 = first.Text27 + "D" + second.ID.ToString();

                    if (second.Text27 != "" && second.Text27 != null)
                        second.Text27 = second.Text27 + ",";
                        
                        second.Text27 = second.Text27 + "D" + first.ID.ToString();     

                    ThisAddIn.SetGanttBarFormat(first, second);  
                    second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    processed= true;
                    break;


                case "Meet":
                    if (DateTime.Compare(first.Finish, second.Start) < 0)
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjStartToFinish, 0);

                    if (first.Text27 != "" && first.Text27 != null)
                        first.Text27 = first.Text27 + ",";
                        
                        first.Text27 = first.Text27 + "M" + second.ID.ToString();

                    if (second.Text27 != "" && second.Text27 != null)
                        second.Text27 = second.Text27 + ",";
                        
                        second.Text27 = second.Text27 + "M" + first.ID.ToString();                  

                    ThisAddIn.SetGanttBarFormat(first, second); 
                    second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    processed = true;
                    break;


                case "Overlap":
                    //here is at least, for overlap more than specified days, no change is made.
                    //by default everyday includes 8 working hrs, 480 mins.
                    if (days > first.Duration / 480 || days > second.Duration / 480)
                    {
                        MessageBox.Show("Error: Overlap days cannot be longer than the durations of the tasks "+"("+first.Name.ToString()+","+second.Name.ToString()+").");
                        return false;
                    }
                    else
                    {
                        if (first.Text27 != "" && first.Text27 != null)
                            first.Text27 = first.Text27 + ",";
                          
                            first.Text27 = first.Text27 + "O" + second.ID.ToString() + "(" + days.ToString() + ")";

                        if (second.Text27 != "" && second.Text27 != null)
                            second.Text27 = second.Text27 + ",";
                            
                            second.Text27 = second.Text27 + "O" + first.ID.ToString() + "(" + days.ToString() + ")";   
                        
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjStartToFinish, days*480);
                        ThisAddIn.SetGanttBarFormat(first, second);
                        processed = true;
                     }
                    break;
            }

            i = 1;
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }
            if(processed)
            {
                string BinaryString = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
                string NewBinaryString = BinaryString + first.Name.ToString() + "," + second.Name.ToString() + "," + binaryRelationship + "," + days.ToString() + ";";

                project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), NewBinaryString);
            }        
            return true;
        }

        static public bool BinaryTGA_Check(int id1, int id2, string binaryRelationship, int days)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            MSProject.Task first;
            MSProject.Task second;

            if (DateTime.Compare(project.Tasks.UniqueID[id2].Start, project.Tasks.UniqueID[id1].Start) < 0)
            {
                first = project.Tasks.UniqueID[id2];
                second = project.Tasks.UniqueID[id1];
            }
            else
            {
                first = project.Tasks.UniqueID[id1];
                second = project.Tasks.UniqueID[id2];
            }

            first.Manual = true;
            second.Manual = true;
            bool id1_before_id2 = true;
            //to remove the existing links between 1 and 2, check which one is the predecessor first.
            foreach (MSProject.Task predecessor in project.Tasks.UniqueID[id1].PredecessorTasks)
            {
                if (predecessor.UniqueID == project.Tasks.UniqueID[id2].UniqueID)
                {
                    id1_before_id2 = false;
                    project.Tasks.UniqueID[id2].UnlinkSuccessors(project.Tasks.UniqueID[id1]);
                }

            }

            if (id1_before_id2)
                project.Tasks.UniqueID[id1].UnlinkSuccessors(project.Tasks.UniqueID[id2]);

            switch (binaryRelationship)
            {
                case "Contain":
                    bool contained = false;
                    MSProject.Task longer, shorter;
                    if (second.Duration > first.Duration)
                    {
                        longer = second;
                        shorter = first;
                    }
                    else
                    {
                        longer = first;
                        shorter = second;
                    }

                    if (DateTime.Compare(first.Finish, second.Finish) < 0)
                    {
                        while (!contained)
                        {
                            first.Start = first.Start.AddDays(1);
                            if (DateTime.Compare(first.Finish, second.Finish) == 0)
                            {
                                contained = true;
                                shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjFinishToFinish, 0);
                            }

                            if (DateTime.Compare(first.Start, second.Start) == 0)
                            {
                                contained = true;
                                shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjStartToStart, 0);
                            }
                        }
                    }
                    else
                        shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjStartToStart, 0);
                    break;

                case "Disjoint":
                    //only change when overlap.
                    if (DateTime.Compare(first.Finish, second.Start) > 0)
                        second.Start = first.Finish;

                    second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    break;


                case "Meet":
                    if (DateTime.Compare(first.Finish, second.Start) < 0)
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjStartToFinish, 0);
                    else
                        second.Start = first.Finish;

                    second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    break;


                case "Overlap":
                    //here is at least, for overlap more than specified days, no change is made.
                    //by default everyday includes 8 working hrs, 480 mins.
                    if (days > first.Duration / 480 || days > second.Duration / 480)
                    {
                        MessageBox.Show("Error: Overlap days cannot be longer than the durations of the tasks " + "(" + first.Name.ToString() + "," + second.Name.ToString() + ").");
                        return false;
                    }
                    else
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjStartToFinish, days * 480);

                    break;
            }
          return true;
        }

        static public bool BinaryFGA(int id1, int id2, string binaryrela, int days)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            MSProject.Task first;
            MSProject.Task second;

            if (DateTime.Compare(project.Tasks.UniqueID[id2].Start, project.Tasks.UniqueID[id1].Start) < 0)
            {
                first = project.Tasks.UniqueID[id2];
                second = project.Tasks.UniqueID[id1];
            }
            else
            {
                first = project.Tasks.UniqueID[id1];
                second = project.Tasks.UniqueID[id2];
            }

            first.Manual = true;
            second.Manual = true;
            bool id1_before_id2=true;
            //to remove the existing links between 1 and 2, check which one is the predecessor first.
            foreach (MSProject.Task predecessor in project.Tasks.UniqueID[id1].PredecessorTasks)
            {
                if (predecessor.UniqueID == id2)
                {
                   id1_before_id2 = false;
                   project.Tasks.UniqueID[id2].UnlinkSuccessors(project.Tasks.UniqueID[id1]);
                }
                
            }

            if(id1_before_id2)
            project.Tasks.UniqueID[id1].UnlinkSuccessors(project.Tasks.UniqueID[id2]);

            switch (binaryrela)
            {
                case "Contain":
                    MSProject.Task longer, shorter;
                    if (second.Duration > first.Duration)
                    {
                        longer = second;
                        shorter = first;
                    }
                    else
                    {
                        longer = first;
                        shorter = second;
                    }
                    //shift the first task, depends on the length of the first, constain at start or at end
                    //no need to format gantt bar, because they have been formatted when assigned, here is only to change the sequence or arrangement
                    if (longer==first)                      
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjStartToStart, 0);
                    else
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjFinishToFinish, 0);
                    break;

                case "Disjoint":
                    //only change when overlap.
                    //if it is alrealy in disjoint, then still need to alter the sequence
                    first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    break;

                case "Meet":
                    first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    break;

                case "Overlap":
                    //here is at least, for overlap more than specified days, no change is made.
                    //by default everyday includes 8 working hrs, 480 mins.
                    if (days > first.Duration / 480 || days > second.Duration / 480)
                    {
                        MessageBox.Show("Error: Overlap days cannot be longer than the durations of the tasks " + "(" + first.Name.ToString() + "," + second.Name.ToString() + ").");
                        return false;
                    }
                    else
                        first.TaskDependencies.Add(second, MSProject.PjTaskLinkType.pjFinishToFinish, first.Duration-days * 480);
                    break;
            }
            return true;
        }

        static public bool UnaryRelation(string taskname, string unaryRelationship, DateTime date1, DateTime date2)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            int id = 0;
            bool found1 = false;

            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.Name.Equals(taskname))
                {
                    id = task.UniqueID;
                    found1 = true;
                }
            }

            if (found1 == false)
            {
                MessageBox.Show("Error: Task can not be found.");
                return false;
            }

            else
            {
                MSProject.Task thistask = project.Tasks.UniqueID[id];

                if (thistask.Duration == null)
                    thistask.Duration = 480;
                if (thistask.StartText == null || thistask.StartText == "")
                {
                    thistask.StartText = DateTime.Today.ToString("yyyy-MM-dd");
                    project.Application.GanttBarFormat(thistask.ID, Type.Missing, MSProject.PjBarEndShape.pjLeftBracket, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjBarEndShape.pjRightBracket);
                }

                //check if there are contradicting unary relationships
                MSProject.PjCustomField UnaryField = MSProject.PjCustomField.pjCustomTaskText30;
                if (project.Application.CustomFieldGetName(UnaryField) != "Unary Relationship")
                    project.Application.CustomFieldRename(UnaryField, "Unary Relationship", Type.Missing);

                string Unary = project.Tasks.UniqueID[1].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"));
                string UnaryData;
                int l3 = Unary.Length;
                int l4;
                int p3 = Unary.IndexOf(";");
                int p4;
                string tk, re, d1, d2, s;

                while (p3 > 0)
                {
                    UnaryData = Unary.Substring(0, p3);
                    l4 = UnaryData.Length;
                    p4 = UnaryData.IndexOf(",");
                    tk = UnaryData.Substring(0, p4);

                    UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 - 1);
                    p4 = UnaryData.IndexOf(",");
                    re = UnaryData.Substring(0, p4);
                    l4 = UnaryData.Length;

                    UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 - 1);
                    p4 = UnaryData.IndexOf(",");
                    d1 = UnaryData.Substring(0, p4);
                    l4 = UnaryData.Length;

                    UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 - 1);
                    d2 = UnaryData;

                    //for can not occur, it also stores the data of whether can split or not, need to process
                    if (re.StartsWith("C"))
                    {
                        s = re.Substring(re.IndexOf("/"));
                        re = "Can Not Occur";
                    }

                    //can not occur can coexit with all others, the remaining cant coexit with each other.
                    if (tk == thistask.Name.ToString())
                    {
                        if (re != "Can Not Occur")
                        {
                            if (unaryRelationship != "Can Not Occur")
                                MessageBox.Show("Error: The unary relationship " + re + " and " + unaryRelationship + " can not coexist for the same task.");
                            return false;
                        }
                    }

                    Unary = Unary.Substring(p3 + 1, l3 - p3 - 1);
                    p3 = Unary.IndexOf(";");
                    l3 = Unary.Length;
                }

                string split="";
                switch (unaryRelationship)
                {
                    case "Can Not Occur":
                        DialogResult result = MessageBox.Show("Can " + thistask.Name.ToString() + " be split?", "Can Not Occur", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            thistask.Split(date1, date2);
                            split = "y";
                        }
                            
                        if (result == DialogResult.No)
                        {
                            split = "n";
                            if (DateTime.Compare(date1, thistask.Finish) < 0 & DateTime.Compare(date2, thistask.Start) > 0)
                                thistask.Start = date2;
                        }
                            
                        break;

                    case "Due After"://what does due after means exactly?? if due after 30/4, then finish 30/04 can? or must be 01/05??
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjFNET; //FinishNoEarlierThan	Value=6. Finish no earlier than (FNET).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;//???should we do so?
                        break;

                    case "Due Before":
                        //it will check if there is any constraint before this in the system, if not, will start today.
                        //but our pdm++ relationship is not checked in this process.
                        //do we need to propse a new method in this??
                        //FNET + CHECK PDM++ RELATIONSHIP.
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjFNLT;//FinishNoLaterThan	Value=7. Finish no later than (FNLT).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;

                    case "Start After"://similar question as due after.
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjSNET;//StartNoEarlierThan	Value=4. Start no earlier than (SNET).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;

                    case "Start Before":
                        //it will check if there is any constraint before this in the system, if not, will start today.
                        //but our pdm++ relationship is not checked in this process.
                        //SNLT + Check PDM++ RELATIONHSHIP.
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjSNLT;////StartNoLaterThan	Value=5. Start no later than (SNLT).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;
                }

                int i = 1;
                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.ID == 1)
                        i = task.UniqueID;
                }
  
                string UnaryString = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"));
                string NewUnaryString;

                if (unaryRelationship == "Can Not Occur")
                {
                    NewUnaryString = UnaryString + thistask.Name.ToString() + "," + unaryRelationship+"/"+split+","+ date1.ToString("yyyy-MM-dd") + "," + date2.ToString("yyyy-MM-dd") + ";";
                    project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), NewUnaryString);
                }
                else
                {
                    NewUnaryString = UnaryString + thistask.Name.ToString() + "," + unaryRelationship + "," + date1.ToString("yyyy-MM-dd") + "," + ";";
                    project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), NewUnaryString);
                }
                return true;
            }
            
        }
       
        static public void UnaryCheck (string taskname, string unaryRelationship, DateTime date1, DateTime date2)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            int id = 0;
            bool found1 = false;

            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.Name.Equals(taskname))
                {
                    id = task.UniqueID;
                    found1 = true;
                }
            }

            if (found1 == false)
            {
                MessageBox.Show("Error: Task can not be found.");
                return;
            }

            else
            {
                MSProject.Task thistask = project.Tasks.UniqueID[id];
                //need to remove the constraint first
                string sp = "";
                
                if(unaryRelationship.StartsWith("C"))
                {
                    sp = unaryRelationship.Substring(unaryRelationship.IndexOf("/"));
                    unaryRelationship = "Can Not Occur";
                }

                switch (unaryRelationship)
                {
                    case "Can Not Occur":                     
                        if (sp=="y")
                            thistask.Split(date1, date2);
                        if (sp=="n")
                        {
                            if (DateTime.Compare(date1, thistask.Finish) < 0 & DateTime.Compare(date2, thistask.Start) > 0)
                                thistask.Start = date2;
                        }
                        break;

                    case "Due After":
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjFNET; //FinishNoEarlierThan	Value=6. Finish no earlier than (FNET).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;

                    case "Due Before":
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjFNLT;//FinishNoLaterThan	Value=7. Finish no later than (FNLT).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;

                    case "Start After"://similar question as due after.
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjSNET;//StartNoEarlierThan	Value=4. Start no earlier than (SNET).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;

                    case "Start Before":
                        thistask.Manual = false;
                        thistask.ConstraintType = MSProject.PjConstraint.pjSNLT;////StartNoLaterThan	Value=5. Start no later than (SNLT).
                        thistask.ConstraintDate = date1;
                        thistask.Manual = true;
                        break;
                }
               
                return;
            }
            
        
        }

        static public void GeneticAlgorithm()
        {
            //check if there is more than one relationships

            
        }

        static public DateTime GetFinishDate(Array chromosome)
        {
            DateTime finishdate = DateTime.Today;
            //call binayTGA and binaryFGA many times depent on input array argument
            //return finishdate as fitness value to GA
            return finishdate;
        }

        static public void SetGanttBarFormat (MSProject.Task tk1, MSProject.Task tk2)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

            project.Application.SelectRow(tk1.ID, false, 0, false, false);
            project.Application.GanttBarFormat(Type.Missing, Type.Missing, MSProject.PjBarEndShape.pjNoBarEndShape, MSProject.PjBarType.pjSolid, MSProject.PjColor.pjYellow, MSProject.PjBarShape.pjRectangleBottom, MSProject.PjFillPattern.pjSolidFillPattern, MSProject.PjColor.pjFuchsia, MSProject.PjBarEndShape.pjNoBarEndShape, MSProject.PjBarType.pjSolid, MSProject.PjColor.pjRed, Type.Missing, "Text27", Type.Missing, Type.Missing, Type.Missing, false, Type.Missing);

            project.Application.SelectRow(tk2.ID, false, 0, false, false);
            project.Application.GanttBarFormat(Type.Missing, Type.Missing, MSProject.PjBarEndShape.pjNoBarEndShape, MSProject.PjBarType.pjSolid, MSProject.PjColor.pjYellow, MSProject.PjBarShape.pjRectangleBottom, MSProject.PjFillPattern.pjSolidFillPattern, MSProject.PjColor.pjFuchsia, MSProject.PjBarEndShape.pjNoBarEndShape, MSProject.PjBarType.pjSolid, MSProject.PjColor.pjRed, Type.Missing, "Text27", Type.Missing, Type.Missing, Type.Missing, false, Type.Missing);
        }

        static public void ResetGanttBarFormat (MSProject.Task tk)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            project.Application.SelectRow(tk.ID, false, 0, false, false);
            project.Application.GanttBarFormat(Type.Missing,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing);

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }
       



        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
