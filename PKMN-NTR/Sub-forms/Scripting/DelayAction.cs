using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkmn_ntr.Sub_forms.Scripting
{
    public class DelayAction : ScriptAction
    {
        private int time;
        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value >= 0)
                {
                    time = value;
                }
                else
                {
                    time = 0;
                }
            }
        }

        public override ActionType Type
        {
            get
            {
                return ActionType.Delay;
            }
        }

        public override int[] Instruction
        {
            get
            {
                return new int[] { time };
            }
            set
            {
                if (value.Length == 0)
                {
                    time = 0;
                }
                else
                {
                    time = value[0];
                }

            }
        }

        public override string Tag
        {
            get
            {
                return $"Wait {time} ms";
            }
        }

        public DelayAction(int _time)
        {
            if (_time > 0)
            {
                time = _time;
            }
            else
            {
                time = 0;
            }
        }

        public async override Task Excecute()
        {
            if (time > 0)
            {
                Report($"Script: Wait {time} ms");
                await Task.Delay(time);
            }
            else
            {
                return;
            }
        }
    }
}
