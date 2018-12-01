namespace StorageMaster
{
    using StorageMaster.Core;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            StorageMaster storageMaster = new StorageMaster();
            Engine engine = new Engine(storageMaster);
            engine.Run();
        }
    }
}
