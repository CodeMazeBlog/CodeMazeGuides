using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegatesInCSharp.Classes
{
    public class SoundMaker
    {
        public void Make()
        {
            var sound = new Sounds();
            sound.Cow();
            sound.Goat();
            sound.Dog();
       }
    }
}
