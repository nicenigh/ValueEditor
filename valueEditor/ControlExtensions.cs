namespace System.Windows.Forms
{
    public static class ControlInvoke
    {
        public static void Invoke(this Control control, Action action)
        {
            try
            {
                if (control.InvokeRequired)
                    control.BeginInvoke(action);
                else
                    action.Invoke();
            }
            catch
            {
            }
        }
        public static Threading.Tasks.Task InvokeSync(this Control control, Action action)
        {
            try
            {
                return Threading.Tasks.Task.Run(() => { control.BeginInvoke(action); });
            }
            catch
            {
                return null;
            }
        }
    }
}
