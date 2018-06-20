using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Service;
using Android.Media;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
namespace AdMusic.Code.Services
{
    /**
 * 音乐播放后台服务
 * Created by wcy on 2015/11/27.
 */
    public class PlayService : Service
    {

        public override void OnCreate()
        {
            base.OnCreate();

        }

        public override IBinder OnBind(Intent intent)
        {
            return new Binder();
        }

        public static void StartCommand(Context context, String action)
        {
            Intent intent = new Intent(context, typeof(PlayService));
            intent.SetAction(action);
            context.StartService(intent);
        }
        private void stop()
        {
            AudioPlayer.get().stopPlayer();
            QuitTimer.get().stop();
            Notifier.get().cancelAll();
        }
    }
}