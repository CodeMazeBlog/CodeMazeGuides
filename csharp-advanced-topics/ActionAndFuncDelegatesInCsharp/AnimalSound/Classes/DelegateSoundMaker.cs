using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSound.Classes
{
    public class DelegateSoundMaker
    {
        public delegate void SoundMaker();
        public void Make(SoundMaker soundMaker)
        {
            var sound = new Sounds();
            soundMaker();
            
        }
    }
}
