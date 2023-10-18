using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSound.Classes
{
    public class ActionDelegateSoundMaker
    {
       
        public void Make(Action soundMaker)
        {
            var sound = new Sounds();
            soundMaker();

        }
    }
}
