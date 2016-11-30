namespace FreightHepler
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class MethodManager
    {
        public static int BeginInvokeNoneException(MethodHandler method)
        {
            ThreadStart start = null;
            int runResult = 0;
            try
            {
                if (start == null)
                {
                    start = delegate {
                        try
                        {
                            method();
                            runResult = 1;
                        }
                        catch
                        {
                            runResult = -1;
                        }
                    };
                }
                new Thread(start).Start();
                while (runResult == 0)
                {
                    Thread.Sleep(50);
                }
            }
            catch
            {
            }
            return runResult;
        }

        public static void ControlBeginInvoke(Control control_0, MethodInvoker method)
        {
            try
            {
                control_0.BeginInvoke(method);
            }
            catch
            {
            }
        }

        public static void ControlInvoke(Control control_0, MethodInvoker method)
        {
            try
            {
                control_0.Invoke(method);
            }
            catch
            {
            }
        }

        public static void Invoke(MethodHandler method)
        {
            Invoke(method, 0);
        }

        public static T Invoke<T>(MethodHandler<T> method)
        {
            return Invoke<T>(method);
        }

        public static void Invoke(MethodHandler method, int timeout)
        {
            ThreadStart start = null;
            Exception exception = null;
            DateTime now = DateTime.Now;
            try
            {
                if (start == null)
                {
                    start = delegate {
                        try
                        {
                            method();
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
                        }
                    };
                }
                Thread thread = new Thread(start);
                thread.Start();
                while (thread.IsAlive)
                {
                    if (timeout > 0)
                    {
                        TimeSpan span = (TimeSpan) (DateTime.Now - now);
                        if (span.TotalMilliseconds > timeout)
                        {
                            goto Label_0072;
                        }
                    }
                    Thread.Sleep(10);
                }
                goto Label_0096;
            Label_0072:
                exception = new Exception("Method invoke has time out");
                thread.Abort();
            }
            catch (Exception e)
            {
                //exception = exception;
            }
        Label_0096:
            if (exception != null)
            {
                throw exception;
            }
        }

        public static T Invoke<T>(MethodHandler<T> method, int timeout)
        {
            ThreadStart start = null;
            T result = default(T);
            Exception exception = null;
            DateTime now = DateTime.Now;
            try
            {
                if (start == null)
                {
                    start = delegate {
                        try
                        {
                            result = method();
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
                        }
                    };
                }
                Thread thread = new Thread(start);
                thread.Start();
                while (thread.IsAlive)
                {
                    if (timeout > 0)
                    {
                        TimeSpan span = (TimeSpan) (DateTime.Now - now);
                        if (span.TotalMilliseconds > timeout)
                        {
                            goto Label_0082;
                        }
                    }
                    Application.DoEvents();
                    Thread.Sleep(5);
                }
                goto Label_00A6;
            Label_0082:
                exception = new Exception("Method invoke has time out");
                thread.Abort();
            }
            catch (Exception e)
            {
                //exception = exception;
            }
        Label_00A6:
            if (exception != null)
            {
                throw exception;
            }
            return result;
        }

        public static void InvokeNoneException(MethodHandler method)
        {
            try
            {
                method();
            }
            catch
            {
            }
        }

        public static void InvokeNoneException(MethodHandler method, int timeout)
        {
            ThreadStart start = null;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool isFinish = false;
            try
            {
                if (start == null)
                {
                    start = delegate {
                        Thread.CurrentThread.IsBackground = true;
                        try
                        {
                            method();
                        }
                        catch
                        {
                        }
                        isFinish = true;
                    };
                }
                new Thread(start).Start();
                while (isFinish)
                {
                
                    Thread.Sleep(100);
                }
               stopwatch.Stop();
            }
            catch
            {
                stopwatch.Stop();
            }
        
            
        }

        public delegate void MethodHandler();

        public delegate T MethodHandler<T>();
    }
}

