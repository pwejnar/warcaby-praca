using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace Checkers
{
    public static class Extension
    {
        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to allow changes in that 
        /// window to be redrawn or to prevent changes in that window from being redrawn.
        /// </summary>
        private const int WM_SETREDRAW = 11;

        /// <summary>
        /// Suspends painting for the target control. Do NOT forget to call EndControlUpdate!!!
        /// </summary>
        /// <param name="control">visual control</param>
        public static void BeginControlUpdate(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }

        /// <summary>
        /// Resumes painting for the target control. Intended to be called following a call to BeginControlUpdate()
        /// </summary>
        /// <param name="control">visual control</param>
        public static void EndControlUpdate(Control control)
        {
            // Create a C "true" boolean as an IntPtr
            IntPtr wparam = new IntPtr(1);
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Invalidate();
            control.Refresh();
        }

        //public static List<List<FightMove>> GetlongestWays(List<FightMove> tree)
        //{
        //    int? maxCount = null;
        //    List<List<FightMove>> longestPaths = new List<List<FightMove>>();

        //    foreach (FightMove list in tree)
        //    {
        //        foreach (List<FightMove> fightMove in list.GetPossibleWays())
        //        {
        //            int longestWayCount = fightMove.Count;

        //            if (maxCount == null || longestWayCount > maxCount)
        //            {
        //                maxCount = longestWayCount;
        //                longestPaths.Clear();
        //                longestPaths.Add(fightMove);
        //            }

        //            else if (maxCount == longestWayCount)
        //            {
        //                longestPaths.Add(fightMove);
        //            }

        //        }
        //    }
        //    return longestPaths;
        //}
    
    }
}
