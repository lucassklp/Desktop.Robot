using System;
using System.Threading;

namespace Desktop.Robot.Clicks
{
    public interface IClick
    {
        int Delay { get; }
        
        void ExecuteMouseDown(MouseContext context);
        void ExecuteMouseUp(MouseContext context);
        void ExecuteClick(MouseContext context) {
            ExecuteMouseDown(context);
            Thread.Sleep(Delay);
            ExecuteMouseUp(context);
        }
    }
}
