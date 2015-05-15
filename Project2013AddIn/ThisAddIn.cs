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
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

        }

        static public bool BinaryRelation(string task1, string task2, string relationship, int days)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            int id1 = 0, id2 = 0;
            bool found1 = false, found2 = false;

            //found corresponding tasks
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.Name.Equals(task1))
                {
                    id1 = task.UniqueID;
                    found1 = true;
                }

                if (task.Name.Equals(task2))
                {
                    id2 = task.UniqueID;
                    found2 = true;
                }
            }

            if (found1 == false || found2 == false)
            {
                MessageBox.Show("Error: Tasks can not be found.");
            }

            //check empty fileds.
            if (project.Tasks.UniqueID[id1].Duration == null)
                project.Tasks.UniqueID[id1].Duration = 480;

            if (project.Tasks.UniqueID[id2].Duration == null)
                project.Tasks.UniqueID[id2].Duration = 480;

            if (project.Tasks.UniqueID[id1].Start == null)
                project.Tasks.UniqueID[id1].Start = DateTime.Today;

            if (project.Tasks.UniqueID[id2].Start == null)
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

            switch (relationship)
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
                        first.Start = second.Start;
                    break;

                case "Contain":
                    if (DateTime.Compare(first.Start, second.Start) > 0)
                        second.Start = first.Start;
                    if (DateTime.Compare(first.Finish, second.Finish) < 0)
                    {
                        while (first.Finish != second.Finish)
                            first.Start = first.Start.AddDays(1);
                    }
                    break;

                case "Disjoint":
                    //only change when overlap.
                    //check if there is 3rd task in disjoint.Need to store sassigned relationships first.
                    if (DateTime.Compare(first.Finish, second.Start) < 0)
                        break;
                    else
                        second.Start = first.Finish;
                    break;

                case "Meet":
                    if (DateTime.Compare(first.Finish, second.Start) < 0)
                    {
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
                        second.Start = first.Finish;
                    break;

                case "Overlap":
                    //here is at least, for overlap more than specified days, no change is made.
                    //by default everyday includes 8 working hrs, 480 mins.
                    if (days > first.Duration / 480 || days > second.Duration / 480)
                    {
                        MessageBox.Show("Error: Overlap days cannot be longer than the durations of the tasks.");
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
                    }
                    break;
            }
            return true;
        }

        static public bool UnaryRelation(string taskname, string constraintype, DateTime date1, DateTime date2)
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
                if (thistask.Start == null)
                    thistask.Start = DateTime.Today.Date;

                switch (constraintype)
                {
                    case "Can Not Occur":
                        thistask.Split(date1,date2);
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
            return true;
            }
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
