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

        static public bool BinaryRelation(int id1, int id2, string binaryRelationship, int days, bool Isnew)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            
            //check empty fileds.
            if (project.Tasks.UniqueID[id1].Duration == null)
                project.Tasks.UniqueID[id1].Duration = 480;

            if (project.Tasks.UniqueID[id2].Duration == null)
                project.Tasks.UniqueID[id2].Duration = 480;

            if (project.Tasks.UniqueID[id1].StartText == null || project.Tasks.UniqueID[id1].StartText=="")
            {
                project.Tasks.UniqueID[id1].Start= DateTime.Today;
                project.Application.GanttBarFormat(project.Tasks.UniqueID[id1].ID, Type.Missing, MSProject.PjBarEndShape.pjLeftBracket, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjBarEndShape.pjRightBracket);
            }

            if (project.Tasks.UniqueID[id2].StartText == null || project.Tasks.UniqueID[id2].StartText == "")
            {
                project.Tasks.UniqueID[id2].Start = DateTime.Today;
                project.Application.GanttBarFormat(project.Tasks.UniqueID[id2].ID, Type.Missing, MSProject.PjBarEndShape.pjLeftBracket, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjBarEndShape.pjRightBracket);
            }

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
            //check if there is exisiting binary relationships
            if(Isnew)
            {
                MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
                if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                    project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);
                
                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.ID == 1)
                        i = task.UniqueID;
                }
                string Binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
                string BinaryData;

                //process binary relationships
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
            }
            

            //if no contradicting assignment, or if isnew=false, then can process the binary relationship
            first.Manual = true;
            second.Manual = true;
            bool processed = false;

            switch (binaryRelationship)
            {
                case "Concurrent":
                    //activity 1 is the reference.
                    //Can we assume most likely one task is dependent on the other task?
                    if (first.Duration != second.Duration)
                    {
                        MessageBox.Show("Please make sure task 1 and task 2 have equal duration in a Concurrent relationship.");
                        return false;
                    }
                    else
                    {
                        first.Start = second.Start;
                        processed = true;
                        second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjStartToStart, 0);
                    }
                    break;

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
                    {
                        shorter.TaskDependencies.Add(longer, MSProject.PjTaskLinkType.pjStartToStart, 0);
                    }
                    processed = true;
                    break;

                case "Disjoint":
                    //only change when overlap.
                    //check if there is 3rd task in disjoint.Need to store sassigned relationships first.
                    if (DateTime.Compare(first.Finish, second.Start) < 0)
                        break;
                    else
                    {
                        second.Start = first.Finish;
                    }
                    second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    return true;


                case "Meet":
                    if (DateTime.Compare(first.Finish, second.Start) < 0)
                    {
                        //just in case garbage in that second start on weekend.
                        if (second.Start.DayOfWeek == DayOfWeek.Saturday)
                        {
                            while (DateTime.Compare(first.Finish.AddDays(1), second.Start) < 0)
                                first.Start = first.Start.AddDays(1);
                        }

                        if (second.Start.DayOfWeek == DayOfWeek.Sunday)
                        {
                            while (DateTime.Compare(first.Finish.AddDays(2), second.Start) < 0)
                                first.Start = first.Start.AddDays(1);
                        }

                        if (second.Start.DayOfWeek == DayOfWeek.Monday)
                        {
                            while (DateTime.Compare(first.Finish.AddDays(3), second.Start) < 0)
                                first.Start = first.Start.AddDays(1);
                        }
                        else
                        {
                            while (DateTime.Compare(first.Finish.AddDays(1), second.Start) < 0)
                                first.Start = first.Start.AddDays(1);
                        }

                    }
                    else
                    {
                        second.Start = first.Finish;
                    }
                    second.TaskDependencies.Add(first, MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    return true;

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
                        if (DateTime.Compare(first.Finish, second.Start) < 0)
                        {
                            while (DateTime.Compare(first.Finish, second.Start) < 0)
                                first.Start = first.Start.AddDays(1);
                        }

                        int D = 0;
                        DateTime reference = second.Start;
                        while (D != days)
                        {
                            //Count overlap days.
                            while (DateTime.Compare(reference, first.Finish) < 0)
                            {
                                if (reference.DayOfWeek == DayOfWeek.Monday || reference.DayOfWeek == DayOfWeek.Tuesday ||
                                    reference.DayOfWeek == DayOfWeek.Wednesday || reference.DayOfWeek == DayOfWeek.Thursday ||
                                    reference.DayOfWeek == DayOfWeek.Friday)
                                    D = D + 1;
                                reference = reference.AddDays(1);
                            }

                            if (D > days || D == days)
                                break;
                            first.Start = first.Start.AddDays(1);
                            reference = second.Start;
                            D = 0;
                        }
                        processed = true;
                        //color codes for overlapped days????
                    }
                    break;
            }

            i = 1;
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }
            if(processed&Isnew)
            {
                string BinaryString = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
                string NewBinaryString = BinaryString + first.Name.ToString() + "," + second.Name.ToString() + "," + binaryRelationship + "," + days.ToString() + ";";

                project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), NewBinaryString);

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
                if (thistask.StartText == null||thistask.StartText=="")
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
                string tk, re, d1, d2;

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

                    //can not occur can coexit with all others, the remaining cant coexit with each other.
                    if(tk==thistask.Name.ToString())
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


                switch (unaryRelationship)
                {
                    case "Can Not Occur":
                        DialogResult result = MessageBox.Show("Can "+thistask.Name.ToString()+" be split?", "Can Not Occur", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                            thistask.Split(date1, date2);
                        if (result == DialogResult.No)
                            if (DateTime.Compare(date1, thistask.Finish) < 0 & DateTime.Compare(date2, thistask.Start) > 0)
                                thistask.Start = date2;
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


                string UnaryString = project.Tasks.UniqueID[1].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"));
                string NewUnaryString;
                int i = 1;
                foreach(MSProject.Task task in project.Tasks)
                {
                    if (task.ID == 1)
                        i = task.UniqueID;
                }

                if (unaryRelationship == "Can Not Occur")
                {
                    NewUnaryString = UnaryString + thistask.Name.ToString() + "," + unaryRelationship + "," + date1.ToString("yyyy-MM-dd") + "," + date2.ToString("yyyy-MM-dd") + ";";
                    project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), NewUnaryString);
                }
                else
                {
                    NewUnaryString = UnaryString + thistask.Name.ToString() + "," + unaryRelationship + "," + date1.ToString("yyyy-MM-dd") + "," + ";";
                    project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), NewUnaryString);
                }

            } return true;
        }

        static public bool MultipleRelation(string relation, string task1, string task2, string task3, string task4, string task5, bool Isnew)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

            int taskCount=2;
            if (task3 == "NA")
                taskCount = 2;
            else if (task4 == "NA")
                taskCount = 3;
            else if (task5 == "NA")
                taskCount = 4;
            else
                taskCount = 5;


            MSProject.Task[] alltasks = new MSProject.Task[5];
            int id1 = 1, id2 = 1, id3 = 1, id4 = 1, id5 = 1;
            int i,j;

            //found corresponding tasks
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.Name.Equals(task1))
                    id1 = task.UniqueID;

                if (task.Name.Equals(task2))
                    id2 = task.UniqueID;

                if (task.Name.Equals(task3))
                    id3 = task.UniqueID;

                if (task.Name.Equals(task4))
                    id4 = task.UniqueID;

                if (task.Name.Equals(task5))
                    id5 = task.UniqueID;
                }

            alltasks[0] = project.Tasks.UniqueID[id1];
            alltasks[1] = project.Tasks.UniqueID[id2];
            if (taskCount > 2)
                alltasks[2] = project.Tasks.UniqueID[id3];
            if (taskCount > 3)
                alltasks[3] = project.Tasks.UniqueID[id4];
            if (taskCount > 4)
                alltasks[4] = project.Tasks.UniqueID[id5];

            MSProject.Task tk;

            for(i=0;i<taskCount;i++)
            {
                if (alltasks[i].Duration == null)
                    alltasks[i].Duration = 480;
                if (alltasks[i].StartText == null || alltasks[i].StartText == "")
                {
                    alltasks[i].Start = DateTime.Today;
                    project.Application.GanttBarFormat(alltasks[i].ID, Type.Missing, MSProject.PjBarEndShape.pjLeftBracket, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjBarEndShape.pjRightBracket);
                }
            }

            //if is new, check if there is existing contradicting relationships
            bool success = false;
            if(Isnew)
            {
                MSProject.PjCustomField MultipleField = MSProject.PjCustomField.pjCustomTaskText28;
                if (project.Application.CustomFieldGetName(MultipleField) != "Multiple Relationship")
                    project.Application.CustomFieldRename(MultipleField, "Multiple Relationship", Type.Missing);

                
                if (taskCount == 2)
                    success = BinaryRelation(id1, id2, relation, 0, true);

                else
                {
                    i = 1;
                    while (project.Tasks.UniqueID[i] == null)
                    {
                        i++;
                    }
                    string Multiple = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"));
                    string MultipleData = "";
                    int l5 = Multiple.Length;
                    int p5 = Multiple.IndexOf(";");
                    int p6;
                    string rela;
                    string[] tasks = new string[5];
                    int m = 0;

                    while (p5 > 0)
                    {
                        MultipleData = Multiple.Substring(0, p5);
                        p6 = MultipleData.IndexOf(",");
                        rela = MultipleData.Substring(0, p6);
                        MultipleData = MultipleData.Substring(p6 + 1);
                        p6 = MultipleData.IndexOf(",");

                        while (p6 > 0)
                        {
                            tasks[m] = MultipleData.Substring(0, p6);
                            MultipleData = MultipleData.Substring(p6 + 1);
                            p6 = MultipleData.IndexOf(",");
                            m++;
                        }
                        tasks[m] = MultipleData;

                        for (m = 0; m < 5; m++)
                        {
                            if ((tasks[m] == task1 || tasks[m] == task2 || tasks[m] == task3 || tasks[m] == task4 || tasks[m] == task5) && (rela == relation))
                            {
                                MessageBox.Show("Error: Task " + tasks[m] + " is already in a " + rela + " relationship.");
                                return false;
                            }
                        }

                        Multiple = Multiple.Substring(p5 + 1);
                        p5 = Multiple.IndexOf(";");
                        m = 0;
                    }


                }
            }

            else //not isnew
            {
                if (taskCount == 2)
                    success = BinaryRelation(id1, id2, relation, 0, false);
                return success;
            }

            //rank the tasks according to their start date
            for (i = 0; i < taskCount - 1; i++)
            {
                for (j = i + 1; j < taskCount; j++)
                {
                    if (DateTime.Compare(alltasks[i].Start, alltasks[j].Start) > 0)
                    {
                        tk = alltasks[i];
                        alltasks[i] = alltasks[j];
                        alltasks[j] = tk;
                    }
                }
            }

            switch (relation)
            {
                case "Disjoint":
                    for (i = 0; i < taskCount - 1; i++)
                    {
                        if (DateTime.Compare(alltasks[i].Finish, alltasks[i + 1].Start) < 0)
                            break;
                        else
                            alltasks[i + 1].Start = alltasks[i].Finish;

                        //add links 
                        alltasks[i + 1].TaskDependencies.Add(alltasks[i], MSProject.PjTaskLinkType.pjFinishToStart, 0);
                    }
                    success = true;
                    break;

                case "Meet":
                    //need to lop twice to avoid mistakes, once may induce error, refer to notebook.
                    int loop;
                    for (loop = 1; loop < 3; loop++)
                    {
                        for (i = 0; i < taskCount - 1; i++)
                        {
                            if (DateTime.Compare(alltasks[i].Finish, alltasks[i + 1].Start) < 0)
                            {
                                //just in case garbage in that second start on weekend.
                                //if first ends earlier, shift first to meet second, but if second starts on weekend or monday, never will they meet.
                                if (alltasks[i + 1].Start.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    while (DateTime.Compare(alltasks[i].Finish.AddDays(1), alltasks[i + 1].Start) < 0)
                                        alltasks[i].Start = alltasks[i].Start.AddDays(1);
                                }

                                if (alltasks[i + 1].Start.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    while (DateTime.Compare(alltasks[i].Finish.AddDays(2), alltasks[i + 1].Start) < 0)
                                        alltasks[i].Start = alltasks[i].Start.AddDays(1);
                                }

                                if (alltasks[i + 1].Start.DayOfWeek == DayOfWeek.Monday)
                                {
                                    while (DateTime.Compare(alltasks[i].Finish.AddDays(3), alltasks[i + 1].Start) < 0)
                                        alltasks[i].Start = alltasks[i].Start.AddDays(1);
                                }
                                else
                                {
                                    while (DateTime.Compare(alltasks[i].Finish.AddDays(1), alltasks[i + 1].Start) < 0)
                                        alltasks[i].Start = alltasks[i].Start.AddDays(1);
                                }
                            }
                            else
                                //first ends later than the start of second
                                alltasks[i + 1].Start = alltasks[i].Finish;

                            //add links 
                            alltasks[i + 1].TaskDependencies.Add(alltasks[i], MSProject.PjTaskLinkType.pjFinishToStart, 0);
                        }
                    }
                    success = true;
                    break;
            }     
                        

            if(success&Isnew)
            {
                //store info into custom field text28
                i = 1;
                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.ID == 1)
                        i = task.UniqueID;
                }
                string MultipleString = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"));
                string tasknames = alltasks[0].Name.ToString();
                int m;
                for (m = 1; m < taskCount; m++)
                {
                    tasknames = tasknames + "," + alltasks[m].Name.ToString();
                }
                string NewMultipleString = MultipleString + relation + "," + tasknames + ";";
                
                //first task may not be task1.
                project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"), NewMultipleString);

            } return true;  
            
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
