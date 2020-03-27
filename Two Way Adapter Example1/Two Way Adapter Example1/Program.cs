using System;

namespace Two_Way_Adapter_Example1
{
    interface IMP3Player
    {
        void PlayMP3();
    }
    interface IMP4Player
    {
        void PlayMP4();
    }
    class ConcreteMP3Player : IMP3Player
    {
        public void PlayMP3()
        {
            Console.WriteLine("ConcreteMP3player instance");
        }
    }
    class ConcreteMP4Player : IMP4Player
    {
        public void PlayMP4()
        {
            Console.WriteLine("ConcreteMP4player instance");
        }
    }
    class TwoWayAdapter1 : IMP3Player, IMP4Player
    {
        private IMP3Player _MP3Player;//adaptee
        public TwoWayAdapter1(IMP3Player player)
        {
            this._MP3Player = player;
        }
        public void PlayMP3()
        {
            _MP3Player.PlayMP3();
        }

        public void PlayMP4()
        {
            _MP3Player.PlayMP3();
        }
    }
    class TwoWayAdapter2 : IMP3Player, IMP4Player
    {
        private IMP4Player _MP4Player;//adaptee
        public TwoWayAdapter2(IMP4Player player)
        {
            this._MP4Player = player;
        }
        public void PlayMP3()
        {
            _MP4Player.PlayMP4();
        }

        public void PlayMP4()
        {
            _MP4Player.PlayMP4();
        }
    }
    static class TestScenario
    {
        private static void TestMP3Adapter()
        {
            IMP3Player mp3 = new ConcreteMP3Player();
            TwoWayAdapter1 twa = new TwoWayAdapter1(mp3);
            twa.PlayMP3();
            twa.PlayMP4();
            Console.WriteLine();
        }
        private static void TestMP4Adapter()
        {
            IMP4Player mp4 = new ConcreteMP4Player();
            TwoWayAdapter2 twa = new TwoWayAdapter2(mp4);
            twa.PlayMP3();
            twa.PlayMP4();
            Console.WriteLine();
        }
        public static void Test()
        {
            TestMP3Adapter();
            TestMP4Adapter();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestScenario.Test();
            Console.ReadKey(true);
        }
    }
}
