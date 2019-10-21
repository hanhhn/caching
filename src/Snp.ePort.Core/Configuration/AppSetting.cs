namespace Snp.ePort.Core.Configuration
{
    public class AppSetting
    {
        public static int KeepAlive()
        {
            return 30;
        }

        public static int ConnectTimeout()
        {
            return 15000;
        }

        public static int SyncTimeout()
        {
            return 15000;
        }

        public static bool SSL()
        {
            return false;
        }

        public static string[] Connection()
        {
            return null;
        }
    }
}
