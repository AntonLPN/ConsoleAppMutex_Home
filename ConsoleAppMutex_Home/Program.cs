using System;
using System.Threading;


//Задание №1
//Разработайте приложение, в котором мьютекс используется для определения
//того, что приложение запущено в единственном экземпляре. Для этого пытаемся
//открыть именованный мьютекс при запуске приложения. Так как мьютексы
//создаются на уровне операционной системы, то они видны всем процессам. Если
//созданного мьютекса нет, то будет сгенерировано исключение
//WaitHandleCannotBeOpenedException, а значит, приложение запускается первый
//раз.

namespace ConsoleAppMutex_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mutexName = "myMutex";

            Mutex mutex = null;
            bool doesNotExist = false;
            bool unauthorized = false;


            // Attempt to open the named mutex.
            try
            {
                // Open the mutex with (MutexRights.Synchronize |
                // MutexRights.Modify), to enter and release the
                // named mutex.
                //
                mutex = Mutex.OpenExisting(mutexName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                Console.WriteLine("Mutex does not exist.");
                doesNotExist = true;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Unauthorized access: {0}", ex.Message);
                unauthorized = true;
            }


        }
    }
}
