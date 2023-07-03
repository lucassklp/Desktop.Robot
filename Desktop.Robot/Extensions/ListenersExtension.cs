using System;
using System.Drawing;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace Desktop.Robot.Extensions
{
    public static class ListenersExtension
    {
        private static Point position = Point.Empty;

        public static IObservable<Point> OnMouseMove(this IRobot robot)
        {
            position = robot.GetMousePosition();
            var scheduler = new EventLoopScheduler(ts => new Thread(ts));
            return Observable.Create<Point>(observer =>
            {
                var newPosition = robot.GetMousePosition();
                if (position != newPosition)
                {
                    observer.OnNext(newPosition);
                }
                position = newPosition;
                observer.OnCompleted();
                return Disposable.Empty;
            })
            .ObserveOn(scheduler)
            .Repeat();
        }
    }
}