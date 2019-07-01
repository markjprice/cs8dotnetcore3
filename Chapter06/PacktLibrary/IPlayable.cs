using static System.Console;

namespace Packt.Shared
{
  public interface IPlayable
  {
    void Play();

    void Pause();

    void Stop();

    // you cannot use default interface implementations in a class library (yet)
    // void Stop()
    // {
    //   WriteLine("Default implementation of Stop.");
    // }
  }
}